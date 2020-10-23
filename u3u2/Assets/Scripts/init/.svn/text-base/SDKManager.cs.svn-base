using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using minijson;

namespace init
{
    public class SDKManager : MonoBehaviour
    {
        #if !UNITY_EDITOR&&WINGLOONG&&UNITY_IPHONE
        [DllImport("__Internal", CallingConvention=CallingConvention.Cdecl)]
        private static extern void showLoginView();
        private string iosAccountId = "";
        #endif
        
        private int mScrW = 0;
        private int mScrH = 0;
        private string mDeviceId = null;
        private string mDeviceType = null;
        private static SDKManager mIns = null;
		private static ISDK isdk = null;
		public static SDKManager ins
      {
            get
            {
                if (mIns == null)
                {
                    GameObject scriptsRoot = GameObject.Find("ScriptsRoot");
                    if (scriptsRoot == null)
                    {
                        scriptsRoot = new GameObject("ScriptsRoot");
                    }
                    mIns = scriptsRoot.GetComponent<SDKManager>();
                    if (mIns == null)
                    {
                        mIns = scriptsRoot.AddComponent<SDKManager>();
                    }
					isdk = getISDK();
                }
                return mIns;
            }
        }
		public static ISDK getISDK ()
		{
			
			#if UNITY_ANDROID

				#if UC
					isdk = UCSDK.ins;
				#elif YSDK
					isdk = YSDK.ins;
				#elif MI
					isdk = MISDK.ins;
				#elif TSZ
					isdk = TSZSDK.ins;
				#elif VIVO
					isdk = VIVOSDK.ins;
				#elif OPPO
					isdk = OPPOSDK.ins;
				#elif BAIDU
					isdk = BAIDUSDK.ins;
				#endif
			#endif
			if (isdk == null) {
				isdk = DEFAULTSDK.ins;
			}
			return isdk;
		}
        private string _userid;
        private string _usersource;
        public int loginScrW{
            get{
                return mScrW;
            }
        } 
        public int loginScrH{
            get{
                return mScrH;
            }
        }
        public string loginDeviceId{
            get{
                return mDeviceId;
            }
        }
        public string loingDebiceType{
            get{
                return mDeviceType;
            }
        }
        public string loginuserid {
            get{
                return _userid;
            }
            set{
                _userid = value;
            }
        }
        public string loginsource{
            get{
                return _usersource;
            }
            set{
                _usersource = value;
            }
        }
        
        public void Init()
        {
            GameSimpleEventCore.ins.AddListener("init_screen_size", InitScreenSize);
            GameSimpleEventCore.ins.AddListener("init_device_info", InitDeviceInfo);
            GameSimpleEventCore.ins.AddListener("show_login", ShowLogin);
            GameSimpleEventCore.ins.AddListener("do_login", DoLogin);
            GameSimpleEventCore.ins.AddListener("redo_login", ReDoLogin);
            GameSimpleEventCore.ins.AddListener("pay", Pay);
            GameSimpleEventCore.ins.AddListener("report_player_data", ReportPlayerData);
            GameSimpleEventCore.ins.AddListener("exit_game", ExitGame);
        }

        private void InitScreenSize(object data)
        {
            int[] arr = (int[])data;
            mScrW = arr[0];
            mScrH = arr[1];
        }

        private void InitDeviceInfo(object data)
        {
            string[] arr = (string[])data;
            mDeviceId = arr[0];
            mDeviceType = arr[1];
        }

#if !UNITY_EDITOR && ANYSDK

        
        private string mAnySDKSesssionId = null;
        private string mAnySDKChannelId = null;
        private string mAnySDKLoginSource = null;
        
