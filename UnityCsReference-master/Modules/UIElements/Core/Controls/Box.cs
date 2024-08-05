// Unity C# reference source
// Copyright (c) Unity Technologies. For terms of use, see
// https://unity3d.com/legal/licenses/Unity_Reference_Only_License

using System;

namespace UnityEngine.UIElements
{
    /// <summary>
    /// Styled visual element to match the IMGUI Box Style. For more information, refer to [[wiki:UIE-uxml-element-box|UXML element Box]].
    /// </summary>
    public class Box : VisualElement
    {
        [UnityEngine.Internal.ExcludeFromDocs, Serializable]
        public new class UxmlSerializedData : VisualElement.UxmlSerializedData
        {
            public override object CreateInstance() => new Box();
        }

        /// <summary>
        /// Instantiates a <see cref="Box"/> using the data read from a UXML file.
        /// </summary>
        [Obsolete("UxmlFactory is deprecated and will be removed. Use UxmlElementAttribute instead.", false)]
        public new class UxmlFactory : UxmlFactory<Box> {}

        /// <summary>
        /// USS class name of elements of this type.
        /// </summary>
        public static readonly string ussClassName = "unity-box";

        /// <summary>
        ///  Initializes and returns an instance of Box.
        /// </summary>
        public Box()
        {
            AddToClassList(ussClassName);
        }
    }
}
