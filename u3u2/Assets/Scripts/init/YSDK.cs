using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace init
{
    //腾讯平台（QQ&WX）
    public class YSDK :ISDK
    {
        #if !UNITY_EDITOR && UNITY_ANDROID && YSDK
        private AndroidJavaObject m_activity = null;
        #endif
    	private static YSDK _ins; 
    	 
    	public static YSDK ins
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new YSDK();
                }
                return _ins;
            }
        }

        public YSDK()
        {
            #if !UNITY_EDITOR && UNITY_ANDROID && YSDK
            AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            m_activity = jc.GetStatic<AndroidJavaObject>("currentActivity");
            #endif
        }

		public void channelLogin ()
		{
#if !UNITY_EDITOR && UNITY_ANDROID && YSDK
            //m_activity.Call("login");
			ShowPlatformSelecter();
#endif
		}

        public void LoginResult(IDictionary result)
        {

            Debug.Log("------------loginResult=" + result);
			SDKManager.ins.loginuserid = (string)result["platform"] + "|" + (string)result["open_id"] + "|" + (string)result["access_token"];
            SDKManager.ins.loginsource = "{\"deviceID\":\"" + SDKManager.ins.loginDeviceId +
                "\",\"channelName\":\"YSDK\",\"fromServerId\":\"" + ServerConfig.instance.serverId + "\",\"clientVersion\":\"local\",\"source\":\"" + SDKManager.ins.loingDebiceType + "\",\"clientLanguage\":\"CN\",\"otherPlatformLogin\":\"\",\"deviceVersion\":\"-1\",\"screenWidth\":\"" +
                    SDKManager.ins.loginScrW + "\",\"screenHeight\":\"" + SDKManager.ins.loginScrH + "\"}";
            GameSimpleEventCore.ins.DispatchEvent("connect_server", null);
        }

		public void channelPay(Dictionary<string, string> payInfo)
		{
			#if !UNITY_EDITOR && UNITY_ANDROID && YSDK
			m_activity.Call("ZZSDKPay",new string[]{payInfo["Product_Price"],payInfo["Order_Id"],payInfo["Server_Id"]});
			#endif
		}

		private void ShowPlatformSelecter ()
		{
			GameObject.Find ("InitCanvas/InitView/uiContainer/loginTips").SetActive(false);
			GameObject go = GameObject.Find ("InitCanvas/InitView/ysdkPlatSelecter");
			go.SetActive (true);
			Button qqBtn = go.transform.Find ("qq").GetComponent<Button> ();
			Button wxBtn = go.transform.Find ("wx").GetComponent<Button> ();
			qqBtn.onClick.AddListener(LoginQQ);
			wxBtn.onClick.AddListener(LoginWX);
		}

		private void LoginQQ ()
		{
#if !UNITY_EDITOR && UNITY_ANDROID && YSDK
			GameObject.Find ("InitCanvas/InitView/ysdkPlatSelecter").SetActive(false);
			GameObject.Find ("InitCanvas/InitView/uiContainer/loginTips").SetActive(true);
            m_activity.Call("login_qq");
#endif
		}

		private void LoginWX ()
		{
#if !UNITY_EDITOR && UNITY_ANDROID && YSDK
			GameObject.Find ("InitCanvas/InitView/ysdkPlatSelecter").SetActive(false);
			GameObject.Find ("InitCanvas/InitView/uiContainer/loginTips").SetActive(true);
            m_activity.Call("login_wx");
#endif
		}
		public string getSource(){
			return "ysdk";
		}
		public void installAPK(string apkurl){
			#if !UNITY_EDITOR && UNITY_ANDROID && YSDK
			m_activity.Call("installAPK",new string[]{apkurl});
			#endif
		}
		public string getDownloadAPKURL(){
			string url = "";
			#if !UNITY_EDITOR && UNITY_ANDROID && YSDK
			url = m_activity.Call<string>("getDownloadAPKURL");
			#endif
			return url;
		}
    }
}