        private void InitAnySDK()
        {
#if UNITY_ANDROID
            //AnySDK Android
            string appKey = "2CE52BB7-02DF-93DA-0781-6915BC6B7339";
            string appSecret = "6907532a2ccbae4ce625181768b576dd";
            string privateKey = "0B520D38840577CBEFE970A7E433030F";
            string oauthLoginServer = "http://pay.ts.hf-game.com/channel/anysdk/oauthlogin";
            //string oauthLoginServer = "http://oauth.anysdk.com/api/User/LoginOauth/";
            Debug.Log("初始化AnySDK:appKey:" + appKey + " appSecret:" + appSecret + " oauthLoginServer:" + oauthLoginServer);
            anysdk.AnySDK.getInstance().init(appKey, appSecret, privateKey, oauthLoginServer);
            Debug.Log("初始化AnySDK完毕");
            Debug.Log("设置AnySDK回调");
            anysdk.AnySDKUser.getInstance().setListener(this,"AnySDKUserCallBack");
            anysdk.AnySDKIAP.getInstance().setListener (this,"AnySDKIAPCallBack");
            anysdk.AnySDKPush.getInstance().setListener (this,"AnySDKPushCallBack");
            anysdk.AnySDKPush.getInstance().startPush();
            Debug.Log("设置AnySDK回调完毕");
#elif UNITY_IOS
            //AnySDK iOS
            //string appKey = "AEE563E8-C007-DC32-5535-0518D941D6C2";
            //string appSecret = "b9fada2f86e3f73948f52d9673366610";
            //string privateKey = "0EE38DB7E37D13EBC50E329483167860";
            //string oauthLoginServer = "http://oauth.anysdk.com/api/OauthLoginDemo/Login.php";
            //anysdk.AnySDK.getInstance().init(appKey, appSecret, privateKey, oauthLoginServer);
#endif
        }
        
        public void AnySDKUserCallBack(string msg)
        {
            Debug.Log("AnySDKUserCallBack(" + msg + ")");
            Dictionary<string, string> dic = anysdk.AnySDKUtil.stringToDictionary(msg);
            int code = Convert.ToInt32(dic["code"]);
            string result = dic["msg"];
            switch (code)
            {
                case (int)anysdk.UserActionResultCode.kInitSuccess://初始化SDK成功回调
                    Debug.Log("AnySDK初始化成功回调 " + msg);
                    anysdk.AnySDKUser.getInstance().login();
                    break;
                case (int)anysdk.UserActionResultCode.kInitFail://初始化SDK失败回调
                    Debug.Log("AnySDK初始化失败回调 " + msg);
                    break;
                case (int)anysdk.UserActionResultCode.kLoginSuccess://登陆成功回调
                    Debug.Log("AnySDK登陆成功回调 " + msg);
                    IDictionary resultDic = (IDictionary)(Json.Deserialize(result));
                    mAnySDKSesssionId = GetJsonStringData("sessionID", resultDic);
                    mAnySDKChannelId = anysdk.AnySDK.getInstance().getChannelId();
                    mAnySDKLoginSource = "{\"deviceID\":\"" + mDeviceId +
                                "\",\"channelName\":" + mAnySDKChannelId + ",\"fromServerId\":\"" + ServerConfig.instance.serverId + "\",\"clientVersion\":\"local\",\"source\":\"" + mDeviceType + "\",\"clientLanguage\":\"CN\",\"otherPlatformLogin\":\"\",\"deviceVersion\":\"-1\",\"screenWidth\":\"" +
                                mScrW + "\",\"screenHeight\":\"" + mScrH + "\"}";
                    //LoginModel.Ins.connectServer();
                    //PlayerCGHandler.sendCGPlayerCookieLogin(sessionId, source);
                    GameSimpleEventCore.ins.DispatchEvent("connect_server", null);
                    break;
                case (int)anysdk.UserActionResultCode.kLoginNetworkError://登陆网络出错回调
                    Debug.Log("AnySDK登陆网络出错回调 " + msg);
                    anysdk.AnySDKUser.getInstance().login();
                    break;
                case (int)anysdk.UserActionResultCode.kLoginCancel://登陆取消回调
                    Debug.Log("AnySDK登陆取消回调 " + msg);
                    //Application.Quit();
                    //StateManager.Ins.SwitchAccount();
                    GameSimpleEventCore.ins.DispatchEvent("switch_account", null);
                    break;
                case (int)anysdk.UserActionResultCode.kLoginFail://登陆失败回调
                    Debug.Log("AnySDK登陆失败回调 " + msg);
                    anysdk.AnySDKUser.getInstance().login();
                    break;
                case (int)anysdk.UserActionResultCode.kLogoutSuccess://登出成功回调
                    Debug.Log("AnySDK登出成功回调 " + msg);
                    //anysdk.AnySDKUser.getInstance().login();
                    //StateManager.Ins.SwitchAccount();
                    GameSimpleEventCore.ins.DispatchEvent("switch_account", null);
                    break;
                case (int)anysdk.UserActionResultCode.kLogoutFail://登出失败回调
                    Debug.Log("AnySDK登出失败回调 " + msg);
                    break;
                case (int)anysdk.UserActionResultCode.kPlatformEnter://平台中心进入回调
                    Debug.Log("AnySDK平台中心进入回调 " + msg);
                    break;
                case (int)anysdk.UserActionResultCode.kPlatformBack://平台中心退出回调
                    Debug.Log("AnySDK平台中心退出回调 " + msg);
                    break;
                case (int)anysdk.UserActionResultCode.kPausePage://暂停界面回调
                    Debug.Log("AnySDK暂停界面回调 " + msg);
                    break;
                case (int)anysdk.UserActionResultCode.kExitPage://退出游戏回调
                    Debug.Log("AnySDK退出游戏回调 " + msg);
                    Application.Quit();
                    break;
                case (int)anysdk.UserActionResultCode.kAntiAddictionQuery://防沉迷查询回调
                    Debug.Log("AnySDK防沉迷查询回调 " + msg);
                    break;
                case (int)anysdk.UserActionResultCode.kRealNameRegister://实名注册回调
                    Debug.Log("AnySDK实名注册回调 " + msg);
                    break;
                case (int)anysdk.UserActionResultCode.kAccountSwitchSuccess://切换账号成功回调
                    Debug.Log("AnySDK切换账号成功回调 " + msg);
                    break;
                case (int)anysdk.UserActionResultCode.kAccountSwitchFail://切换账号失败回调
                    Debug.Log("AnySDK切换账号失败回调 " + msg);
                    break;
                case (int)anysdk.UserActionResultCode.kOpenShop://应用汇  悬浮窗点击粮饷按钮回调
                    Debug.Log("AnySDK应用汇  悬浮窗点击粮饷按钮回调 " + msg);
                    break;
                default:
                    break;
            }
        }
        
