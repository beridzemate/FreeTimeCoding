// Unity C# reference source
// Copyright (c) Unity Technologies. For terms of use, see
// https://unity3d.com/legal/licenses/Unity_Reference_Only_License

using System.Collections.Generic;

namespace UnityEditor.ShaderFoundry
{
    internal struct Utilities
    {
        static internal void AddToList<T>(ref List<T> list, T value)
        {
            if (list == null)
                list = new List<T>();
            list.Add(value);
        }

        static internal Namespace BuildDefaultObjectNamespace(ShaderContainer container, string objectName)
        {
            var builder = new Namespace.Builder(container, $"{objectName}_Namespace");
            return builder.Build();
        }
    }
    static class SelectExtensions
    {
        static internal IEnumerable<BlockVariable> Select(this IEnumerable<BlockVariable> items, BlockVariableInternal.Flags flags)
        {
            foreach (var item in items)
            {
                if (item.HasFlag(flags))
                    yield return item;
            }
        }
        static internal IEnumerable<StructField> Select(this IEnumerable<StructField> items, StructFieldInternal.Flags flags)
        {
            foreach (var item in items)
            {
                if (item.HasFlag(flags))
                    yield return item;
            }
        }
        static internal IEnumerable<FunctionParameter> Select(this IEnumerable<FunctionParameter> items, FunctionParameterInternal.Flags flags)
        {
            foreach (var item in items)
            {
                if (item.HasFlag(flags))
                    yield return item;
            }
        }
    }
}
