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
    public int currentLevelID = 11;
    private CrossLevelEntity level;
    /// <summary>
    /// 能否展示精英关卡的ui，有提前展示逻辑
    /// </summary>
    private bool canShowEliteUI = false;
    private EliteConfig currentConfig = null;
    /// <summary>
    /// 提前八小时展示
    /// </summary>
    private const long ShowTime = 28800000;
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

    /// <summary>
    /// 是否有即将到来的新关卡
    /// </summary>
    /// <returns></returns>
    public EliteWorld GetComingElite()
    {
        if (currentConfig != null && AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value >= currentConfig.data.init.startLevel)
        {
            long currentTimespan = XUtils.GetRealTimeStamp();
            for (int i = 0; i < currentConfig.data.list.Count; i++)
            {
                if (ShowTime >= (currentConfig.data.list[i].startTime - currentTimespan) && ( currentConfig.data.list[i].startTime - currentTimespan) >= 0 )
                {
                    return currentConfig.data.list[i];
                }
            }
        }

        return null;
    }

    /// <summary>
    /// 是否可以显示new标签
    /// </summary>
    /// <returns></returns>
    public bool CanShowNew()
    {
        if (currentConfig != null && AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value >= currentConfig.data.init.startLevel)
        {
            long currentTimespan = XUtils.GetRealTimeStamp();
            for (int i = 0; i < currentConfig.data.list.Count; i++)
            {
                if (currentConfig.data.init.showTime >=(currentTimespan - currentConfig.data.list[i].startTime) && (currentTimespan - currentConfig.data.list[i].startTime) >= 0 )
                {
                    return true;
                }
            }
        }

        return false;
    }

    public bool IsReplayCurLevel()
    {
        return false;
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
