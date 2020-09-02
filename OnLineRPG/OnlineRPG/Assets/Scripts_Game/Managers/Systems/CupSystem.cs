using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Scripts_Game.Managers
{
    public class CupSystem : ISystem
    {
        private WebBox _webBoxConfig;
        private RecordExtra.ObjectPrefData<List<string>> playerClaimedList;

        public override void InitSystem()
        {
            playerClaimedList = new RecordExtra.ObjectPrefData<List<string>>("playerGetWebBox", new List<string>());
            _webBoxConfig = PreLoadManager.GetPreLoadConfig<WebBox>(ViewConst.asset_WebBox_ProbabilityPool);
            base.InitSystem();
        }

        public int GetCurTarget(int cup)
        {
            for (int i = 0; i < _webBoxConfig.dataList.Count; i++)
            {
                if (_webBoxConfig.dataList[i].FanTarget > cup)
                {
                    return _webBoxConfig.dataList[i].FanTarget;
                }
            }

            return 0;
        }

        public string GetCurTargetReward(int cup)
        {
            for (int i = 0; i < _webBoxConfig.dataList.Count; i++)
            {
                if (_webBoxConfig.dataList[i].FanTarget > cup)
                {
                    return _webBoxConfig.dataList[i].RewardId;
                }
            }

            return "";
        }

        public int GetCurrentTargetRegion(int cup)
        {
            int last = 0;
            int next = 0;
            for (int i = 0; i < _webBoxConfig.dataList.Count; i++)
            {
                if (_webBoxConfig.dataList[i].FanTarget >= cup)
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

        public int GetLastTarget(int cup)
        {
            int last = 0;
            for (int i = 0; i < _webBoxConfig.dataList.Count; i++)
            {
                if (_webBoxConfig.dataList[i].FanTarget >= cup)
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

        public string GetLastTargetReward(int cup)
        {
            string last = "";
            for (int i = 0; i < _webBoxConfig.dataList.Count; i++)
            {
                if (_webBoxConfig.dataList[i].FanTarget >= cup)
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

        public string GetLastTargetID(int cup)
        {
            string last = "";
            for (int i = 0; i < _webBoxConfig.dataList.Count; i++)
            {
                if (_webBoxConfig.dataList[i].FanTarget >= cup)
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
        /// <param name="targetId"></param>
        public void PlayerClaim(string targetId)
        {
            playerClaimedList.UpdateValue(list =>
            {
                if (!list.Contains(targetId))
                {
                    list.Add(targetId);
                }

                return list;
            });
        }

        public bool IsTargetClaimed(string targetId)
        {
            return playerClaimedList.Value.Contains(targetId);
        }
    }
}