        public void AnySDKIAPCallBack(string msg)
        {
            Debug.Log("AnySDKIAPCallBack("+ msg+")");
            Dictionary<string,string> dic = anysdk.AnySDKUtil.stringToDictionary (msg);
            int code = Convert.ToInt32(dic["code"]);
            string result = dic["msg"];
            
            switch(code)
            {
            case (int)anysdk.PayResultCode.kPaySuccess://支付成功回调
                Debug.Log("AnySDK支付成功回调 " + msg);
                //PlayerCGHandler.sendCGIosAndroidCharge();
                GameSimpleEventCore.ins.DispatchEvent("send_cg_ios_android_charge", null);
                break;
            case (int)anysdk.PayResultCode.kPayFail://支付失败回调
                Debug.Log("AnySDK支付失败回调 " + msg);
                //ZoneBubbleManager.ins.BubbleSysMsg("支付失败");
                GameSimpleEventCore.ins.DispatchEvent("bubble_sys_msg", "支付失败");
                anysdk.AnySDKIAP.getInstance().resetPayState();
                break;
            case (int)anysdk.PayResultCode.kPayCancel://支付取消回调
                Debug.Log("AnySDK支付取消回调 " + msg);
                anysdk.AnySDKIAP.getInstance().resetPayState();
                //ZoneBubbleManager.ins.BubbleSysMsg("支付取消");
                GameSimpleEventCore.ins.DispatchEvent("bubble_sys_msg", "支付取消");
                break;
            case (int)anysdk.PayResultCode.kPayNetworkError://支付超时回调
                Debug.Log("AnySDK支付超时回调 " + msg);
                anysdk.AnySDKIAP.getInstance().resetPayState();
                //ZoneBubbleManager.ins.BubbleSysMsg("支付超时");
                GameSimpleEventCore.ins.DispatchEvent("bubble_sys_msg", "支付超时");
                break;
            case (int)anysdk.PayResultCode.kPayProductionInforIncomplete://支付信息不完整
                Debug.Log("AnySDK支付信息不完整 " + msg);
                anysdk.AnySDKIAP.getInstance().resetPayState();
                //ZoneBubbleManager.ins.BubbleSysMsg("支付信息不完整");
                GameSimpleEventCore.ins.DispatchEvent("bubble_sys_msg", "支付信息不完整");
                break;
                /**
                * 新增加:正在进行中回调
                * 支付过程中若SDK没有回调结果，就认为支付正在进行中
                * 游戏开发商可让玩家去判断是否需要等待，若不等待则进行下一次的支付
                */
            case (int)anysdk.PayResultCode.kPayNowPaying:
                Debug.Log("AnySDK新增加:正在进行中回调\n支付过程中若SDK没有回调结果，就认为支付正在进行中\n游戏开发商可让玩家去判断是否需要等待，若不等待则进行下一次的支付\n " + msg);
                anysdk.AnySDKIAP.getInstance().resetPayState();
                break;
            default:
                break;
            }
        }
        
