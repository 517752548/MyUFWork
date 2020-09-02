using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using BetaFramework;
using Data.Request;
using Newtonsoft.Json;

public class DailyOneWordSystem : ISystem
{
    private List<OneWordLevel> _levels;
    private List<OneWordLevel> _ex_levels;
    private OneWordLevel curLevel = null;
    private DateTime nextLevelTime;
    private OneWordData configData;
    
    public override void InitSystem()
    {
        _levels = new List<OneWordLevel>();
        _ex_levels = new List<OneWordLevel>();
        Load();
        //TimersManager.SetLoopableTimer(1f, UpdateTime);
        base.InitSystem();
    }

    private float _deltaTime = 0f;
    public override void Execute(float deltaTime)
    {
        base.Execute(deltaTime);
        _deltaTime += deltaTime;
        if (_deltaTime > 1f)
        {
            _deltaTime = 0;
            UpdateTime();
        }
    }

    public void Load()
    {
        if (_levels.Count > 2)
            return;
        string json = JsonConvert.SerializeObject(new BaseRequestParam(ServerCode.OneWordLib));
        
        WebRequestPostUtility.Instance.PostJson(Const.ServerUrl, (back) =>
        {
            if (back.isNetworkError || back.isHttpError)
            {
                LoggerHelper.Error("每日一词请求失败 " + back.error);
                Reload();
            }
            else
            {
                LoggerHelper.Log(back.downloadHandler.text);
                OneWordResponseData response = JsonConvert.DeserializeObject<OneWordResponseData>(back.downloadHandler.text);
                if (response.code != 200)
                {
                    LoggerHelper.Error("每日一词请求失败 code=" + response.code);
                    Reload();
                }
                else
                {
                    OnLoaded(response.data);
                }
            }
            
        }, json);
    }

    private void OnLoaded(OneWordData data)
    {
        if (data != null)
        {
            configData = data;
            _levels = configData.Levels;
            _ex_levels = configData.ExLevels;
            _levels.Sort((x, y) => (int) (x.StartTimeStamp - y.StartTimeStamp));
            _ex_levels.Sort((x, y) =>
            {
                if (x.StartTimeStamp == y.StartTimeStamp)
                {
                    return y.Order - x.Order;
                }
                return (int) (x.StartTimeStamp - y.StartTimeStamp);
            });
            CheckCurLevel();
            AppEngine.SSystemManager.GetSystem<NotificationSystem>().SendNotification();
        }
        else
        {
            LoggerHelper.Error("每日一词请求失败 data error");
            Reload();
        }
    }

    private void Reload()
    {
        TimersManager.SetTimer(10f, Load);
    }

    private void CheckCurLevel()
    {
        curLevel = FindLevelOfTime(UtcNow);
        if (curLevel == null)
        {
            nextLevelTime = DateTime.MaxValue;
        }
        else
        {
            int nextIndex = _levels.IndexOf(curLevel) + 1;
            if (nextIndex < _levels.Count)
                nextLevelTime = _levels[nextIndex].UtcStartTime();
            else
            {
                nextLevelTime = DateTime.MaxValue;
            }
        }
    }

    public void UpdateTime()
    {
        if (curLevel == null)
            CheckCurLevel();
        if (curLevel == null)
        {
            _OnTimeUpdate?.Invoke(0);
            return;
        }
        var sec = (int) nextLevelTime.Subtract(UtcNow).TotalSeconds;
        if (sec <= 0)
        {
            sec = 0;
            CheckCurLevel();
        }
        _OnTimeUpdate?.Invoke(sec);
    }

    public bool IsCompleted => curLevel != null && AppEngine.SyncManager.Data.OneWordLastCompleteID.Value.Equals(curLevel.LevelID());

    public bool IsExLevelEnable
    {
        get
        {
            if (curLevel != null && AppEngine.SyncManager.Data.OneWordExLevelStartID.Value.Equals(curLevel.LevelID()))
            {
                var level = ExLevel;
                if (level != null && !IsExLevelCompleted(level.LevelID()))
                    return true;
            }

            return false;
        }
    }

    private bool IsExLevelCompleted(string id)
    {
        return AppEngine.SyncManager.Data.OneWordLastCompleteExID.Value.Split(',').Contains(id);
    }

    public bool IsAllCompleted => IsCompleted && !IsExLevelEnable;

    public OneWordLevel ExLevel
    {
        get
        {
            if (string.IsNullOrEmpty(AppEngine.SyncManager.Data.OneWordCurExID.Value) || _ex_levels.Count == 0)
                return null;
            return _ex_levels.Find(level => level.LevelID().Equals(AppEngine.SyncManager.Data.OneWordCurExID.Value));
        }
    }

    public bool CanRefreshExLevel
    {
        get
        {
            var level = GetExLevel();
            if (level == null || !IsCompleted || AppEngine.SyncManager.Data.OneWordCurExID.Value.Equals(level.LevelID()))
                return false;
            return true;
        }
    }

    private event Action<int> _OnTimeUpdate;
    public event Action<int> OnTimeUpdate
    {
        add
        {
            if (_OnTimeUpdate == null || !_OnTimeUpdate.GetInvocationList().Contains(value))
            {
                _OnTimeUpdate += value;
            }
        }

        remove
        {
            if (_OnTimeUpdate != null && _OnTimeUpdate.GetInvocationList().Contains(value))
            {
                _OnTimeUpdate -= value;
            }
        }
    }

