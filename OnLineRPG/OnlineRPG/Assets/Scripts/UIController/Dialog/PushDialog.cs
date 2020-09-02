using BetaFramework;
using EventUtil;
using System;

public class PushDialog : UIWindowBase
{
    public void CloseButton()
    {
        Close();
    }

    public void OnSureClick()
    {
        //原生通知
        BetaFramework.LoggerHelper.Log("原生通知申请权限");

//        int pushState = LocalNotification.GetNotificationState();
//        if (pushState != 1)
//        {
//            LocalNotification.RequestPushAuthentication();
//        }
//        else
//        {
//            Record.SetBool(PrefKeys.disableNotiKey, false);
//        }

        Close();
    }

    public void OnDisableSureClick()
    {
        //动画弹板
        UIManager.OpenUIAsync(ViewConst.prefab_PushContinueDialog);
    }

    public void OnContinueClick()
    {
        
#if UNITY_IOS && !UNITY_EDITOR
        //跳转到系统设置
        PlatformIOS.OpenSetting();
        BetaFramework.LoggerHelper.Log("跳转到系统设置");
        //LocalNotification.GoToPushSetting();
#elif UNITY_ANDROID && !UNITY_EDITOR
        PlatformAndroid.OpenSetting();
        BetaFramework.LoggerHelper.Log("continue原生通知申请权限");
        //PlatformUtil.OpenSetting();
        //LocalNotification.RequestPushAuthentication();
        //PlatformAndroid.OpenNotificationSetting();
#else

#endif
        TimersManager.SetTimer(3, () =>
        {
            GameAnalyze.SettingReport("Home","Noti",AppEngine.SGameSettingManager.Notification.Value.ToString());
        });
        Close();
    }
	public void PrivacyClick()
	{
        UIManager.OpenUIAsync(ViewConst.prefab_PrivacyPolicyDialog, OpenType.Stack);
    }
    public void PermissionCancel() {
        if (objs.Length > 0) {
            if (objs[0] is Action) {
                (objs[0] as Action).Invoke();
			}
		}
        Close();
	}
}