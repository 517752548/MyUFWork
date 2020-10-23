using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace init
{
    public class ZZSDK :ISDK
    {
        private static ZZSDK _ins;
        #if !UNITY_EDITOR && UNITY_ANDROID
        private AndroidJavaObject m_activity = null;
        #endif
        public static ZZSDK ins
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new ZZSDK();
                }
                return _ins;
            }
        }
        public ZZSDK()
        {
            #if !UNITY_EDITOR && UNITY_ANDROID
            AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            m_activity = jc.GetStatic<AndroidJavaObject>("currentActivity");
            #endif
        }

        public void login()
        {
            #if !UNITY_EDITOR && UNITY_ANDROID
            m_activity.Call("ZZSDKlogin");
            #endif
        }
        public void pay(Dictionary<string, string> payInfo)
        {
            Debug.Log("order_id:"+payInfo["Order_Id"]);
            #if !UNITY_EDITOR && UNITY_ANDROID
            m_activity.Call("ZZSDKpay",new string[]{payInfo["Product_Price"],payInfo["Order_Id"]});
            #endif
        }
		public string getSource(){
			return "zz";
		}
		public void installAPK(string apkurl){
			#if !UNITY_EDITOR && UNITY_ANDROID && ZZ
			m_activity.Call("installAPK",new string[]{apkurl});
			#endif
		}
		public string getDownloadAPKURL(){
			string url = "";
			#if !UNITY_EDITOR && UNITY_ANDROID && ZZ
			url = m_activity.Call<string>("getDownloadAPKURL");
			#endif
			return url;
		}
    }
}
