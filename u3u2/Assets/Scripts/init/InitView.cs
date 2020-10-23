using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

namespace init
{
    enum LoadingStep
    {
        None,
        LoadClientConfig,
        LoadServerList,
        LoadServerCfg,
        LoadServerVersionCfg,
        LoadLocalVersionCfg,
        CheckApp,
        //CheckScripts,
        CheckAssets,
        CheckDB,
        LoadScripts,
        AllDone
    }
    /// <summary>
    /// 游戏启动时 加载界面，包含游戏启动时的加载流程
    /// </summary>
    public class InitView : MonoBehaviour
    {
        public GameObject[] m_hideobjs;
        public GameObject defaultImage;
        public GameObject uiContainer;
        public Image loginday;
        public Image loginnight;
        //选择服务器列表
        public SelectServerUI selectServerUI;
        public Button selectedBtn;
        public GameObject progressBarContainer;
        public Transform progressBar;
        public int progressMinX;
        public int progressMaxX;
        public Text progressLabel;
        public Text appVerLabel;
        public Text userLoginTips;
        public string selectedServerId;
        public AssetsDownloadConfirmWnd assetsDownloaderConfirmWnd;
        public Button retryBtn;
		public Button showLoginBtn;
        //////游戏公告Start
        public GameObject gameNoticeUI;
        public Text noticeContent;
        public Button closeNoticeBtn;
        private string gameNoticeURL = "";
        //////游戏公告End
        
        /// <summary>
        /// log开关
        /// </summary>
        private bool switchLog = true;

        private static int MaxRetryCount = 3;

        private LoadingStep step = LoadingStep.None;
        private int retryCount;

        private AssetsDownloader downloader = null;

        private Array mLoadingSteps = null;
        private int mLoadingStepsCount = 0;

        private List<string[]> mArtsToDownload = null;
        private int mArtsToDownloadCount = 0;
        private int mDownloadingArtsZipIdx = 0;

        private string mLocalInVerCfg = null;
        private string mLocalInBaseVer = null;
        private string mLocalExtVerCfg = null;
        private string mLocalExtBaseVer = null;
        private string mlocalExtAssetsVer = null;

        private string mServerCfg = null;

        private bool mIsLocalVerCfgForceInAppPath = false;
        /// <summary>
        /// 当前是否通过审核
        /// </summary>
        private string passAppIds = "";
        private bool IsPassedCheck { get; set; }

        //private string mServerAssetsConfigUrl = null;
        //private string mServerAssetsDownloadUrlBase = null;
        /*
        private string mServerAppVer = null;
        private string mServerAssetsVer = null;
        private string mLocalAppVer = null;
        private string mLocalAssetsVer = null;
        private string mLocalDBMd5 = null;
        */
        public void Awake()
        {
            
            //Application.targetFrameRate = 30;
            mLoadingSteps = Enum.GetValues(typeof(LoadingStep));
            mLoadingStepsCount = mLoadingSteps.Length - 1;
            selectedBtn.onClick.AddListener(OnServerSelected);
            retryBtn.onClick.AddListener(RetryStep);
            if (GameObject.Find("accountSwitched") == null)
            {
                BuglyAgent.ConfigDebugMode(true);
				BuglyAgent.ConfigDefault ("Bugly", null, "ronnie", 0);
                //BuglyAgent.ConfigAutoQuitApplication(false);
                //BuglyAgent.RegisterLogCallback(null);

				#if UNITY_IPHONE || UNITY_IOS
				BuglyAgent.InitWithAppId("900039544");	
				#elif UNITY_ANDROID
				BuglyAgent.InitWithAppId("900011735");
				#endif

				BuglyAgent.EnableExceptionHandler ();

                SDKManager.ins.Init();
            }
			showLoginBtn.onClick.AddListener (showLoginAgain);
        }

        public void Start()
        {
            for (int i = 0; i < m_hideobjs.Length; ++i)
            {
                m_hideobjs[i].SetActive(false);
            }
            userLoginTips.gameObject.SetActive(false);
            retryBtn.gameObject.SetActive(false);
            updateStep(LoadingStep.LoadClientConfig);
            //StartCoroutine(LoadClientConfig());
            LoadLocalVersionCfg(true);
            //根据日夜设置登录背景
            SetLoginAlpha();
        }

        private void SetLoginAlpha()
        {
            DateTime dt = DateTime.Now;
            //dt.TimeOfDay.TotalDays 0-1表示00:00到24：00
            int MinAlpha = 0;
            int MaxAlpha = 255;
            //早晨天完全亮的时间
            int MorningStartTime = 8;
            //晚上开始的时间
            int NightStartTime = 7;
            //前半夜的开始(0.8到1)
            float FrontNightStart = (NightStartTime + 12f) / 24f;
            //后半夜的结束(0到0.3)
            float BackNightEnd = MorningStartTime*1f/24f;
            string s=dt.TimeOfDay.TotalDays.ToString("f2");
            float f = float.Parse(s);
            Color c = loginday.color;
            if (f>=FrontNightStart)
            {
                float passCel = (f - FrontNightStart)/(1f - FrontNightStart);
                c.a = (MaxAlpha - (MaxAlpha - MinAlpha) * passCel) / 255;
                loginnight.gameObject.SetActive(true);
            }
            else if (f <= BackNightEnd)
            {
                float passCel = (f)/(BackNightEnd);
                c.a = (MinAlpha + (MaxAlpha - MinAlpha) * passCel) / 255;
                loginnight.gameObject.SetActive(true);
            }
            else
            {
                c.a = 1f;
                loginnight.gameObject.SetActive(false);
            }
            loginday.color = c;
        }

