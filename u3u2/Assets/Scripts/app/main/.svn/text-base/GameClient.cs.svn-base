using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using app.model;
using app.chat;
using app.login;
using app.net;
using app.state;
using app.zone;
using app.config;
using app.report;
using UnityEngine.EventSystems;

namespace app.main
{
    /**
     * 登陆流程
     * cgPlayerLogin
     * gcRoleList
     *      cgRoleTemplate
     *      gcRoleTemplate,gcRoleRandomName
     *      cgCreateRole
     * gcRoleList
     * cgPlayerEnter
     * gcSceneInfo
     * cgEnterScene
     * gc***
     * gcEnterScene
     * gcPopPanelEnd
     * 
     */
    public class GameClient : MonoBehaviour
    {
        public GameObject cachedDisplayModels = null;
        
        public GameObject initViewCanvas { get; set; }
        public GameObject initViewServerSelecter { get; set; }
        public GameObject initViewProgressBarContainer { get; set; }
        public GameObject initViewProgressBar { get; set; }
        public GameObject initViewProgressBarLabel { get; set; }
        //public GameObject initViewLoginTips { get; set; }
        public string sdk { get; set; }
        public float serverTime = 0;

        public string shortcut = null;
        
        public GameShaders gameShaders = null;

        //private float mServerTimePingCD = 0;
        private ChatModel mChatModel = null;
        //行为列表
        private List<AbsMonoBehaviour> mBehaviourList = new List<AbsMonoBehaviour>();
        private int mBehaviourListCount = 0;
        //GC消息处理器注册
        //private MsgHandlerRegister msgHandlerRegister;
        /// <summary>
        /// 定时触发器的执行间隔，单位秒
        /// </summary>
        private const float InvokeRepeatRate = 0.1f;
        private static GameClient mIns = null;
        //public const string StartCoroutineEvent = "StartCoroutineEvent";
        //private RMetaEventHandler startCoroutineFunc;

        public GameClient()
        {
			
        }

        public static GameClient ins
        {
            get
            {
                if (mIns == null)
                {
                    GameObject go = GameObject.Find("ScriptsRoot");
                    mIns = go.GetComponent<GameClient>();
                    if (mIns == null)
                    {
                        mIns = go.AddComponent<GameClient>();
                    }
                }
                return mIns;
            }
        }

