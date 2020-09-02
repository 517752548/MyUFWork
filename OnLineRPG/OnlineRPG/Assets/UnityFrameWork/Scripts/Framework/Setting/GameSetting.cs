using UnityEngine;
using UnityEngine.SceneManagement;

namespace BetaFramework
{
    public static class GameSetting
    {
        private static string m_AppsflyerDevKey = "aenSuFdSXYGEa8HyMfspZA";
#if UNITY_ANDROID
        private const string m_AppsflyerAppID = "1273162445";
#else
        private const string m_AppsflyerAppID = "1453795744";
#endif
        private static string m_AdjustAppToken = "";
        private static string m_FtdAppId = "";
        private static string m_FtdAppKey = "";
        private static string m_FtdSignWay = "";
        private static string m_AdjustEventToken = "uz669m";
        private static bool m_isAllowDebugSandBoxDispatchEvent;

        private static string m_GooglePublicKey =
            "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAnLHqFqmmHADtTGtSgOX6bZDNu6nIz57KZop/bxn9c7kZqOCJUrBerIhu8fkzKjEvAQYYjwsqZo5O0Bfkfgwk3O4juUTZi6YBrgm86N+KzyGKBOc4tQTYlVSXdmBLhx3Q9KXdF0/U6+bCxd0BptOeFB2HSUEP39MI7GDitr0zrfJ0Noclbb/gD1N/QbQ+l7KgzO5OFISio7Re8mQQZnTPJcI7fCooDrSPL3+sr4TyGLrBJ4usfQAW8LGL8TAwJW3WYlI76fZwOeoGKOrddJYmMb2In66IW/pt3f8gFgWo5Uwj101f478gT2lCKIUoGv2FkrUGsQPyqvUlDLdMpBiy8QIDAQAB";

        public static void Init()
        {
            Application.runInBackground = false;
#if UNITY_IOS
            string modelStr = SystemInfo.deviceModel;
            // iPhoneX:"iPhone10,3","iPhone10,6"  iPhoneXR:"iPhone11,8"  iPhoneXS:"iPhone11,2"  iPhoneXS Max:"iPhone11,6"
            if (modelStr.Contains("iPhone6") || modelStr.Contains("iPhone5") || modelStr.Contains("iPhone4"))
            {
                Application.targetFrameRate = 30;
            }
            else
            {
                Application.targetFrameRate = 60;
            }
#else
Application.targetFrameRate = 60;
#endif


            Screen.orientation = ScreenOrientation.Portrait;
            Screen.autorotateToPortrait = true;
            Screen.autorotateToPortraitUpsideDown = true;
            Screen.autorotateToLandscapeLeft = false;
            Screen.autorotateToLandscapeRight = false;
            Input.multiTouchEnabled = false;

#if UNITY_ANDROID
            m_BuildVersion = 1;
#elif UNITY_IOS
            m_BuildVersion = 7;
#endif
            IsAllowDebugSandBoxDispatchEvent = false;

            m_IsDebugMode = !PlatformUtil.GetAppIsRelease();
            LoggerHelper.Init(m_IsDebugMode);
            Application.logMessageReceived += (condition, trace, type) =>
            {
                if (type.ToString().Contains("Exception"))
                {
                    if (!trace.Contains("BetaFramework.TimersManager.Execute"))
                    {
                        BQReport.LogPlayerException(condition, trace);
                        GameAnalyze.LogException(SceneManager.GetActiveScene().name + condition, trace);
                        if (m_IsDebugMode)
                            UIManager.ShowMessage("有报错,给程序看一下");
                    }

//                    ReportDataManager.PostUseExceptoin_new(condition, trace);
                }
            };
        }

        private static int m_BuildVersion;

        public static int BuildVersion
        {
            get { return m_BuildVersion; }
            set { m_BuildVersion = value; }
        }

        //游戏版本号
        private static string m_Version;

        public static string Version
        {
            get { return m_Version; }
            set { m_Version = value; }
        }

        //资源版本号
        private static string m_ResourceVersion;

        public static string ResourceVersion
        {
            get { return m_ResourceVersion; }
            set { m_ResourceVersion = value; }
        }

        //是否是测试环境
        private static bool m_IsDebugMode;

        public static bool IsDebugMode
        {
            get { return m_IsDebugMode; }
            set { m_IsDebugMode = value; }
        }

        public static bool ShowText { get; set; }

        //appsflyer key
        public static string AppsflyerDevKey
        {
            get { return m_AppsflyerDevKey; }
        }

        public static string AppsflyerAppID
        {
            get { return m_AppsflyerAppID; }
        }

        //adjust
        public static string AdjustAppToken
        {
            get { return m_AdjustAppToken; }
        }

        //ftd
        public static string FtdAppId
        {
            get { return m_FtdAppId; }
        }

        public static string FtdAppKey
        {
            get { return m_FtdAppKey; }
        }

        public static string FtdSignWay
        {
            get { return m_FtdSignWay; }
        }

        public static string GooglePublicKey
        {
            get { return m_GooglePublicKey; }
        }

        public static string AdjustEventToken
        {
            get { return m_AdjustAppToken; }
        }

        public static bool IsAllowDebugSandBoxDispatchEvent
        {
            get { return m_isAllowDebugSandBoxDispatchEvent; }

            set { m_isAllowDebugSandBoxDispatchEvent = value; }
        }
    }
}