// Unity C# reference source
// Copyright (c) Unity Technologies. For terms of use, see
// https://unity3d.com/legal/licenses/Unity_Reference_Only_License

using System;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEditor.UIElements;
using UnityEditor.PackageManager.UI.Internal;
using UnityEngine.UIElements;

namespace UnityEditor.PackageManager.UI
{
    /// <summary>
    /// PackageManager Window helper class
    /// </summary>
    public static class Window
    {
        [MenuItem("Window/Package Manager", priority = 1500)]
        internal static void ShowPackageManagerWindow(MenuCommand item)
        {
            Open(item.context?.name);
        }

        /// <summary>
        /// Open Package Manager Window and select specified package(if any).
        /// The string used to identify the package can be any of the following:
        /// <list type="bullet">
        /// <item><description>productId (e.g. 12345)</description></item>
        /// <item><description>packageName (e.g. com.unity.x)</description></item>
        /// <item><description>packageId (e.g. com.unity.x@1.0.0)</description></item>
        /// <item><description>displayName (e.g. 2D Common)</description></item>
        /// <item><description>null (no specific package to focus)</description></item>
        /// </list>
        /// </summary>
        /// <param name="packageToSelect">packageToSelect can be identified by packageName, displayName, packageId, productId or null</param>
        public static void Open(string packageToSelect)
        {
            PackageManagerWindow.OpenPackageManager(packageToSelect);
        }

        /// <summary>
        /// Open Package Manager Window and select specified page.
        /// The string used to identify the page can be any of the following:
        /// <list type="bullet">
        /// <item><description>Basic pages including "UnityRegistry", "BuiltIn", "InProject", "MyRegistries", and "MyAssets"</description></item>
        /// <item><description>Extension pages with id that looks like "Extension/id", where "id" is the unique string id for the extension</description></item>
        /// <item><description>null (no specific page to focus)</description></item>
        /// </list>
        /// </summary>
        /// <param name="pageIdToSelect">Page Id to select. If page cannot be found, last selected page will be selected</param>
        internal static void OpenPage(string pageIdToSelect)
        {
            PackageManagerWindow.OpenPackageManagerOnPage(pageIdToSelect);
        }
    }

    [EditorWindowTitle(title = "Package Manager", icon = "Package Manager")]
    internal class PackageManagerWindow : EditorWindow
    {
        internal static PackageManagerWindow instance { get; private set; }

        private PackageManagerWindowRoot m_Root;
        private ScrollView m_ScrollView;

        internal const string k_UpmUrl = "com.unity3d.kharma:upmpackage/";

        void OnEnable()
        {
            this.SetAntiAliasing(4);
            if (instance == null) instance = this;
            if (instance != this)
                return;

            titleContent = GetLocalizedTitleContent();

            minSize = new Vector2(1050, 250);
            BuildGUI();

            Events.registeredPackages += OnRegisteredPackages;
        }