        void Awake()
        {
            mIns = this;
            ClientLog.LogWarning("======GameClient Awake Begin======");
            //设置帧率。
            Application.targetFrameRate = CommonDefines.FPS;
            //禁止手机休眠。
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
            //Instantiate AbsGameClientDelegate 
            /*
            BuglyAgent.ConfigDebugMode(true);
            BuglyAgent.ConfigAutoQuitApplication(false);
            BuglyAgent.RegisterLogCallback(null);
            BuglyAgent.InitWithAppId("900011735");
            */
            //SDKManager.ins.InitSDK();
            
            GameClientDelegate.Ins = new GameClientDelegate();
            
            /*
            if (Application.platform == RuntimePlatform.Android)
            {
                int scrW = Screen.currentResolution.width;
                int scrH = Screen.currentResolution.height;

                float widthPer = (float)scrW / (float)CommonDefines.DESIGNED_WIDTH;
                float heightPer = (float)scrH / (float)CommonDefines.DESIGNED_HEIGHT;

                float maxPer = Mathf.Max(widthPer, heightPer);

                if (maxPer < 1)
                {
                    //屏幕尺寸小于设计尺寸。
                    Screen.SetResolution((int)(scrW * maxPer), (int)(scrH * maxPer), true);

                }
                else
                {
                    Screen.SetResolution((int)(scrW / maxPer), (int)(scrH / maxPer), true);
                }
            }
            */
            
            initViewCanvas = GameObject.Find("InitCanvas");
            //GameObject.DontDestroyOnLoad(initViewCanvas);
            GameObject.DontDestroyOnLoad(GameObject.Find("ScriptsRoot"));
            GameObject.DontDestroyOnLoad(GameObject.Find("Canvas"));
            UGUIConfig.EventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
            GameObject.DontDestroyOnLoad(UGUIConfig.EventSystem);
            //GameObject.DontDestroyOnLoad(GameObject.Find("ModelCamera"));
            cachedDisplayModels = new GameObject("cachedDisplayModels");
            cachedDisplayModels.SetActive(false);
            GameObject.DontDestroyOnLoad(cachedDisplayModels);

            //消息监听注册
            //msgHandlerRegister = new MsgHandlerRegister();
            MsgHandlerRegister.Init();
            //mBehaviourList.Add(SourceLoader.Ins);
            //mBehaviourList.Add(SocketMsgReceiver.Ins);
            //mBehaviourList.Add(TimerManager.Ins);
            //mBehaviourList.Add(GameSceneManager.Ins);
            mBehaviourList.Add(WndManager.Ins);
            mBehaviourList.Add(StateManager.Ins);
            //mBehaviourList.Add(InputManager.Ins);
            //mBehaviourList.Add(Logger.Ins);
            //mBehaviourList.Add(OCheatDetector.Instance);
            //mBehaviourList.Add(InjectionDetector.Instance);
            //mBehaviourList.Add(Human.Instance);
            mBehaviourList.Add(ZoneBubbleManager.ins);
            mBehaviourList.Add(ScrollerManager.Ins);
            //mBehaviourList.Add(EffectUtil.Ins);
            mBehaviourList.Add(AutoMaticManager.Ins);
            mBehaviourList.Add(AudioManager.Ins);
            //mBehaviourList.Add(SystemNotice.ins);

            //mBehaviourList.Add(DisplayQualitySetting.ins);
            mBehaviourListCount = mBehaviourList.Count;

            for (int i = 0; i < mBehaviourListCount; i++)
            {
                mBehaviourList[i].Awake();
            }

            GameObject scriptsRoot = GameObject.Find("ScriptsRoot");
            scriptsRoot.AddComponent<SourceLoader>();
            scriptsRoot.AddComponent<SocketMsgReceiver>();
            scriptsRoot.AddComponent<TimerManager>();
            scriptsRoot.AddComponent<GameSceneManager>();
            scriptsRoot.AddComponent<InputManager>();

            //加载配置文件
            //ClientConfig.Ins.loadXml();
            //SetupDB();
            
            GameSimpleEventCore.ins.DispatchEvent("init_device_info", new string[]{ReYun.Instance.Game_GetDeviceID(), ReYun.Instance.Game_GetDeviceType()});
            
            if (GameObject.Find("accountSwitched") == null)
            {
#if !UNITY_EDITOR
                AudioManager.Ins.LoadPlatfromSound();
                PlatForm.Instance.SetRecUploadURL(CommonDefines.REC_UPLOAD_URL);
#endif
            }
            
            ClientLog.LogWarning("======GameClient Awake End======");

            //StartCoroutine(Start);
        }

