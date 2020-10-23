using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using init;

public class UCSDK :ISDK
{
    private static UCSDK _ins;
#if !UNITY_EDITOR && UNITY_ANDROID
    private AndroidJavaObject m_activity = null;
#endif
    public static UCSDK ins
    {
        get
        {
            if (_ins == null)
            {
                _ins = new UCSDK();
            }
            return _ins;
        }
    }
    public UCSDK()
    {
#if !UNITY_EDITOR && UNITY_ANDROID
            AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            m_activity = jc.GetStatic<AndroidJavaObject>("currentActivity");
#endif
    }
	public void channelLogin(){
			#if !UNITY_EDITOR && UNITY_ANDROID
            m_activity.Call("ZZSDKlogin");
            #endif
		}
		public void channelPay(Dictionary<string, string> payInfo)
        {
            Debug.Log("order_id:"+payInfo["Order_Id"]);
            #if !UNITY_EDITOR && UNITY_ANDROID
            m_activity.Call("ZZSDKPay",new string[]{payInfo["Product_Price"],payInfo["Order_Id"]});
            #endif
        }
		public void LoginResult (string result)
	{

		Debug.Log ("------------loginResult=" + result);
		init.SDKManager.ins.loginuserid = result;
				init.SDKManager.ins.loginsource = "{\"deviceID\":\"" + init.SDKManager.ins.loginDeviceId +
                                "\",\"channelName\":\"UC\",\"fromServerId\":\"" + GameObject.Find("InitCanvas/InitView").GetComponent<InitView>().selectedServerId + "\",\"clientVersion\":\"local\",\"source\":\"" + init.SDKManager.ins.loingDebiceType + "\",\"clientLanguage\":\"CN\",\"otherPlatformLogin\":\"\",\"deviceVersion\":\"-1\",\"screenWidth\":\"" +
                                init.SDKManager.ins.loginScrW + "\",\"screenHeight\":\"" + init.SDKManager.ins.loginScrH + "\"}";
				GameSimpleEventCore.ins.DispatchEvent("connect_server", null);
	}
	public void ReportPlayerData(Dictionary<string, string> data){
		Debug.Log("ucreport:");
//		string roleName = dic["roleName"];
//		string roleLevel = dic["roleLevel"];
//		string zoneId = dic["zoneId"];
//		string zoneName = dic["zoneName"];
		#if !UNITY_EDITOR && UNITY_ANDROID
		m_activity.Call("ZZSDKRole",new string[]{data["roleLevel"],data["roleId"],data["roleName"],data["zoneId"],data["createTime"]});
		#endif
	}
	public void onExit(){
		#if !UNITY_EDITOR && UNITY_ANDROID
		m_activity.Call("ZZSDKONEXIT");
		#endif
	}
	public string getSource ()
	{
		return "uc";
	}
	public void installAPK(string apkurl){
		#if !UNITY_EDITOR && UNITY_ANDROID && UC
		m_activity.Call("installAPK",new string[]{apkurl});
		#endif
	}
	public string getDownloadAPKURL(){
		string url = "";
		#if !UNITY_EDITOR && UNITY_ANDROID && UC
		url = m_activity.Call<string>("getDownloadAPKURL");
		#endif
		return url;
	}
	
}
