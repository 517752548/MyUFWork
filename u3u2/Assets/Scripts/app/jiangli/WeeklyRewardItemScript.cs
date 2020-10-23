using System.Collections.Generic;
using app.net;
using app.reward;
using app.tips;
using app.utils;
using UnityEngine;

namespace app.jiangli
{
    class WeeklyRewardItemScript
    {
        private WeeklyRewardItemUI itemUI;
        public int index;
        private RewardItem mRewardItemLeft;
        private RewardItem mRewardItemRight;
        public GoodActivityRewardInfos rewardInfo;
        private List<RewardItem> mRewardItems; 


        public WeeklyRewardItemScript(int index,WeeklyRewardItemUI itemUI)
        {
            this.itemUI = itemUI;
            this.index = index;
            itemUI.recieveButton.AddClickCallBack(OnClickReward);
        }

        public void SetData(int index,GoodActivityRewardInfos rewardInfo)
        {
            this.rewardInfo = rewardInfo;
            if (mRewardItemLeft == null)
            { 
                mRewardItemLeft = new RewardItem(itemUI.leftItem);
            }

            if (mRewardItemRight == null)
            {
                mRewardItemRight = new RewardItem(itemUI.rightItem);
            }
            if (mRewardItems == null)
            {
                mRewardItems = new List<RewardItem>();
            }

            mRewardItems.Clear();
            mRewardItems.Add(mRewardItemLeft);
            mRewardItems.Add(mRewardItemRight);

            SetItemData(index);
            SetButtonInfo();
        }

        private void SetItemData(int index)
        {
            RewardData rewardData = new RewardData();
            rewardData.Parse(rewardInfo.rewardData,mRewardItems);


            itemUI.textDay.text = string.Format("第 {0} 天",index + 1);
            itemUI.textDescrip.text = rewardInfo.desc;

            itemUI.leftButton.AddClickCallBack(OnclickInfo);
            itemUI.rightButton.AddClickCallBack(OnclickInfo);
        }

        private void SetButtonInfo()
        {
            if (rewardInfo.hasGiveKey)
            {
                itemUI.objHaveRecieve.SetActive(true);
                itemUI.recieveButton.gameObject.SetActive(false);
            }
            else
            {
                itemUI.objHaveRecieve.SetActive(false);
                itemUI.recieveButton.gameObject.SetActive(true);
                if (rewardInfo.canGiveKey)
                {
                    if (!itemUI.recieveButton.IsInteractable())
                    {
                        ColorUtil.DeGray(itemUI.recieveButton);
                        itemUI.recieveButton.interactable = true;
                    }
                }
                else
                {
                    if (itemUI.recieveButton.IsInteractable())
                    {
                        itemUI.recieveButton.interactable = false;
                        ColorUtil.Gray(itemUI.recieveButton);
                    }
                }

                itemUI.recieveButton.enabled = rewardInfo.canGiveKey;

            }
        }

        private void OnClickReward()
        {
            if (rewardInfo.canGiveKey)
            {
                GoodactivityCGHandler.sendCGGoodActivityGetBonus(rewardInfo.activityId,rewardInfo.targetId);
            }
        }

        private void OnclickInfo(GameObject go)
        {
            if (go == itemUI.leftButton.gameObject)
            {
                if (mRewardItemLeft.rewarddata.type == RewardType.ITEM)
                {
                    ItemTips.Ins.ShowTips(mRewardItemLeft.rewarddata.id);
                }
            }
            else if (go == itemUI.rightButton.gameObject)
            {
                if (mRewardItemRight.rewarddata.type == RewardType.ITEM)
                {
                    ItemTips.Ins.ShowTips(mRewardItemRight.rewarddata.id);
                }
            }
            
        }

    }
}