        IEnumerator Start()
        {
            ClientLog.LogWarning("======GameClient Start Begin======");

            //一上来就加载配置文件，因为后边可能用到
            string clientCfgStr = PathUtil.Ins.GetFinalPath(ClientConfig.ConfigPath);
            ClientLog.LogWarning("configstr::" + clientCfgStr);
            WWW clientCfgLoader = new WWW(clientCfgStr);
            yield return clientCfgLoader;
            ClientConfig.Ins.ParseConfig(clientCfgLoader.text);
            clientCfgLoader.Dispose();
            clientCfgLoader = null;

            string clientVerCfgStr = PathUtil.Ins.GetFinalPath(ClientVersionConfig.ConfigPath);
            ClientLog.LogWarning("clientVerCfgStr::" + clientVerCfgStr);
            WWW clientVerCfgLoader = new WWW(clientVerCfgStr);
            yield return clientVerCfgLoader;
            ClientVersionConfig.Ins.ParseConfig(clientVerCfgLoader.text);
            clientVerCfgLoader.Dispose();
            clientVerCfgLoader = null;

            string serverConfigstr = PathUtil.Ins.GetFinalPath(ServerConfig.ConfigPath, true);
            ClientLog.LogWarning("serverConfigstr::" + serverConfigstr);
            WWW serverCfgLoader = new WWW(serverConfigstr);
            yield return serverCfgLoader;
            ServerConfig.instance.ParseConfig(serverCfgLoader.text);
            serverCfgLoader.Dispose();
            serverCfgLoader = null;

            GameObject shaders = GameObject.Find("shaders");
            if (!shaders)
            {
                string shadersPath = PathUtil.Ins.GetFinalPath("shaders.abl");
                WWW shadersLoader = new WWW(shadersPath);
                yield return shadersLoader;
                shaders = GameObject.Instantiate(shadersLoader.assetBundle.mainAsset) as GameObject;
                shaders.name = "shaders";
                gameShaders = shaders.GetComponent<GameShaders>();
                GameObject.DontDestroyOnLoad(shaders);
            }

            ChatModel.Ins.InitBiaoqing();

            //增加协成回调事件
            //EventCore.addRMetaEventListener(StartCoroutineEvent,DoStartCoroutine);
            //防作弊启动
            //InjectionDetector.Instance.genTxt();
            //InjectionDetector.Instance.StartDetection(onCheat);
            
            if (GameObject.Find("accountSwitched") == null)
            {
                //ReYun.Instance.Game_Init(ClientConfig.Ins.reyunAppid, ClientConfig.Ins.reyunChannel);
                DataReport.Instance.Game_Init();
            }
            
            //OCheatDetector.Instance.StartDetection(onCheat);
            RMeta.starUp(Config.instance);

            if (mBehaviourList.Count > 0)
            {
                for (int i = 0; i < mBehaviourListCount; i++)
                {
                    mBehaviourList[i].Start();
                }
            }
            //WndManager.open(GlobalConstDefine.LoginView_Name);
            
            StateManager.Ins.changeState(StateDef.initUI);

            ClientLog.LogWarning("======GameClient Start End======");
            //this.name = "gameclient";
            InvokeRepeating("DoUpdate", 0f, InvokeRepeatRate);
        }

        //private void DoStartCoroutine(RMetaEvent e)
        //{
        //    RMetaEventHandler callback = e.Handler as RMetaEventHandler;
        //    ClientLog.LogWarning("======GameClient DoStartCoroutine======"+callback);
        //    startCoroutineFunc = callback;
        //    StartCoroutine(DoCoroutine());
        //}

        //IEnumerator DoCoroutine()
        //{
        //    ClientLog.LogWarning("======GameClient 执行startCoroutineFunc======" + startCoroutineFunc);
        //    if (startCoroutineFunc!=null) startCoroutineFunc(null);
        //    yield return null;
        //}

        private void DoUpdate()
        {
            try
            {
                if (mBehaviourList.Count > 0)
                {
                    for (int i = 0; i < mBehaviourListCount; i++)
                    {
                        mBehaviourList[i].DoUpdate(InvokeRepeatRate);
                    }
                }
            }
            catch (Exception e)
            {
                ClientLog.LogError("GameClient.DoUpdate Throw Exception: " + e.StackTrace);
            }
        }

        void Update()
        {
            try
            {
                if (mBehaviourList.Count > 0)
                {
                    for (int i = 0; i < mBehaviourListCount; i++)
                    {
                        mBehaviourList[i].Update();
                    }
                }
            }
            catch (Exception e)
            {
                ClientLog.LogError("GameClient.Update Throw Exception: " + e.ToString());
            }
        }

        void FixedUpdate()
        {
            //serverTime += Time.fixedDeltaTime;

            try
            {
                if (mBehaviourList.Count > 0)
                {
                    for (int i = 0; i < mBehaviourListCount; i++)
                    {
                        mBehaviourList[i].FixedUpdate();
                    }
                }
            }
            catch (Exception e)
            {
                ClientLog.LogError("GameClient.FixedUpdate Throw Exception: " + e.ToString());
            }
            /*
            if (mServerTimePingCD <= 0)
            {
                mServerTimePingCD = 5;
                if (GameConnection.Instance.IsConnected())
                {
                    CommonCGHandler.sendCGPing();
                }
            }
            else
            {
                mServerTimePingCD -= Time.fixedDeltaTime;
            }
            */
        }

