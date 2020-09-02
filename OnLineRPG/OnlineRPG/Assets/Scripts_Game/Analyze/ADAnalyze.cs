using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using Facebook.Unity;
using UnityEngine;

public class ADAnalyze
{
    
    public static void ADBtnShow(string source)
    {
        Dictionary<String, String> customParams = new Dictionary<string, string>();
        customParams.Add("source",source);
        LogCustomAdEvent("AdBtnShow",customParams);
    }

    public static void AdBtnClick(string source)
    {
        GameAnalyze.LogAdBtnClick(AppEngine.SyncManager.Data.ClassicLevel.Value.ToString(),
            AppEngine.SyncManager.Data.Coin.Value.ToString(),
            AppEngine.SyncManager.Data.Hint1.Value.ToString(),
            AppEngine.SyncManager.Data.Hint2.Value.ToString(),
            AppEngine.SyncManager.Data.Hint3.Value.ToString(),
            AppEngine.SyncManager.Data.Hint4.Value.ToString(),
            source,
            AppEngine.SyncManager.Data.Bee.Value.ToString()
            );
        //LogCustomAdEvent("AdBtnClick",customParams);
    }

    public static void AdShowing(string platform,string placementid)
    {
        Dictionary<string, string> _staticdata = new Dictionary<string, string>();
        _staticdata.Add("platform",platform);
        _staticdata.Add("placementid",placementid);
        LogCustomAdEvent("AdVideoShow",_staticdata);
    }

    public static void AdRewarded()
    {
        LogCustomAdEvent("AdVideoShowComplete",null);
    }

    public static void AdShowFailed()
    {
        LogCustomAdEvent("AdVideoShowFail",null);
    }



    private static void LogCustomAdEvent(string name,Dictionary<String, String> customParams)
    {
        FTDSdk.getInstance().logCustomEvent(name, name, customParams);
        // try
        // {
        //     if (FB.IsInitialized && Const.reportFB)
        //     {
        //         Dictionary<string, object> fbParas = new Dictionary<string, object>();
        //         foreach (string eventParamsKey in customParams.Keys)
        //         {
        //             if (!string.IsNullOrEmpty(eventParamsKey) && !string.IsNullOrEmpty(customParams[eventParamsKey]))
        //             {
        //                 fbParas.Add(eventParamsKey, customParams[eventParamsKey]);
        //             }
        //         }
        //
        //         if (fbParas.Count == 0)
        //         {
        //             FB.LogAppEvent(name, null, null);
        //         }
        //         else
        //         {
        //             FB.LogAppEvent(name, null, fbParas);
        //         }
        //     }
        // }
        // catch (Exception e)
        // {
        //     Debug.LogError("fb打点报错了" + name);
        // }
    }
}