        public void AnySDKPushCallBack(string msg)
        {
            Debug.Log("AnySDKPushCallBack("+ msg+")");
            Dictionary<string,string> dic = anysdk.AnySDKUtil.stringToDictionary (msg);
            int code = Convert.ToInt32(dic["code"]);
            string result = dic["msg"];
            switch(code)
            {
                case (int)anysdk.PushActionResultCode.kPushReceiveMessage://Push接受到消息回调
                    Debug.Log("Push接受到消息回调:" + result);
                    break;
                default:
                    break;
        }
}
        
        public void OnApplicationPause(bool pauseStatus)
        {
            
        }
        
        public void OnApplicationFocus(bool focusStatus)
        {
            if (focusStatus)
            {
                anysdk.AnySDKAnalytics.getInstance().startSession();
            }
            else
            {
                anysdk.AnySDKAnalytics.getInstance().stopSession();
            }
        }
        
        public void OnApplicationQuit()
        {
            anysdk.AnySDKAnalytics.getInstance().stopSession();
        }
        
        private void AnySDKPay(Dictionary<string, string> productInfo)
        {
            List<String> idArrayList =  anysdk.AnySDKIAP.getInstance().getPluginId();
            if (idArrayList.Count == 1) {
                anysdk.AnySDKIAP.getInstance().payForProduct(productInfo,idArrayList[0]);
            }
            else //多种支付方式
            {
                Debug.Log("开发者需要自己设计多支付方式的逻辑及UI,Sample中有示例");
                //开发者需要自己设计多支付方式的逻辑及UI,Sample中有示例
            }
        }
#endif


#if !UNITY_EDITOR && ZZ
		private string zzid = "";
		private string zzsource = "";
#endif

#if !UNITY_EDITOR && YSDK
        public void YSDKResultCallback(string msg)
        {
			Debug.Log("YSDKResultCallback:" + msg);
			IDictionary data = (IDictionary)Json.Deserialize(msg);
            Debug.Log("data:" + data);
			string msgType = (string)data["key"];
            Debug.Log("msgType:" + msgType);
            switch (msgType)
            {
                case "PLAYER_LOGIN_SUCC":
                    {
                        IDictionary msgData = (IDictionary)data["value"];
                        YSDK.ins.LoginResult(msgData);
                    }
                    break;
            }
        }
#endif