        void LateUpdate()
        {
            if (mBehaviourList.Count > 0)
            {
                for (int i = 0; i < mBehaviourListCount; i++)
                {
                    mBehaviourList[i].LateUpdate();
                }
            }
        }

        private void onCheat()
        {
            try
            {
                RMetaEventHandler retryHandler = delegate (RMetaEvent @event)
                {
                    ClientLog.LogError("#GameClient#onCheat");
                    Application.Quit();
                };
                ConnectFailView.Instance.PopView();
            }
            catch (Exception e)
            {
                ClientLog.LogError("#GameClient#onCheat#Exception!e=" + e.ToString());
            }
            finally
            {
                //强制退出
                Application.Quit();
            }
        }

        public void onChat(string message)
        {
            ClientLog.LogWarning("录音now client return:" + message);
            string[] messageArr = message.Split(new char[] { '|' });
            //IDictionary data = (IDictionary)(Json.Deserialize(messageArr[0]));
            if (mChatModel == null)
            {
                // mChatModel = Singleton.getObj(typeof(ChatModel)) as ChatModel;
                mChatModel = ChatModel.Ins;
            }
            int pindao = mChatModel.CurrentRecordingChannel;
            //PlatForm.Instance.PlayChat(recordUrl);
            ChatCGHandler.sendCGChatMsg(pindao, "", "", message, 1);
        }

        public void AddBehaviour(AbsMonoBehaviour behaviour)
        {
            if (!mBehaviourList.Contains(behaviour))
            {
                mBehaviourList.Add(behaviour);
                behaviour.Awake();
                behaviour.Start();
                mBehaviourListCount++;
            }
        }

        public void RemoveBehaviour(AbsMonoBehaviour behaviour)
        {
            if (mBehaviourList.Contains(behaviour))
            {
                mBehaviourList.Remove(behaviour);
                mBehaviourListCount--;
            }
        }

        public void ParseShortcut(string shortcut)
        {
            this.shortcut = shortcut;
            DoShortcut();
        }

        public void DoShortcut()
        {
            if (WndManager.Ins.IsWndShowing(GlobalConstDefine.LoginView_Name))
            {
                LoginView loginView = (LoginView)WndManager.Ins.GetCurrentShowWndByType(WndType.FirstWND);
                loginView.loginGame(loginView.UI.loginBtn.gameObject);
            }
            else if (ZoneManager.ins.curZoneInited)
            {
                if (shortcut == "chat")
                {
                    WndManager.open(GlobalConstDefine.RelationView_Name);
                }
                else if (shortcut == "sell")
                {
                    WndManager.open(GlobalConstDefine.ShopView_Name, WndParam.CreateWndParam(WndParam.SelectTab, 2));
                }

                shortcut = null;
            }
        }

        private Dictionary<string, List<RMetaEventHandler>> mLoadingPathAndCompleteHadlers = new Dictionary<string, List<RMetaEventHandler>>();

        public void SimpleLoad(string path, RMetaEventHandler onComplete, LoadArgs loadArgs = LoadArgs.SLIMABLE, object onCompleteParam = null, LoadContentType contentType = LoadContentType.ABL)
        {
            AssetBundleContainer assetBundleContainer = SourceManager.Ins.GetBundleConainer(path);
            if (assetBundleContainer != null)
            {
                assetBundleContainer.referenceCount--;
                if (onComplete != null)
                {
                    LoadInfo loadInfo = new LoadInfo();
                    loadInfo.urlPath = path;
                    loadInfo.param = onCompleteParam;
                    loadInfo.bundleContainer = assetBundleContainer;
                    loadInfo.loadArgs = loadArgs;
                    loadInfo.contentType = contentType;
                    onComplete(new RMetaEvent(SourceLoader.LOAD_COMPLETE, loadInfo));
                }
                return;
            }

            if (mLoadingPathAndCompleteHadlers.ContainsKey(path))
            {
                if (!mLoadingPathAndCompleteHadlers[path].Contains(onComplete))
                {
                    mLoadingPathAndCompleteHadlers[path].Add(onComplete);
                }
            }
            else
            {
                mLoadingPathAndCompleteHadlers.Add(path, new List<RMetaEventHandler>());
                mLoadingPathAndCompleteHadlers[path].Add(onComplete);
                StartCoroutine(StartSimpleLoad(path, loadArgs, onCompleteParam, contentType));
            }
        }

