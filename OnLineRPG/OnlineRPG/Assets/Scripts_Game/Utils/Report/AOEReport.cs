using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BetaFramework;
using Facebook.Unity;
using Firebase.Analytics;
using UnityEngine;

public class AOEReport
{
    private static int[] levels = new[] {30, 40, 50};

    private static int[] playtime = new[]
        {25, 35, 45};

    public static void ReportOnLine(int min)
    {
        Debug.Log("aeoTime:" + min);
        if (playtime.Contains(min))
        {
            UserPlayTime(min);
        }
    }


    public static void LevelPass(int level)
    {
        if (DataManager.ProcessData.IsAOE && levels.Contains(level))
        {
            var fbpara = new Dictionary<string, object>();
            fbpara.Add("userId", AppEngine.SSystemManager.GetSystem<PlayerLoginSystem>().deviceID.Value);
            fbpara.Add("levelid", level);
            fbpara.Add("passtime", DateTime.UtcNow.ToString());
            fbpara.Add("status",
                AppEngine.SSystemManager.GetSystem<PlayerInfoSystem>().playerPayDict.Count > 0 ? "pay" : "free");
            //FBReport("aeopass" + level, fbpara);
            FireBaseReport("passLevel" + level, fbpara);
            if (level == 30)
            {
                if (FB.IsInitialized)
                    FB.LogAppEvent(AppEventName.AchievedLevel, null, fbpara);
            }
            else if (level == 40)
            {
                if (FB.IsInitialized)
                    FB.LogAppEvent(AppEventName.AddedToCart, null, fbpara);
            }
            else if (level == 50)
            {
                if (FB.IsInitialized)
                    FB.LogAppEvent(AppEventName.AddedToWishlist, null, fbpara);
            }
        }
    }

    public static void PlayerBuy(float buycent, string dollermoney, string currency, string itemname, string itemid)
    {
        if (DataManager.ProcessData.IsAOE)
        {
            var fbpara = new Dictionary<string, object>();
            fbpara.Add("userId", AppEngine.SSystemManager.GetSystem<PlayerLoginSystem>().deviceID.Value);
            fbpara.Add("price", buycent);
            fbpara.Add("name", itemname);
            fbpara.Add("itemid", itemid);
            fbpara.Add("status", "pay");
            //FBReport("aeobuy", fbpara);
            if (FB.IsInitialized)
            {
                float money = 0;
                float.TryParse(dollermoney, out money);
                FB.LogPurchase(money, "USD", fbpara);
            }

            //FireBaseReport("aeobuy",fbpara);
        }
    }

    private static void UserPlayTime(int timemin)
    {
        var fbpara = new Dictionary<string, object>();
        fbpara.Add("userId", AppEngine.SSystemManager.GetSystem<PlayerLoginSystem>().deviceID.Value);
        fbpara.Add("playtime", timemin);
        fbpara.Add("eventtime", DateTime.UtcNow.ToString());
        fbpara.Add("status",
            AppEngine.SSystemManager.GetSystem<PlayerInfoSystem>().playerPayDict.Count > 0 ? "pay" : "free");
        //FBReport("aeoonline" + timemin, fbpara);
        FireBaseReport("playTime" + timemin, fbpara);
        if (timemin == 25)
        {
            if (FB.IsInitialized)
                FB.LogAppEvent(AppEventName.CompletedRegistration, null, fbpara);
        }
        else if (timemin == 35)
        {
            if (FB.IsInitialized)
                FB.LogAppEvent(AppEventName.CompletedTutorial, null, fbpara);
        }
        else if (timemin == 45)
        {
            if (FB.IsInitialized)
                FB.LogAppEvent(AppEventName.UnlockedAchievement, null, fbpara);
        }
    }

    private static void FBReport(string name, Dictionary<string, object> para)
    {
        if (FB.IsInitialized)
        {
            FB.LogAppEvent(name, null, para);
        }
    }

    private static void FireBaseReport(string name, Dictionary<string, object> para)
    {
        if (FireBaseGragh.FireBaseInited)
        {
            Firebase.Analytics.Parameter[] custompara = new Parameter[para.Count];
            int index = 0;
            foreach (var key in para.Keys)
            {
                custompara[index] = new Parameter(key, para[key].ToString());
                index++;
            }

            Firebase.Analytics.FirebaseAnalytics.LogEvent(
                name,
                custompara);
        }
    }
}