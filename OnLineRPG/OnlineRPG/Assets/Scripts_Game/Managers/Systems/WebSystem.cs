using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using Newtonsoft.Json;
using Scripts_Game.Managers;
using UnityEngine;

public class WebSystem : ISystem
{
    private WebBox _webBoxConfig;
    private RecordExtra.StringPrefData _playerGetReward;
    private List<string> playerGetRewardsList = new List<string>();

    public override BaseState Init(StateMachine stateMachine, string tag = "")
    {
        _playerGetReward = new RecordExtra.StringPrefData("playerGetWebBox","");
        playerGetRewardsList = JsonConvert.DeserializeObject<List<string>>(_playerGetReward.Value);
        if (playerGetRewardsList == null)
        {
            playerGetRewardsList = new List<string>();
        }
        
        return base.Init(stateMachine);
    }

    public override void InitSystem()
    {
        _webBoxConfig = PreLoadManager.GetPreLoadConfig<WebBox>(ViewConst.asset_WebBox_ProbabilityPool);
        CheckReward();
        base.InitSystem();
    }

    /// <summary>
    /// 检查补发奖励
    /// </summary>
    public void CheckReward()
    {
        string rewardId = GetLastTargetID(AppEngine.SyncManager.Data.fansNumber.Value);
        if (!playerGetRewardsList.Contains(rewardId))
        {
            string rewardid = GetLastTargetReward(AppEngine.SyncManager.Data.fansNumber.Value);
            RewardMgr.RewardInventory(RewardMgr.GetRewards(rewardid), RewardSource.WebBox);
            GivePlayerReward(rewardId);
        }
    }
    

    /// <summary>
    /// 获取下个阶段的目标粉丝值
    /// </summary>
    /// <returns></returns>
    public int GetNextTarget(int fansNum)
    {
        for (int i = 0; i < _webBoxConfig.dataList.Count; i++)
        {
            if (_webBoxConfig.dataList[i].FanTarget > fansNum)
            {
                return _webBoxConfig.dataList[i].FanTarget;
            }
        }
        return 0;
    }

    public string GetNestTargetRewardId(int fansNum)
    {
        for (int i = 0; i < _webBoxConfig.dataList.Count; i++)
        {
            if (_webBoxConfig.dataList[i].FanTarget > fansNum)
            {
                return _webBoxConfig.dataList[i].RewardId;
            }
        }
        return "";
    }
    public int GetCurrentTargetRegion(int fansNum)
    {
        int last = 0;
        int next = 0;
        for (int i = 0; i < _webBoxConfig.dataList.Count; i++)
        {
            if (_webBoxConfig.dataList[i].FanTarget >= fansNum)
            {
                next = _webBoxConfig.dataList[i].FanTarget;
                return next - last;
            }
            else
            {
                last = _webBoxConfig.dataList[i].FanTarget;
            }
        }

        return 0;
    }

    public int GetLastTarget(int fans)
    {
        int last = 0;
        for (int i = 0; i < _webBoxConfig.dataList.Count; i++)
        {
            if (_webBoxConfig.dataList[i].FanTarget >= fans)
            {
                return last;
            }
            else
            {
                last = _webBoxConfig.dataList[i].FanTarget;
            }
        }

        return 0;
    }

    public string GetLastTargetReward(int fans)
    {
        string last = "";
        for (int i = 0; i < _webBoxConfig.dataList.Count; i++)
        {
            if (_webBoxConfig.dataList[i].FanTarget >= fans)
            {
                return last;
            }
            else
            {
                last = _webBoxConfig.dataList[i].RewardId;
            }
        }

        return "";
    }
    
    public string GetLastTargetID(int fans)
    {
        string last = "";
        for (int i = 0; i < _webBoxConfig.dataList.Count; i++)
        {
            if (_webBoxConfig.dataList[i].FanTarget >= fans)
            {
                return _webBoxConfig.dataList[i].ID;
            }
            else
            {
                last = _webBoxConfig.dataList[i].ID;
            }
        }

        return "";
    }

    /// <summary>
    /// 玩家已经奖励的所有id
    /// </summary>
    /// <param name="rewardId"></param>
    public void GivePlayerReward(string rewardId)
    {
        if (!playerGetRewardsList.Contains(rewardId))
        {
            playerGetRewardsList.Add(rewardId);
        }

        _playerGetReward.Value = JsonConvert.SerializeObject(playerGetRewardsList);
    }
}
