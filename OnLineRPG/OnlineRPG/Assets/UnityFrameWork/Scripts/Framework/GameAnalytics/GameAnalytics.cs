using Newtonsoft.Json;
using System.Collections.Generic;

namespace BetaFramework
{
    public static class GameAnalytics
    {
        public const int P_All = 0x11111111;
        public const int P_Fabric = 0x00000001;
        public const int P_Firebase = 0x00000010;
        public const int P_Flurry = 0x00000100;
        public const int P_Facebook = 0x00001000;
        public const int P_Appsflyer = 0x00010000;

        public static void LogEvent(string eventName)
        {
#if UNITY_EDITOR

#elif UNITY_IOS
        GameAnalyticsForIOS.LogEvent(eventName);
#elif UNITY_ANDROID
        GameAnalyticsForAndroid.LogEvent(eventName);
#endif
        }

        public static void LogEventWithParameters(string eventName, Dictionary<string, string> parameters)
        {
#if UNITY_EDITOR

#elif UNITY_IOS
        GameAnalyticsForIOS.LogEventWithParameters(eventName, parameters);
#elif UNITY_ANDROID
        GameAnalyticsForAndroid.LogEventWithParameters(eventName, parameters);
#endif
            LoggerHelper.Log("eventName: " + eventName + JsonConvert.SerializeObject(parameters));
        }

        public static void fabricLogEvent(string eventName)
        {
#if UNITY_EDITOR

#elif UNITY_IOS
        GameAnalyticsForIOS.LogEvent_fabric(eventName);
#elif UNITY_ANDROID
        GameAnalyticsForAndroid.LogEvent(eventName, P_Fabric);
#endif
        }

        public static void fabricLogEventWithParameters(string eventName, Dictionary<string, string> parameters)
        {
#if UNITY_EDITOR

#elif UNITY_IOS
        GameAnalyticsForIOS.LogEventWithParameters_fabric(eventName, parameters);
#elif UNITY_ANDROID
        GameAnalyticsForAndroid.LogEventWithParameters(eventName, parameters,P_Fabric);
#endif
        }

        public static void LogPartEvent(string eventName)
        {
#if UNITY_EDITOR

#elif UNITY_IOS
        GameAnalyticsForIOS.LogEvent(eventName);
#elif UNITY_ANDROID
        GameAnalyticsForAndroid.LogEvent(eventName, P_Facebook | P_Flurry | P_Fabric);
#endif
        }

        public static void LogPartEvent(string eventName, Dictionary<string, string> parameters)
        {
#if UNITY_EDITOR

#elif UNITY_IOS
        GameAnalyticsForIOS.LogEventWithParameters(eventName, parameters);
#elif UNITY_ANDROID
        GameAnalyticsForAndroid.LogEventWithParameters(eventName, parameters, P_Facebook | P_Flurry | P_Fabric);
#endif
        }

        public static void LogFirebaseAFEvent(string eventName)
        {
#if UNITY_EDITOR

#elif UNITY_IOS
        GameAnalyticsForIOS.LogEvent(eventName);
#elif UNITY_ANDROID
        GameAnalyticsForAndroid.LogEvent(eventName, P_Firebase | P_Appsflyer);
#endif
        }

        public static void LogFirebaseAFEvent(string eventName, Dictionary<string, string> parameters)
        {
#if UNITY_EDITOR

#elif UNITY_IOS
        GameAnalyticsForIOS.LogEventWithParameters(eventName, parameters);
#elif UNITY_ANDROID
        GameAnalyticsForAndroid.LogEventWithParameters(eventName, parameters, P_Firebase | P_Appsflyer);
#endif
        }

        public static void FlurryLogPayment(string productName,
                                             string productId,
                                             int quantity,
                                             double price,
                                             string currency,
                                             string transactionId,
                                             Dictionary<string, string> parameters)
        {
#if UNITY_EDITOR

#elif UNITY_IOS
        //GameAnalyticsForIOS.LogEventWithParameters_fabric(eventName, parameters);
#elif UNITY_ANDROID
        GameAnalyticsForAndroid.FlurryLogPayment(productName,
                                                 productId,
                                                 quantity,
                                                 price,
                                                 currency,
                                                 transactionId,
                                                 parameters);
#endif
        }

        public static void FbLogPurchase(string purchaseAmount, string isoCurrencyCode)
        {
#if UNITY_EDITOR

#elif UNITY_IOS
        GameAnalyticsForIOS.FbLogPurchase(purchaseAmount, isoCurrencyCode);
#elif UNITY_ANDROID
        GameAnalyticsForAndroid.FbLogPurchase(purchaseAmount, isoCurrencyCode);
#endif
        }

        public static void LogException(System.Exception exception)
        {
#if UNITY_EDITOR

#elif UNITY_IOS
        GameAnalyticsForIOS.LogException(exception);
#elif UNITY_ANDROID
        GameAnalyticsForAndroid.LogException(exception);
#endif
        }
    }
}