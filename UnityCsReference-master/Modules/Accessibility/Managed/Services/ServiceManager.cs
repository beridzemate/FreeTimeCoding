// Unity C# reference source
// Copyright (c) Unity Technologies. For terms of use, see
// https://unity3d.com/legal/licenses/Unity_Reference_Only_License

using System;
using System.Collections.Generic;

namespace UnityEngine.Accessibility
{
    internal class ServiceManager
    {
        // All of the services that are currently created, but not necessarily active.
        readonly IDictionary<Type, IService> m_Services;

        public ServiceManager()
        {
            m_Services = new Dictionary<Type, IService>();

            AccessibilityManager.screenReaderStatusChanged += ScreenReaderStatusChanged;

            // In the Editor context, we always initialize services in order to allow users to build,
            // activate and debug (using the Accessibility Hierarchy Viewer for instance) their Accessibility hierarchies in play mode
            // even if Screen Reader is off and the Accessibility backend is not supported.
            UpdateServices(true);
        }

        public T GetService<T>() where T : IService
        {
            var serviceType = typeof(T);
            m_Services.TryGetValue(serviceType, out var service);
            return (T)service;
        }

        void StartService<T>() where T : IService
        {
            var service = GetService<T>();

            // If the service doesn't exist yet or isn't running, create a new instance and start it
            if (service == null)
            {
                var serviceType = typeof(T);
                service = (T)Activator.CreateInstance(serviceType);
                service.Start();
                m_Services.Add(serviceType, service);
            }
        }

        void StopService<T>() where T : IService
        {
            var service = GetService<T>();

            // Only stop the service if it exists and is already running, then remove references to it
            if (service != null)
            {
                service.Stop();
                m_Services.Remove(typeof(T));
            }
        }

        void UpdateServices(bool isScreenReaderEnabled)
        {
            if (isScreenReaderEnabled)
            {
                if (!m_Services.ContainsKey(typeof(AccessibilityHierarchyService)))
                {
                    var service = new AccessibilityHierarchyService();
                    service.Start();
                    m_Services.Add(typeof(AccessibilityHierarchyService), service);
                }
            }
            else
            {
                StopService<AccessibilityHierarchyService>();
            }
        }

        protected void ScreenReaderStatusChanged(bool isScreenReaderEnabled)
        {
            UpdateServices(isScreenReaderEnabled);
        }
    }
}