        private void BuildGUI()
        {
            var container = ServicesContainer.instance;
            var resourceLoader = container.Resolve<IResourceLoader>();
            var extensionManager = container.Resolve<IExtensionManager>();
            var selection = container.Resolve<ISelectionProxy>();
            var packageManagerPrefs = container.Resolve<IPackageManagerPrefs>();
            var packageDatabase = container.Resolve<IPackageDatabase>();
            var pageManager = container.Resolve<IPageManager>();
            var settingsProxy = container.Resolve<IProjectSettingsProxy>();
            var unityConnectProxy = container.Resolve<IUnityConnectProxy>();
            var applicationProxy = container.Resolve<IApplicationProxy>();
            var upmClient = container.Resolve<IUpmClient>();
            var assetStoreCachePathProxy = container.Resolve<IAssetStoreCachePathProxy>();
            var pageRefreshHandler = container.Resolve<IPageRefreshHandler>();
            var operationDispatcher = container.Resolve<IPackageOperationDispatcher>();

            // Adding the ScrollView object here because it really need to be the first child under rootVisualElement for it to work properly.
            // Since the StyleSheet is added to PackageManagerRoot, the css is exceptionally added directly to the object
            m_ScrollView = new ScrollView
            {
                mode = ScrollViewMode.Horizontal,
                style =
                {
                    flexGrow = 1
                }
            };
            m_Root = new PackageManagerWindowRoot(resourceLoader, extensionManager, selection, packageManagerPrefs, packageDatabase, pageManager, settingsProxy, unityConnectProxy, applicationProxy, upmClient, assetStoreCachePathProxy, pageRefreshHandler, operationDispatcher);
            try
            {
                m_Root.OnEnable();
                rootVisualElement.Add(m_ScrollView);
                m_ScrollView.Add(m_Root);
            }
            catch (ResourceLoaderException)
            {
                // Do nothing, defer it to CreateGUI
            }
            catch (TargetInvocationException e)
            {
                CheckInnerException<ResourceLoaderException>(e);
            }

            if (pageRefreshHandler.IsInitialFetchingDone(pageManager.activePage))
                OnFirstRefreshOperationFinish();
            else
                pageRefreshHandler.onRefreshOperationFinish += OnFirstRefreshOperationFinish;
        }

        void CreateGUI()
        {
            if (m_Root == null)
                return;

            if (!rootVisualElement.Contains(m_Root))
            {
                try
                {
                    m_Root.OnEnable();
                    rootVisualElement.Add(m_Root);
                }
                catch (ResourceLoaderException)
                {
                    Debug.LogError(L10n.Tr("[Package Manager Window] Unable to load resource, window can't be displayed.)"));
                    return;
                }
                catch (TargetInvocationException e)
                {
                    CheckInnerException<ResourceLoaderException>(e);
                    Debug.LogError(L10n.Tr("[Package Manager Window] Unable to load resource, window can't be displayed.)"));
                    return;
                }
            }

            m_Root.OnCreateGUI();
        }

        private void OnFirstRefreshOperationFinish()
        {
            var container = ServicesContainer.instance;
            var pageRefreshHandler = container.Resolve<IPageRefreshHandler>();
            pageRefreshHandler.onRefreshOperationFinish -= OnFirstRefreshOperationFinish;
        }

        void OnDisable()
        {
            if (instance == null) instance = this;
            if (instance != this)
                return;

            m_Root?.OnDisable();

            Events.registeredPackages -= OnRegisteredPackages;
        }

        void OnDestroy()
        {
            m_Root?.OnDestroy();

            instance = null;
        }

        void OnFocus()
        {
            m_Root?.OnFocus();
        }

        void OnLostFocus()
        {
            m_Root?.OnLostFocus();
        }

        [UsedByNativeCode]
        internal static void OpenURL(string url)
        {
            if (string.IsNullOrEmpty(url))
                return;

            // com.unity3d.kharma:content/11111                       => AssetStore url
            // com.unity3d.kharma:upmpackage/com.unity.xxx@1.2.2      => Upm url
            if (url.StartsWith(k_UpmUrl))
            {
                SelectPackageAndPageStatic(pageId: InProjectPage.k_Id);
                EditorApplication.delayCall += () => OpenAddPackageByName(url);
            }
            else
            {
                var startIndex = url.LastIndexOf('/');
                if (startIndex > 0)
                {
                    var id = url.Substring(startIndex + 1);
                    var endIndex = id.IndexOf('?');
                    if (endIndex > 0)
                        id = id.Substring(0, endIndex);

                    SelectPackageAndPageStatic(id, MyAssetsPage.k_Id);
                }
            }
        }

        private static void OpenAddPackageByName(string url)
        {
            if (float.IsNaN(instance.position.x) || float.IsNaN(instance.position.y))
            {
                EditorApplication.delayCall += () => OpenAddPackageByName(url);
                return;
            }
            instance.Focus();
            instance.m_Root.OpenAddPackageByNameDropdown(url, instance);
        }

