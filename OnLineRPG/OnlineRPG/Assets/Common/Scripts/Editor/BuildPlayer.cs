using FastBundle.Editor;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.AddressableAssets.Settings;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEditor.Callbacks;
using UnityEngine;

namespace BettaFramework
{
    public class BuildPlayer : IPreprocessBuildWithReport, IPostprocessBuildWithReport
    {
        public static string germanBundleIdentifier = "com.fillword.cross.wordmind.de"; //德语包名
        public static string amazonBundleIdentifier = "com.crosswords.connect.sights.en"; //amazon包名
        public static string googleBundleIdentifier = "com.wordgame.newcross.android.en";
        public static string amazonStoreMenu = "Window/Unity IAP/Android/Target Amazon";
        public static string googlePlayStoreMenu = "Window/Unity IAP/Android/Target Google Play";

        public static string targetXcodePath = "/Users/Shared/Jenkins/Home/workspace/WordCrossyIos"; //正式工程编译出目录

        #region Auto Set Version

        //[DidReloadScripts]
        static void AutoSetVersion()
        {
            PlayerSettings.bundleVersion = Const.Version;
        }

        #endregion

        #region IOrderedCallback implementation

        public int callbackOrder
        {
            get { return 0; }
        }
        public void OnPreprocessBuild(BuildReport report)
        {
            Debug.Log("~~~~~~~~~~~~~~~~~~~~开始打包~~~~~~~~~~~~~~~~~~~~~~~~");
            AutoSetVersion();
        }
        public void OnPostprocessBuild(BuildReport report)
        {
            if (report.summary.platform == BuildTarget.iOS)
            {
                Debug.Log("~~~~~~~~~~~~~~~~~~~~打包成功~~~~~~~~~~~~~~~~~~~~~~~~");

                Debug.Log("~~~~~~~~~~~~~~~~~~~~开始复制打包脚本~~~~~~~~~~~~~~~~~~~~~~~~");

                DirectoryInfo directory = new DirectoryInfo(Application.dataPath);
                string outpath = directory.Parent + "/IosProject/PPAutoPackageScript";
                string srcPath = directory + "/PPAutoPackageScript";

                CopyAndReplaceDirectory(srcPath, outpath);

                Debug.Log("~~~~~~~~~~~~~~~~~~~~成功复制打包脚本~~~~~~~~~~~~~~~~~~~~~~~~");
            }
        }
        #endregion

        static string[] GetBuildScenes()
        {
            List<string> names = new List<string>();
            foreach (EditorBuildSettingsScene e in EditorBuildSettings.scenes)
            {
                if (e == null)
                    continue;
                if (e.enabled)
                    names.Add(e.path);
            }

            return names.ToArray();
        }

        static void BuildBundle()
        {
            AddressablesBundleBuildScript.AddFileToAddressables();
            AddressableAssetSettings.BuildPlayerContent();
        }

        [MenuItem("Build/Export Android Player")]
        static void ExportAndroidPlayer()
        {
            // keystore 路径, ./user.keystore
            PlayerSettings.Android.keystoreName = "./wordcraze.jks";
            // one.keystore 密码
            PlayerSettings.Android.keystorePass = "123456";

            // one.keystore 别名
            PlayerSettings.Android.keyaliasName = "craze";
            // 别名密码
            PlayerSettings.Android.keyaliasPass = "123456";
            var argsDic = new Dictionary<string, string>();
            var args = Environment.GetCommandLineArgs();
            foreach (var arg in args)
            {
                var kv = arg.Split('=');
                if (kv.Length == 2)
                {
                    argsDic.Add(kv[0], kv[1]);
                }
            }
            //修改配置
            //修改配置
            PlayerSettings.applicationIdentifier = googleBundleIdentifier;
            //PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, "NEW_VERSION;");
            EditorApplication.ExecuteMenuItem(googlePlayStoreMenu);
            DirectoryInfo directory = new DirectoryInfo(Application.dataPath);
            var ext = "apk";
            if (argsDic.ContainsKey("Format"))
            {
                ext = argsDic["Format"];
            }
            string outpath = directory.Parent + "/build/WordCraze." + ext;
            EditorUserBuildSettings.androidBuildSystem = AndroidBuildSystem.Gradle;
            EditorUserBuildSettings.buildAppBundle = false;
            if (ext == "aab")
            {
                EditorUserBuildSettings.buildAppBundle = true;
            }
            if (argsDic.ContainsKey("BuildBundle") && bool.Parse(argsDic["BuildBundle"]))
            {
                BuildBundle();
            }
            var option = BuildOptions.None;
            EditorUserBuildSettings.androidBuildType = AndroidBuildType.Release;
            if (argsDic.ContainsKey("Config") && argsDic["Config"] == "Debug")
            {
                option = BuildOptions.Development;
                EditorUserBuildSettings.androidBuildType = AndroidBuildType.Debug;
            }
            PlayerSettings.SplashScreen.showUnityLogo = false;
            BuildPipeline.BuildPlayer(GetBuildScenes(), outpath, BuildTarget.Android, option);
        }


