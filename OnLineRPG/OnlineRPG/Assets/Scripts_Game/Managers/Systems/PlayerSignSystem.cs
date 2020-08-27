using BetaFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using EventUtil;
using UnityEngine;

public class PlayerSignSystem : ISystem
{
    private PlayerSign _playerSign;
    public override void InitSystem()
    {
        _playerSign = PreLoadManager.GetPreLoadConfig<PlayerSign>(ViewConst.asset_PlayerSign_Sign);
        
        UpdateNextSignStartTime();
        base.InitSystem();
    }
    
    public DateTime NextSignStartTime { get; private set; }

    public bool IsCanSign()
    {
        return IsSignUnlocked() && AppEngine.STimeHeart.IsTimeReal && !IsTodaySignCompleted();
    }

    public void DelayRefresh()
    {
        if (!AppEngine.STimeHeart.IsTimeReal)
        {
            AppEngine.STimeHeart.OnTimeUpdate += OnWebTimeGot;
        }
    }

    private void OnWebTimeGot()
    {
        HomeRootFsmManager.CheckRefresh();
        AppEngine.STimeHeart.OnTimeUpdate -= OnWebTimeGot;
    }

    public bool IsSignUnlocked()
    {
        return AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value >= 5;
    }

    public bool IsTodaySignCompleted()
    {
        DateTime lastSignDate = AppEngine.SyncManager.Data.LastSignDate.Date;
        DateTime utcNow = AppEngine.STimeHeart.RealTime;
        return utcNow.Subtract(lastSignDate).TotalDays < 1 && utcNow.Day == lastSignDate.Day;
    }

    public int TodaySignIndex {
        get
        {
            int signTimes = AppEngine.SyncManager.Data.SignTimes.Value;
            if (signTimes == 0)
                return 0;
            if (IsTodaySignCompleted())
                return signTimes - 1;
            return signTimes;
        }
    }

    public int Round => (AppEngine.SyncManager.Data.SignTimes.Value / 7) + 1;

    public void CheckSign(Action overCallback)
    {
        if (IsCanSign())
        {
            UIManager.OpenUIAsync(ViewConst.prefab_SignDialog, null, true, overCallback);
            //overCallback?.Invoke();
        }
        else
        {
            overCallback?.Invoke();
        }
    }

    
    /// <summary>
    /// 获取指定天的奖励ID
    /// </summary>
    /// <param name="dayIndex">从1开始</param>
    /// <returns></returns>
    public string GetSignGift(int dayIndex)
    {
        dayIndex--;
        if (dayIndex > 6)
            dayIndex = (dayIndex - 7) % 7 + 7;
        dayIndex++;
        for (int i = 0; i < _playerSign.dataList.Count; i++)
        {
            if (dayIndex.ToString() == _playerSign.dataList[i].ID )
            {
                return _playerSign.dataList[i].RewardId;
            }
        }
        return "";
    }
    
    /// <summary>
    /// 获取指定天的宝箱类型
    /// </summary>
    /// <param name="dayIndex">从1开始</param>
    /// <returns></returns>
    public int GetSignGiftBox(int dayIndex)
    {
        dayIndex--;
        if (dayIndex > 6)
            dayIndex = (dayIndex - 7) % 7 + 7;
        dayIndex++;
        for (int i = 0; i < _playerSign.dataList.Count; i++)
        {
            if (dayIndex.ToString() == _playerSign.dataList[i].ID )
            {
                return _playerSign.dataList[i].BoxStyle;
            }
        }
        return 0;
    }

    public string GetTodaySignRewardId()
    {
        return GetSignGift(AppEngine.SyncManager.Data.SignTimes.Value+1);
    }

    public void CompleteSign()
    {
        AppEngine.SyncManager.Data.SignTimes.Value++;
        AppEngine.SyncManager.Data.LastSignDate.Date = AppEngine.STimeHeart.RealTime;
        UpdateNextSignStartTime();
    }

    private void UpdateNextSignStartTime()
    {
        DateTime lastSignDate = AppEngine.SyncManager.Data.LastSignDate.Date;
        NextSignStartTime = new DateTime(lastSignDate.Year, lastSignDate.Month, 
            lastSignDate.Day, 0, 0, 0).AddDays(1);
    }

    public void ResetLastSignDateForTest()
    {
        AppEngine.SyncManager.Data.LastSignDate.Date = DateTime.MinValue;
    }

    public void SetSignTimesForTest(int times)
    {
        AppEngine.SyncManager.Data.SignTimes.Value = times;
    }
}
