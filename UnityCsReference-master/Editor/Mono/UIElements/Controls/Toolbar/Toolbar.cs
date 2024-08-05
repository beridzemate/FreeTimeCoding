// Unity C# reference source
// Copyright (c) Unity Technologies. For terms of use, see
// https://unity3d.com/legal/licenses/Unity_Reference_Only_License

using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace UnityEditor.UIElements
{
    /// <summary>
    /// A toolbar for tool windows. For more information, refer to [[wiki:UIE-uxml-element-Toolbar|UXML element Toolbar]].
    /// </summary>
    public class Toolbar : VisualElement
    {
        private static readonly string s_ToolbarDarkStyleSheetPath = "StyleSheets/Generated/ToolbarDark.uss.asset";
        private static readonly string s_ToolbarLightStyleSheetPath = "StyleSheets/Generated/ToolbarLight.uss.asset";

        private static readonly StyleSheet s_ToolbarDarkStyleSheet;
        private static readonly StyleSheet s_ToolbarLightStyleSheet;

        [UnityEngine.Internal.ExcludeFromDocs, Serializable]
        public new class UxmlSerializedData : VisualElement.UxmlSerializedData
        {
            public override object CreateInstance() => new Toolbar();
        }

        /// <summary>
        /// Instantiates a <see cref="Toolbar"/> using the data read from a UXML file.
        /// </summary>
        [Obsolete("UxmlFactory is deprecated and will be removed. Use UxmlElementAttribute instead.", false)]
        public new class UxmlFactory : UxmlFactory<Toolbar> {}

        static Toolbar()
        {
            if (Application.isBuildingEditorResources)
                return;
            s_ToolbarDarkStyleSheet = EditorGUIUtility.Load(UIElementsEditorUtility.GetStyleSheetPathForCurrentFont(s_ToolbarDarkStyleSheetPath)) as StyleSheet;
            s_ToolbarDarkStyleSheet.isDefaultStyleSheet = true;

            s_ToolbarLightStyleSheet = EditorGUIUtility.Load(UIElementsEditorUtility.GetStyleSheetPathForCurrentFont(s_ToolbarLightStyleSheetPath)) as StyleSheet;
            s_ToolbarLightStyleSheet.isDefaultStyleSheet = true;
        }

        internal static void SetToolbarStyleSheet(VisualElement ve)
        {
            if (EditorGUIUtility.isProSkin)
            {
                ve.styleSheets.Add(s_ToolbarDarkStyleSheet);
            }
            else
            {
                ve.styleSheets.Add(s_ToolbarLightStyleSheet);
            }
        }

        /// <summary>
        /// USS class name of elements of this type.
        /// </summary>
        public static readonly string ussClassName = "unity-toolbar";

        /// <summary>
        /// Constructor.
        /// </summary>
        public Toolbar()
        {
            AddToClassList(ussClassName);
            SetToolbarStyleSheet(this);
        }
    }
}
