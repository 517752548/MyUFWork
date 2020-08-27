using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using BetaFramework;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class BQReport : MonoBehaviour
{
    private const string BQURL = "https://crazecnbq.wordzhgame.net/crazeBquery/mainBase";
    
    
    private const string TAG = "BQBQBQ";
    
    public static void PostQuestion(string levelid,string questid,int rate,string levelVersion,string question,string answer,int times)
    {
        int butterflylevel = 0;
        JObject rss =
            new JObject(
                new JProperty("LevelID", levelid),
                new JProperty("QueID", questid),
                new JProperty("Rate", rate),
                new JProperty("LevelVersion", levelVersion),
                new JProperty("UserID", PlatformUtil.GetIDFA()),
                new JProperty("Question", question),
                new JProperty("Answer", answer),
                new JProperty("Times", times)
            );
        PostCommTable("QueFeedback", rss, "活跃用户表");
    }

    public static void PostVoiceFeedback(VoiceFeedBackModel model) {
        JObject rss = new JObject(
            new JProperty("levelid", model.levelid),
			new JProperty("levelType", model.levelType),
			new JProperty("voiceType", model.voiceType),
			new JProperty("question", model.question),
			new JProperty("recognition", model.recognition),
			new JProperty("answer", model.answer),
			new JProperty("consumeTime", model.consumeTime),
			new JProperty("right", model.right),
			new JProperty("version", model.version),
			new JProperty("text", model.text),
			new JProperty("toggle1", model.toggle1),
			new JProperty("toggle2", model.toggle2),
			new JProperty("toggle3", model.toggle3),
			new JProperty("toggle4", model.toggle4),
			new JProperty("toggle5", model.toggle5),
			new JProperty("toggle6", model.toggle6),
			new JProperty("toggle7", model.toggle7),
			new JProperty("toggle8", model.toggle8)
            );
        PostCommTable("VoiceFeedback", rss, "语音反馈表");
	}

    public static void PostVoiceInput(VoiceInputModel model) {
        JObject rss = new JObject(
            new JProperty("levelId", model.levelId),
			new JProperty("levelType", model.levelType),
			new JProperty("type", model.type),
			new JProperty("question", model.question),
			new JProperty("recognition", model.recognition),
			new JProperty("answer", model.answer),
			new JProperty("consumeTime", model.consumeTime),
			new JProperty("right", model.right),
			new JProperty("version", model.version)
            );
        PostCommTable("VoiceInput", rss, "语音输入表");
	}
	public static void PostVoicePermission(voicePermissionModel model)
	{
        JObject rss = new JObject(
            new JProperty("userid", model.userid),
			new JProperty("permission", model.permission)
            );
        PostCommTable("voicePermission", rss, "语音权限");
	}
    
    /// <summary>
    /// 主线单词打点
    /// 上报条件：每当玩家完成一次单词输入时上传（如果玩家把模式调整成非删除错误字母的模式，错误词只上传一次，如果是删除模式，则每次输入错误均上传）
    /// <summary>
    /// <param name="levelSeq">关卡序号</param>
    /// <param name="queId">问题序号</param>
    /// <param name="playSeq">回答出这个问题的次序，如果是错误词则上传-1，出现一次多个，那就顺延序数</param>
    /// <param name="answer">这个答案是什么</param>
    /// <param name="type">单词类型，1：正确词2：错误词</param>
    /// <param name="playTime">距离上一次答对的时间</param>
    /// <param name="hint1Num">在这次以及上次回答中正确答案之间使用过几个Hint1</param>
    /// <param name="hint2Num">在这次以及上次回答中正确答案之间使用过几个Hint2</param>
    /// <param name="hint3Num">在这次以及上次回答中正确答案之间使用过几个Hint3</param>
    /// <param name="hint4Num">在这次以及上次回答中正确答案之间使用过几个Hint4</param>
    /// <param name="wrongWord">当这个答案是一个错误答案时，用户输入的错误答案是什么。对于正确单词不打</param>
    public static void LogclassicLevelWords(string p_levelSeq,string p_queId,string p_playSeq,string p_answer,string p_type,string p_playTime,string p_hint1Num,string p_hint2Num,string p_hint3Num,string p_hint4Num,string p_wrongWord)
    {
        Dictionary<string, string> data = new Dictionary<string, string>()
        {
            { "levelSeq" , p_levelSeq },
            { "queId" , p_queId },
            { "playSeq" , p_playSeq },
            { "answer" , p_answer },
            { "type" , p_type },
            { "playTime" , p_playTime },
            { "hint1Num" , p_hint1Num },
            { "hint2Num" , p_hint2Num },
            { "hint3Num" , p_hint3Num },
            { "hint4Num" , p_hint4Num },
            { "wrongWord" , p_wrongWord },
            { "LevelABTestVersion" , AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().GetAbTestSpecialId() },
            { "LevelABTestAB" , AppEngine.SSystemManager.GetSystem<TestABWordLibSystem>().GetUserTestLib() },
            { "LoginID" , AppEngine.SSystemManager.GetSystem<PlayerLoginSystem>().playerCrazeID.Value },
            { "FBID" , AppEngine.SSystemManager.GetSystem<PlayerInfoSystem>().PlsyerFBID.Value },
            { "userId" , AppEngine.SSystemManager.GetSystem<PlayerLoginSystem>().deviceID.Value },
            { "appVersion" , Const.Version },
            #if UNITY_IOS
            { "platform" , "ios" },
            #elif UNITY_ANDROID
            { "platform" , "android" },
            #endif
            
        };
        JObject rss =
            new JObject();
        foreach (string dataKey in data.Keys)
        {
            rss.Add(dataKey,data[dataKey]);
        }
        PostCommTable("classicLevelWords_New", rss, "用户错误词表");
    }
    /// <summary>
    /// 每日挑战单词打点
    /// 上报条件：每当玩家完成一次单词输入时上传（如果玩家把模式调整成非删除错误字母的模式，错误词只上传一次，如果是删除模式，则每次输入错误均上传）
    /// <summary>
    /// <param name="levelTimeStamp">关卡时间戳</param>
    /// <param name="queId">问题序号</param>
    /// <param name="playSeq">回答出这个问题的次序，如果是错误词则上传-1，出现一次多个，那就顺延序数</param>
    /// <param name="answer">这个答案是什么</param>
    /// <param name="type">单词类型，1：正确词2：错误词</param>
    /// <param name="playTime">距离上一次答对的时间</param>
    /// <param name="hint1Num">在这次以及上次回答中正确答案之间使用过几个Hint1</param>
    /// <param name="hint2Num">在这次以及上次回答中正确答案之间使用过几个Hint2</param>
    /// <param name="hint3Num">在这次以及上次回答中正确答案之间使用过几个Hint3</param>
    /// <param name="hint4Num">在这次以及上次回答中正确答案之间使用过几个Hint4</param>
    /// <param name="wrongWord">当这个答案是一个错误答案时，用户输入的错误答案是什么。对于正确单词不打</param>
    public static void LogDailyLevelWords(string p_levelTimeStamp,string p_queId,string p_playSeq,string p_answer,string p_type,string p_playTime,string p_hint1Num,string p_hint2Num,string p_hint3Num,string p_hint4Num,string p_wrongWord)
    {
        Dictionary<string, string> data = new Dictionary<string, string>()
        {
            { "levelTimeStamp" , p_levelTimeStamp },
            { "queId" , p_queId },
            { "playSeq" , p_playSeq },
            { "answer" , p_answer },
            { "type" , p_type },
            { "playTime" , p_playTime },
            { "hint1Num" , p_hint1Num },
            { "hint2Num" , p_hint2Num },
            { "hint3Num" , p_hint3Num },
            { "hint4Num" , p_hint4Num },
            { "wrongWord" , p_wrongWord },
            { "LevelABTestVersion" , AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().GetAbTestSpecialId() },
            { "LevelABTestAB" , AppEngine.SSystemManager.GetSystem<TestABWordLibSystem>().GetUserTestLib() },
            { "LoginID" , AppEngine.SSystemManager.GetSystem<PlayerLoginSystem>().playerCrazeID.Value },
            { "FBID" , AppEngine.SSystemManager.GetSystem<PlayerInfoSystem>().PlsyerFBID.Value },
            { "userId" , AppEngine.SSystemManager.GetSystem<PlayerLoginSystem>().deviceID.Value },
            { "appVersion" , Const.Version },
#if UNITY_IOS
            { "platform" , "ios" },
#elif UNITY_ANDROID
            { "platform" , "android" },
#endif
        };
        JObject rss =
            new JObject();
        foreach (string dataKey in data.Keys)
        {
            rss.Add(dataKey,data[dataKey]);
        }
        PostCommTable("DailyLevelWords_New", rss, "每日挑战过关表");
    }
    
    public static void LogPlayerException(string condition,string trace)
    {
        
#if UNITY_EDITOR
      return;  
#endif
        Dictionary<string, string> data = new Dictionary<string, string>();
        if (AppEngine.SSystemManager != null && AppEngine.SSystemManager.GetSystem<PlayerLoginSystem>() != null)
        {
            data.Add("userId",AppEngine.SSystemManager.GetSystem<PlayerLoginSystem>().playerCrazeID.Value);
        }
        else
        {
            data.Add("userId","unknown");
        }
            
        data.Add("condition",condition);
        data.Add("trace",trace);
        data.Add("ver",Const.Version);
        data.Add("platform",Application.platform.ToString());
        JObject rss =
            new JObject();
        foreach (string dataKey in data.Keys)
        {
            rss.Add(dataKey,data[dataKey]);
        }
        PostCommTable("CrazeException", rss, "用户错误词表");
    }
    
    private static void PostTable(string table, JObject record, string url, string des, Action<bool> resultCallback = null)
    {
        string json = record.ToString();
        Dictionary<string, string> formFields = new Dictionary<string, string>
        {
            {"row", json}
        };
        LogInfo(des + table + ":" + json);
        AppEngine.SDownloadManager.PostBytes(new PostListener(des + table), url, formFields);
    }
    private static void LogInfo(string text)
    {
        LoggerHelper.Log(TAG + " " + text);
    }
    private static void PostCommTable(string table, JObject record, string des, Action<bool> resultCallback = null)
    {
        try
        {
            record.Add(new JProperty("table", table));
        }
        catch (Exception e)
        {
            //Debug.LogException(e);
        }
        PostTable(table, record, BQURL, des, resultCallback);
    }

}

public class PostListener : IDownloadListener
{
    private string des;

    public PostListener(string des)
    {
        this.des = des;
    }
    public void OnError(int transactionId, string errorMessage)
    {
        Debug.LogError("上传失败" + errorMessage);
    }

    public void OnUpdate(int transactionId, float progress)
    {
    }

    public void OnSuccess(int transactionId, byte[] bytes)
    {
        LoggerHelper.Log("上传成功");
    }
}

public class VoiceFeedBackModel
{
    public string levelid;
    public string levelType;
    public string voiceType;
    public string question;
    public string recognition;
    public string answer;
    public string consumeTime;
    public string right;
    public string version;
    public string text;
    public string toggle1;
    public string toggle2;
    public string toggle3;
    public string toggle4;
    public string toggle5;
    public string toggle6;
    public string toggle7;
    public string toggle8;
}

public class VoiceInputModel {
    public string levelId;
    public string levelType;
    public string type;
    public string question;
    public string recognition;
    public string answer;
    public string consumeTime;
    public string right;
    public string version;

}

public class voicePermissionModel {
    public string userid;
    public string permission;
    public string insertTime;
}