using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;

namespace BetaFramework
{
    public static class GameAnalyticsForIOS
    {
#if UNITY_IOS

        [DllImport("__Internal")]
        private static extern void logEvent(string eventName);

        [DllImport("__Internal")]
        private static extern void logEventWithParameters(string eventName, string parameters);

        [DllImport("__Internal")]
        private static extern void fabridLogEvent(string eventName);

        [DllImport("__Internal")]
        private static extern void fabricLogEventWithParameters(string eventName, string parameters);

        //[DllImport("__Internal")]
        //private static extern void fabridLogException(string eventName);

        [DllImport("__Internal")]
        private static extern void fbLogEvent(string eventName);

        [DllImport("__Internal")]
        private static extern void fbLogEventWithParameters(string eventName, string parameters);

        [DllImport("__Internal")]
        private static extern void fbLogPurchase(string purchaseAmount, string isoCurrencyCode);

#endif

        public static void LogEvent(string eventName)
        {
#if UNITY_IOS
            DebugLog("Log event: " + eventName);

            if (!IsIPhonePlayer())
            {
                return;
            }
            logEvent(eventName);
#endif
        }

        public static void LogEventWithParameters(string eventName, Dictionary<string, string> parameters)
        {
#if UNITY_IOS
            DebugLog("Log event: " + eventName);

            if (!IsIPhonePlayer())
            {
                return;
            }
            BetaFramework.LoggerHelper.Log(ConvertParameters(parameters));
            logEventWithParameters(eventName, ConvertParameters(parameters));

#endif
        }

        public static void LogEvent_fabric(string eventName)
        {
#if UNITY_IOS
            DebugLog("Log event: " + eventName);

            if (!IsIPhonePlayer())
            {
                return;
            }
            fabridLogEvent(eventName);
#endif
        }

        public static void LogEventWithParameters_fabric(string eventName, Dictionary<string, string> parameters)
        {
#if UNITY_IOS
            DebugLog("Log event: " + eventName);

            if (!IsIPhonePlayer())
            {
                return;
            }
            BetaFramework.LoggerHelper.Log(ConvertParameters(parameters));
            fabricLogEventWithParameters(eventName, ConvertParameters(parameters));

#endif
        }

        /// <summary>
        /// Converts the parameters to json.
        /// </summary>
        private static string ConvertParameters(Dictionary<string, string> parameters)
        {
            if (parameters == null)
            {
                return null;
            }
            StringBuilder builder = new StringBuilder();
            builder.Append("{\n");
            if (builder == null)
            {
                return null;
            }
            var first = true;
            foreach (var pair in parameters)
            {
                if (!first)
                {
                    builder.Append(',');
                }

                SerializeString(builder, pair.Key);
                builder.Append(":");
                SerializeString(builder, pair.Value);

                first = false;
            }

            builder.Append("}\n");
            return builder.ToString();
        }

        /// <summary>
        /// Serialize string to json string.
        /// </summary>
        private static void SerializeString(StringBuilder builder, string str)
        {
            builder.Append('\"');

            var charArray = str.ToCharArray();
            foreach (var c in charArray)
            {
                switch (c)
                {
                    case '"':
                        builder.Append("\\\"");
                        break;

                    case '\\':
                        builder.Append("\\\\");
                        break;

                    case '\b':
                        builder.Append("\\b");
                        break;

                    case '\f':
                        builder.Append("\\f");
                        break;

                    case '\n':
                        builder.Append("\\n");
                        break;

                    case '\r':
                        builder.Append("\\r");
                        break;

                    case '\t':
                        builder.Append("\\t");
                        break;

                    default:
                        var codepoint = System.Convert.ToInt32(c);
                        if ((codepoint >= 32) && (codepoint <= 126))
                        {
                            builder.Append(c);
                        }
                        else
                        {
                            builder.Append("\\u" + System.Convert.ToString(codepoint, 16).PadLeft(4, '0'));
                        }
                        break;
                }
            }

            builder.Append('\"');
        }

        public static void LogException(System.Exception exception)
        {
#if UNITY_IOS
            DebugLog("Log event: " + exception.Message);

            if (!IsIPhonePlayer())
            {
                return;
            }
            //fabricLogException(exception.ToString());
#endif
        }

        public static void FbLogPurchase(string purchaseAmount, string isoCurrencyCode)
        {
#if UNITY_IOS
            if (!IsIPhonePlayer())
            {
                return;
            }
            fbLogPurchase(purchaseAmount, isoCurrencyCode);
#endif
        }

        /// <returns><c>true</c> if is iPhone player.</returns>
        private static bool IsIPhonePlayer()
        {
            return Application.platform == RuntimePlatform.IPhonePlayer;
        }

        private static void DebugLog(string log)
        {
#if UNITY_EDITOR
            BetaFramework.LoggerHelper.Log("[GameAnalyticsPlugin]: " + log);
#endif
        }

        private static void DebugLogError(string error)
        {
#if UNITY_EDITOR
            BetaFramework.LoggerHelper.Log("[GameAnalyticsPlugin]: " + error);
#endif
        }
    }
}