        private void LoadLocalVersionCfg(bool forceInAppPackPath)
        {
            mIsLocalVerCfgForceInAppPath = forceInAppPackPath;
            updateStep(LoadingStep.LoadLocalVersionCfg);
            StartCoroutine(StartLoadLocalVersionCfg(forceInAppPackPath));
        }

        private IEnumerator StartLoadLocalVersionCfg(bool forceInAppPackPath)
        {
            string localExtAssetsVerCfgPath = GetFinalPath("config/versionConfig.xml", forceInAppPackPath);
			Debug.Log ("bbb" + localExtAssetsVerCfgPath);
            if (switchLog) { Debug.Log("load localAssetsVer from:" + localExtAssetsVerCfgPath); }
            WWW www = new WWW(localExtAssetsVerCfgPath);
            yield return www;
            if (www.isDone && string.IsNullOrEmpty(www.error))
            {
                LocalVersionConfig.Ins.ParseConfig(www.text);
                if (forceInAppPackPath)
                {
                    mLocalInVerCfg = www.text;
                    mLocalInBaseVer = LocalVersionConfig.Ins.GetBaseVersion();
                    LoadLocalVersionCfg(false);
                }
                else
                {
                    mLocalExtVerCfg = www.text;
                    mLocalExtBaseVer = LocalVersionConfig.Ins.GetBaseVersion();
                    mlocalExtAssetsVer = LocalVersionConfig.Ins.GetAssetsVersion();
                    //CheckAppVer();
                    StartCoroutine(LoadClientConfig());
                }

                appVerLabel.text = "版本号：" + LocalVersionConfig.Ins.GetAppVersion();
            }
            else
            {
                if (retryCount < MaxRetryCount)
                {
                    LoadLocalVersionCfg(forceInAppPackPath);
                }
                else
                {
                    //TODO:加载失败
                    progressLabel.text = "加载客户端版本信息失败!\n" + www.error;
                    PrepareRetry();
                }
            }
            www.Dispose();
            www.Dispose();
        }
        
        private IEnumerator LoadClientConfig()
        {
            WWW www = new WWW(GetClientConfigPath());
            yield return www;
            if (www.isDone && string.IsNullOrEmpty(www.error))
            {
                ClientConfig.Ins.ParseConfig(www.text);
                defaultImage.SetActive(false);
                uiContainer.SetActive(true);
                selectServerUI.gameObject.SetActive(false);
                progressBarContainer.SetActive(true);
                LoadServerList();
            }
            else
            {
                //TODO:加载客户端配置失败。
                if (switchLog) { Debug.LogError("下载客户端配置失败:" + www.error); }
                progressLabel.text = "加载客户端配置失败!\n" + www.error;
                PrepareRetry();
            }
            www.Dispose();
        }

        private IEnumerator LoadGameNoticeText()
        {
            if (string.IsNullOrEmpty(gameNoticeURL))
            {
                yield return 1;
            }
            gameNoticeUI.gameObject.SetActive(false);
            WWW noticeWWW = new WWW(gameNoticeURL);
            if (switchLog) { Debug.Log("load notice file  from:" + noticeWWW.url); }
            yield return noticeWWW;
            if (noticeWWW.isDone && string.IsNullOrEmpty(noticeWWW.error) && !string.IsNullOrEmpty(noticeWWW.text))
            {
                if (transform.gameObject.activeInHierarchy)
                {
                    string realText = noticeWWW.text.Trim();
                    if (!string.IsNullOrEmpty(realText))
                    {
                        gameNoticeUI.gameObject.SetActive(true);
                        noticeContent.text= noticeWWW.text;
                        closeNoticeBtn.onClick.AddListener(closeNotice);
                    }
                }
            }
        }

        private void closeNotice()
        {
            closeNoticeBtn.onClick.RemoveAllListeners();
            gameNoticeUI.gameObject.SetActive(false);
        }

        private void LoadServerList()
        {
            updateStep(LoadingStep.LoadServerList);
            StartCoroutine(StartLoadServerList());
        }

