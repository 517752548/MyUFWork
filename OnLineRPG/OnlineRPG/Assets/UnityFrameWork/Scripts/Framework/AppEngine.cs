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
        public static ObjectPoolManager SObjectPoolManager;
        public static SoundManager SSoundManager;
        public static TimersManager STimersManager;
        public static GameSettingManager SGameSettingManager;
        public static UIManager SUIManager;
        public static SDKManager SSDKManager;

        private static PurchaserManager s_PurchaserManager;
        public static PurchaserManager SPurchaserManager
        {
            get
            {
                if (s_PurchaserManager == null || !s_PurchaserManager.Enable)
                    s_PurchaserManager = modules.FindModule<PurchaserManager>();
                return s_PurchaserManager;
            }
        }
        public static AdManager SAdManager;
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
            s_PurchaserManager = Modules.Registered<PurchaserManager>();
            SAdManager = Modules.Registered<AdManager>();
            SNetworkManager = Modules.Registered<NetworkManager>();
            SSDKManager = Modules.Registered<SDKManager>();
//            STaskManager = Modules.Registered<AsyncTaskManager>();
            SSystemManager = new SystemManager();
            Modules.Registered<KeyEventManager>();
        }

        public static void Init(Action callback = null)
        {
            s_InitSuccess = callback;
            
            SNetworkReachability = Application.internetReachability;

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
            if (SNetworkReachability == NetworkReachability.NotReachable &&
                SNetworkReachability != Application.internetReachability)
            {
                CommandBinder.DispatchBinding(GameEvent.AppRestart);
            }
            SSystemManager.Pause(pause);
            Modules.Pause(pause);
            if (SSystemManager.GetSystem<NotificationSystem>() != null)
                AppEngine.SSystemManager.GetSystem<NotificationSystem>().CheckPlayerClickNotifi();
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
                GameAnalyze.LogusersActive();
            }
        }
    }
}