        public void ShowLogin(object data)
        {
#if UNITY_EDITOR
            //WndManager.open(GlobalConstDefine.LoginView_Name);
            GameSimpleEventCore.ins.DispatchEvent("show_login_view", null);
#else
#if ANYSDK
            //GameClient.ins.initViewLoginTips.SetActive(true);
            GameObject.Find("InitCanvas/InitView").GetComponent<InitView>().userLoginTips.gameObject.SetActive(true);
            if (GameObject.Find("accountSwitched") == null)
            {
                InitAnySDK();
            }
            else
            {
                anysdk.AnySDKUser.getInstance().login();
            }

#elif ZZ
			GameObject.Find("InitCanvas/InitView").GetComponent<InitView>().userLoginTips.gameObject.SetActive(true);
			ZZSDK.ins.login();
#elif YJ 
            GameObject.Find("InitCanvas/InitView").GetComponent<InitView>().userLoginTips.gameObject.SetActive(true);
            YJSDK.ins.channellogin();
#elif TSZ
            GameObject.Find("InitCanvas/InitView").GetComponent<InitView>().userLoginTips.gameObject.SetActive(true);
            TSZSDK.ins.channelLogin();
#elif UC
            GameObject.Find("InitCanvas/InitView").GetComponent<InitView>().userLoginTips.gameObject.SetActive(true);
            UCSDK.ins.channelLogin();
#elif MI
            GameObject.Find("InitCanvas/InitView").GetComponent<InitView>().userLoginTips.gameObject.SetActive(true);
            MISDK.ins.channelLogin();
#elif YSDK
            GameObject.Find("InitCanvas/InitView").GetComponent<InitView>().userLoginTips.gameObject.SetActive(true);
            YSDK.ins.channelLogin();
#elif OPPO 
            GameObject.Find("InitCanvas/InitView").GetComponent<InitView>().userLoginTips.gameObject.SetActive(true);
			OPPOSDK.ins.channelLogin();
#elif VIVO 
            GameObject.Find("InitCanvas/InitView").GetComponent<InitView>().userLoginTips.gameObject.SetActive(true);
            VIVOSDK.ins.channelLogin();
#elif HUAWEI 
            GameObject.Find("InitCanvas/InitView").GetComponent<InitView>().userLoginTips.gameObject.SetActive(true);
            HUAWEISDK.ins.channelLogin();
#elif BAIDU 
			GameObject.Find("InitCanvas/InitView").GetComponent<InitView>().userLoginTips.gameObject.SetActive(true);
			BAIDUSDK.ins.channelLogin();
			
			
			#else
			//WndManager.open(GlobalConstDefine.LoginView_Name);
            #if UNITY_IOS
                #if WINGLOONG
                GameObject.Find("InitCanvas/InitView").GetComponent<InitView>().userLoginTips.gameObject.SetActive(true);
                showLoginView();
                //GameSimpleEventCore.ins.DispatchEvent("show_login_view", null);
                #else
                GameSimpleEventCore.ins.DispatchEvent("show_login_view", null);
                #endif
            #else
            GameSimpleEventCore.ins.DispatchEvent("show_login_view", null);
            #endif
#endif
#endif
        }

    #if !UNITY_EDITOR&&WINGLOONG&&UNITY_IOS
    public void GotIOSAccountId(string data)
    {
        iosAccountId = data;
        if (iosAccountId == "-1")
        {
            InitView initView = GameObject.Find("InitCanvas/InitView").GetComponent<InitView>();
            initView.selectServerUI.gameObject.SetActive(true);
            initView.userLoginTips.gameObject.SetActive(false);
        }
        else
        {
            GameSimpleEventCore.ins.DispatchEvent("connect_server", null);
        }
    }
    #endif