        private IEnumerator StartLoadServerList()
        {
            EventTriggerListener.Get(appVerLabel.gameObject).onClick = clickVersionText;
            WWW www = new WWW(GetServerListURL());
            if (switchLog) { Debug.Log("load serverList from:" + www.url); }
            yield return www;
            if (www.isDone && string.IsNullOrEmpty(www.error))
            {
                if (switchLog) { Debug.Log("serverList:" + www.text); }
                XElement root = XElement.Parse(www.text);
                //游戏公告
                XElement noticeurl = root.Element("gamenoticeurl");
                gameNoticeURL = noticeurl != null ? noticeurl.Value : "";
                #if !UNITY_EDITOR&&UNITY_IOS
                //检测是否过审
                XElement passappids = root.Element("passAppIds");
                passAppIds = passappids != null ? passappids.Value : null;
                List<string> passList = (passAppIds != null && !string.IsNullOrEmpty(passAppIds)) ? passAppIds.Split(',').ToList() : null;
                string myappid = PlatForm.Instance.GetAppID();
                ClientLog.LogWarning("PlatForm.Instance.GetAppID()获取到的appid："+myappid);
                if ((passList != null && passList.Contains(myappid))||init.ClientConfig.Ins.debug)
                {//过审
                    CreateServerList(root.Element("serverurl").Elements("url"));
                    IsPassedCheck = true;
                }
                else
                {//没过审
                    CreateServerList(root.Element("noPassServerurl").Elements("url"));
                    IsPassedCheck = false;
                }
                #else
                CreateServerList(root.Element("serverurl").Elements("url"));
                IsPassedCheck = true;
                #endif
                //加载并显示游戏公告
                if (noticeurl != null && IsPassedCheck)
                {
                    StartCoroutine(LoadGameNoticeText());
                }
            }
            else
            {
                if (retryCount < MaxRetryCount)
                {
                    LoadServerList();
                }
                else
                {
                    //TODO:加载失败。
                    progressLabel.text = "下载服务器列表失败!\n" + www.error;
                    PrepareRetry();
                }
            }
            www.Dispose();
        }

        private string GetServerListURL()
        {
            if (ClientConfig.Ins.debug)
            {
                return GetFinalPath("config/debug/serverList.xml", true);
            }
            return ClientConfig.Ins.serverListUrl + "?timestamp=" + Time.realtimeSinceStartup;
        }

        private void CreateServerList(IEnumerable<XElement> serverList)
        {
            selectServerUI.gameObject.SetActive(true);
            selectServerUI.setData(serverList,this);
            progressBarContainer.SetActive(false);
        }

        public void OnServerSelected()
        {
            closeNotice();
            if (selectServerUI.SelectedServerItem == null || string.IsNullOrEmpty(selectServerUI.SelectedServerId))
            {
                return;
            }
            SaveSelectedServer();
            selectServerUI.gameObject.SetActive(false);
            progressBarContainer.SetActive(true);
            LoadServerConfig();
        }

        private void SaveSelectedServer()
        {
            ServerItem xelem = selectServerUI.SelectedServerItem;
            try
            {
                StreamWriter ws = File.CreateText(GetPathViaPlatform(VerifyAssets.ins.extFilesRoot + "/defaultServer.xml"));
                ws.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                ws.WriteLine("<config>");
                ws.WriteLine(xelem.elem.ToString());
                ws.WriteLine("</config>");
                ws.Flush();
                ws.Close();
                ws.Dispose();
            }
            catch (Exception e)
            {
                if (switchLog) { Debug.LogError(e.Message); }
                progressLabel.text = "保存默认服务器到本地失败!\n" + e.Message;
            }
        }

        public int GetDefaultServerId()
        {
            if (File.Exists(GetPathViaPlatform(VerifyAssets.ins.extFilesRoot + "/defaultServer.xml")))
            {
                string str = File.ReadAllText(GetPathViaPlatform(VerifyAssets.ins.extFilesRoot + "/defaultServer.xml"));
                if (switchLog) { Debug.Log("DefaultServer:\n" + str); }
                XElement root = XElement.Parse(str);
                string serverid = root.Element("url").Attribute("serverid").Value;
                return int.Parse(serverid);
            }
            return 0;
        }

        private void LoadServerConfig()
        {
            updateStep(LoadingStep.LoadServerCfg);
            StartCoroutine(StartLoadServerConfig());
        }

        private IEnumerator StartLoadServerConfig()
        {
            WWW www = new WWW(GetServerConfigURL());
            if (switchLog) { Debug.Log(www.url); }
            yield return www;
            if (www.isDone && string.IsNullOrEmpty(www.error))
            {
                updatePgBar(1, null);
                mServerCfg = www.text;
                ServerConfig.instance.ParseConfig(www.text);

                if (ClientConfig.Ins.debug)
                {
                    if (SaveServerConfig())
                    {
                        CheckDB();
                    }
                    else
                    {
                        PrepareRetry();
                    }
                }
                else
                {
                    //CheckAppVer();
                    LoadServerVersionCfg();
                }
            }
            else
            {
                if (switchLog) { Debug.Log(www.error); }
                if (retryCount < MaxRetryCount)
                {
                    LoadServerConfig();
                }
                else
                {
                    //TODO:加载失败。
                    progressLabel.text = "下载服务器配置失败!\n" + www.error;
                    PrepareRetry();
                }
            }

            www.Dispose();
        }

        private string GetServerBaseURL()
        {
            if (ClientConfig.Ins.debug)
            {
                return "config/debug/" + selectServerUI.SelectedServerItem.domain;
            }
            return "http://" + selectServerUI.SelectedServerItem.domain;
        }

