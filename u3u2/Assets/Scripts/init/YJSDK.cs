using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Runtime.InteropServices;
using System;
using System.IO;  
using System.Net;
using System.Globalization;
using Common;
using init;

public class YJSDK :ISDK
{
	public static string CP_LOGIN_CHECK_URL = "http://pay.ts.wywlwx.com.cn/channel/yj/login";
	public static string CP_PAY_SYNC_URL = "http://pay.ts.wywlwx.com.cn/channel/yj/pay";
	// public static string CP_PAY_CHECK_URL = "http://testomsdk.xiaobalei.com:5555/cp/user/paylog/get?orderId=";
	// public static string CP_PAY_SYNC_URL = "http://testomsdk.xiaobalei.com:5555/cp/user/paylog/sync";
    #if !UNITY_EDITOR && UNITY_ANDROID
	[DllImport("gangaOnlineUnityHelper")]
	private static extern void login (IntPtr context, string customParams);
	[DllImport("gangaOnlineUnityHelper")]
	private static extern void setLoginListener (IntPtr context, string gameObject, string listener);
	[DllImport("gangaOnlineUnityHelper")]
	private static extern void pay (IntPtr context, string gameObject, int unitPrice, string unitName,
            int count, string callBackInfo, string callBackUrl, string payResultListener);
	 [DllImport("gangaOnlineUnityHelper")]
	private static extern void setRoleData (IntPtr context, string roleId,
            string roleName, string roleLevel, string zoneId, string zoneName);
	[DllImport("gangaOnlineUnityHelper")]
	private static extern void setData (IntPtr context, string key, string value);
	[DllImport("gangaOnlineUnityHelper")]
	private static extern void exit(IntPtr context, string gameObject,string listener);
    #endif
	 public SFOnlineUser user;
	 private static YJSDK _ins; 
	 
