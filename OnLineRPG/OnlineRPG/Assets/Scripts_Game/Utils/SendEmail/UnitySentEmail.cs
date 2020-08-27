//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System.Runtime.InteropServices;
//using System;

//public static class UnitySentEmail {
//	#if UNITY_IOS
//	 [DllImport("__Internal")]
//	private static extern void sendEmail();

//	#endif
//	public static void Send(string subject,string body,string to)
//	{
//		#if UNITY_IOS
//		sendEmail();
////		subject = "WordCrumble "+SystemInfo.deviceModel;
////		Uri url = new Uri(string.Format("mailto:{0}?subject={1}&body={2}",to,subject,body));
////		Application.OpenURL(url.AbsoluteUri);
//		#elif UNITY_ANDROID
//		using (AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
//		{
//			using (AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity"))
//			{
//				jo.Call("sendEmail", subject, body, to);
//			}
//		}
//		#endif
//	}

//}