        [MenuItem("Build/Export Android Profile")]
        static void ExportAndroidProfile()
        {
            //修改配置
            PlayerSettings.applicationIdentifier = googleBundleIdentifier;
            EditorApplication.ExecuteMenuItem(googlePlayStoreMenu);
            PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, "NEW_VERSION;CONVERT");

            AssetDatabase.Refresh();


            DirectoryInfo directory = new DirectoryInfo(Application.dataPath);
            string outpath = directory.Parent + "/AndroidProject";
            EditorUserBuildSettings.androidBuildSystem = AndroidBuildSystem.Gradle;
            EditorUserBuildSettings.androidBuildType = AndroidBuildType.Debug;
            EditorUserBuildSettings.development = true;
            EditorUserBuildSettings.connectProfiler = true;

            BuildPipeline.BuildPlayer(GetBuildScenes(), outpath, BuildTarget.Android,
                BuildOptions.AcceptExternalModificationsToPlayer);
        }

        [MenuItem("Build/Export Amazon Player")]
        static void ExportAmazonPlayer()
        {
            //修改配置
            PlayerSettings.applicationIdentifier = amazonBundleIdentifier;
            PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android,
                "NEW_VERSION;WordCrossy;UNITY_AMAZON");
            EditorApplication.ExecuteMenuItem(amazonStoreMenu);


            AssetDatabase.Refresh();

            DirectoryInfo directory = new DirectoryInfo(Application.dataPath);
            string outpath = directory.Parent + "/AndroidProject";
            EditorUserBuildSettings.androidBuildSystem = AndroidBuildSystem.Gradle;
            EditorUserBuildSettings.androidBuildType = AndroidBuildType.Release;

