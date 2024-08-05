// Unity C# reference source
// Copyright (c) Unity Technologies. For terms of use, see
// https://unity3d.com/legal/licenses/Unity_Reference_Only_License

namespace UnityEditor.PackageManager.UI.Internal
{
    internal class DownloadUpdateFoldoutGroup : MultiSelectFoldoutGroup
    {
        public DownloadUpdateFoldoutGroup(IAssetStoreDownloadManager assetStoreDownloadManager,
                                          IAssetStoreCache assetStoreCache,
                                          IPackageOperationDispatcher operationDispatcher,
                                          IUnityConnectProxy unityConnect,
                                          IApplicationProxy application)
            : base(new DownloadUpdateAction(operationDispatcher, assetStoreDownloadManager, unityConnect, application),
                   new CancelDownloadAction(operationDispatcher, assetStoreDownloadManager, application))
        {
            mainFoldout.headerTextTemplate = L10n.Tr("Download update for {0}");
            inProgressFoldout.headerTextTemplate = L10n.Tr("Downloading updates for {0}...");
        }
    }
}
