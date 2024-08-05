// Unity C# reference source
// Copyright (c) Unity Technologies. For terms of use, see
// https://unity3d.com/legal/licenses/Unity_Reference_Only_License

using System;
using System.Collections.Generic;
using UnityEngine.Bindings;

namespace UnityEditor.ShaderFoundry
{
    [NativeHeader("Modules/ShaderFoundry/Public/FunctionParameter.h")]
    internal struct FunctionParameterInternal : IInternalType<FunctionParameterInternal>
    {
        // these enums must match the declarations in FunctionParameter.h
        internal enum Flags
        {
            kFlagsInput = 1 << 0,
            kFlagsOutput = 1 << 1,
            kFlagsInputOutput = 3,
        };

        internal FoundryHandle m_NameHandle;
        internal FoundryHandle m_TypeHandle;
        internal FoundryHandle m_AttributeListHandle;
        internal UInt32 m_Flags;

        // TODO no need to make this extern, can duplicate it here
        internal static extern FunctionParameterInternal Invalid();

        internal bool IsValid => (m_NameHandle.IsValid && (m_Flags != 0));
        internal extern string GetName(ShaderContainer container);

        internal extern static bool ValueEquals(ShaderContainer aContainer, FoundryHandle aHandle, ShaderContainer bContainer, FoundryHandle bHandle);

        // IInternalType
        FunctionParameterInternal IInternalType<FunctionParameterInternal>.ConstructInvalid() => Invalid();
    }

    [FoundryAPI]
    internal readonly struct FunctionParameter : IEquatable<FunctionParameter>, IPublicType<FunctionParameter>
    {
        // data members
        readonly ShaderContainer container;
        internal readonly FoundryHandle handle;
        readonly FunctionParameterInternal param;

        // IPublicType
        ShaderContainer IPublicType.Container => Container;
        bool IPublicType.IsValid => IsValid;
        FoundryHandle IPublicType.Handle => handle;
        FunctionParameter IPublicType<FunctionParameter>.ConstructFromHandle(ShaderContainer container, FoundryHandle handle) => new FunctionParameter(container, handle);

        // public API
        public ShaderContainer Container => container;
        public bool IsValid => (container != null) && handle.IsValid && (param.IsValid);
        public string Name => param.GetName(container);
        public ShaderType Type => new ShaderType(container, param.m_TypeHandle);
        public IEnumerable<ShaderAttribute> Attributes => param.m_AttributeListHandle.AsListEnumerable<ShaderAttribute>(container, (container, handle) => (new ShaderAttribute(container, handle)));
        public bool IsInput => ((param.m_Flags & (UInt32)FunctionParameterInternal.Flags.kFlagsInput) != 0);
        public bool IsOutput => ((param.m_Flags & (UInt32)FunctionParameterInternal.Flags.kFlagsOutput) != 0);
        internal FunctionParameterInternal.Flags Flags => (FunctionParameterInternal.Flags)param.m_Flags;
        internal bool HasFlag(FunctionParameterInternal.Flags flags) => Flags.HasFlag(flags);

        // private
        internal FunctionParameter(ShaderContainer container, FoundryHandle handle)
        {
            this.container = container;
            this.handle = handle;
            ShaderContainer.Get(container, handle, out param);
        }

        public static FunctionParameter Invalid => new FunctionParameter(null, FoundryHandle.Invalid());

        // Equals and operator == implement Reference Equality.  ValueEquals does a deep compare if you need that instead.
        public override bool Equals(object obj) => obj is FunctionParameter other && this.Equals(other);
        public bool Equals(FunctionParameter other) => EqualityChecks.ReferenceEquals(this.handle, this.container, other.handle, other.container);
        public override int GetHashCode() => (container, handle).GetHashCode();
        public static bool operator==(FunctionParameter lhs, FunctionParameter rhs) => lhs.Equals(rhs);
        public static bool operator!=(FunctionParameter lhs, FunctionParameter rhs) => !lhs.Equals(rhs);

        public bool ValueEquals(in FunctionParameter other)
        {
            return FunctionParameterInternal.ValueEquals(container, handle, other.container, other.handle);
        }

        public class Builder
        {
            ShaderContainer container;
            internal string name;
            internal ShaderType type;
            internal List<ShaderAttribute> attributes;
            internal UInt32 flags;
            public ShaderContainer Container => container;

            public Builder(ShaderContainer container, string name, ShaderType type, bool input, bool output)
            {
                this.container = container;
                this.name = name;
                this.type = type;
                this.flags = (input ? (UInt32)FunctionParameterInternal.Flags.kFlagsInput : 0) | (output ? (UInt32)FunctionParameterInternal.Flags.kFlagsOutput : 0);
            }

            internal Builder(ShaderContainer container, string name, ShaderType type, UInt32 flags)
            {
                this.container = container;
                this.name = name;
                this.type = type;
                this.flags = flags;
            }

            public void AddAttribute(ShaderAttribute attribute)
            {
                if (attributes == null)
                    attributes = new List<ShaderAttribute>();
                attributes.Add(attribute);
            }

            public FunctionParameter Build()
            {
                var functionParamInternal = new FunctionParameterInternal();
                functionParamInternal.m_NameHandle = container.AddString(name);
                functionParamInternal.m_TypeHandle = type.handle;
                functionParamInternal.m_AttributeListHandle = HandleListInternal.Build(container, attributes, (a) => (a.handle));
                functionParamInternal.m_Flags = flags;
                FoundryHandle returnHandle = container.Add(functionParamInternal);
                return new FunctionParameter(Container, returnHandle);
            }
        }
    }
}
