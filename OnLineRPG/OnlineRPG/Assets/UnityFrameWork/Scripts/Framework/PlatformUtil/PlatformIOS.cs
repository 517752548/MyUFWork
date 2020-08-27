using System.Runtime.InteropServices;
using UnityEngine;

namespace BetaFramework
{
    public class PlatformIOS
    {
#if UNITY_IOS
        private const string PluginName = "__Internal";

        [DllImport(PluginName)]
        private static extern bool uploadException(string name, string message);

        [DllImport(PluginName)]
        private static extern int getNotificationTypeCallback();

        [DllImport(PluginName)]
        private static extern int CFBuildVersion();

        [DllImport(PluginName)]
        private static extern string CFAppVersion();

        [DllImport(PluginName)]
        private static extern bool CFGetAppIsRelease();

        [DllImport(PluginName)]
        private static extern bool CFCanSearchWord(string word);

        [DllImport(PluginName)]
        private static extern string CFGetIDFA();

        [DllImport(PluginName)]
        private static extern bool CFNetWorkAvailable();

        [DllImport(PluginName)]
        private static extern void shareGamePic(string content, string pic);

        [DllImport(PluginName)]
        private static extern void sendEmail(string subject, string body, string to);

        [DllImport(PluginName)]
        private static extern string CFGetCountryName();

        [DllImport(PluginName)]
        private static extern void CFOpenApp(string url);

        [DllImport(PluginName)]
        private static extern string GetAppCar();

        [DllImport(PluginName)]
        private static extern bool CFAppIsInstall(string urlScheme);

        [DllImport(PluginName)]
        private static extern string CFGetAppName();

        [DllImport(PluginName)]
        private static extern int CFPushNotificationState();

        [DllImport(PluginName)]
        private static extern void CFRequestPushAuthentication();

        [DllImport(PluginName)]
        private static extern void CFOpenSetting();

        [DllImport(PluginName)]
        private static extern void CFStartListen();

        [DllImport(PluginName)]
        private static extern void CFStopListen();

        [DllImport(PluginName)]
        private static extern void CFRequestVoicePermission();

        [DllImport(PluginName)]
        private static extern void CopyTextToClipboard(string id);

        public static void RequestVoicePermission()
        {
            CFRequestVoicePermission();
        }

        public static void StartListen()
        {
            CFStartListen();
        }

        public static void StopListen()
        {
            CFStopListen();
        }

        public static bool IosNetReachAble()
        {
            return CFNetWorkAvailable();
        }

        public static int PushNotificationState()
        {
            return CFPushNotificationState();
        }

        public static void OpenSetting()
        {
            CFOpenSetting();
        }

        public static void RequestPushAuthentication()
        {
            CFRequestPushAuthentication();
        }

        public static string GetIDFA()
        {
            return CFGetIDFA();
        }

        public static int GetIosBuildVersion()
        {
            return CFBuildVersion();
        }

        public static string GetIosVersion()
        {
            return CFAppVersion() + "";
        }

        public static bool GetAppIsRelease()
        {
            return CFGetAppIsRelease();
        }

        /// <returns><c>true</c> if is iPhone player.</returns>
        private static bool IsIPhonePlayer()
        {
            return Application.platform == RuntimePlatform.IPhonePlayer;
        }

        private static void DebugLog(string log)
        {
            LoggerHelper.Log("[PlatformIOS]: " + log);
        }

        private static void DebugLogError(string error)
        {
            LoggerHelper.Log("[PlatformIOS]: " + error);
        }

        public static bool WordCheck(string word)
        {
            return CFCanSearchWord(word);
        }

        public static int getNotificationTypeCallbacks()
        {
            return getNotificationTypeCallback();
        }

        public static void UploadException(string name, string message)
        {
            uploadException(name, message);
        }

        public static void ShareGamePicture(string text, string pic)
        {
            shareGamePic(text, pic);
        }

        public static void SendEmail(string subject, string body, string to)
        {
            sendEmail(subject, body, to);
        }

        public static string GetCountryName()
        {
            return CFGetCountryName();
        }

        public static void OpenApp(string url)
        {
            CFOpenApp(url);
        }

        public static string IosGetAppCar()
        {
            return GetAppCar();
        }

        public static bool AppIsInstall(string urlScheme)
        {
            return CFAppIsInstall(urlScheme);
        }

        public static string AppName()
        {
            return CFGetAppName();
        }

        public static void CopyIDToClipBoard(string id)
        {
#if !UNITY_EDITOR
            CopyTextToClipboard(id);
#endif
        }
#endif
    }
}