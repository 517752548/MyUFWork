using UnityEngine;

namespace BetaFramework
{
    public class PlatformUtil
    {
        public static void Init()
        {
            PlatformEvents.Init();
        }

        public static bool GetNetReachAble()
        {
#if UNITY_EDITOR
            return true;
#elif UNITY_IOS
            return PlatformIOS.IosNetReachAble();
#elif UNITY_ANDROID
            return PlatformAndroid.IsNetEnable();
#else
            return false;
#endif
        }

        public static string GetIDFA()
        {
#if UNITY_EDITOR
            return "fotoableTestIDFA_daguoDaguo3";
#elif UNITY_IOS
            return PlatformIOS.GetIDFA();
#elif UNITY_ANDROID
            return PlatformAndroid.GetAndroidId();
#else
            return "fotoableTestIDFA";
#endif
        }

        public static string GetBIIDFA()
        {
#if UNITY_EDITOR
            return "GetBIIDFA";
#elif UNITY_IOS
            return PlatformIOS.GetIDFA();
#elif UNITY_ANDROID
            return PlatformAndroid.GetAndroidUUID();
#else
            return "GetBIIDFA";
#endif
        }

        public static string GetDeviceId()
        {
#if UNITY_EDITOR
            return "fotoableTestDevice" + SystemInfo.deviceUniqueIdentifier;
#elif UNITY_IOS
            return PlatformIOS.GetIDFA();
#elif UNITY_ANDROID
            string androidId = PlatformAndroid.GetAndroidId();
            if (string.IsNullOrEmpty(androidId) || androidId.Equals("00000000"))
                androidId = SystemInfo.deviceUniqueIdentifier;
            return androidId;
#else
            return "fotoableTestDevice";
#endif
        }

        public static string GetAdId()
        {
#if UNITY_EDITOR
            return "fotoableTestIDFA";
#elif UNITY_IOS
            return PlatformIOS.GetIDFA();
#elif UNITY_ANDROID
            return PlatformAndroid.GetAdvertisingId();
#else
            return "fotoableTestIDFA";
#endif
        }

        public static string GetMobileNetworkOperator()
        {
#if UNITY_EDITOR
            return "editor";
#elif UNITY_IOS
            return PlatformIOS.IosGetAppCar();
#elif UNITY_ANDROID
            //return PlatformAndroid.GetMobileNetworkOperator();
            return "";//安卓确认不需要这个字段，需要单独的权限
#else
            return "unknown";
#endif
        }

        public static int GetVersionCode()
        {
#if UNITY_EDITOR
            return GameSetting.BuildVersion;
#elif UNITY_IOS
            return PlatformIOS.GetIosBuildVersion();
#elif UNITY_ANDROID
            return PlatformAndroid.GetVersionCode();
#else
		    return 0;
#endif
        }

        public static string GetVersionName()
        {
#if UNITY_EDITOR
            return "0.0.0";
#elif UNITY_IOS
            return PlatformIOS.GetIosVersion();
#elif UNITY_ANDROID
            return PlatformAndroid.GetVersionName();
#else
		    return "";
#endif
        }

        public static bool GetAppIsRelease()
        {
#if UNITY_EDITOR
            return false;
#elif UNITY_IOS
            return PlatformIOS.GetAppIsRelease();
#elif UNITY_ANDROID
            return PlatformAndroid.AppIsRelease();
#else
            return true;
#endif
        }

        public static bool WordCheck(string word)
        {
#if UNITY_IOS
            return false; //PlatformIOS.WordCheck(word);
#else
            return false;
#endif
        }

        public static int GetNotificationBackId()
        {
#if UNITY_EDITOR
            return 0;
#elif UNITY_IOS
            return PlatformIOS.getNotificationTypeCallbacks();
#elif UNITY_ANDROID
            return PlatformAndroid.GetClickNotificationId();
#else
		    return 0;
#endif
        }

