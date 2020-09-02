//using UnityEngine;
//using System;
//using System.Collections.Generic;
//using Facebook.Unity;
//using System.Runtime.InteropServices;

//public static class FBShare
//{
//	#if UNITY_IOS
////	[DllImport("__Internal")]
////	private static extern void FBShareWithTag(string score, string level);
//	#elif UNITY_ANDROID

//	#endif
//	public static void ShareBrag (string score, string level)
//    {
//		#if UNITY_IOS
////		FBShareWithTag(score,level);
//		#elif UNITY_ANDROID
//		using (AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
//		{
//			using (AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity"))
//			{
//				jo.Call("FBShareWithTag", score,level);
//			}
//		}
//		#endif
//    }

//}