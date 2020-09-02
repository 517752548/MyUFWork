using System;
using UnityEngine;

namespace BetaFramework
{
    public class PlatformAndroid
    {
#if UNITY_ANDROID
        private static readonly string m_PlatformUtilClassName = "com.wordgame.newcross.android.en.PlatformUtil";
        private static readonly string m_UNITY_PLAYER_CLASS_NAME = "com.unity3d.player.UnityPlayer";

        private static AndroidJavaObject _platformUtil = null;
        private static AndroidJavaObject PlatformUtil
        {
            get
            {
                if (_platformUtil == null)
                {
                    _platformUtil = new AndroidJavaClass(m_PlatformUtilClassName);
                }
                return _platformUtil;
            }
        }

        private static AndroidJavaObject _curActivity = null;
        private static AndroidJavaObject CurActivity
        {
            get
            {
                if (_curActivity == null)
                {
                    AndroidJavaClass jc = new AndroidJavaClass(m_UNITY_PLAYER_CLASS_NAME);
                    _curActivity = jc.GetStatic<AndroidJavaObject>("currentActivity");
                }
                return _curActivity;
            }
        }

        #region Call Method

        private static void CallMethod(AndroidJavaObject obj, string className, string method, params object[] args)
        {
            try
            {
                obj.Call(method, args);
            }
            catch (Exception e)
            {
                LogError("Not find " + method + " methord at " + className);
                LogException(e);
            }
        }

        private static void CallStaticMethod(AndroidJavaObject obj, string className, string method, params object[] args)
        {
            try
            {
                obj.CallStatic(method, args);
            }
            catch (System.Exception e)
            {
                LogError("Not find " + method + " static methord at " + className);
                LogException(e);
            }
        }

        private static T CallMethodWithReturn<T>(AndroidJavaObject obj, string className, string method, T defVal, params object[] args)
        {
            try
            {
                return obj.Call<T>(method, args);
            }
            catch (System.Exception e)
            {
                LogError("Not find " + method + " methord at " + className);
                LogException(e);
            }
            return defVal;
        }

        private static T CallStaticMethodWithReturn<T>(AndroidJavaObject obj, string className, string method, T defVal, params object[] args)
        {
            try
            {
                return obj.CallStatic<T>(method, args);
            }
            catch (System.Exception e)
            {
                LogError("Not find " + method + " static methord at " + className);
                LogException(e);
            }
            return defVal;
        }

        #endregion Call Method

        public static bool IsNetEnable()
        {
            return CallStaticMethodWithReturn(PlatformUtil, m_PlatformUtilClassName, "isNetEnable", false);
        }

        public static string GetImeiData()
        {
            return CallStaticMethodWithReturn(PlatformUtil, m_PlatformUtilClassName, "getImeiData", "");
        }

        public static int PushNotificationState()
        {
            bool open = CallStaticMethodWithReturn(PlatformUtil, m_PlatformUtilClassName, "isNotificationEnabled", true);

            return open ? 1 : 0;
        }

        public static string GetAndroidId()
        {
            return CallStaticMethodWithReturn(PlatformUtil, m_PlatformUtilClassName, "getAndroidID", "");
        }

        public static string GetAdvertisingId()
        {
            return CallStaticMethodWithReturn(PlatformUtil, m_PlatformUtilClassName, "getAdvertisingId", "");
        }

        public static string GetVersionName()
        {
            return Application.version;
            return CallStaticMethodWithReturn(PlatformUtil, m_PlatformUtilClassName, "getVersionName", "0.0.0");
        }

        public static int GetVersionCode()
        {
            return GameSetting.BuildVersion;
            return CallStaticMethodWithReturn(PlatformUtil, m_PlatformUtilClassName, "getVersionCode", 1);
        }

        public static string GetAppLabel()
        {
            return CallStaticMethodWithReturn(PlatformUtil, m_PlatformUtilClassName, "getAppLabel", "app");
        }

        public static bool AppIsRelease()
        {
            return !Debug.isDebugBuild;
            //return CallStaticMethodWithReturn(PlatformUtil, m_PlatformUtilClassName, "isBuildRelease", true);
        }

        public static int GetClickNotificationId()
        {
            return CallStaticMethodWithReturn(PlatformUtil, m_PlatformUtilClassName, "getClickNotificationId", 0);
        }

        public static void ShareGamePicture(string text, string pic)
        {
            CallStaticMethod(PlatformUtil, m_PlatformUtilClassName, "shareTextPicture", text, pic);
        }

        public static void SendEmail(string subject, string body, string to)
        {
            CallStaticMethod(PlatformUtil, m_PlatformUtilClassName, "sendEmail", subject, body, to);
        }

        public static void SendException(string ex)
        {
            CallStaticMethod(PlatformUtil, m_PlatformUtilClassName, "logException", ex);
        }

        public static void RestartApplication()
        {
            CallStaticMethod(PlatformUtil, m_PlatformUtilClassName, "restartApplication");
        }

        /// <summary>
        /// 获取运营商信息
        /// </summary>
        /// <returns></returns>
        public static string GetMobileNetworkOperator()
        {
            return CallStaticMethodWithReturn(PlatformUtil, m_PlatformUtilClassName, "getMobileNetworkOperator", "");
        }

        public static string GetAndroidUUID()
        {
            return CallStaticMethodWithReturn(PlatformUtil, m_PlatformUtilClassName, "getUniquePsuedoID", "");
        }
        public static string GetAndroidNativeCountry()
        {
            return CallStaticMethodWithReturn(PlatformUtil, m_PlatformUtilClassName, "getCountry", "");
        }

        public static bool IsApkInstalled(string packageName)
        {
            return CallStaticMethodWithReturn(PlatformUtil, m_PlatformUtilClassName, "isApkInstalled", true, packageName);
        }

        public static void OpenNotificationSetting()
        {
            CallStaticMethod(PlatformUtil, m_PlatformUtilClassName, "openNotificationSetting");
        }

        public static void OpenSetting()
        {
            CallStaticMethod(PlatformUtil, m_PlatformUtilClassName, "openSetting");
        }
        public static void CopyTextToClipboard(string id)
        {
            CallStaticMethod(PlatformUtil, m_PlatformUtilClassName, "CopyTextToClipboard", id);
        }

        public static void OpenWithGooglePlay()
        {
            CallStaticMethod(PlatformUtil, m_PlatformUtilClassName, "OpenWithGooglePlay");
        }
#endif

        private static void LogInfo(string info)
        {
            LoggerHelper.Log(info);
        }

        private static void LogError(string error)
        {
            LoggerHelper.Error(error);
        }

        private static void LogException(System.Exception e)
        {
            LoggerHelper.Exception(e);
        }
    }
}