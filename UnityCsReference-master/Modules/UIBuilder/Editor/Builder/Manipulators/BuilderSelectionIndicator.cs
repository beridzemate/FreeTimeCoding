// Unity C# reference source
// Copyright (c) Unity Technologies. For terms of use, see
// https://unity3d.com/legal/licenses/Unity_Reference_Only_License

using System;
using UnityEngine.UIElements;

namespace Unity.UI.Builder
{
    class BuilderSelectionIndicator : BuilderTracker
    {
        static readonly string s_UssClassName = "unity-builder-selection-indicator";
        VisualElement m_Header;
        Label m_HeaderLabel;
        BuilderCanvasStyleControls m_CanvasStyleControls;

        [Serializable]
        public new class UxmlSerializedData : BuilderTracker.UxmlSerializedData
        {
            public override object CreateInstance() => new BuilderSelectionIndicator();
        }

        public BuilderCanvasStyleControls canvasStyleControls => m_CanvasStyleControls;

        public BuilderSelectionIndicator()
        {
            var builderTemplate = BuilderPackageUtilities.LoadAssetAtPath<VisualTreeAsset>(
                BuilderConstants.UIBuilderPackagePath + "/Manipulators/BuilderSelectionIndicator.uxml");
            builderTemplate.CloneTree(this);

            AddToClassList(s_UssClassName);
            m_Header = this.Q("header");
            m_HeaderLabel = m_Header.Q<Label>("header-label");
            m_CanvasStyleControls = m_Header.Q<BuilderCanvasStyleControls>();
        }

        public void Activate(BuilderSelection selection, VisualTreeAsset visualTreeAsset, VisualElement element, BuilderBindingsCache bindingCache)
        {
            base.Activate(element);

            UpdateLabel();

            m_CanvasStyleControls.Activate(selection, visualTreeAsset, element, bindingCache);
        }

        public override void Deactivate()
        {
            base.Deactivate();
            m_CanvasStyleControls.Deactivate();
        }

        public void OnHierarchyChanged(VisualElement element)
        {
            UpdateLabel();
        }

        void UpdateLabel()
        {
            if (m_Target == null)
                return;

            if (string.IsNullOrEmpty(m_Target.name))
                m_HeaderLabel.text = m_Target.typeName;
            else
                m_HeaderLabel.text = BuilderConstants.UssSelectorNameSymbol + m_Target.name;
        }
    }
}