        private string GetServerConfigURL()
        {
            if (ClientConfig.Ins.debug)
            {
                return GetFinalPath(GetServerBaseURL() + "/config.xml", true);
            }
            return GetServerBaseURL() + "/config.xml" + "?timestamp=" + Time.realtimeSinceStartup;
        }

        private string GetServerVersionConfigURL()
        {
			return GetServerBaseURL() + "/" + ClientConfig.Ins.platform + "/config.php?f="+init.SDKManager.ins.getSource()+"&v="+LocalVersionConfig.Ins.GetAppVersion()+"&timestamp=" + Time.realtimeSinceStartup;
        }

        private void LoadServerVersionCfg()
        {
            updateStep(LoadingStep.LoadServerVersionCfg);
            StartCoroutine(StartLoadServerVersionCfg());
        }

        private IEnumerator StartLoadServerVersionCfg()
        {
            //mServerAssetsConfigUrl = string.Format(ServerConfig.instance.assetsConfigUrl, (ClientConfig.Ins.platform + "/" + ServerConfig.instance.appVersion)) + "?timestamp=" + Time.realtimeSinceStartup;
            //mServerAssetsDownloadUrlBase = string.Format(ServerConfig.instance.assetsDownloadUrlBase, (ClientConfig.Ins.platform + "/" + ServerConfig.instance.appVersion));
            WWW www = new WWW(GetServerVersionConfigURL());
            if (switchLog) { Debug.Log("load serverAssetsVer from:" + www.url); }
            yield return www;
            if (www.isDone && string.IsNullOrEmpty(www.error))
            {
                ServerVersionConfig.Ins.ParseConfig(www.text);
                //LoadLocalVersionCfg(true);
                CheckAppVer();
            }
            else
            {
                if (retryCount < MaxRetryCount)
                {
                    LoadServerVersionCfg();
                }
                else
                {
                    //TODO:加载失败
                    progressLabel.text = "下载服务器版本信息失败!\n" + www.error;
                    PrepareRetry();
                }
            }
            www.Dispose();
        }

        private void CheckAppVer()
        {
            updateStep(LoadingStep.CheckApp);
            //if (switchLog) { Debug.LogWarning("最新App版本：" + ServerConfig.instance.appVersion + "  本地App版本：" + ClientConfig.Ins.appVersion); }
            if (!IsPassedCheck || (mLocalInBaseVer != mLocalExtBaseVer || int.Parse(mlocalExtAssetsVer) > int.Parse(ServerVersionConfig.Ins.assetsVersion)))
            {
                string extAssetsDir = GetPathViaPlatform(VerifyAssets.ins.extFilesRoot + "/Assets");
                string extAssetsDownloadedDir = GetPathViaPlatform(VerifyAssets.ins.extFilesRoot + "/AssetsDownloaded");
                if (Directory.Exists(extAssetsDir))
                {
                    Directory.Delete(extAssetsDir, true);
                }
                if (Directory.Exists(extAssetsDownloadedDir))
                {
                    Directory.Delete(extAssetsDownloadedDir, true);
                }

                LocalVersionConfig.Ins.ParseConfig(mLocalInVerCfg);
            }

            //appVerLabel.text = "版本号：" + LocalVersionConfig.Ins.GetAppVersion();

            string localBaseVer = LocalVersionConfig.Ins.GetBaseVersion();
            string serverBaseVer = ServerVersionConfig.Ins.baseVersion;
			if (ServerVersionConfig.Ins.needforceupdate) {
				progressLabel.text = "请下载最新版客户端安装包!"+ServerVersionConfig.Ins.forceupdateurl;

                string localDir = null;
                string localName = null;
                string url = null;
//                localDir = VerifyAssets.ins.extAssetsDownloadedDir;
				localDir  = init.SDKManager.ins.getDownloadAPKURL();
                localName = "tianshu.apk";
				Debug.Log(localDir);
                url = ServerVersionConfig.Ins.forceupdateurl;
                if (downloader == null)
                {
                    downloader = new AssetsDownloader();
                }
                downloader.Download(localDir, localName, url);
				return ;
			}
//			Debug.Log ("aaaa" + LocalVersionConfig.Ins.GetAppVersion()	);
//            if (IsPassedCheck && CompareBaseVer(localBaseVer, serverBaseVer) == 1)
//            {
//                progressLabel.text = "请下载最新版客户端安装包!";
//                return;
//            }

            //LoadServerAssetsVerCfg();
            //CheckScriptsVer();
            if (SaveServerConfig())
            {
                CheckArtsVer();
            }
            else
            {
                PrepareRetry();
            }
        }

        /**
         * 比较主版本号（3位）的大小，a大返回－1，b大返回1，相等返回0。
         */
        private int CompareBaseVer(string a, string b)
        {
            string[] aStrArr = a.Split(new char[] { '.' });
            string[] bStrArr = a.Split(new char[] { '.' });
            int[] aIntArr = new int[3];
            int[] bIntArr = new int[3];

            aIntArr[0] = int.Parse(aStrArr[0]);
            aIntArr[1] = int.Parse(aStrArr[1]);
            aIntArr[2] = int.Parse(aStrArr[2]);

            bIntArr[0] = int.Parse(bStrArr[0]);
            bIntArr[1] = int.Parse(bStrArr[1]);
            bIntArr[2] = int.Parse(bStrArr[2]);

            int aInt = aIntArr[0] * 100000 + aIntArr[1] * 10000 + aIntArr[2] * 1000;
            int bInt = bIntArr[0] * 100000 + bIntArr[1] * 10000 + bIntArr[2] * 1000;

            if (aInt > bInt)
            {
                return -1;
            }

            if (aInt < bInt)
            {
                return 1;
            }

            return 0;
        }