        public void DoLogin(object data)
        {
#if UNITY_EDITOR
            //Debug.Log("PlayerCGHandler.sendCGPlayerLogin(" + LoginModel.Ins.LoginName + ", " + LoginModel.Ins.LoginPwd + ", " + LoginModel.Ins.Source + ")");
            //PlayerCGHandler.sendCGPlayerLogin(LoginModel.Ins.LoginName, LoginModel.Ins.LoginPwd, LoginModel.Ins.Source);
            GameSimpleEventCore.ins.DispatchEvent("send_cg_player_login", null);
#else
#if WINGLOONG
        #if UNITY_IOS
            string source = "{\"deviceID\":\"" + mDeviceId +
                "\",\"channelName\":\"ZZ\",\"fromServerId\":\"" + ServerConfig.instance.serverId + "\",\"clientVersion\":\"local\",\"source\":\"" + loingDebiceType + "\",\"clientLanguage\":\"CN\",\"otherPlatformLogin\":\"\",\"deviceVersion\":\"-1\",\"screenWidth\":\"" +
                mScrW + "\",\"screenHeight\":\"" + mScrH + "\"}";
            GameSimpleEventCore.ins.DispatchEvent("send_cg_player_cookie_login", new string[]{iosAccountId, source});
            //GameSimpleEventCore.ins.DispatchEvent("send_cg_player_login", null);
        #else
            GameSimpleEventCore.ins.DispatchEvent("send_cg_player_login", null);
        #endif
#elif ANYSDK
            //Debug.Log("PlayerCGHandler.sendCGPlayerCookieLogin(" + mAnySDKSesssionId + ", " + mAnySDKLoginSource + ")");
            //PlayerCGHandler.sendCGPlayerCookieLogin(mAnySDKSesssionId, mAnySDKLoginSource);
            GameSimpleEventCore.ins.DispatchEvent("send_cg_player_cookie_login", new string[]{mAnySDKSesssionId, mAnySDKLoginSource});
#elif ZZ
			GameSimpleEventCore.ins.DispatchEvent("send_cg_player_cookie_login", new string[]{zzid, zzsource});
#else
            Debug.Log("now DoLogin userId:"+_userid+" userSource:"+_usersource);
            GameSimpleEventCore.ins.DispatchEvent("send_cg_player_cookie_login", new string[]{_userid,_usersource});
#endif
#endif
        }

        private void ReDoLogin(object data)
        {
#if UNITY_EDITOR
            //PlayerCGHandler.sendCGPlayerTokenLogin(PlayerGCHandler.pid, PlayerGCHandler.id, PlayerGCHandler.token, LoginModel.Ins.Source);
            GameSimpleEventCore.ins.DispatchEvent("send_cg_player_tocken_login", null);
#elif WINGLOONG
			#if UNITY_IOS
			string source = "{\"deviceID\":\"" + mDeviceId +
				"\",\"channelName\":\"ZZ\",\"fromServerId\":\"" + 
            ServerConfig.instance.serverId
            + "\",\"clientVersion\":\"local\",\"source\":\"" + loingDebiceType + "\",\"clientLanguage\":\"CN\",\"otherPlatformLogin\":\"\",\"deviceVersion\":\"-1\",\"screenWidth\":\"" +
					mScrW + "\",\"screenHeight\":\"" + mScrH + "\"}";
			GameSimpleEventCore.ins.DispatchEvent("send_cg_player_tocken_login", source);
#else
			GameSimpleEventCore.ins.DispatchEvent("send_cg_player_tocken_login", null);
#endif
		
#elif ANYSDK
        //PlayerCGHandler.sendCGPlayerTokenLogin(PlayerGCHandler.pid, PlayerGCHandler.id, PlayerGCHandler.token, mAnySDKLoginSource);
        GameSimpleEventCore.ins.DispatchEvent("send_cg_player_tocken_login", mAnySDKLoginSource);
#elif ZZ
		GameSimpleEventCore.ins.DispatchEvent("send_cg_player_tocken_login", zzsource);
#else
        //PlayerCGHandler.sendCGPlayerTokenLogin(PlayerGCHandler.pid, PlayerGCHandler.id, PlayerGCHandler.token, LoginModel.Ins.Source);
        GameSimpleEventCore.ins.DispatchEvent("send_cg_player_tocken_login", _usersource);
#endif
        }

        private void Pay(object data)
        {
#if UNITY_EDITOR

#else
#if ANYSDK
            AnySDKPay((Dictionary<string, string>)data);
#elif ZZ
            ZZSDK.ins.pay((Dictionary<string, string>)data);
#elif YJ   
            YJSDK.ins.channelPay((Dictionary<string, string>)data);
#elif TSZ 
            TSZSDK.ins.channelPay((Dictionary<string, string>)data);
#elif UC
            UCSDK.ins.channelPay((Dictionary<string, string>)data);
#elif MI
            MISDK.ins.channelPay((Dictionary<string, string>)data);
#elif OPPO 
			OPPOSDK.ins.channelPay((Dictionary<string, string>)data);
#elif VIVO 
            VIVOSDK.ins.channelPay((Dictionary<string, string>)data);
#elif HUAWEI 
            HUAWEISDK.ins.channelPay((Dictionary<string, string>)data);
#elif BAIDU 
			BAIDUSDK.ins.channelPay((Dictionary<string, string>)data);
#elif YSDK
			YSDK.ins.channelPay((Dictionary<string, string>)data);

#elif WINGLOONG
	#if UNITY_ANDROID

	#elif UNITY_IOS
	            //app store 充值
	        if (IAPPaymentHelper.Instance.CanPay())
	        {
	            string id = PlatForm.Instance.GetAppID();
	            IAPPaymentHelper.Instance.BuyProduct(id + "." + ((Dictionary<string, string>)data)["Product_Id"].ToString());
	        }
	#endif
#endif
#endif
        }

#if !UNITY_EDITOR && UNITY_IOS
        public void ReceivedIAPReceipt(string receipt)
        {
#if WINGLOONG
            GameSimpleEventCore.ins.DispatchEvent("received_iapreceipt", receipt);
#endif
	}
#endif

