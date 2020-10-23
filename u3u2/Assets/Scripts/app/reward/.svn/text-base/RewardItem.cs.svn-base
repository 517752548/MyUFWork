using app.item;
using UnityEngine.Events;

namespace app.reward
{
    public class RewardItem:CommonItemScript
    {
        public RewardItemData rewarddata;

        public RewardItem(CommonItemUI ui, UnityAction<ItemDetailData> clickHandler = null) : base(ui, clickHandler)
        {
        }

        public RewardItem(CommonItemUINoClick ui):base(ui)
        {
        }

        public void setRewardData(RewardItemData rewarditemdata)
        {
            rewarddata = rewarditemdata;
            if (rewarddata==null)
            {
                setEmpty();
                return;
            }
            clearData();
            switch (rewarddata.type)
            {
                case RewardType.CURRENCY:
                    {
                        setNumText(rewarddata.ivalue.ToString());
                        setCurrencyItem(rewarddata.currencyType);
                    }
                    break;
                case RewardType.ITEM:
                    {
                        setTemplate(rewarddata.id);
                        setNumText(rewarddata.ivalue.ToString());
                    }
                    break;
                case RewardType.EXP:
                    setCurrencyItem(CurrencyTypeDef.SKILL_POINT);
                    setName("主角经验");
                    setNumText(rewarddata.lvalue.ToString());
                    break;
                case RewardType.REWARD_PUB_EXP:
                    setCurrencyItem(CurrencyTypeDef.JIUGUAN_EXP);
                    setName("酒馆经验");
                    setNumText(rewarddata.lvalue.ToString());
                    break;
                case RewardType.REWARD_PET_EXP:
                    setCurrencyItem(CurrencyTypeDef.PET_EXP);
                    setName("宠物经验");
                    setNumText(rewarddata.lvalue.ToString());
                    break;
                case RewardType.REWARD_CORP_EXP:
                    setCurrencyItem(CurrencyTypeDef.CORP_EXP);
                    setName("帮派经验");
                    setNumText(rewarddata.lvalue.ToString());
                    break;
                case RewardType.REWARD_CORP_MONEY:
                    setCurrencyItem(CurrencyTypeDef.BANGPAI_ZIJIN);
                    setName("帮派资金");
                    setNumText(rewarddata.lvalue.ToString());
                    break;
                case RewardType.REWARD_CORP_CORDINATE:
                    setCurrencyItem(CurrencyTypeDef.BANGGONG);
                    setName("帮贡");
                    setNumText(rewarddata.lvalue.ToString());
                    break;
                case RewardType.REWARD_RIDE_EXP:
                    setCurrencyItem(CurrencyTypeDef.RIDE_EXP);
                    setName("骑宠经验");
                    setNumText(rewarddata.lvalue.ToString());
                    break;
                case RewardType.PET:
                    break;
                default:
                    break;
            }
        }

        public override void Destroy()
        {
            base.Destroy();
            rewarddata = null;
        }
    }
}
