using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using Newtonsoft.Json.Utilities;
using UnityEngine;

/// <summary>
/// 精英关卡存档
/// </summary>
public class EliteData :BaseSyncHandData
{
    public Dictionary<int,ElitePref> elitedata = new Dictionary<int, ElitePref>();

    public ElitePref GetElitePref(int id)
    {
        if (elitedata.ContainsKey(id))
        {
            return elitedata[id];
        }
        ElitePref elitePref = new ElitePref();
        AddElitePref(id,elitePref);
        return elitePref;
    }

    public void AddElitePref(int id,ElitePref elitePref)
    {
        if (elitedata.ContainsKey(id))
        {
            elitedata[id] = elitePref;
        }
        else
        {
            elitedata[id] = elitePref;
        }

        AppEngine.SyncManager.Data.Elitedata.Value = this;
    }

    public void Save()
    {
        AppEngine.SyncManager.Data.Elitedata.Value = this;
    }
}

public class ElitePref
{
    /// <summary>
    /// 0代表未解锁1代表解锁了没有完成2代表完成了
    /// </summary>
    public string levelStatus = "000000000000";
    
    /// <summary>
    /// 0代表没有领取 1代表领取了
    /// </summary>
    public string rewardStatus = "000";
    public void SetRewardRewarded(int rewardIndex)
    {
        StringBuffer cache = new StringBuffer();
        for (int i = 0; i < rewardStatus.Length; i++)
        {
            if (i == rewardIndex)
            {
                cache.Append('1');
            }
            else
            {
                cache.Append(rewardStatus[i]);
            }
        }
        rewardStatus = cache.ToString();
        AppEngine.SyncManager.Data.Elitedata.Value.Save();
    }
    public void SetLevelUnlock(int levelIndex)
    {
        StringBuffer cache = new StringBuffer();
        for (int i = 0; i < levelStatus.Length; i++)
        {
            if (i == levelIndex)
            {
                cache.Append('1');
            }
            else
            {
                cache.Append(levelStatus[i]);
            }
        }
        levelStatus = cache.ToString();
        AppEngine.SyncManager.Data.Elitedata.Value.Save();
    }
    
    public void SetLevelPass(int levelIndex)
    {
        StringBuffer cache = new StringBuffer();
        for (int i = 0; i < levelStatus.Length; i++)
        {
            if (i == levelIndex)
            {
                cache.Append('2');
            }
            else
            {
                cache.Append(levelStatus[i]);
            }
        }
        levelStatus = cache.ToString();
        AppEngine.SyncManager.Data.Elitedata.Value.Save();
    }

    public int GetCurrentStar()
    {
        int star = 0;
        for (int i = 0; i < levelStatus.Length; i++)
        {
            if (levelStatus[i] == '2')
            {
                star += CommUtil.GetLevelStar(AppEngine.SSystemManager.GetSystem<EliteSystem>().GetCurrentWorld()
                    .stars[i]);
            }
        }

        return star;
    }
}
