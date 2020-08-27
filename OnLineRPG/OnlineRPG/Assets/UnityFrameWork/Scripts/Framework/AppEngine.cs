using EventUtil;
using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace BetaFramework
{
    public static partial class AppEngine
    {
        private static ModuleManager modules = null;

        public static DownloadManager SDownloadManager;
        public static ResourcesManager SResourceManager;
        public static ObjectPoolManager SObjectPoolManager;
        public static SoundManager SSoundManager;
        public static TimersManager STimersManager;
        public static GameSettingManager SGameSettingManager;
        public static UIManager SUIManager;

        public static NetworkManager SNetworkManager;
//        public static AsyncTaskManager STaskManager;



        public static TimeHeart STimeHeart;

        public static SystemManager SSystemManager;

        public static NetworkReachability SNetworkReachability;

        private static List<GameObject> m_DontGameObjects = new List<GameObject>();

        private static Action s_InitSuccess;

        static AppEngine(){
            modules = new ModuleManager();
            SGameSettingManager = Modules.Registered<GameSettingManager>();
            STimeHeart = Modules.Registered<TimeHeart>();
            STimersManager = Modules.Registered<TimersManager>();
            SDownloadManager = Modules.Registered<DownloadManager>();
            SObjectPoolManager = Modules.Registered<ObjectPoolManager>();
            SSoundManager = Modules.Registered<SoundManager>();
            SUIManager = Modules.Registered<UIManager>();
            SNetworkManager = Modules.Registered<NetworkManager>();
//            STaskManager = Modules.Registered<AsyncTaskManager>();
            SSystemManager = new SystemManager();
            Modules.Registered<KeyEventManager>();
        }

        public static void Init(Action callback = null)
        {
            s_InitSuccess = callback;
            
            SNetworkReachability = Application.internetReachability;

            SResourceManager = Object.FindObjectOfType<ResourcesManager>();

            OnLoadConfigSuccess();
        }

        public static ModuleManager Modules
        {
            get
            {
                if (modules == null)
                    modules = new ModuleManager();
                return modules;
            }
        }
        
        public static T GetModule<T>() where T : IModule
        {
            return Modules.GetModule<T>();
        }

        private static void OnLoadConfigSuccess()
        {
            DataManager.Init();
            LanguageManager.Init();
            Modules.Init();
            
            SSystemManager.Complete(() =>
            {
                if (s_InitSuccess != null)
                {
                    s_InitSuccess();
                    s_InitSuccess = null;
                }
            });
            SSystemManager.Init();
        }

        public static void Update()
        {
            SSystemManager.Execute(Time.deltaTime);
            Modules.Execute(Time.deltaTime);
        }

        public static void Destroy()
        {
            Modules.Release();
            Modules.UnRegisteredAll();

            DataManager.Clear();

            for (int i = 0; i < m_DontGameObjects.Count; i++)
            {
                Object.Destroy(m_DontGameObjects[i]);
            }
            m_DontGameObjects.Clear();
        }

        public static void ApplicationPause(bool pause)
        {
            SSystemManager.Pause(pause);
            Modules.Pause(pause);
        }

        public static void AddDontGameObject(GameObject go)
        {
            if (!m_DontGameObjects.Contains(go))
            {
                m_DontGameObjects.Add(go);
                Object.DontDestroyOnLoad(go);
            }
        }
        
        public static void SwitchUI(GameUI UiToSwitch)
        {
            Modules.OnEnterUI(UiToSwitch);
            SSystemManager.OnEnterUI(UiToSwitch);
            if (UiToSwitch == GameUI.Home)
            {
            }
        }
    }
}