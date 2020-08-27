using System;
using System.Collections.Generic;
using UnityEngine;

namespace BetaFramework
{
    public static class GameAnalyticsForAndroid
    {
#if UNITY_ANDROID
        private const string EventLogUtilClassName = "com.words.game.wordguess.EventLogUtil";
        private const string UNITY_PLAYER_CLASS_NAME = "com.unity3d.player.UnityPlayer";
        private const string UNITY_PLAYER_ACTIVITY_NAME = "currentActivity";

        private static AndroidJavaClass _analytics;
        private static AndroidJavaClass EventLogUtil
        {
            get
            {
                if (_analytics == null)
                {
                    _analytics = new AndroidJavaClass(EventLogUtilClassName);
                }
                return _analytics;
            }
        }

        private static AndroidJavaObject _curApplication = null;
        private static AndroidJavaObject CurApplication
        {
            get
            {
                if (_curApplication == null)
                {
                    try
                    {
                        AndroidJavaClass jc = new AndroidJavaClass(UNITY_PLAYER_CLASS_NAME);
                        AndroidJavaObject cls_Activity = jc.GetStatic<AndroidJavaObject>("currentActivity");
                        _curApplication = cls_Activity.Call<AndroidJavaObject>("getApplication");
                    }
                    catch (Exception e)
                    {
                        LogError("Get Current Android Application Failed!");
                        LogException(e);
                    }
                }
                return _curApplication;
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

        public static void LogEvent(string eventName)
        {
            CallStaticMethod(EventLogUtil, EventLogUtilClassName, "logEvent", CurApplication, eventName);
        }

        public static void LogEventWithParameters(string eventName, Dictionary<string, string> parameters)
        {
            using (var hashMap = ConvertDictionaryToJavaHashMap(parameters))
            {
                CallStaticMethod(EventLogUtil, EventLogUtilClassName, "logEvent", CurApplication, eventName, hashMap);
            }
        }

        public static void LogEvent(string eventName, int platform)
        {
            CallStaticMethod(EventLogUtil, EventLogUtilClassName, "logEvent", CurApplication, platform, eventName);
        }

        public static void LogEventWithParameters(string eventName, Dictionary<string, string> parameters, int platform)
        {
            using (var hashMap = ConvertDictionaryToJavaHashMap(parameters))
            {
                CallStaticMethod(EventLogUtil, EventLogUtilClassName, "logEvent", CurApplication, platform, eventName, hashMap);
            }
        }

        public static void FlurryLogPayment(string productName, string productId, int quantity, double price,
                                             string currency, string transactionId, Dictionary<string, string> parameters)
        {
            using (var hashMap = ConvertDictionaryToJavaHashMap(parameters))
            {
                CallStaticMethod(EventLogUtil, EventLogUtilClassName, "flurryLogPayment", productName, productId, quantity, price, currency, transactionId, hashMap);
            }
        }

        public static void FbLogPurchase(string purchaseAmount, string isoCurrencyCode)
        {
            CallStaticMethod(EventLogUtil, EventLogUtilClassName, "FBLogPurchase", CurApplication, purchaseAmount, isoCurrencyCode);
        }

        private static AndroidJavaObject ConvertDictionaryToJavaHashMap(Dictionary<string, string> parameters)
        {
            var hashMap = new AndroidJavaObject("java.util.HashMap");
            var put = AndroidJNIHelper.GetMethodID(hashMap.GetRawClass(), "put",
                                                   "(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;");

            foreach (var entry in parameters)
            {
                if (string.IsNullOrEmpty(entry.Key)) continue;
                using (var key = new AndroidJavaObject("java.lang.String", entry.Key))
                {
                    string val = entry.Value;
                    if (string.IsNullOrEmpty(entry.Value)) val = "null";
                    using (var value = new AndroidJavaObject("java.lang.String", val))
                    {
                        AndroidJNI.CallObjectMethod(hashMap.GetRawObject(), put,
                                                    AndroidJNIHelper.CreateJNIArgArray(new object[] { key, value }));
                    }
                }
            }

            return hashMap;
        }

        public static void LogException(System.Exception exception)
        {
            CallStaticMethod(EventLogUtil, EventLogUtilClassName, "logException", exception.ToString());
        }

#endif

        private static bool IsAndroidPlayer()
        {
            return Application.platform == RuntimePlatform.Android;
        }

        private static void LogInfo(string info)
        {
            BetaFramework.LoggerHelper.Log(info);
        }

        private static void LogError(string error)
        {
            BetaFramework.LoggerHelper.Error(error);
        }

        private static void LogExp(Exception e)
        {
            BetaFramework.LoggerHelper.Log(e);
        }
    }
}