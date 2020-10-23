using UnityEngine;
using System.Collections;
using app.db;
using app.tips;
using app.reward;

namespace app.xianhu
{
    public class XianHuItem
    {
        public CommonItemUI m_item;
        public RewardItemData m_rewarditemdata;

        public XianHuItem(GameObject item)
        {
            m_item = item.AddComponent<CommonItemUI>();
            m_item.Init();
        }

        public void SetReward(RewardItemData reward)
        {
            m_rewarditemdata = reward;
            m_item.ClickCommonItemHandler = itemclick;
        }


        public void SetItemNum(int itemnum)
        {
            m_item.num.text = itemnum.ToString();
        }

        private void itemclick()
        {
            if(null != m_rewarditemdata)
            {
                RewardType rewardType = m_rewarditemdata.type;
                switch (rewardType)
                {
                    case RewardType.CURRENCY:
                        //奖励类型为货币

                        break;
                    case RewardType.ITEM:
                        //奖励类型为物品
                        ItemTemplate temp = ItemTemplateDB.Instance.getTempalte(m_rewarditemdata.id);
                        if (null != temp)
                        {
                            ItemTips.Ins.ShowTips(temp);
                        }
                        break;
                    case RewardType.EXP:
                        //奖励类型为经验

                        break;
                    case RewardType.REWARD_PUB_EXP:
                        //奖励类型为经验


                        break;
                    case RewardType.REWARD_PET_EXP:
                        //奖励类型为经验


                        break;
                }
            }
        }
        
    }
}
