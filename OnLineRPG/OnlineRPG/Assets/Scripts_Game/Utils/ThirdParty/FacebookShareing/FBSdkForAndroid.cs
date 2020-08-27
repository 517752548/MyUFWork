using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FBSdkForAndroid
{
	#if UNITY_ANDROID
	private const string FACEBOOKSHAR_ANGENT_CLASS_NAME = "com.words.game.wordguess.FBUtil";

	private static AndroidJavaClass FacebookSdk
	{
		get
		{
			if (!IsAndroidPlayer())
			{
				return null;
			}
			if (_FacebookSdk == null)
			{
				_FacebookSdk = new AndroidJavaClass(FACEBOOKSHAR_ANGENT_CLASS_NAME);
			}
			return _FacebookSdk;
		}
	}

	private static AndroidJavaClass _FacebookSdk;
	#endif

	public static void Login()
	{
		#if UNITY_ANDROID
		try
		{
			FacebookSdk.CallStatic("checkFacebookLogin");
		}
		catch (System.Exception ex)
		{
			DebugLog(ex.Message + " Not find loginFacebook methord!");
		}

		#endif
	}

	public static void GetFriends()
	{
		#if UNITY_ANDROID
		try
		{
			FacebookSdk.CallStatic("getFacebookFriends");
		}
		catch (System.Exception ex)
		{
			DebugLog(ex.Message + " Not find GetFriends methord!");
		}

		#endif
	}

	public static void InviteFriends(string message, string uids)
	{
		#if UNITY_ANDROID
		try
		{
			FacebookSdk.CallStatic("inviteFriends");
		}
		catch (System.Exception ex)
		{
			DebugLog(ex.Message + " Not find InviteFriends methord!");
		}

		#endif
	}

	public static bool IsLogin()
	{
#if UNITY_ANDROID
		try
		{
			return FacebookSdk.CallStatic<bool>("isFacebookLogin");
		}
		catch (System.Exception ex)
		{
			DebugLog(ex.Message + " Not find InviteFriends methord!");
			return false;
		}
#else
		return false;
#endif
	}

	private static bool IsAndroidPlayer()
	{
		return Application.platform == RuntimePlatform.Android;
	}

	private static void DebugLog(string log)
	{
		BetaFramework.LoggerHelper.Log("[FacebookAnalyticsPlugin]: " + log);
	}

	private static void DebugLogError(string error)
	{
		BetaFramework.LoggerHelper.Log("[FacebookAnalyticsPlugin]: " + error);
	}
}
