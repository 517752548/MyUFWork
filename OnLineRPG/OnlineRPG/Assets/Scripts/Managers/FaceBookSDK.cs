using BetaFramework;
using EventUtil;
using Facebook.Unity;
using System;
using UnityEngine;

public class FaceBookSDK
{
    private Action FBInitCallback;

    public void Init()
    {
        EventDispatcher.AddEventListener(GlobalEvents.FirebaseInitSuccess, OnFirebaseInitSuccess);
    }

    public void OnDestroy()
    {
        EventDispatcher.RemoveEventListener(GlobalEvents.FirebaseInitSuccess, OnFirebaseInitSuccess);
    }

    private void OnFirebaseInitSuccess()
    {
        GetPlayerInfo();
    }

    public void Start(Action FBInitCallback)
    {
        this.FBInitCallback = FBInitCallback;
        if (!FB.IsInitialized)
        {
            FB.Init(InitCallback);
        }
    }

    #region FB Restart

    private void InitCallback()
    {
        if (FBInitCallback != null)
        {
            FBInitCallback.Invoke();
        }

        FBAppEvents.LaunchEvent();
        FB.LogAppEvent(AppEventName.ActivatedApp);
        GetPlayerInfo();
        EventDispatcher.TriggerEvent(GlobalEvents.FaceBookInitOver);
    }

    private void GetPlayerInfo()
    {
        if (FB.IsInitialized && FB.IsLoggedIn)
        {
            BetaFramework.LoggerHelper.Log("Facebook request firebase data");
            AppEngine.SSystemManager.GetSystem<PlayerInfoSystem>().FBLogined.Value = true;

            FBGraph.GetPlayerInfo();
        }
        else
        {
            //facebook自动登录失败，此时重置facebook状态
            AppEngine.SSystemManager.GetSystem<PlayerInfoSystem>().FBLogined.Value = false;
        }
    }

    #endregion FB Restart

    #region Login

    public void OnLoginClick()
    {
        BetaFramework.LoggerHelper.Log("OnLoginClick");

        FBLogin.PromptForLogin(OnLoginComplete);
    }

    private void OnLoginComplete(bool success)
    {
        Debug.LogError("OnLoginComplete " + success);
        if (success == false)
        {
            UIManager.OpenUIAsync(ViewConst.prefab_FBLoginFailDialog); 
            AppEngine.SSystemManager.GetSystem<PlayerInfoSystem>().FBLogined.Value = false;
            return;
        }
        AppEngine.SSystemManager.GetSystem<PlayerInfoSystem>().FBLogined.Value = true;
        FBGraph.GetPlayerInfo();
        EventDispatcher.TriggerEvent(GlobalEvents.FaceBookLoginedSuccessful);
    }

    #endregion Login

    public static bool IsFacebookLoggedIn()
    {
        return FB.IsLoggedIn || AppEngine.SSystemManager.GetSystem<PlayerInfoSystem>().FBLogined.Value;;
    }
}