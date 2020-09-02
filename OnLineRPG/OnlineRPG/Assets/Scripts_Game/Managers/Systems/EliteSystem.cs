using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using EventUtil;
using Newtonsoft.Json;
using PathC;
using UnityEngine;

public class EliteSystem : ISystem
{
    public int currentWordID = 1;
    /// <summary>
    /// 这个从1开始，计算的时候-1
    /// </summary>
    public int currentLevelID = 11;
    private CrossLevelEntity level;
    public EliteConfig currentConfig = null;
    /// <summary>
    /// 能否展示精英关卡的ui，有提前展示逻辑
    /// </summary>
    private bool canShowEliteUI = false;
    public override void InitSystem()
    {
        base.InitSystem();
    }

    /// <summary>
    /// 是否可以在入口和活动界面显示精英关卡的UI
    /// </summary>
    /// <returns></returns>
    public bool CanShowEliteUI()
    {
        if (currentConfig == null)
        {
            return false;
        }
        return canShowEliteUI;
    }
    public void OnConfigLoaded()
    {
        currentConfig = WebConfigMgr.Get<EliteConfig>();
        Debug.Log(JsonConvert.SerializeObject(currentConfig));
        if (currentConfig != null && AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value >= currentConfig.data.init.startLevel)
        {
            //关卡满足条件了
            canShowEliteUI = true;
        }
        else
        {
            canShowEliteUI = false;
        }
        EventDispatcher.TriggerEvent(GlobalEvents.EliteConfigLoad);
    }

    public EliteWorld GetCurrentWorld()
    {
        for (int i = 0; i < currentConfig.data.list.Count; i++)
        {
            if (currentConfig.data.list[i].id == currentWordID)
            {
                return currentConfig.data.list[i];
            }
        }

        return null;
    }
    public int GetTotalSubworld()
    {
        if (currentConfig != null)
        {
            return currentConfig.data.list.Count;
        }

        return 1;
    }
    
    public List<EliteWorld> GetAllSubWorld()
    {
        if (currentConfig != null)
        {
            return currentConfig.data.list;
        }
        return null;
    }
    
    public EliteWorld GetLastSubWorld()
    {
        EliteWorld world = null;
        if (currentConfig != null)
        {
            for (int i = 0; i < currentConfig.data.list.Count; i++)
            {
                if (world == null)
                {
                    world = currentConfig.data.list[i];
                }

                if (world.order < currentConfig.data.list[i].order)
                {
                    world = currentConfig.data.list[i];
                }
            }
        }
        return world;
    }
    /// <summary>
    /// 是否可以显示new标签
    /// </summary>
    /// <returns></returns>
    public bool CanShowNew()
    {
        bool hasNew = false;
        if (currentConfig != null && AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value >= currentConfig.data.init.startLevel)
        {
            long currentTimespan = XUtils.GetRealTimeStamp();
            for (int i = 0; i < currentConfig.data.list.Count; i++)
            {
                if (currentConfig.data.init.showTime * 3600000 >=(currentTimespan - currentConfig.data.list[i].startTime) && (currentTimespan - currentConfig.data.list[i].startTime) >= 0 )
                {
                    hasNew = true;
                    currentConfig.data.list[i].isNew = true;
                }
            }
        }

        return hasNew;
    }

    /// <summary>
    /// 获取解锁关卡
    /// </summary>
    /// <returns></returns>
    public int GetUnLockLevel()
    {
        return currentConfig.data.init.startLevel;
    }

    public bool IsReplayCurLevel()
    {
        char status = AppEngine.SyncManager.Data.Elitedata.Value.GetElitePref(currentWordID)
            .levelStatus[currentLevelID - 1];
        if (status == '2')
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// 获得当前关卡的星星数量
    /// </summary>
    /// <returns></returns>
    public int GetCurrentLevelStars()
    {
        int stars =  CommUtil.GetLevelStar(GetCurrentWorld().stars[currentLevelID - 1]);
        return stars;
    }
    
    /// <summary>
    /// 完成了当前关卡
    /// </summary>
    public void FinishCurrentLevel()
    {
        AppEngine.SyncManager.Data.Elitedata.Value.GetElitePref(currentWordID).SetLevelPass(currentLevelID - 1);
    }
    /// <summary>
    /// 获取当前精英关卡
    /// </summary>
    /// <returns></returns>
    public CrossLevelEntity GetCurrentCrossLevel()
    {
        return level;
    }
    public void LoadEliteLevel(Action<bool> callback)
    {
        WebRequestGetUtility.Instance.Get(string.Format(PathLevelConst.ServerLevelURL.Replace("/Level/","/Elite/") + "/{0}/{1}.txt",currentWordID,currentLevelID),
            op =>
            {
                if (op.isDone && !op.isHttpError && !op.isNetworkError)
                {
                    Debug.LogError(op.downloadHandler.text);
                    CrossLevelEntity level =
                        JsonConvert.DeserializeObject<CrossLevelEntity>(op.downloadHandler.text);
                    level.LoadOnLineImage(ok =>
                    {
                        if (ok)
                        {
                            this.level = level;
                            callback?.Invoke(true);
                        }
                        else
                        {
                            callback?.Invoke(false);
                        }
                    });
                }
                else
                {
                    Debug.Log(string.Format(PathLevelConst.ServerLevelURL.Replace("/Level/","/Elite/") + "/{0}/{1}.txt",currentWordID,currentLevelID));
                    callback?.Invoke(false);
                }
            });
    }
}
