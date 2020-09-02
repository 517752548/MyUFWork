using BetaFramework;
using DG.Tweening;
using EventUtil;
using Facebook.Unity;
using Newtonsoft.Json;
using System;
using UnityEngine;

public static class FBGraph
{
    /// <summary>
    /// {"id":"2642829375806620","name":"Enter Yang","picture":{"data":{"height":120,"is_silhouette":false,"url":"https://platform-lookaside.fbsbx.com/platform/profilepic/?asid=2642829375806620&height=120&width=120&ext=1577514987&hash=AeQ9hrTWr4kzp1DJ","width":120}},"install_type":"UNKNOW
    /// </summary>
    public static void GetPlayerInfo()
    {
        string queryString =
            "/me?fields=id,name,age_range,address,email,gender,work,picture.width(120).height(120),birthday,install_type,link";
        FB.API(queryString, HttpMethod.GET, GetPlayerInfoCallback);
    }

    private static int restartCount = 0;

    private static void GetPlayerInfoCallback(IGraphResult result)
    {
        if (result == null)
        {
            return;
        }

        if (result.Error != null)
        {
            if (restartCount < 5)
            {
                GetPlayerInfo();
                restartCount++;
            }

            BetaFramework.LoggerHelper.Error(result.Error);
            return;
        }

        DataManager.ProcessData.tempFBInfo = JsonConvert.SerializeObject(result.ResultDictionary);
        Debug.LogError("BQ FB all data " + DataManager.ProcessData.tempFBInfo);
        string name, id, email;
        if (result.ResultDictionary.TryGetValue("name", out name))
        {
            AppEngine.SSystemManager.GetSystem<PlayerInfoSystem>().PlsyerFBName.Value = name;
        }

        if (result.ResultDictionary.TryGetValue("email", out email))
        {
            AppEngine.SSystemManager.GetSystem<PlayerInfoSystem>().PlsyerFBEmail.Value = email;
        }

        if (result.ResultDictionary.TryGetValue("id", out id))
        {
            AppEngine.SSystemManager.GetSystem<PlayerInfoSystem>().PlsyerFBID.Value = id;
            AppEngine.SSystemManager.GetSystem<PlayerLoginSystem>().CheckFBLogin();
        }

        string imageUrl = GraphUtil.DeserializePictureURL(result.ResultDictionary);
        AppEngine.SSystemManager.GetSystem<PlayerInfoSystem>().PlsyerFBImageUrl.Value = imageUrl;
        AppEngine.SDownloadManager.GetBytes(new FBDownLoadListener(),imageUrl
            , false);
        EventDispatcher.TriggerEvent(GlobalEvents.FaceBookUserInfoLoaded);
        if (!Record.GetBool("FBLoginReport"))
        {
            Record.SetBool("FBLoginReport",true);
            GameAnalyze.LogFBLoginInfo(id,name,email);
        }
       
    }
}

public class FBDownLoadListener : IDownloadListener
{
    //fb下载用户头像用
    public void OnError(int transactionId, string errorMessage)
    {
    }

    public void OnUpdate(int transactionId, float progress)
    {
    }

    public void OnSuccess(int transactionId, byte[] bytes)
    {
        if (bytes != null && bytes.Length > 0)
        {
           
            AppEngine.SSystemManager.GetSystem<PlayerInfoSystem>().ChangeFBPic(bytes);
            EventUtil.EventDispatcher.TriggerEvent(GlobalEvents.HeadChanged);
        }
    }
}

public class FBLoginData
{
    public string id;
    public string name;
    public FBPic picture;
    public string install_type;
}

public class FBPic
{
    public PicData data;
}

public class PicData
{
    public int height;
    public bool is_silhouette;
    public string url;
    public int width;
}