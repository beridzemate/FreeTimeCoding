// Unity C# reference source
// Copyright (c) Unity Technologies. For terms of use, see
// https://unity3d.com/legal/licenses/Unity_Reference_Only_License

using System;
using System.Collections.Generic;
using UnityEngine.Bindings;

namespace UnityEditor.ShaderFoundry
{
    [NativeHeader("Modules/ShaderFoundry/Public/CustomizationPointImplementation.h")]
    internal struct CustomizationPointImplementationInternal : IInternalType<CustomizationPointImplementationInternal>
    {
        internal FoundryHandle m_CustomizationPointHandle;
        internal FoundryHandle m_BlockSequenceElementListHandle;

        internal extern static CustomizationPointImplementationInternal Invalid();
        internal extern bool IsValid();

        // IInternalType
        CustomizationPointImplementationInternal IInternalType<CustomizationPointImplementationInternal>.ConstructInvalid() => Invalid();
    }

    [FoundryAPI]
    internal readonly struct CustomizationPointImplementation : IEquatable<CustomizationPointImplementation>, IPublicType<CustomizationPointImplementation>
    {
        // data members
        readonly ShaderContainer container;
        readonly internal FoundryHandle handle;
        readonly CustomizationPointImplementationInternal customizationPointImplementation;

        // IPublicType
        ShaderContainer IPublicType.Container => Container;
        bool IPublicType.IsValid => IsValid;
        FoundryHandle IPublicType.Handle => handle;
        CustomizationPointImplementation IPublicType<CustomizationPointImplementation>.ConstructFromHandle(ShaderContainer container, FoundryHandle handle) => new CustomizationPointImplementation(container, handle);

        // public API
        public ShaderContainer Container => container;
        public bool IsValid => (container != null && handle.IsValid);
        public CustomizationPoint CustomizationPoint => new CustomizationPoint(container, customizationPointImplementation.m_CustomizationPointHandle);

        public IEnumerable<BlockSequenceElement> BlockSequenceElements
        {
            get
            {
                return customizationPointImplementation.m_BlockSequenceElementListHandle.AsListEnumerable<BlockSequenceElement>(container,
                    (container, handle) => (new BlockSequenceElement(container, handle)));
            }
        }

        // private
        internal CustomizationPointImplementation(ShaderContainer container, FoundryHandle handle)
        {
            this.container = container;
            this.handle = handle;
            ShaderContainer.Get(container, handle, out customizationPointImplementation);
        }

        public static CustomizationPointImplementation Invalid => new CustomizationPointImplementation(null, FoundryHandle.Invalid());

        // Equals and operator == implement Reference Equality.  ValueEquals does a deep compare if you need that instead.
        public override bool Equals(object obj) => obj is CustomizationPointImplementation other && this.Equals(other);
        public bool Equals(CustomizationPointImplementation other) => EqualityChecks.ReferenceEquals(this.handle, this.container, other.handle, other.container);
        public override int GetHashCode() => (container, handle).GetHashCode();
        public static bool operator==(CustomizationPointImplementation lhs, CustomizationPointImplementation rhs) => lhs.Equals(rhs);
        public static bool operator!=(CustomizationPointImplementation lhs, CustomizationPointImplementation rhs) => !lhs.Equals(rhs);

        public class Builder
        {
            ShaderContainer container;
            CustomizationPoint customizationPoint = CustomizationPoint.Invalid;
            List<BlockSequenceElement> blockSequenceElements;
            public ShaderContainer Container => container;

            public Builder(ShaderContainer container, CustomizationPoint customizationPoint)
            {
                this.container = container;
                this.customizationPoint = customizationPoint;
            }

            public void AddBlockSequenceElement(BlockSequenceElement element)
            {
                if (blockSequenceElements == null)
                    blockSequenceElements = new List<BlockSequenceElement>();
                blockSequenceElements.Add(element);
            }

            public CustomizationPointImplementation Build()
            {
                var customizationPointImplementationInternal = new CustomizationPointImplementationInternal()
                {
                    m_CustomizationPointHandle = customizationPoint.handle,
                };

                customizationPointImplementationInternal.m_BlockSequenceElementListHandle = HandleListInternal.Build(container, blockSequenceElements, (e) => (e.handle));

                var returnTypeHandle = container.Add(customizationPointImplementationInternal);
                return new CustomizationPointImplementation(container, returnTypeHandle);
            }
        }
    }
}