		private string GetJsonStringData(string key, IDictionary data)
        {
            if (data != null && data.Contains(key))
            {
                try
                {
                    return data[key].ToString();
                }
                catch
                {
                    return "";
                }
            }
            return "";
        }
        public void loingDataCallBack(string data)
        {
#if !UNITY_EDITOR
            Debug.Log("now loginDataCallback");
#if ZZ
			zzid = data;
            zzsource = "{\"deviceID\":\"" + mDeviceId +
                                "\",\"channelName\":\"ZZ\",\"fromServerId\":\"" + ServerConfig.instance.serverId + "\",\"clientVersion\":\"local\",\"source\":\"" + loingDebiceType + "\",\"clientLanguage\":\"CN\",\"otherPlatformLogin\":\"\",\"deviceVersion\":\"-1\",\"screenWidth\":\"" +
                                mScrW + "\",\"screenHeight\":\"" + mScrH + "\"}";
            
            GameSimpleEventCore.ins.DispatchEvent("connect_server", null);
#elif YJ
        YJSDK.ins.LoginResult(data);
#elif TSZ
        TSZSDK.ins.LoginResult(data);
#elif UC
        UCSDK.ins.LoginResult(data);
#elif MI
        MISDK.ins.LoginResult(data);
#elif OPPO
		OPPOSDK.ins.LoginResult(data);
#elif VIVO
        VIVOSDK.ins.LoginResult(data);
#elif BAIDU
		BAIDUSDK.ins.LoginResult(data);
#elif HUAWEI
		HUAWEISDK.ins.LoginResult(data);
#endif
#endif
        }

        public void ReportPlayerData(object data)
        {
            Dictionary<string, string> dic = (Dictionary<string, string>)data;
            string roleName = dic["roleName"];
            string roleLevel = dic["roleLevel"];
            string zoneId = dic["zoneId"];
            string zoneName = dic["zoneName"];
			#if !UNITY_EDITOR
#if UC
			UCSDK.ins.ReportPlayerData((Dictionary<string, string>)data);
#elif VIVO
            VIVOSDK.ins.ReportPlayerData((Dictionary<string, string>)data);
#elif HUAWEI
			HUAWEISDK.ins.ReportPlayerData((Dictionary<string, string>)data);
#endif
#endif
        }

        public void ExitGame(object data)
        {
			#if !UNITY_EDITOR
    			#if YJ
                 YJSDK.ins.onExit();
                #elif UC
    			 UCSDK.ins.onExit();
                #elif TSZ
    			 TSZSDK.ins.onExit();
				#elif BAIDU
				 BAIDUSDK.ins.onExit();
                #elif OPPO
    			 OPPOSDK.ins.onExit();
                #else
                GameSimpleEventCore.ins.DispatchEvent("show_exit_game_alert", null);
                #endif
            #endif

        }
		public void switch_account(object data){
			Debug.Log ("switch_account1");
			GameSimpleEventCore.ins.DispatchEvent("switch_account", null);
		}

		public string getSource ()
		{
			return isdk.getSource ();
		}
		public void installAPK(string apkurl){
			isdk.installAPK (apkurl);
		}
		public string getDownloadAPKURL(){
			return isdk.getDownloadAPKURL ();
		}
    }

}