        private bool SaveServerConfig()
        {
            try
            {
                if (!Directory.Exists(GetPathViaPlatform(VerifyAssets.ins.extFilesRoot + "/Assets")))
                {
                    Directory.CreateDirectory(GetPathViaPlatform(VerifyAssets.ins.extFilesRoot + "/Assets"));
                }

                if (!Directory.Exists(GetPathViaPlatform(VerifyAssets.ins.extFilesRoot + "/Assets/config")))
                {
                    Directory.CreateDirectory(GetPathViaPlatform(VerifyAssets.ins.extFilesRoot + "/Assets/config"));
                }

                XElement root = XElement.Parse(mServerCfg);
                XAttribute canpay = selectServerUI.SelectedServerItem.canpay;
                XElement canPayElem = new XElement("can_pay", "0");
                if (canpay != null)
                {
                    canPayElem.SetValue(canpay.Value);
                }
                root.Add(canPayElem);

                XElement IsPassedCheckElem = new XElement("IsPassedCheck", "0");
                IsPassedCheckElem.SetValue(IsPassedCheck?1:0);
                root.Add(IsPassedCheckElem);

                StreamWriter ws = File.CreateText(GetPathViaPlatform(VerifyAssets.ins.extFilesRoot + "/Assets/config/serverconfig.xml"));
                ws.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                char[] chrs = root.ToString().ToCharArray();
                ws.Write(chrs);
                ws.Flush();
                ws.Close();
                ws.Dispose();
                return true;

            }
            catch (Exception e)
            {
                if (switchLog) { Debug.LogError(e.Message); }
                progressLabel.text = "保存服务器配置到本地失败!\n" + e.Message;
                return false;
            }
        }

        /*
        private void CheckScriptsVer()
        {
            updateStep(LoadingStep.CheckScripts);
            if (switchLog) { Debug.Log("ServerAssetsVersionConfig.Ins.scriptsMD5:" + ServerVersionConfig.Ins.scriptsMD5 + "  LocalAssetsVersionConfig.Ins.GetScriptsMD5()" + LocalVersionConfig.Ins.GetScriptsMD5()); }
            if (!ClientConfig.Ins.externalScripts || ServerVersionConfig.Ins.scriptsMD5 == LocalVersionConfig.Ins.GetScriptsMD5())
            {
                CheckArtsVer();
            }
            else
            {
                LoadAssets();
            }
        }
        */

