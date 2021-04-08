//
// ApplicationKernel.cs
//

using UnityEngine;
using LuaFramework;
using DG.Tweening;
using UnityEngine.SceneManagement;
using System.IO;
using System.Collections;
using System;
using System.Collections.Generic;
using Gear;

public class ApplicationKernel : MonoBehaviour
{
    public string testScene = "";
    private static ApplicationLua appLua;
    private static ObjectPoolManager objPoolManager;
    private static GResManager resManager;
    public static string runtimeBuildVersion = "";

    public ApplicationKernel()
    {
    }

    public static ApplicationLua GetApplicationLua()
    {
        return appLua;
    }

    public static ObjectPoolManager GetObjectPoolManager()
    {
        return objPoolManager;
    }

    public static GResManager GetResManager()
    {
        return resManager;
    }

    public void InitApplicationLua()
    {
        ApplicationLua _appLua = gameObject.GetComponent<ApplicationLua>();
        if (_appLua != null)
        {
            appLua = _appLua;
        }
        else
        {
            appLua = gameObject.AddComponent<ApplicationLua>();
        }

        appLua.Init();
    }

    public void InitResManager()
    {
        resManager = gameObject.GetComponent<GResManager>();
        if (resManager == null)
        {
            resManager = gameObject.AddComponent<GResManager>();
        }
    }

    void Awake()
    {
        Debug.Log("ApplicationKernel:Awake");
        Screen.autorotateToPortrait = true;
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.autorotateToLandscapeLeft = false;
        Screen.autorotateToLandscapeRight = false;
        Screen.orientation = ScreenOrientation.Portrait;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.fullScreen = true;

        DontDestroyOnLoad(gameObject); //防止销毁自己
        DontDestroyOnLoad(GameObject.FindWithTag("MainCamera"));//主相机防止销毁
        
        TickRunner.GetInstance().Init(); //先启动Tick管理器,让加载管理器(GBaseLoader, GResManager)可以运行
        InitResManager();
        //SRDebug.Init();
        CheckExtractResource();
        SDKInit();
    }

    void SDKInit()
    {
        TDGA.Init();
    }

    /// <summary>
    /// 释放资源
    /// </summary>
    public void CheckExtractResource()
    {
        //编辑器模式下，直接启动游戏
        if (PlatformUtil.IsRunInEditor())
        {
            InitApplication();
            return;
        }

        string inBuildVersionFilePath = GFileManager.GetInstance().GetBuildVersionConfigStreamingAssetsPath();
        string outBuildVersionFilePath = GFileManager.GetInstance().GetBuildVersionConfigPersistentDataPath();
        Version inVersion = null;
        GTextLoader inBuildVersionLoader = new GTextLoader();
        inBuildVersionLoader.Url = inBuildVersionFilePath;
        inBuildVersionLoader.OnLoadComplete = delegate(GBaseLoader loader)
        {
            inVersion = new Version(inBuildVersionLoader.Text);
            runtimeBuildVersion = inVersion.ToString();
            if (Directory.Exists(Util.DataPath) == false)
            {
                OnExtractResource();
                return;
            }

            bool isExistsBuildVersionFile = File.Exists(outBuildVersionFilePath);
            if (isExistsBuildVersionFile == false)
            {
                Debug.Log("Can not find old buildversion.txt");
                OnExtractResource();
                return;
            }

            //检查版本号
            Version outVersion = null;
            GTextLoader outBuildVersionLoader = new GTextLoader();
            outBuildVersionLoader.Url = outBuildVersionFilePath;
            outBuildVersionLoader.OnLoadComplete = delegate(GBaseLoader l)
            {
                outVersion = new Version(outBuildVersionLoader.Text);
                if (inVersion != null && outVersion != null)
                {
                    if (outVersion.Minor != inVersion.Minor || outVersion.Revision < inVersion.Revision)
                    {
                        runtimeBuildVersion = inVersion.ToString();
                        Debug.Log("Has new buildversion : " + runtimeBuildVersion);
                        OnExtractResource();
                    }
                    else
                    {
                        runtimeBuildVersion = outVersion.ToString();
                        Debug.Log("None new buildversion : " + runtimeBuildVersion);
                        InitApplication();
                    }
                }
            };
            outBuildVersionLoader.Load();
        };
        inBuildVersionLoader.Load();
    }

    void OnExtractResource()
    {
        //进入到这个方法之后表示，是因为装了新包了，并且新包里的buildversion大于本地的,或者本地根本就没有（第一次安装进入游戏）

        string dataPath = Util.DataPath; //数据目录

        //没有DATAPATH目录就创建一个
        if (Directory.Exists(dataPath) == false)
            Directory.CreateDirectory(dataPath);

        string streamingPath_files_txt = GFileManager.GetInstance().GetBundlesInfoConfigStreamingAssetsPath();
        string dataPath_files_txt = GFileManager.GetInstance().GetBundlesInfoConfigPersistentDataPath();

        if (File.Exists(dataPath_files_txt))
        {
            //已经有files.txt在DataPath目录了
            CopyLuaFiles();
        }
        else
        {
            GFileManager.GetInstance().CopyFile(streamingPath_files_txt, dataPath, delegate() { CopyLuaFiles(); });
        }
    }

