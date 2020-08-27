using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FBSdkAgent
{
	public static void Login()
	{
		#if UNITY_IOS

		#elif UNITY_ANDROID
		FBSdkForAndroid.Login();
		#endif
	}

	public static void GetFriends()
	{
		#if UNITY_IOS

		#elif UNITY_ANDROID
		FBSdkForAndroid.GetFriends();
		#endif
	}

	public static void InviteFriends(string message, string uids)
	{
		#if UNITY_IOS

		#elif UNITY_ANDROID
		FBSdkForAndroid.InviteFriends(message, uids);
		#endif
	}

	public static bool IsLogin()
	{
		#if UNITY_IOS
		return false;
		#elif UNITY_ANDROID
		return FBSdkForAndroid.IsLogin();
		#else
		return false;
		#endif
	}
}