    private void CheckTime()
    {
        while (curLevel != null && UtcNow > nextLevelTime)
        {
            CheckCurLevel();
        }
    }
    
    private DateTime UtcNow => AppEngine.STimeHeart.RealTime;

    public bool IsReady()
    {
        return curLevel != null && AppEngine.STimeHeart.IsTimeReal;
    }

    public bool IsUnlocked()
    {
        if (configData != null)
            return configData.StartLevel <= AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value;
        return false;
    }

    public int GetUnlockLevel()
    {
        if (configData != null)
            return configData.StartLevel;
        return 17;
    }

    public bool IsEnable()
    {
        if (curLevel != null && IsUnlocked())
            return true;
        return false;
    }

    public OneWordLevel GetCurrentGameLevel()
    {
        if (IsExLevelEnable)
            return ExLevel;
        return curLevel;
    }

    public void CompleteCurLevel(string levelID)
    {
        Debug.LogError("完成了" + levelID);
        if (AppEngine.SyncManager.Data.OneWordCurExID.Value.Equals(levelID))
        {
            string[] ids = AppEngine.SyncManager.Data.OneWordLastCompleteExID.Value.Split(',');
            
            if (ids.Length > 0)
            {
                int start = 0;
                if (ids.Length > 10)
                {
                    start = ids.Length - 9;
                }
                var _id = ids[start];
                for (int i = start + 1; i < ids.Length; i++)
                {
                    _id = _id + "," + ids[i];
                }
                AppEngine.SyncManager.Data.OneWordLastCompleteExID.Value = _id + "," + levelID;
            }
            else
            {
                AppEngine.SyncManager.Data.OneWordLastCompleteExID.Value = levelID;
            }
            return;
        }
        AppEngine.SyncManager.Data.OneWordLastCompleteID.Value = levelID;
    }

    public void SetExLevelEnable(string levelID)
    {
        var level = GetExLevel();
        if (level != null)
        {
            if (!IsExLevel(levelID))
            {
                AppEngine.SyncManager.Data.OneWordExLevelStartID.Value = levelID;
            }
            AppEngine.SyncManager.Data.OneWordCurExID.Value = level.LevelID();
        }
    }
    
    public bool IsDateNodeLevelCompleted(DateTime dtNode)
    {
        if (curLevel == null)
            return false;
        DateTime utc = LocalTimeToUtc(dtNode);
        if (utc < nextLevelTime && utc > curLevel.UtcStartTime())
            return IsCompleted;
        return false;
    }

    public string GetDateNodeLevelQuestion(DateTime dtNode)
    {
        var level = FindLevelOfTime(dtNode);
        return level == null ? null : level.Question;
    }

    private DateTime LocalTimeToUtc(DateTime localTime)
    {
        return DateTime.UtcNow + (localTime - DateTime.Now);
    }

    private OneWordLevel FindLevelOfTime(DateTime utc)
    {
        if (_levels == null || _levels.Count == 0)
            return null;
        if (utc < _levels[0].UtcStartTime())
            return null;
        for (var i = 1; i < _levels.Count; i++)
        {
            var level = _levels[i];
            if (utc < level.UtcStartTime())
                return _levels[i-1];
        }

        return null;
    }

    private OneWordLevel GetExLevel()
    {
        DateTime utc = UtcNow;
        if (_ex_levels == null || _ex_levels.Count == 0)
            return null;
        if (utc < _ex_levels[0].UtcStartTime())
            return null;
        for (var i = 1; i < _ex_levels.Count; i++)
        {
            var level = _ex_levels[i];
            if (utc < level.UtcStartTime())
            {
                for (int j = i-1; j >= 0; j--)
                {
                    if (utc > _ex_levels[j].UtcStartTime() && !IsExLevelCompleted(_ex_levels[j].LevelID()))
                    {
                        return _ex_levels[j];
                    }
                }
                return null;
            }
        }
        for (int j = _ex_levels.Count-1; j >= 0; j--)
        {
            if (utc > _ex_levels[j].UtcStartTime() && !IsExLevelCompleted(_ex_levels[j].LevelID()))
            {
                return _ex_levels[j];
            }
        }
        return null;
        //return _ex_levels[_ex_levels.Count-1];
        //return null;
    }

    private bool IsExLevel(string levelId)
    {
        return _ex_levels?.Find(level => level.LevelID().Equals(levelId)) != null;
    }
}

public class OneWordResponseData : BaseResponseData<OneWordData>
{
}

public class OneWordData
{
    [JsonProperty("startLevel")]
    public int StartLevel;
    [JsonProperty("levels")]
    public List<OneWordLevel> Levels;
    [JsonProperty("ex_levels")]
    public List<OneWordLevel> ExLevels;
}

public class OneWordLevel
{
    [JsonProperty("order")]
    public int Order;
    [JsonProperty("startTimeStamp")]
    public long StartTimeStamp;
    [JsonProperty("questionId")]
    public string QuestionId;
    [JsonProperty("question")]
    public string Question;
    [JsonProperty("answer")]
    public string Answer;
    [JsonProperty("rewardId")]
    public int RewardId;
    
    public DateTime UtcStartTime()
    {
        return XUtils.TimeStampToUTCDateTime(StartTimeStamp);
    }

    public string LevelID()
    {
        return QuestionId;
    }
}