using System;
using System.Collections;
using app.db;

namespace app.reward
{
    public class RewardItemData
    {
        public RewardType type { get; private set; }
        public int currencyType { get; private set; }
        public int id { get; private set; }
        public int ivalue { get; private set; }
        public long lvalue { get; private set; }
        
        public void setData(RewardType type, int id, int value)
        {
            this.type = type;
            currencyType = 0;
            this.id = id;
            this.ivalue = value;
            this.lvalue = (long)value;
        }

        public void setData(RewardType type, int id, long value)
        {
            this.type = type;
            currencyType = 0;
            this.id = id;
            this.ivalue = (int)value;
            this.lvalue = value;
        }

        /// <summary>
        /// 货币
        /// </summary>
        /// <param name="currencyType"></param>
        /// <param name="currencyValue"></param>
        public void setCurrencyData(int currencyType, int currencyValue)
        {
            this.type = RewardType.CURRENCY;
            this.currencyType = currencyType;
            this.ivalue = currencyValue;
            this.lvalue = (long)currencyValue;
        }

        public string ToString()
        {
            string str = "";
            switch (type)
            {
                case RewardType.CURRENCY:
                    str +=  lvalue.ToString().ToString()+CurrencyTypeDef.GetCurrencyName(currencyType);
                break;
                case RewardType.ITEM:
                    ItemTemplate it = ItemTemplateDB.Instance.getTempalte(id);
                    if (it != null) str += it.name + "*" + ivalue.ToString();
                break;
                case RewardType.EXP:
                    str += lvalue.ToString() + "主角经验";
                break;
                case RewardType.REWARD_CALCULATE:
                break;
                case RewardType.REWARD_PUB_EXP:
                    str += lvalue.ToString() + "酒馆经验";
                break;
                case RewardType.REWARD_PET_EXP:
                    str += lvalue.ToString() + "宠物经验";
                break;
                case RewardType.REWARD_CORP_EXP:
                str += lvalue.ToString() + "帮派经验";
                break;
                case RewardType.REWARD_CORP_MONEY:
                str += lvalue.ToString() + "帮派资金";
                break;
                case RewardType.REWARD_CORP_CORDINATE:
                str += lvalue.ToString() + "帮贡";
                break;
                case RewardType.REWARD_RIDE_EXP:
                str += lvalue.ToString() + "骑宠经验";
                break;
                case RewardType.PET:
                    PetTemplate pt = PetTemplateDB.Instance.getTemplate(id);
                    if (pt!=null) str += pt.name + " 宠物";
                break;
            }
            return str;
        }
    }
}

