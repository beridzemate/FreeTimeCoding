// Unity C# reference source
// Copyright (c) Unity Technologies. For terms of use, see
// https://unity3d.com/legal/licenses/Unity_Reference_Only_License

using System;
using System.Collections.Generic;

namespace UnityEngine.Rendering
{
    public abstract class RenderPipelineGlobalSettings : ScriptableObject, ISerializationCallbackReceiver
    {
        protected virtual List<IRenderPipelineGraphicsSettings> settingsList
        {
            get
            {
                Debug.LogWarning($"To be able to use {nameof(IRenderPipelineGraphicsSettings)} in your {GetType()} you must override {nameof(settingsList)}");
                Debug.LogWarning($"Create your own '[{nameof(SerializeReference)}] List<{nameof(IRenderPipelineGraphicsSettings)}> m_Settings = new();' in your {GetType()} and override {nameof(settingsList)} returning m_Settings;");
                return null;
            }
        }

        Dictionary<Type, int> settingsMap { get; } = new();

        private void RecreateSettingsMap()
        {
            settingsMap.Clear();

            if (settingsList == null)
                return;

            for (int i = 0; i < settingsList.Count; i++)
            {
                var element = settingsList[i];

                if (element == null)
                    continue; //missing script can cause this, preserve data, just not access it

                settingsMap.Add(element.GetType(), i);
            }
        }

        public virtual void Initialize(RenderPipelineGlobalSettings source = null)
        {
        }

        protected internal bool Add(IRenderPipelineGraphicsSettings settings)
        {
            if (settingsList == null || settingsMap.ContainsKey(settings.GetType()))
                return false;

            settingsMap.Add(settings.GetType(), settingsList.Count);
            settingsList.Add(settings);
            MarkDirty();
            return true;
        }

        protected internal bool Remove(IRenderPipelineGraphicsSettings settings)
        {
            if (settingsList == null || !settingsMap.TryGetValue(settings.GetType(), out var index))
                return false;

            settingsList.RemoveAt(index);
            RecreateSettingsMap();
            MarkDirty();
            return true;
        }

        internal int IndexOf(Type settingsType)
        {
            if (settingsList == null)
                return -1;

            return settingsMap.GetValueOrDefault(settingsType, -1);
        }

        internal void CleanNullSettings()
        {
            if (settingsList == null)
                return;

            var initialCount = settingsList.Count;
            for (int i = 0; i < settingsList.Count; i++)
            {
                if (settingsList[i] == null)
                {
                    settingsList.RemoveAt(i);
                    --i;
                }
            }
            if(initialCount != settingsList.Count)
                MarkDirty();
        }

        protected internal bool TryGet(Type type, out IRenderPipelineGraphicsSettings settings)
        {
            settings = null;

            if (settingsList == null)
                return false;

            if (!settingsMap.TryGetValue(type, out var index))
                return false;

            settings = settingsList[index];
            return settings != null;
        }

        protected internal bool TryGetFirstSettingsImplementingInterface<TSettingsInterfaceType>(out TSettingsInterfaceType settings)
            where TSettingsInterfaceType : class, IRenderPipelineGraphicsSettings
        {
            settings = null;

            if (settingsList == null)
                return false;

            for (int i = 0; i < settingsList.Count; i++)
            {
                if (settingsList[i] is TSettingsInterfaceType match)
                {
                    settings = match;
                    return true;
                }
            }

            return false;
        }

        protected internal bool GetSettingsImplementingInterface<TSettingsInterfaceType>(out List<TSettingsInterfaceType> settings)
            where TSettingsInterfaceType : class, IRenderPipelineGraphicsSettings
        {
            settings = new ();

            if (settingsList == null)
                return false;

            for (int i = 0; i < settingsList.Count; i++)
            {
                if (settingsList[i] is TSettingsInterfaceType match)
                {
                    settings.Add(match);
                }
            }

            return settings.Count > 0;
        }

        protected internal bool Contains(Type type)
        {
            return settingsList != null && settingsMap.ContainsKey(type);
        }

        public virtual void OnBeforeSerialize()
        {
        }

        public virtual void OnAfterDeserialize()
        {
            RecreateSettingsMap();
        }
    }
}
