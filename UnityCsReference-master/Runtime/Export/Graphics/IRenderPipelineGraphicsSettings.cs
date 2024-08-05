// Unity C# reference source
// Copyright (c) Unity Technologies. For terms of use, see
// https://unity3d.com/legal/licenses/Unity_Reference_Only_License

namespace UnityEngine.Rendering
{
    public interface IRenderPipelineGraphicsSettings
    {
        int version { get; }

        bool isAvailableInPlayerBuild => false;

        void Reset() { }
    }
}