        public static void sendException(string name, string message)
        {
#if UNITY_EDITOR

#elif UNITY_IOS
        //TODO
#elif UNITY_ANDROID
            PlatformAndroid.SendException(name + " " + message);
#else
#endif
        }

        public static void ShareGamePicture(string text, string pic)
        {
#if UNITY_EDITOR

#elif UNITY_IOS
            PlatformIOS.ShareGamePicture(text, pic);
#elif UNITY_ANDROID
            PlatformAndroid.ShareGamePicture(text, pic);
#else
#endif
        }

        public static void SendEmail(string subject, string body, string to)
        {
#if UNITY_EDITOR

#elif UNITY_IOS
            PlatformIOS.SendEmail(subject, body, to);
#elif UNITY_ANDROID
            PlatformAndroid.SendEmail(subject, body, to);
#else
#endif
        }

        public static void RestartApplication()
        {
#if UNITY_EDITOR

#elif UNITY_IOS
#elif UNITY_ANDROID
            PlatformAndroid.RestartApplication();
#else
#endif
        }

        public static string GetNativeCountry()
        {
#if UNITY_EDITOR
            return "USD";
#elif UNITY_IOS
		    return PlatformIOS.GetCountryName();
#elif UNITY_ANDROID
            return PlatformAndroid.GetAndroidNativeCountry();
#else
            return "USD";
#endif
        }

        public static bool AppIsInstall(string urlScheme)
        {
#if UNITY_EDITOR
            return false;
#elif UNITY_IOS
            return PlatformIOS.AppIsInstall(urlScheme);
#elif UNITY_ANDROID
            return PlatformAndroid.IsApkInstalled(urlScheme);
#else
            return false;
#endif
        }

        public static void OpenAppStore(string url)
        {
#if UNITY_EDITOR

#elif UNITY_IOS
            PlatformIOS.OpenApp(url);
#elif UNITY_ANDROID
            //PlatformAndroid.RestartApplication();
#else
#endif
        }

        public static string GetProductName()
        {
#if UNITY_EDITOR
            return Application.productName;
#elif UNITY_IOS
            return PlatformIOS.AppName();
#elif UNITY_ANDROID
            return PlatformAndroid.GetAppLabel();
#else
            return Application.productName;
#endif
        }

        /// <summary>
        /// 0未开启 1开启 2未定
        /// </summary>
        /// <returns>The notification state.</returns>
        public static int GetNotificationState()
        {
#if UNITY_EDITOR
            return 1;
#elif UNITY_IOS
        return PlatformIOS.PushNotificationState();
#elif UNITY_ANDROID
        return PlatformAndroid.PushNotificationState();
 //        bool enable =
 // CallStaticMethodWithReturn(NotificationUtil, NotificationUtilClassName, "isNotificationEnabled", false, CurActivity);
 //        return enable ? 1 : 0;
#else
        return 0;
#endif
        }

        public static void RequestPushAuthentication()
        {
            
#if UNITY_EDITOR

#elif UNITY_IOS
        PlatformIOS.RequestPushAuthentication();
#elif UNITY_ANDROID
        //CallStaticMethod(NotificationUtil, NotificationUtilClassName, "requestPermission", CurActivity);
#else
#endif
        }
        
        public static void OpenSetting()
        {
#if UNITY_EDITOR

#elif UNITY_IOS
        PlatformIOS.OpenSetting();
#elif UNITY_ANDROID
        PlatformAndroid.OpenSetting();
#else
#endif
        }
        public static void StartListen()
        {
#if UNITY_IOS && !UNITY_EDITOR
            PlatformIOS.StartListen();
#endif
        }
        public static void StopListen()
        {
            Debug.LogError("StopListen");
#if UNITY_IOS && !UNITY_EDITOR
            PlatformIOS.StopListen();
#endif
        }
		public static void RequestVoicePermission() {
#if UNITY_IOS && !UNITY_EDITOR
            PlatformIOS.RequestVoicePermission();
#endif
        }
    }
}