using System.Collections.Generic;
using app.net;
using app.reward;
using app.tips;
using app.utils;
using UnityEngine;

namespace app.jiangli
{
    class LevelRewardItemScript
    {
        public LevelRewardItemUI itemUI;

        private List<RewardItem> rewardItems;

        private GoodActivityRewardInfos rewardInfo;

        private RewardData mReaRewardData;

        private bool isInit = false;

        public LevelRewardItemScript(LevelRewardItemUI itemUI)
        {
            this.itemUI = itemUI;
        }

        public void SetData(GoodActivityRewardInfos rewardInfo)
        {
            if (rewardItems == null)
            {
                rewardItems = new List<RewardItem>();
            }

            rewardItems.Clear();

            if (mReaRewardData == null)
            {
                mReaRewardData = new RewardData();
            }

            this.rewardInfo = rewardInfo;

            for (int i = 0; i < itemUI.commonUIs.Count; i++)
            {
                RewardItem rewardItem = new RewardItem(itemUI.commonUIs[i]);
                rewardItems.Add(rewardItem);
            }

            if (!isInit)
            {
                isInit = true;
                InitButtonDelegate();
            }

            mReaRewardData.Parse(rewardInfo.rewardData, rewardItems);

            HandleButton();
        }


        private void HandleButton()
        {
            if (rewardInfo.hasGiveKey)
            {
                itemUI.buttonReceive.gameObject.SetActive(false);
                itemUI.objHaveReveive.SetActive(true);
            }
            else
            {
                itemUI.buttonReceive.gameObject.SetActive(true);
                itemUI.objHaveReveive.SetActive(false);
                if (rewardInfo.canGiveKey)
                {
                    if (!itemUI.buttonReceive.IsInteractable())
                    {
                        ColorUtil.DeGray(itemUI.buttonReceive);
                        itemUI.buttonReceive.interactable = true;
                    }
                }
                else
                {
                    if (itemUI.buttonReceive.IsInteractable())
                    {
                        itemUI.buttonReceive.interactable = false;
                        ColorUtil.Gray(itemUI.buttonReceive);
                    }
                }
                itemUI.buttonReceive.enabled = rewardInfo.canGiveKey;
            }

            itemUI.textTarget.text = rewardInfo.desc;
        }

        private void InitButtonDelegate()
        {
            itemUI.buttonReceive.SetClickCallBack(OnClickReceive);
            for (int i = 0; i < itemUI.gameButtons.Count; i++)
            {
                itemUI.gameButtons[i].AddClickCallBack(OnClickItem);
            }
        }

        private void OnClickReceive()
        {
            if (rewardInfo.canGiveKey && !rewardInfo.hasGiveKey)
            {
                GoodactivityCGHandler.sendCGGoodActivityGetBonus(rewardInfo.activityId, rewardInfo.targetId);
            }
            GuideManager.Ins.RemoveGuide(GuideIdDef.LevelReward);
        }

        private void OnClickItem(GameObject obj)
        {
            int index = GetIndex(obj);
            if (index > -1 && index < rewardItems.Count)
            {
                if (rewardItems[index].rewarddata == null)
                {
                    return;
                }
                if (rewardItems[index].rewarddata.type == RewardType.ITEM)
                {
                    ItemTips.Ins.ShowTips(rewardItems[index].rewarddata.id);
                }
            }
        }

        private int GetIndex(GameObject obj)
        {
            for (int i = 0; i < itemUI.gameButtons.Count; i++)
            {
                if (obj == itemUI.gameButtons[i].gameObject)
                {
                    return i;
                }
            }
            return -1;
        }



    }
}