        private void CheckArtsVer()
        {
            updateStep(LoadingStep.CheckAssets);
            if (IsPassedCheck && ClientConfig.Ins.externalArts)
            {
                mArtsToDownload = VerifyAssets.ins.GetArtsToDownload();
                mArtsToDownloadCount = mArtsToDownload.Count;
                mDownloadingArtsZipIdx = 0;
                if (mArtsToDownloadCount == 0)
                {
                    CheckDB();
                }
                else
                {
                    if (Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
                    {
                        LoadAssets();
                    }
                    else
                    {
                        assetsDownloaderConfirmWnd.Show(mArtsToDownload, LoadAssets);
                    }
                }
            }
            else
            {
                CheckDB();
            }
        }

        private void CheckDB()
        {
            updateStep(LoadingStep.CheckDB);
            // 获取到服务器配置后，检查本地的配置文件
            if (switchLog) { Debug.Log("ServerAssetsVersionConfig.Ins.dbMD5:" + ServerVersionConfig.Ins.dbMD5); }
            if (ClientConfig.Ins.debug)
            {
                LoadAssets();
            }
            else
            {
                if (!File.Exists(VerifyAssets.ins.finalDbFilePath) || LocalVersionConfig.Ins.GetDBMD5() != ServerVersionConfig.Ins.dbMD5)
                {//需要 更新数据文件
                    if (switchLog) { Debug.LogWarning("now loadingDbFile!!!!!!!"); }
                    LoadAssets();
                }
                else
                {
                    if (switchLog) { Debug.LogWarning("donot need loadingDbFile!!!!!!!"); }
                    {
                        LoadScripts();
                    }
                }
            }
        }

        private string GetDBDownloadURL()
        {
            if (ClientConfig.Ins.debug)
            {
                return ServerConfig.instance.assetsConfigUrl;
            }
            return ServerVersionConfig.Ins.dbUrl;
        }

        private void LoadAssets()
        {
			Debug.Log ("now loadAssets");
            string localDir = null;
            string localName = null;
            string url = null;
            if (step == LoadingStep.CheckDB)
            {
                if (VerifyAssets.isLocalDB)
                {
                    OnLoadAssetsComplete();
                }
                else
                {
                    localDir = VerifyAssets.ins.extAssetsDownloadedDir;
                    localName = VerifyAssets.ins.dbZipFileName;
                    url = GetDBDownloadURL();
                    if (downloader == null)
                    {
                        downloader = new AssetsDownloader();
                    }
                    downloader.Download(localDir, localName, url);
                }
            }
            else
            {
                if (downloader == null)
                {
                    downloader = new AssetsDownloader();
                }
                /*
                if (step == LoadingStep.CheckScripts)
                {
                    localDir = VerifyAssets.EXTERNAL_ASSETS_DOWNLOADED_DIR;
                    localName = "Scripts.zip";
                    url = mServerAssetsDownloadUrlBase + "scripts/Scripts.zip";
                    downloader.Download(localDir, localName, url);
                }
                else */
                if (step == LoadingStep.CheckAssets)
                {
                    localDir = VerifyAssets.ins.extAssetsDownloadedDir;
                    localName = mArtsToDownload[mDownloadingArtsZipIdx][1];
					url = ServerVersionConfig.Ins.assetsDownloadUrlBase + localName ;
                    downloader.Download(localDir, localName, url);
                }
            }
        }

        private void OnLoadAssetsUpdate()
        {
            if (downloader != null && !downloader.error)
            {
                updatePgBar(GetAssetsLoadPer(), "正在下载  " + downloader.downloadingFileName + " [" + (downloader.curLen / 1024) + "KB/" + (downloader.totalLen / 1024) + "KB]");
            }
        }

        private void OnLoadAssetsComplete()
        {
            bool flag = false;
            
            if (this.step == LoadingStep.CheckApp)
            {
                updatePgBar(1, "正在解压安装包");
                string localApkPath = VerifyAssets.ins.extAssetsDownloadedDir+"tianshu.apk";
				SDKManager.ins.installAPK("tianshu.apk");
                return;
            }
            
            if (this.step == LoadingStep.CheckAssets)
            {
                updatePgBar(1, "正在解压" + mArtsToDownload[mDownloadingArtsZipIdx][1]);
                flag = VerifyAssets.ins.UnZipAssets(mArtsToDownload[mDownloadingArtsZipIdx][1], mArtsToDownload[mDownloadingArtsZipIdx][2]);
                if (!flag)
                {
                    updatePgBar(1, "解压" + mArtsToDownload[mDownloadingArtsZipIdx][1] + "失败!\n" + VerifyAssets.ins.error);
                }
            }
            else if (this.step == LoadingStep.CheckDB)
            {
                updatePgBar(1, "正在解压" + VerifyAssets.ins.dbZipFileName);
                flag = VerifyAssets.ins.unZipDbFile();
                if (!flag)
                {
                    updatePgBar(1, "解压" + VerifyAssets.ins.dbZipFileName + "失败!\n" + VerifyAssets.ins.error);
                }
            }

            if (flag)
            {
                /*
                if (this.step == LoadingStep.CheckScripts)
                {
                    LocalVersionConfig.Ins.SetScriptsMD5(ServerVersionConfig.Ins.scriptsMD5);
                    CheckArtsVer();
                }
                else */
                if (this.step == LoadingStep.CheckAssets)
                {
                    LocalVersionConfig.Ins.SetAppVersion(mArtsToDownload[mDownloadingArtsZipIdx][0]);
                    mDownloadingArtsZipIdx++;
                    if (mDownloadingArtsZipIdx == mArtsToDownloadCount)
                    {
                        appVerLabel.text = LocalVersionConfig.Ins.GetAppVersion();
                        CheckDB();
                    }
                    else
                    {
                        LoadAssets();
                    }
                }
                else if (this.step == LoadingStep.CheckDB)
                {
                    if (!ClientConfig.Ins.debug)
                    {
                        LocalVersionConfig.Ins.SetDBMD5(ServerVersionConfig.Ins.dbMD5);
                    }
                    LoadScripts();
                }
            }
            else
            {
                if (retryCount < MaxRetryCount)
                {
                    if (switchLog) { Debug.LogWarning("retry LoadAssets " + retryCount); }
                    LoadAssets();
                    retryCount++;
                }
                else
                {
                    PrepareRetry();
                }
            }
        }

        private void LoadScripts()
        {
            updateStep(LoadingStep.LoadScripts);
            GameObject scriptsRoot = GameObject.Find("ScriptsRoot");
            if (scriptsRoot == null)
            {
                scriptsRoot = new GameObject("ScriptsRoot");
            }

            if (!ClientConfig.Ins.debug && ClientConfig.Ins.externalScripts)
            {
                StartCoroutine(StartLoadScripts());
            }
            else
            {
                Component gameClient = scriptsRoot.AddComponent(Type.GetType("app.main.GameClient"));
                InitGameClient(gameClient);
                updateStep(LoadingStep.AllDone);
            }
        }

        private IEnumerator StartLoadScripts()
        {
            string scriptsPath = GetLocalExtScriptsPath();
            WWW www = new WWW(scriptsPath);
            Debug.LogWarning("scriptsUrl:" + scriptsPath);
            yield return www;
            if (www.isDone && string.IsNullOrEmpty(www.error))
            {
                updatePgBar(1, null);
                Assembly asb = Assembly.Load(www.bytes);
                Type[] types = asb.GetTypes();

                Component gameClient = GameObject.Find("ScriptsRoot").AddComponent(asb.GetType("app.main.GameClient"));
                InitGameClient(gameClient);
                updateStep(LoadingStep.AllDone);
            }
            else
            {
                if (retryCount < MaxRetryCount)
                {
                    LoadScripts();
                }
                else
                {
                    PrepareRetry();
                }
            }
            www.Dispose();
        }

        private void InitGameClient(Component gameClient)
        {
            Type gameClientType = gameClient.GetType();
            object serverSelecter = Convert.ChangeType(selectServerUI.gameObject, gameClientType.GetProperty("initViewServerSelecter").PropertyType);
            gameClientType.GetProperty("initViewServerSelecter").SetValue(gameClient, serverSelecter, null);
            object pgBar = Convert.ChangeType(progressBar.gameObject, gameClientType.GetProperty("initViewProgressBar").PropertyType);
            gameClientType.GetProperty("initViewProgressBar").SetValue(gameClient, pgBar, null);
            object pgBarLabel = Convert.ChangeType(progressLabel.gameObject, gameClientType.GetProperty("initViewProgressBarLabel").PropertyType);
            gameClientType.GetProperty("initViewProgressBarLabel").SetValue(gameClient, pgBarLabel, null);
            string sdk = null;
#if WINGLOONG
            sdk = "WINGLOONG";
#elif ANYSDK
            sdk = "ANYSDK";
#endif
            object sdkObj = Convert.ChangeType(sdk, gameClientType.GetProperty("sdk").PropertyType);
            gameClientType.GetProperty("sdk").SetValue(gameClient, sdkObj, null);
            //object loginTips = Convert.ChangeType(userLoginTips.gameObject, gameClientType.GetProperty("initViewLoginTips").PropertyType);
            //gameClientType.GetProperty("initViewLoginTips").SetValue(gameClient, loginTips, null);
        }

        public float GetAssetsLoadPer()
        {
            if (downloader != null)
            {
                if (downloader.totalLen == 0)
                {
                    return 0;
                }
                return (float)downloader.curLen / (float)downloader.totalLen;
            }
            return 0;
        }

        public void updatePgBar(float f, string tips)
        {
            float pBarWidth = progressMaxX - progressMinX;
            /*
            float normalPartWidth = (pBarWidth * 0.7f * 0.3f) / (mLoadingStepsCount);
            float assetsPartWidth = pBarWidth * 0.7f * 0.7f;
            float initGamePartWidth = pBarWidth * 0.3f;
            */
            float normalPartWidth = (pBarWidth * 1.0f * 0.3f) / (mLoadingStepsCount - 1);
            float assetsPartWidth = pBarWidth * 1.0f * 0.7f;
            float initGamePartWidth = pBarWidth * 0.0f;
            
            float passedWidth = 0;
            int idx = 0;
            for (int i = 0; i <= mLoadingStepsCount; i++)
            {
                if ((int)step == (int)mLoadingSteps.GetValue(i))
                {
                    idx = i;
                    break;
                }
                else
                {
                    if (i == (int)LoadingStep.CheckAssets)
                    {
                        passedWidth += assetsPartWidth;
                    }
                    else
                    {
                        passedWidth += normalPartWidth;
                    }
                }
            }

            float x = 0;

            if (idx == (int)LoadingStep.CheckAssets)
            {
                if (mArtsToDownloadCount == 0)
                {
                    x = progressMinX + passedWidth + assetsPartWidth * f;
                }
                else
                {
                    float temp = (assetsPartWidth / (float)mArtsToDownloadCount) * mDownloadingArtsZipIdx;
                    x = progressMinX + passedWidth + temp + (assetsPartWidth / (float)mArtsToDownloadCount) * f;
                }
            }
            else
            {
                if (idx == (int)LoadingStep.AllDone)
                {
                    x = progressMinX + passedWidth + initGamePartWidth * f;
                }
                else
                {
                    x = progressMinX + passedWidth + normalPartWidth * f;
                }
            }
            progressBar.localPosition = new Vector3(x, 0, 0);
            if (tips != null)
            {
                progressLabel.text = tips;
            }
        }

        private void updateStep(LoadingStep step)
        {
            if (this.step != step)
            {
                if (switchLog) { Debug.LogWarning("updateStep:" + step); }
                this.step = step;
                retryCount = 0;
                if (switchLog) { Debug.LogWarning("now checkAllComplete !!!!!!!"); }
                //updatePgBar(0, "");
                if (this.step == LoadingStep.LoadClientConfig)
                {
                    updatePgBar(0, "加载客户端配置");
                }
                else if (this.step == LoadingStep.LoadServerList)
                {
                    updatePgBar(0, "加载服务器列表");
                }
                else if (this.step == LoadingStep.LoadServerCfg)
                {
                    updatePgBar(0, "加载服务器配置");
                }
                else if (this.step == LoadingStep.CheckApp)
                {
                    updatePgBar(0, "检查程序版本");
                }
                else if (this.step == LoadingStep.CheckAssets)
                {
                    updatePgBar(0, "更新美术素材");
                }
                /*
                else if (this.step == LoadingStep.CheckScripts)
                {
                    updatePgBar(0, "更新脚本");
                }
                */
                else if (this.step == LoadingStep.CheckDB)
                {
                    updatePgBar(0, "更新数据库");
                }
                else if (this.step == LoadingStep.LoadScripts)
                {
                    updatePgBar(0, "初始化游戏");
                }
                else if (this.step == LoadingStep.AllDone)
                {
                    downloader = null;
                    updatePgBar(0, "初始化游戏");
                    EventTriggerListener.Get(appVerLabel.gameObject).onClick = null;
                    //关闭游戏公告
                    closeNotice();
                }
            }
            else
            {
                retryCount++;
                if (switchLog) { Debug.LogWarning("retryStep:" + step); }
            }
        }

        private void PrepareRetry()
        {
            retryBtn.gameObject.SetActive(true);
        }

		private void showLoginAgain(){
			SDKManager.ins.ShowLogin (null);
		}
        private void RetryStep()
        {
            retryCount = 0;
            retryBtn.gameObject.SetActive(false);
            switch (this.step)
            {
                case LoadingStep.LoadClientConfig:
                    StartCoroutine(LoadClientConfig());
                    break;
                case LoadingStep.LoadServerList:
                    StartCoroutine(StartLoadServerList());
                    break;
                case LoadingStep.LoadServerCfg:
                    StartCoroutine(StartLoadServerConfig());
                    break;
                case LoadingStep.LoadServerVersionCfg:
                    StartCoroutine(StartLoadServerVersionCfg());
                    break;
                case LoadingStep.LoadLocalVersionCfg:
                    StartCoroutine(StartLoadLocalVersionCfg(mIsLocalVerCfgForceInAppPath));
                    break;
                case LoadingStep.CheckApp:
                    CheckAppVer();
                    break;
                case LoadingStep.CheckAssets:
                    LoadAssets();
                    break;
                case LoadingStep.CheckDB:
                    LoadAssets();
                    break;
                case LoadingStep.LoadScripts:
                    LoadScripts();
                    break;
            }
        }

        public void Update()
        {
            if (downloader != null)
            {
                OnLoadAssetsUpdate();

                if (downloader.isCompleted)
                {
                    if (!downloader.error)
                    {
                        OnLoadAssetsComplete();
                    }
                    else
                    {
                        if (retryCount < MaxRetryCount)
                        {
                            LoadAssets();
                            retryCount++;
                        }
                        else
                        {
                            if (!retryBtn.gameObject.activeSelf)
                            {
                                updatePgBar(1, "下载" + downloader.downloadingFileName + "失败!\n" + downloader.errorMsg);
                                PrepareRetry();
                            }
                        }
                    }
                }
            }
        }

        private string GetLocalExtScriptsPath()
        {
            return GetFinalPath("Scripts/Scripts.dll", !ClientConfig.Ins.externalScripts);
        }

        private string GetClientConfigPath()
        {
            return GetFinalPath(ClientConfig.ConfigPath, false);
        }

        private string GetFinalPath(string path, bool forceInAppPackPath)
        {
            //Debug.LogWarning("========GetFinalPath========");
            string inAppPackPath = new StringBuilder(Application.streamingAssetsPath).Append("/").Append(path).ToString();
            string outAppPackPath = new StringBuilder(VerifyAssets.ins.extFilesRoot).Append("/Assets/").Append(path).ToString();

            if (inAppPackPath.IndexOf("file://") == 0)
            {
                inAppPackPath = inAppPackPath.Substring(7);
            }

            if (outAppPackPath.IndexOf("file://") == 0)
            {
                outAppPackPath = outAppPackPath.Substring(7);
            }

            inAppPackPath = inAppPackPath.Replace('/', System.IO.Path.DirectorySeparatorChar);
            outAppPackPath = outAppPackPath.Replace('/', System.IO.Path.DirectorySeparatorChar);

            string finalPath = null;

            if (forceInAppPackPath)
            {
                finalPath = inAppPackPath;
            }
            else
            {
                if (File.Exists(outAppPackPath))
                {
                    finalPath = outAppPackPath;
                }
                else
                {
                    finalPath = inAppPackPath;
                }
            }

            if (finalPath.IndexOf("file://") == -1)
            {
                finalPath = new StringBuilder("file://").Append(finalPath).ToString();
            }

            if (switchLog) { Debug.Log("finalPath:" + finalPath); }
            //Debug.LogWarning("finalPath:" + finalPath);
            return finalPath;
        }

        private string GetPathViaPlatform(string path)
        {
            //string pre = "file://";
            if (path.IndexOf("file://") == 0)
            {
                path = path.Substring(7);
                //return pre + path.Replace('/', System.IO.Path.DirectorySeparatorChar);
            }
            return path.Replace('/', System.IO.Path.DirectorySeparatorChar);
        }

        private void clickVersionText(GameObject go)
        {
            selectServerUI.clickVersionText(go);
        }


    }
}