            BuildPipeline.BuildPlayer(GetBuildScenes(), outpath, BuildTarget.Android,
                BuildOptions.AcceptExternalModificationsToPlayer);
        }

        [MenuItem("Build/Export DE Android Player")]
        static void ExportDeAndroidPlayer()
        {
            //修改配置
            PlayerSettings.applicationIdentifier = germanBundleIdentifier;
            PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, "NEW_VERSION;WordCrossyDE");
            EditorApplication.ExecuteMenuItem(googlePlayStoreMenu);

            AssetDatabase.Refresh();

            DirectoryInfo directory = new DirectoryInfo(Application.dataPath);
            string outpath = directory.Parent + "/AndroidProject";
            EditorUserBuildSettings.androidBuildSystem = AndroidBuildSystem.Gradle;
            EditorUserBuildSettings.androidBuildType = AndroidBuildType.Release;

            BuildPipeline.BuildPlayer(GetBuildScenes(), outpath, BuildTarget.Android,
                BuildOptions.AcceptExternalModificationsToPlayer);
        }

        [MenuItem("Build/Export DE Android Profile")]
        static void ExportDeAndroidProfile()
        {
            //修改配置
            PlayerSettings.applicationIdentifier = germanBundleIdentifier;
            PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, "NEW_VERSION;WordCrossyDE");
            EditorApplication.ExecuteMenuItem(googlePlayStoreMenu);

            AssetDatabase.Refresh();

            DirectoryInfo directory = new DirectoryInfo(Application.dataPath);
            string outpath = directory.Parent + "/AndroidProject";
            EditorUserBuildSettings.androidBuildSystem = AndroidBuildSystem.Gradle;
            EditorUserBuildSettings.androidBuildType = AndroidBuildType.Debug;
            EditorUserBuildSettings.development = true;
            EditorUserBuildSettings.connectProfiler = true;

            BuildPipeline.BuildPlayer(GetBuildScenes(), outpath, BuildTarget.Android,
                BuildOptions.AcceptExternalModificationsToPlayer);
        }

        [MenuItem("Build/Build IOS Player")]
        static void BuildIOSPlayer()
        {
            Debug.Log("~~~~~~~~~~~~~~~~~~~~准备打包~~~~~~~~~~~~~~~~~~~~~~~~");
            PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.iOS, "NEW_VERSION;CONVERT");
            FrameworkMenuTool.AddressablesFileSelect();
            Debug.Log("~~~~~~~~~~~~~~~~~~~~打bundle~~~~~~~~~~~~~~~~~~~~~~~~");
            AddressablesBundleBuildScript.BuildBundle();
            //修改配置


            AssetDatabase.Refresh();

            DirectoryInfo directory = new DirectoryInfo(Application.dataPath);
            string outpath = directory.Parent + "/IosProject";

            EditorUserBuildSettings.iOSBuildConfigType = iOSBuildType.Release;
            EditorUserBuildSettings.symlinkLibraries = false;

            EditorUserBuildSettings.development = false;
            EditorUserBuildSettings.connectProfiler = false;
            EditorUserBuildSettings.allowDebugging = false;

            BuildOptions option = EditorUserBuildSettings.development ? BuildOptions.Development : BuildOptions.None;


            Debug.Log("~~~~~~~~~~~~~~~~~~~~开始打包~~~~~~~~~~~~~~~~~~~~~~~~");
            BuildPipeline.BuildPlayer(GetBuildScenes(), outpath, BuildTarget.iOS, option);
        }

        [MenuItem("Build/Build IOS Player UnBundle")]
        static void BuildIosPlayer()
        {
            BuildIOSPlayerNBBundle("");
        }
        [MenuItem("Build/Build Debug IOS Player ReleaseServer")]
        static void BuildIosDebugWithReleaseServerPlayer()
        {
            BuildIOSPlayerNBBundle("DebugInReleaseServer");
        }
        static void BuildIOSPlayerNBBundle(string defines)
        {
            Debug.Log("~~~~~~~~~~~~~~~~~~~~准备打包~~~~~~~~~~~~~~~~~~~~~~~~");
            PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.iOS, defines);
            Debug.Log("~~~~~~~~~~~~~~~~~~~~打bundle~~~~~~~~~~~~~~~~~~~~~~~~");
            //修改配置


            AssetDatabase.Refresh();

            DirectoryInfo directory = new DirectoryInfo(Application.dataPath);
            string outpath = directory.Parent + "/IosProject";
            try
            {
                Directory.Delete(string.Format("{0}/Data/Raw/aa", outpath), true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            EditorUserBuildSettings.iOSBuildConfigType = iOSBuildType.Release;
            EditorUserBuildSettings.symlinkLibraries = false;

            EditorUserBuildSettings.development = false;
            EditorUserBuildSettings.connectProfiler = false;
            EditorUserBuildSettings.allowDebugging = false;

            PlayerSettings.SplashScreen.showUnityLogo = false;

            BuildOptions option = EditorUserBuildSettings.development ? BuildOptions.Development : BuildOptions.None;


            Debug.Log("~~~~~~~~~~~~~~~~~~~~开始打包~~~~~~~~~~~~~~~~~~~~~~~~");
            BuildPipeline.BuildPlayer(GetBuildScenes(), outpath, BuildTarget.iOS, option);
        }

        [MenuItem("Build/Build IOS Player UnBundle Profiler")]
        static void BuildIOSPlayerNBBundleProfiler()
        {
            Debug.Log("~~~~~~~~~~~~~~~~~~~~准备打包~~~~~~~~~~~~~~~~~~~~~~~~");
            PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.iOS, "");
            Debug.Log("~~~~~~~~~~~~~~~~~~~~打bundle~~~~~~~~~~~~~~~~~~~~~~~~");
            //修改配置


            AssetDatabase.Refresh();

            DirectoryInfo directory = new DirectoryInfo(Application.dataPath);
            string outpath = directory.Parent + "/IosProject";
            try
            {
                Directory.Delete(string.Format("{0}/Data/Raw/aa", outpath), true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            EditorUserBuildSettings.iOSBuildConfigType = iOSBuildType.Release;
            EditorUserBuildSettings.symlinkLibraries = false;

            EditorUserBuildSettings.development = true;
            EditorUserBuildSettings.connectProfiler = true;
            EditorUserBuildSettings.allowDebugging = true;

            BuildOptions option = EditorUserBuildSettings.development ? BuildOptions.Development : BuildOptions.None;


            Debug.Log("~~~~~~~~~~~~~~~~~~~~开始打包~~~~~~~~~~~~~~~~~~~~~~~~");
            BuildPipeline.BuildPlayer(GetBuildScenes(), outpath, BuildTarget.iOS, option);
        }
        [MenuItem("Build/Build IOS Player Profiler")]
        static void BuildIOSPlayerProfiler()
        {
            Debug.Log("~~~~~~~~~~~~~~~~~~~~准备打包~~~~~~~~~~~~~~~~~~~~~~~~");

            //修改配置
            PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.iOS, "NEW_VERSION;CONVERT");

            AssetDatabase.Refresh();

            DirectoryInfo directory = new DirectoryInfo(Application.dataPath);
            string outpath = directory.Parent + "/IosProject";
            EditorUserBuildSettings.iOSBuildConfigType = iOSBuildType.Debug;
            EditorUserBuildSettings.symlinkLibraries = true;

            EditorUserBuildSettings.development = true;
            EditorUserBuildSettings.connectProfiler = true;
            EditorUserBuildSettings.allowDebugging = true;

            BuildOptions option = EditorUserBuildSettings.development ? BuildOptions.Development : BuildOptions.None;


            Debug.Log("~~~~~~~~~~~~~~~~~~~~开始打包~~~~~~~~~~~~~~~~~~~~~~~~");
            BuildPipeline.BuildPlayer(GetBuildScenes(), outpath, BuildTarget.iOS, option);
        }


        public static void DelectDir(string srcPath)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(srcPath);
                FileSystemInfo[] fileinfo = dir.GetFileSystemInfos(); //返回目录中所有文件和子目录
                foreach (FileSystemInfo i in fileinfo)
                {
                    if (i is DirectoryInfo) //判断是否文件夹
                    {
                        DirectoryInfo subdir = new DirectoryInfo(i.FullName);
                        subdir.Delete(true); //删除子目录和文件
                    }
                    else
                    {
                        File.Delete(i.FullName); //删除指定文件
                    }
                }
            }
            catch (Exception ex)
            {
                BetaFramework.LoggerHelper.Exception(ex);
            }
        }

        public static void MoveToDirectory(string from, string to)
        {
            try
            {
                if (Directory.Exists(to))
                {
                    DelectDir(to);
                    Directory.Delete(to);
                }

                Directory.Move(from, to);
            }
            catch (Exception ex)
            {
                BetaFramework.LoggerHelper.Exception(ex);
            }
        }

        internal static void CopyAndReplaceDirectory(string srcPath, string dstPath)
        {
            if (Directory.Exists(dstPath))
                Directory.Delete(dstPath);
            if (File.Exists(dstPath))
                File.Delete(dstPath);

            Directory.CreateDirectory(dstPath);

            foreach (var file in Directory.GetFiles(srcPath))
                File.Copy(file, Path.Combine(dstPath, Path.GetFileName(file)));

            foreach (var dir in Directory.GetDirectories(srcPath))
                CopyAndReplaceDirectory(dir, Path.Combine(dstPath, Path.GetFileName(dir)));
        }
    }
}