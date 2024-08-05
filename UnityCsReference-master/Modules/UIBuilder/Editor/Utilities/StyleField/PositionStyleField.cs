// Unity C# reference source
// Copyright (c) Unity Technologies. For terms of use, see
// https://unity3d.com/legal/licenses/Unity_Reference_Only_License

using System;
using UnityEditor;
using UnityEngine.UIElements;

namespace Unity.UI.Builder
{
    class PositionStyleField : DimensionStyleField
    {
        [Serializable]
        public new class UxmlSerializedData : DimensionStyleField.UxmlSerializedData
        {
            public override object CreateInstance() => new PositionStyleField();
        }

        static readonly string k_FieldClassName = "unity-position-style-field";
        static readonly string k_UssPathNoExt = BuilderConstants.UtilitiesPath + "/StyleField/PositionSection";

        public PositionAnchorPoint point { get; set; }

        public PositionStyleField() : this(null) { }

        public PositionStyleField(string label) : base(label)
        {
            AddToClassList(BuilderConstants.InspectorContainerClassName);
            AddToClassList(k_FieldClassName);
            styleSheets.Add(BuilderPackageUtilities.LoadAssetAtPath<StyleSheet>(k_UssPathNoExt + (EditorGUIUtility.isProSkin ? "Dark" : "Light") + ".uss"));
            styleSheets.Add(BuilderPackageUtilities.LoadAssetAtPath<StyleSheet>(k_UssPathNoExt + ".uss"));
        }

        public override void SetValueWithoutNotify(string newValue)
        {
            base.SetValueWithoutNotify(newValue);
            RefreshAnchor(newValue);
        }

        private void RefreshAnchor(string newValue)
        {
            if (point != null)
                point.SetValueWithoutNotify(newValue != StyleFieldConstants.KeywordAuto);
        }
    }
}
