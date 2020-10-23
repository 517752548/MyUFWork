using UnityEngine;

public class PlatformUtil
{
    private static PlatformUtil _ins;
    public static PlatformUtil Ins
    {
        get
        {
            if (_ins == null)
            {
                _ins = new PlatformUtil();
            }
            return _ins;
        }
    }


    ////android相关变量
    //private AndroidJavaClass androidMainClz;
    //private AndroidJavaObject androidCurActivity;


    private PlatformUtil()
    {
        //switch (Application.platform)
        //{
        //    case RuntimePlatform.IPhonePlayer:
        //        //TODO

        //        ClientLog.LogWaring("#PlatformUtil#init#do not suport this platform=" + Application.platform);
        //        break;

        //    case RuntimePlatform.Android:
        //        androidMainClz = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        //        androidCurActivity = androidMainClz.GetStatic<AndroidJavaObject>("currentActivity");
        //        break;
                
        //    default:
        //        ClientLog.LogWaring("#PlatformUtil#init#do not suport this platform=" + Application.platform);
        //        break;
        //}
    }

    public bool vibrate(long keepTime, int num)
    {
        bool flag = false;
        //if (androidCurActivity != null) 
        //{
        //    flag = androidCurActivity.Call<bool>("vibrate", new object[] { keepTime, num });
        //}
        return flag;
    }

}

