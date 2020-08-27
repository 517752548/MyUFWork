using System;
using System.Collections.Generic;
using UnityEngine;

namespace BetaFramework
{
    public class ModuleManager
    {
        private Dictionary<string, IModule> m_Modules = new Dictionary<string, IModule>();

        public T Registered<T>() where T : IModule
        {
            T plugin = Activator.CreateInstance<T>();
            Type type = typeof(T);

            if (!m_Modules.ContainsKey(type.FullName))
            {
                m_Modules.Add(type.FullName, plugin);
                LoggerHelper.LogFormat("Registered module {0}", type.FullName);
            }
            else
            {
                LoggerHelper.ErrorFormat("Registered module {0} error. {0} already exists", type.FullName);
            }

            return plugin;
        }

        public T CoverRegistered<T, T2>() where T : IModule
        {
            T plugin = Activator.CreateInstance<T>();
            Type type = typeof(T);
            Type type2 = typeof(T2);

            if (m_Modules.ContainsKey(type2.FullName))
            {
                m_Modules[type2.FullName].Enable = false;
                m_Modules.Remove(type2.FullName);
                LoggerHelper.LogFormat("Registered remove module {0}", type2.FullName);
            }
            if (!m_Modules.ContainsKey(type.FullName))
            {
                m_Modules.Add(type.FullName, plugin);
                LoggerHelper.LogFormat("Registered module {0}", type.FullName);
            }
            else
            {
                LoggerHelper.ErrorFormat("Registered module {0} error. {0} already exists", type.FullName);
            }

            return plugin;
        }

        public void UnRegisteredAll()
        {
            foreach (IModule module in m_Modules.Values)
            {
                module.Enable = false;
            }
            m_Modules.Clear();
        }

        public T FindModule<T>() where T : IModule
        {
            IModule module = FindModule(typeof(T).ToString());
            if (module == null)
            {
                return GetModule<T>();
            }
            return (T)module;
        }

        public IModule FindModule(string strModuleName)
        {
            IModule module;
            m_Modules.TryGetValue(strModuleName, out module);
            return module;
        }

        public T GetModule<T>() where T : IModule
        {
            foreach (IModule module in m_Modules.Values)
            {
                if (module is T)
                    return (T)module;
            }
            return null;
        }

        public virtual void Init()
        {
            foreach (IModule plugin in m_Modules.Values)
            {
                if (plugin != null)
                {
                    plugin.Init();
                }
            }
        }

        public virtual void Pause(bool pause)
        {
            foreach (IModule plugin in m_Modules.Values)
            {
                if (plugin != null)
                {
                    plugin.Pause(pause);
                }
            }
        }

        public virtual void Execute(float deltaTime)
        {
            foreach (IModule plugin in m_Modules.Values)
            {
                if (plugin != null)
                {
                    plugin.Execute(deltaTime);
                }
            }
        }

        public virtual void Release()
        {
            foreach (IModule plugin in m_Modules.Values)
            {
                if (plugin != null)
                {
                    plugin.Shut();
                }
            }
        }
        
        public  void OnEnterUI(GameUI UiToSwitch)
        {
            foreach (IModule plugin in m_Modules.Values)
            {
                if (plugin != null)
                {
                    plugin.OnEnterUI(UiToSwitch);
                }
            }
        }
    }
}