	 public static YJSDK ins
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new YJSDK();
                }
                return _ins;
            }
        }
        public YJSDK()
        {
        #if !UNITY_EDITOR && UNITY_ANDROID
           using (AndroidJavaClass unityPlayer = new AndroidJavaClass ("com.unity3d.player.UnityPlayer")) {
				using (AndroidJavaObject curActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity")) {
				   Debug.Log("now init logindatacallback");
				   setLoginListener(curActivity.GetRawObject (), "ScriptsRoot", "loingDataCallBack");
				
				}
			}
        #endif
        }
	public void LoginResult (string result)
	{

		Debug.Log ("------------loginResult=" + result);
		SFJSONObject sfjson = new SFJSONObject (result);
		string type = (string)sfjson.get ("result");	
		string customParams = (string)sfjson.get ("customParams");
		Debug.Log("aaaaaaaa"+customParams+":"+type);
		if (APaymentHelper.LoginResult.LOGOUT == type) {
		
			
		} else if (APaymentHelper.LoginResult.LOGIN_SUCCESS == type) {	
			SFJSONObject userinfo = (SFJSONObject)sfjson.get ("userinfo");
			Debug.Log("now getuserinfo");
			if (userinfo != null) {
				long id = long.Parse ((string)userinfo.get ("id"));
				string channelId = (string)userinfo.get ("channelid");
				string ChannelUserId = (string)userinfo.get ("channeluserid");
				string UserName = (string)userinfo.get ("username");
				string Token = (string)userinfo.get ("token");
				string ProductCode = (string)userinfo.get ("productcode");
				user = new SFOnlineUser (id, channelId, ChannelUserId,
															UserName, Token, ProductCode);
				Debug.Log ("## id:" + id + " channelId:" + channelId + " ChannelUserId:" + ChannelUserId
					+ " UserName:" + UserName + " Token:" + Token + " ProductCode:" + ProductCode);
				LoginCheck();

			}
				
			// LoginCheck ();
		} else if (APaymentHelper.LoginResult.LOGIN_FAILED == type) {
		// 	str = "login result = login failed" + customParams; 
		} 
	}
    public void channellogin()
    {
        #if !UNITY_EDITOR && UNITY_ANDROID
		using (AndroidJavaClass unityPlayer = new AndroidJavaClass ("com.unity3d.player.UnityPlayer")) {
				using (AndroidJavaObject curActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity")) {
					Debug.Log("now yj login");
					login (curActivity.GetRawObject (), "Login");
					
				}
			}
        #endif
    }
    public void channelPay(Dictionary<string, string> payInfo)
    {
        #if !UNITY_EDITOR && UNITY_ANDROID
        Debug.Log("order_id:" + payInfo["Order_Id"]);
       using (AndroidJavaClass unityPlayer = new AndroidJavaClass ("com.unity3d.player.UnityPlayer")) {
				using (AndroidJavaObject curActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity")) {
					pay (curActivity.GetRawObject (), "ScriptsRoot", int.Parse(payInfo["Product_Price"]), "钻石", 1, payInfo["Order_Id"], CP_PAY_SYNC_URL, "PayResult");
		}
			}
        #endif
    }
	public void PayResult (string result)
	{
		Debug.Log ("------------PayResult=" + result);
		SFJSONObject sfjson = new SFJSONObject (result);
		string type = (string)sfjson.get ("result");
		string data = (string)sfjson.get ("data");
	}
	public static string ToUrlEncode (string strCode)
	{ 
		StringBuilder sb = new StringBuilder (); 
		byte[] byStr = System.Text.Encoding.UTF8.GetBytes (strCode); //默认是System.Text.Encoding.Default.GetBytes(str) 
		System.Text.RegularExpressions.Regex regKey = new System.Text.RegularExpressions.Regex ("^[A-Za-z0-9]+$"); 
		for (int i = 0; i < byStr.Length; i++) { 
			string strBy = Convert.ToChar (byStr [i]).ToString (); 
			if (regKey.IsMatch (strBy)) { 
				//是字母或者数字则不进行转换  
				sb.Append (strBy); 
			} else { 
				sb.Append (@"%" + Convert.ToString (byStr [i], 16)); 
			} 
		} 
		return (sb.ToString ()); 
	}
	private string createLoginURL ()
	{
		if (user == null) {
			return null;
		}
		StringBuilder builder = new StringBuilder ();
		builder.Append (CP_LOGIN_CHECK_URL);

		builder.Append ("?app=");
		builder.Append (user.getProductCode ());
		builder.Append ("&sdk=");
		builder.Append (user.getChannelId ());
		builder.Append ("&uin=");
		builder.Append (ToUrlEncode (user.getChannelUserId ()));//(Base64.EncodeBase64(user.getChannelUserId()));
		builder.Append ("&sess=");
		builder.Append (ToUrlEncode (user.getToken ()));//(Base64.EncodeBase64(user.getToken()));
		return builder.ToString ();
	}
	void LoginCheck ()
	{
		string url = createLoginURL ();
		Debug.Log ("LoginCheck url:" + url);
		if (url == null)
			return;
		string result = executeHttpGet (url);
		Debug.Log ("LoginCheck result:" + result);
		if (result == null ) {
			return;
		} else {
			Debug.Log("now login check"+result);
			SFJSONObject sfjson = new SFJSONObject (result);
			if((string)sfjson.get("result")=="success")
			{
				init.SDKManager.ins.loginuserid = (string)sfjson.get("sid");
				init.SDKManager.ins.loginsource = "{\"deviceID\":\"" + init.SDKManager.ins.loginDeviceId +
                                "\",\"channelName\":\"YJ\",\"fromServerId\":\"" + GameObject.Find("InitCanvas/InitView").GetComponent<InitView>().selectedServerId + "\",\"clientVersion\":\"local\",\"source\":\"" + init.SDKManager.ins.loingDebiceType + "\",\"clientLanguage\":\"CN\",\"otherPlatformLogin\":\"\",\"deviceVersion\":\"-1\",\"screenWidth\":\"" +
                                init.SDKManager.ins.loginScrW + "\",\"screenHeight\":\"" + init.SDKManager.ins.loginScrH + "\"}";
				GameSimpleEventCore.ins.DispatchEvent("connect_server", null);
			}

			

		}
			
	}
	 public void onExit()
    {
        #if !UNITY_EDITOR && UNITY_ANDROID
		using (AndroidJavaClass unityPlayer = new AndroidJavaClass ("com.unity3d.player.UnityPlayer")) {
				using (AndroidJavaObject curActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity")) {
					Debug.Log("now yj exit");
					exit(curActivity.GetRawObject (),"ScriptsRoot", "ExitResult");
				}
			}
        #endif
    }
	public static string executeHttpGet (string str)
	{
		WebClient myWebClient = new WebClient ();  
		//myWebClient.Headers.Add("Content-Type", "multipart/form-data; ");  
		byte[] b = myWebClient.DownloadData (str);  
		return (Encoding.UTF8.GetString (b));
	}
	public string getSource(){
		return "yj";
	}
	public void installAPK(string apkurl){
		#if !UNITY_EDITOR && UNITY_ANDROID && YJ
		AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject m_activity = jc.GetStatic<AndroidJavaObject>("currentActivity");
		m_activity.Call("installAPK",new string[]{apkurl});
		#endif
	}
	public string getDownloadAPKURL(){
		string url = "";
		#if !UNITY_EDITOR && UNITY_ANDROID && YJ
		url = m_activity.Call<string>("getDownloadAPKURL");
		#endif
		return url;
	}
}
