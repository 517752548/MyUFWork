using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class PlatformUtil
{
	public static bool IsRunInEditor()
	{
		RuntimePlatform platform = Application.platform;
		switch (platform)
		{
			case RuntimePlatform.Android:
			case RuntimePlatform.IPhonePlayer:
			case RuntimePlatform.WindowsPlayer:
				return false;
			default:
				return true;
		}
	}

	public static bool IsWindowsPlayer()
	{
		return Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor;
	}

	public static bool IsIPhonePlayer()
	{
		return Application.platform == RuntimePlatform.IPhonePlayer;
	}

	public static bool IsAndroidPlayer()
	{
		return Application.platform == RuntimePlatform.Android;
	}

	public static string GetPlatformName()
	{
#if UNITY_EDITOR
		return GetPlatformForAssetBundles(EditorUserBuildSettings.activeBuildTarget);
#else
        return GetPlatformForAssetBundles(Application.platform);
#endif
	}

#if UNITY_EDITOR
	private static string GetPlatformForAssetBundles(BuildTarget target)
	{
		switch (target)
		{
			case BuildTarget.Android:
				return "Android";
#if UNITY_TVOS
                case BuildTarget.tvOS:
                    return "tvOS";
#endif
			case BuildTarget.iOS:
				return "iOS";
			case BuildTarget.WebGL:
				return "WebGL";
			case BuildTarget.StandaloneWindows:
			case BuildTarget.StandaloneWindows64:
				return "Windows";
			case BuildTarget.StandaloneOSX:
				return "OSX";
			// Add more build targets for your own.
			// If you add more targets, don't forget to add the same platforms to GetPlatformForAssetBundles(RuntimePlatform) function.
			default:
				return null;
		}
	}
#endif

	private static string GetPlatformForAssetBundles(RuntimePlatform platform)
	{
		switch (platform)
		{
			case RuntimePlatform.Android:
				return "Android";
			case RuntimePlatform.IPhonePlayer:
				return "iOS";
#if UNITY_TVOS
                case RuntimePlatform.tvOS:
                    return "tvOS";
#endif
			case RuntimePlatform.WebGLPlayer:
				return "WebGL";
			case RuntimePlatform.WindowsPlayer:
				return "Windows";
			case RuntimePlatform.OSXPlayer:
				return "OSX";
			// Add more build targets for your own.
			// If you add more targets, don't forget to add the same platforms to GetPlatformForAssetBundles(RuntimePlatform) function.
			default:
				return null;
		}
	}

	public static bool IsReleaseWindows()
	{
#if USE_RELEASE_WINDOWS
		return true;
#endif
		return false;
	}

	public static bool IsReleaseAndroid()
	{
#if USE_RELEASE_ANDROID
		return true;
#endif
		return false;
	}

	public static bool IsReleaseIOS()
	{
#if USE_RELEASE_IOS
		return true;
#endif
		return false;
	}
}
