using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using app.net;
using app.reward;
using app.tips;
using UnityEngine;

namespace app.onlineReward
{
    class OnlineItemScript
    {
        private ZaiXianItemUI mItemUI;
        private RewardItem mRewarditem;
        private RewardData mRewardData;

        private int index;

        public OnlineItemScript(ZaiXianItemUI itemUI)
        {
            mItemUI = itemUI;
            mItemUI.button.AddClickCallBack(OnClick);
        }

        public void SetData(RewardInfoData rewardInfoData,int index)
        {
            if (mRewardData == null)
            {
                mRewardData = new RewardData();
            }
            if (mRewarditem == null)
            {
                mRewarditem = new RewardItem(mItemUI.commonItem);
            }
            mRewardData.ParseDefaultItem(rewardInfoData.rewardStr,mRewarditem);
            this.index = index;
        }

        public void Refresh(int currentIndex)
        {
            if (index < currentIndex)
            {
                mItemUI.commonItem.icon.color = Color.gray;
            }
            else
            {
                mItemUI.commonItem.icon.color = Color.white;
            }
        }

        public void OnClick()
        {
            if (mRewarditem.rewarddata.type == RewardType.ITEM)
            {
                ItemTips.Ins.ShowTips(mRewarditem.rewarddata.id);
            }
        }
    }
}
