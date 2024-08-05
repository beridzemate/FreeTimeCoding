// Unity C# reference source
// Copyright (c) Unity Technologies. For terms of use, see
// https://unity3d.com/legal/licenses/Unity_Reference_Only_License

using System;
using System.Collections.Generic;

namespace UnityEngine.UIElements
{
    /// <summary>
    /// Styled visual text element. This element doesn't have any functionality. It's just a container with a border and a title, rather than a window or popup. For more information, refer to [[wiki:UIE-uxml-element-PopupWindow|UXML element PopupWindow]].
    /// </summary>
    /// <example>
    /// <code>
    /// var popupWindow = new UnityEngine.UIElements.PopupWindow() { text = "Title" };
    /// popupWindow.Add(new Button());
    /// </code>
    /// </example>
    public class PopupWindow : TextElement
    {
        [UnityEngine.Internal.ExcludeFromDocs, Serializable]
        public new class UxmlSerializedData : TextElement.UxmlSerializedData
        {
            public override object CreateInstance() => new PopupWindow();
        }

        /// <summary>
        /// Instantiates a <see cref="PopupWindow"/> using the data read from a UXML file.
        /// </summary>
        [Obsolete("UxmlFactory is deprecated and will be removed. Use UxmlElementAttribute instead.", false)]
        public new class UxmlFactory : UxmlFactory<PopupWindow, UxmlTraits> {}

        /// <summary>
        /// Defines <see cref="UxmlTraits"/> for the <see cref="PopupWindow"/>.
        /// </summary>
        [Obsolete("UxmlTraits is deprecated and will be removed. Use UxmlElementAttribute instead.", false)]
        public new class UxmlTraits : TextElement.UxmlTraits
        {
            /// <summary>
            /// Returns an empty enumerable, as popup windows generally do not have children.
            /// </summary>
            public override IEnumerable<UxmlChildElementDescription> uxmlChildElementsDescription
            {
                get
                {
                    yield return new UxmlChildElementDescription(typeof(VisualElement));
                }
            }
        }

        private VisualElement m_ContentContainer;

        /// <summary>
        /// USS class name of elements of this type.
        /// </summary>
        public new static readonly string ussClassName = "unity-popup-window";
        /// <summary>
        /// USS class name of content elements in elements of this type.
        /// </summary>
        public static readonly string contentUssClassName = ussClassName + "__content-container";

        /// <summary>
        /// Initializes and returns an instance of PopupWindow.
        /// </summary>
        public PopupWindow()
        {
            AddToClassList(ussClassName);

            m_ContentContainer = new VisualElement() { name = "unity-content-container"};
            m_ContentContainer.AddToClassList(contentUssClassName);
            hierarchy.Add(m_ContentContainer);
        }

        public override VisualElement contentContainer // Contains full content, potentially partially visible
        {
            get { return m_ContentContainer; }
        }
    }
}
