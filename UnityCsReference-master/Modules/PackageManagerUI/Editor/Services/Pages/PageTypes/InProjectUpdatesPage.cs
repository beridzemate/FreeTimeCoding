// Unity C# reference source
// Copyright (c) Unity Technologies. For terms of use, see
// https://unity3d.com/legal/licenses/Unity_Reference_Only_License

using System;

namespace UnityEditor.PackageManager.UI.Internal;

[Serializable]
internal class InProjectUpdatesPage : InProjectPage
{
    public new const string k_Id = "Updates";

    public override string id => k_Id;
    public override string displayName => L10n.Tr("Updates");
    public override Icon icon => Icon.UpdatesPage;

    public InProjectUpdatesPage(IPackageDatabase packageDatabase) : base(packageDatabase) {}

    public override bool ShouldInclude(IPackage package)
    {
        return base.ShouldInclude(package) && package.state == PackageState.UpdateAvailable;
    }
}