        private IEnumerator StartSimpleLoad(string path, LoadArgs loadArgs, object onCompleteParam, LoadContentType contentType)
        {
            WWW www = new WWW(PathUtil.Ins.GetFinalPath(path));
            ClientLog.Log("SimpleLoad:" + www.url);
            yield return www;
            AssetBundleContainer ablContainer = null;
            if (contentType == LoadContentType.BIN)
            {
                ablContainer = SourceManager.Ins.SaveBytes(path, www.bytes);
                if (www.assetBundle != null)
                {
                    www.assetBundle.Unload(false);
                }
            }
            else
            {
                ablContainer = SourceManager.Ins.SaveBundle(path, www.assetBundle, loadArgs);
                /*
                if (initMainAsset)
                {
                    ablContainer.InitMainAsset();
                }
                */
            }

            if (mLoadingPathAndCompleteHadlers.ContainsKey(path))
            {
                List<RMetaEventHandler> handlers = mLoadingPathAndCompleteHadlers[path];
                int len = handlers.Count;
                for (int i = 0; i < len; i++)
                {
                    RMetaEventHandler handler = handlers[i];
                    if (handler != null)
                    {
                        LoadInfo loadInfo = new LoadInfo();
                        loadInfo.www = www;
                        loadInfo.urlPath = path;
                        loadInfo.loadArgs = loadArgs;
                        loadInfo.param = onCompleteParam;
                        loadInfo.bundleContainer = ablContainer;
                        loadInfo.contentType = contentType;
                        handler(new RMetaEvent(SourceLoader.LOAD_COMPLETE, loadInfo));
                    }
                }
                mLoadingPathAndCompleteHadlers.Remove(path);
            }
            www.Dispose();
            www = null;
        }

        /*
        private void SetupDB()
        {
            string dbFile = PathUtil.Ins.extFilesRoot + "/db";
            // 连接db
            DbAccess.Instance.connDB("URI=file:" + dbFile);

            // 从db中获取数据，初始化所有的配置文件对象*DB.cs
            LoadCfg loader = new LoadCfg();
            loader.initAllCfg();

            // XXX 如果不断开链接，再次运行时，db文件删除不掉，会报错
            DbAccess.Instance.CloseSqlConnection();
        }
        */
        public void OnBigWndShown()
        {
            //if (StateManager.Ins.getCurState().state == StateDef.zoneState)
            {
                if (SceneModel.ins.zone3DModelCam != null) SceneModel.ins.zone3DModelCam.SetActive(false);
                UGUIConfig.GetCameraByWndType(WndType.MAINUI).gameObject.SetActive(false);
                if (ZoneUI.ins.ChatView.isShowing)
                {
                    ZoneUI.ins.ChatView.ui.SetActive(false);
                }
                else
                {
                    ZoneUI.ins.UI.chatUI.gameObject.SetActive(false);
                }
                
            }
        }

        public void OnBigWndHidden()
        {
            //if (StateManager.Ins.getCurState().state == StateDef.zoneState)
            {
                if (SceneModel.ins.zone3DModelCam != null) SceneModel.ins.zone3DModelCam.SetActive(true);
                UGUIConfig.GetCameraByWndType(WndType.MAINUI).gameObject.SetActive(true);
                if (ZoneUI.ins.ChatView!=null&&ZoneUI.ins.ChatView.isShowing)
                {
                    ZoneUI.ins.ChatView.ui.SetActive(true);
                }
                else
                {
                    if (ZoneUI.ins.UI!=null) ZoneUI.ins.UI.chatUI.gameObject.SetActive(true);
                }
            }
        }
    }
}