        [UsedByNativeCode]
        internal static void OpenPackageManager(string packageToSelect)
        {
            var isWindowAlreadyVisible = Resources.FindObjectsOfTypeAll<PackageManagerWindow>()?.FirstOrDefault() != null;

            SelectPackageAndPageStatic(packageToSelect);
            if (!isWindowAlreadyVisible)
            {
                string packageId = null;
                if (!string.IsNullOrEmpty(packageToSelect))
                {
                    var packageDatabase = ServicesContainer.instance.Resolve<IPackageDatabase>();
                    packageDatabase.GetPackageAndVersionByIdOrName(packageToSelect, out var package, out var version, true);

                    packageId = version?.uniqueId ?? package?.versions.primary.uniqueId ?? string.Format("{0}@primary", packageToSelect);
                }
                PackageManagerWindowAnalytics.SendEvent("openWindow", packageId);
            }
        }

        internal static void OpenPackageManagerOnPage(string pageId)
        {
            var isWindowAlreadyVisible = Resources.FindObjectsOfTypeAll<PackageManagerWindow>()?.FirstOrDefault() != null;

            SelectPackageAndPageStatic(pageId: pageId);
            if (!isWindowAlreadyVisible)
                PackageManagerWindowAnalytics.SendEvent("openWindowOnFilter", pageId);
        }

        [UsedByNativeCode("PackageManagerUI_OnPackageManagerResolve")]
        internal static void OnPackageManagerResolve()
        {
            var packageDatabase = ServicesContainer.instance.Resolve<IPackageDatabase>();
            packageDatabase?.ClearSamplesCache();

            var applicationProxy = ServicesContainer.instance.Resolve<IApplicationProxy>();
            if (applicationProxy.isBatchMode)
                return;

            var upmRegistryClient = ServicesContainer.instance.Resolve<IUpmRegistryClient>();
            upmRegistryClient.CheckRegistriesChanged();

            var upmClient = ServicesContainer.instance.Resolve<IUpmClient>();
            upmClient.List(true);
        }

        [InitializeOnLoadMethod]
        private static void EditorInitializedInSafeMode()
        {
            if (EditorUtility.isInSafeMode)
                OnEditorFinishLoadingProject();
        }

        [UsedByNativeCode]
        internal static void OnEditorFinishLoadingProject()
        {
            var servicesContainer = ServicesContainer.instance;
            var applicationProxy = servicesContainer.Resolve<IApplicationProxy>();
            if (!applicationProxy.isBatchMode && applicationProxy.isUpmRunning)
            {
                var upmClient = servicesContainer.Resolve<IUpmClient>();
                EntitlementsErrorAndDeprecationChecker.ManagePackageManagerEntitlementErrorAndDeprecation(upmClient);
                upmClient.List();
            }
        }

        private static void OnRegisteredPackages(PackageRegistrationEventArgs args)
        {
            var applicationProxy = ServicesContainer.instance.Resolve<IApplicationProxy>();
            if (applicationProxy.isBatchMode)
                return;

            var pageRefreshHandler = ServicesContainer.instance.Resolve<IPageRefreshHandler>();
            pageRefreshHandler.Refresh(RefreshOptions.UpmListOffline);
        }

        internal static void SelectPackageAndPageStatic(string packageToSelect = null, string pageId = null, bool refresh = false, string searchText = "")
        {
            instance = GetWindow<PackageManagerWindow>();
            instance.minSize = new Vector2(1050, 250);
            instance.m_Root.SelectPackageAndPage(packageToSelect, pageId, refresh, searchText);
            instance.Show();
        }

        internal static void CloseAll()
        {
            var windows = Resources.FindObjectsOfTypeAll<PackageManagerWindow>();
            if (windows == null)
                return;

            foreach (var window in windows)
                window.Close();

            instance = null;
        }

        private static void CheckInnerException<T>(TargetInvocationException e) where T : Exception
        {
            var originalException = e;
            while (e.InnerException is TargetInvocationException)
                e = e.InnerException as TargetInvocationException;
            if (!(e.InnerException is T))
                throw originalException;
        }
    }
}
