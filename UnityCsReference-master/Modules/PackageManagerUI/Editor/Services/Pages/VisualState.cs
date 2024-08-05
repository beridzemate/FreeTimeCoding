// Unity C# reference source
// Copyright (c) Unity Technologies. For terms of use, see
// https://unity3d.com/legal/licenses/Unity_Reference_Only_License

using System;

namespace UnityEditor.PackageManager.UI.Internal
{
    [Serializable]
    internal class VisualState : IEquatable<VisualState>
    {
        public string packageUniqueId;
        public string groupName;
        public bool visible;
        public bool lockedByDefault;
        public bool userUnlocked;

        public bool isLocked => lockedByDefault && !userUnlocked;

        public VisualState(string packageUniqueId, string groupName = "", bool lockedByDefault = false)
        {
            this.packageUniqueId = packageUniqueId;
            this.groupName = groupName;
            this.lockedByDefault = lockedByDefault;
            visible = true;
            userUnlocked = false;
        }

        public bool Equals(VisualState other)
        {
            return other != null
                   && packageUniqueId == other.packageUniqueId
                   && groupName == other.groupName
                   && visible == other.visible
                   && lockedByDefault == other.lockedByDefault
                   && userUnlocked == other.userUnlocked;
        }

        public VisualState Clone()
        {
            return (VisualState)MemberwiseClone();
        }
    }
}