    void CopyLuaFiles()
    {
        string streamingPath = GResManager.GetInstance().GetAssetBundleStreamingAssetsPath();
        string dataPath = Util.DataPath;

        GFileManager.GetInstance().LoadBundlesInfo();
        List<string> copyFiles = new List<string>();
        //从安装包里复制lua文件过去
        GTextLoader loader = new GTextLoader();
        loader.Url = GFileManager.GetInstance().GetBundlesInfoConfigStreamingAssetsPath();
        loader.OnLoadComplete = delegate(GBaseLoader l)
        {
            string content = loader.Text;
            if (string.IsNullOrEmpty(content))
            {
                return;
            }

            string[] files = content.Split('\n');
            for (int i = 0; i < files.Length; i++)
            {
                string file = files[i];
                if (string.IsNullOrEmpty(file))
                    continue;
                GFileBundleInfo streamingFBI = new GFileBundleInfo();
                streamingFBI.Parse(file);
                string fileName = streamingFBI.name;
                bool isLuaFile = fileName.IndexOf("lua") >= 0 && fileName.IndexOf(".unity3d") >= 0;
                if (isLuaFile || fileName.Equals(GFileManager.FILENAME_BUNDLESTABLE_TXT) ||
                    fileName.Equals(GFileManager.FILENAME_BUILDVERSION_TXT))
                {
                    copyFiles.Add(Path.Combine(streamingPath, fileName));
                    //一边更新一遍将安装包的files合并到dataPath的files
                    streamingFBI.location = BundleStorageLocation.STORAGE;
                    GFileManager.GetInstance().UpdateStorageBundleInfo(streamingFBI);
                }
                else
                {
                    if (streamingFBI.location != BundleStorageLocation.CDN)
                    {
                        //新装的包里不是存在CDN上的内容 都用streaming里的 也就是包体里的，并且更新本地DataPath的files.txt与streaming中files.txt内容一致。并且删除DataPath下的旧资源
                        GFileManager.GetInstance().UpdateStorageBundleInfo(streamingFBI);
                        string path = Path.Combine(Util.DataPath, streamingFBI.name);
                        if (File.Exists(path)) File.Delete(path);
                    }
                }
            }

            //复制刚才那些要更新的文件到dataPath
            GFileManager.GetInstance().CopyFiles(copyFiles.ToArray(), dataPath, delegate()
            {
                //重新写入file.txt
                GFileManager.GetInstance().WriteBundlesInfoToFilesTxt();
                //释放完成，开始启动lua层面代码
                InitApplication();
            });
        };
        loader.Load();
    }

    public void InitApplication()
    {
        TexturePackerManager.GetInstance().Init();
        DOTween.Init();
        DOTween.defaultEaseType = Ease.Linear;

        GameObject m_GameManager = GameObject.Find("GameManager");
        objPoolManager = m_GameManager.AddComponent<ObjectPoolManager>();


        GFileManager.GetInstance().LoadBundlesInfo();
        GResManager.GetInstance().InitAppConfigJSON(delegate()
        {
            UIRoot uiRoot = GameObject.Find("UIRoot").GetComponent<UIRoot>();
            if (uiRoot != null)
            {
                //启动引导界面
                GameObject bootGO = Resources.Load("BootstrapPanel") as GameObject;
                GameObject bootInst = Instantiate(bootGO);
                BootstrapPanel bootPanel = bootInst.GetComponent<BootstrapPanel>();
                bootPanel.name = "BootstrapPanel";
                bootPanel.transform.SetParent(GameObject.Find("UIRoot/Canvas").transform, false);
                bootPanel.transform.localPosition = Vector3.zero;
                bootPanel.transform.localRotation = Quaternion.identity;
                bootPanel.transform.localScale = Vector3.one;
                bootPanel.onComplete = delegate()
                {
                    uiRoot.Init();
                    uiRoot.UpdateScreenSize(0, delegate()
                    {
                        StartLua();
                        bootPanel.HideAll();
                        bootGO = null;
                        Destroy(bootPanel.gameObject);
                    });
                };
                bootPanel.Boot();
            }
        });
    }

    public void StartLua()
    {
        InitApplicationLua();
        appLua.InitStart();
    }

    void Update()
    {
        TickRunner.GetInstance().Update();
    }

    void LateUpdate()
    {
        TickRunner.GetInstance().LateUpdate();
    }

    void OnApplicationQuit()
    {
        appLua.Close();
        GNetManager.GetInstance().Disconnect();
        Util.CallMethod("GameApp", "OnApplicationQuit");
    }
}