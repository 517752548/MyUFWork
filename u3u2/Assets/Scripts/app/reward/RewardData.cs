using System;
using System.Collections;
using System.Collections.Generic;
using app.db;
using app.utils;
using app.net;
using minijson;

namespace app.reward
{
    public class RewardData
    {
        public List<RewardItemData> items = new List<RewardItemData>();

        public RewardData()
        {
        }

        public void ParseBattle(IDictionary data)
        {
            IDictionary reward = JsonHelper.GetDictData(RewardKeyDef.REAWRD, data);
            ParseReward(reward);

            IDictionary petData = JsonHelper.GetDictData(RewardKeyDef.PET,data);
            if (petData != null)
            {
                int id = JsonHelper.GetIntData(RewardKeyDef.PET_ID, petData);
                if (PropertyUtil.IsLegalID(id))
                {
                    int gene = JsonHelper.GetIntData(RewardKeyDef.PET_GENE, petData);
                    RewardItemData rewarddata = new RewardItemData();
                    rewarddata.setData(RewardType.PET, id, gene);
                    items.Add(rewarddata);
                }
            }
        }

        public void ParseReward(IDictionary reward)
        {
            if (reward != null)
            {
                items.Clear();
                IList rewardInfoList = JsonHelper.GetListData(RewardKeyDef.REWARD_INFO, reward);
                if (rewardInfoList != null)
                {
                    int len = rewardInfoList.Count;
                    for (int i = 0; i < len; i++)
                    {
                        IDictionary rewardInfo = (IDictionary)rewardInfoList[i];
                        int rewardType = JsonHelper.GetIntData(RewardKeyDef.REWARD_TYPE, rewardInfo);
                        RewardItemData rewarddata;
                        switch (rewardType)
                        {
                            case RewardKeyDef.REWARD_TYPE_CURRENCY:
                                //奖励类型为货币
                                IList currencyList = JsonHelper.GetListData(RewardKeyDef.REWARD_CONTENT, rewardInfo);
                                int currencyLen = currencyList.Count;
                                for (int j = 0; j < currencyLen; j++)
                                {
                                    IDictionary currency = (IDictionary)currencyList[j];
                                    int currencyType = JsonHelper.GetIntData(RewardKeyDef.CURRENCY_TYPE, currency);
                                    int currencyValue = JsonHelper.GetIntData(RewardKeyDef.CURRENCY_VALUE, currency);
                                    rewarddata = new RewardItemData();
                                    rewarddata.setCurrencyData(currencyType, currencyValue);
                                    items.Add(rewarddata);
                                }
                                break;
                            case RewardKeyDef.REWARD_TYPE_ITEM:
                                //奖励类型为物品
                                IList itemList = JsonHelper.GetListData(RewardKeyDef.REWARD_CONTENT, rewardInfo);
                                int itemsLen = itemList.Count;
                                for (int j = 0; j < itemsLen; j++)
                                {
                                    IDictionary itemData = (IDictionary)itemList[j];
                                    int itemId = JsonHelper.GetIntData(RewardKeyDef.ITEM_TEMP_ID, itemData);
                                    if (PropertyUtil.IsLegalID(itemId))
                                    {
                                        int itemNum = JsonHelper.GetIntData(RewardKeyDef.ITEM_NUM, itemData);
                                        rewarddata = new RewardItemData();
                                        rewarddata.setData(RewardType.ITEM, itemId, itemNum);
                                        items.Add(rewarddata);
                                    }
                                }
                                break;
                            case RewardKeyDef.REWARD_TYPE_EXP:
                                //奖励类型为经验
                                long Roleexp = long.Parse(JsonHelper.GetStringData(RewardKeyDef.REWARD_CONTENT, rewardInfo));
                                rewarddata = new RewardItemData();
                                rewarddata.setData(RewardType.EXP, 0, Roleexp);
                                items.Add(rewarddata);
                                break;
                            case RewardKeyDef.REWARD_PUB_EXP:
                                //奖励类型为经验
                                long pubexp = long.Parse(JsonHelper.GetStringData(RewardKeyDef.REWARD_CONTENT, rewardInfo));
                                rewarddata = new RewardItemData();
                                rewarddata.setData(RewardType.REWARD_PUB_EXP, 0, pubexp);
                                items.Add(rewarddata);
                                break;
                            case RewardKeyDef.REWARD_PET_EXP:
                                //奖励类型为经验
                                long petexp = long.Parse(JsonHelper.GetStringData(RewardKeyDef.REWARD_CONTENT, rewardInfo));
                                rewarddata = new RewardItemData();
                                rewarddata.setData(RewardType.REWARD_PET_EXP, 0, petexp);
                                items.Add(rewarddata);
                                break;
                            case RewardKeyDef.REWARD_CORP_EXP:
                                //奖励类型为 帮派经验
                                int corpexp = int.Parse(JsonHelper.GetStringData(RewardKeyDef.REWARD_CONTENT, rewardInfo));
                                rewarddata = new RewardItemData();
                                rewarddata.setData(RewardType.REWARD_CORP_EXP, 0, corpexp);
                                items.Add(rewarddata);
                                break;
                            case RewardKeyDef.REWARD_CORP_MONEY:
                                //奖励类型为 帮派资金
                                int corpmoney = int.Parse(JsonHelper.GetStringData(RewardKeyDef.REWARD_CONTENT, rewardInfo));
                                rewarddata = new RewardItemData();
                                rewarddata.setData(RewardType.REWARD_CORP_MONEY, 0, corpmoney);
                                items.Add(rewarddata);
                                break;
                            case RewardKeyDef.REWARD_CORP_CORDINATE:
                                //奖励类型为 帮贡奖励
                                int corpcordinate = int.Parse(JsonHelper.GetStringData(RewardKeyDef.REWARD_CONTENT, rewardInfo));
                                rewarddata = new RewardItemData();
                                rewarddata.setData(RewardType.REWARD_CORP_CORDINATE, 0, corpcordinate);
                                items.Add(rewarddata);
                                break;
                            case RewardKeyDef.REWARD_RIDE_EXP:
                                //奖励类型为 骑宠经验
                                int rideexp = int.Parse(JsonHelper.GetStringData(RewardKeyDef.REWARD_CONTENT, rewardInfo));
                                rewarddata = new RewardItemData();
                                rewarddata.setData(RewardType.REWARD_RIDE_EXP, 0, rideexp);
                                items.Add(rewarddata);
                                break;
                        }
                    }
                }
            }
        }

        public void ParseReward(ShowRewardTemplate rewardTemplate)
        {
            items.Clear();
            int len = rewardTemplate.rewardTempalteSet.Count;
            for (int i = 0; i < len; i++)
            {
                int rewardType = rewardTemplate.rewardTempalteSet[i].rewardTypeId;
                RewardItemData rewarddata;
                switch (rewardType)
                {
                    case RewardKeyDef.REWARD_TYPE_CURRENCY:
                        //奖励类型为货币
                        int currencyType = rewardTemplate.rewardTempalteSet[i].param1;
                        int currencyValue = rewardTemplate.rewardTempalteSet[i].param2;
                        rewarddata = new RewardItemData();
                        rewarddata.setCurrencyData(currencyType, currencyValue);
                        items.Add(rewarddata);
                        break;
                    case RewardKeyDef.REWARD_TYPE_ITEM:
                        //奖励类型为物品
                        int itemId = rewardTemplate.rewardTempalteSet[i].param1;
                        if (PropertyUtil.IsLegalID(itemId))
                        {
                            int itemNum = rewardTemplate.rewardTempalteSet[i].param2;
                            rewarddata = new RewardItemData();
                            rewarddata.setData(RewardType.ITEM, itemId, itemNum);
                            items.Add(rewarddata);
                        }
                        break;
                    case RewardKeyDef.REWARD_TYPE_EXP:
                        //奖励类型为经验
                        long Roleexp = long.Parse(rewardTemplate.rewardTempalteSet[i].param2+"");
                        rewarddata = new RewardItemData();
                        rewarddata.setData(RewardType.EXP, 0, Roleexp);
                        items.Add(rewarddata);
                        break;
                    case RewardKeyDef.REWARD_PUB_EXP:
                        //奖励类型为 酒馆经验
                        long pubexp = long.Parse(rewardTemplate.rewardTempalteSet[i].param2+"");
                        rewarddata = new RewardItemData();
                        rewarddata.setData(RewardType.REWARD_PUB_EXP, 0, pubexp);
                        items.Add(rewarddata);
                        break;
                    case RewardKeyDef.REWARD_PET_EXP:
                        //奖励类型为 宠物经验
                        long petexp = long.Parse(rewardTemplate.rewardTempalteSet[i].param2 + "");
                        rewarddata = new RewardItemData();
                        rewarddata.setData(RewardType.REWARD_PET_EXP, 0, petexp);
                        items.Add(rewarddata);
                        break;
                    case RewardKeyDef.REWARD_CORP_EXP:
                        //奖励类型为 帮派经验
                        int corpexp = int.Parse(rewardTemplate.rewardTempalteSet[i].param2 + "");
                        rewarddata = new RewardItemData();
                        rewarddata.setData(RewardType.REWARD_CORP_EXP, 0, corpexp);
                        items.Add(rewarddata);
                        break;
                    case RewardKeyDef.REWARD_CORP_MONEY:
                        //奖励类型为 帮派资金
                        int corpmoney = int.Parse(rewardTemplate.rewardTempalteSet[i].param2 + "");
                        rewarddata = new RewardItemData();
                        rewarddata.setData(RewardType.REWARD_CORP_MONEY, 0, corpmoney);
                        items.Add(rewarddata);
                        break;
                    case RewardKeyDef.REWARD_CORP_CORDINATE:
                        //奖励类型为 帮贡
                        int corpcordinate = int.Parse(rewardTemplate.rewardTempalteSet[i].param2 + "");
                        rewarddata = new RewardItemData();
                        rewarddata.setData(RewardType.REWARD_CORP_CORDINATE, 0, corpcordinate);
                        items.Add(rewarddata);
                        break;
                    case RewardKeyDef.REWARD_RIDE_EXP:
                        //奖励类型为 骑宠经验
                        int rideexp = int.Parse(rewardTemplate.rewardTempalteSet[i].param2 + "");
                        rewarddata = new RewardItemData();
                        rewarddata.setData(RewardType.REWARD_RIDE_EXP, 0, rideexp);
                        items.Add(rewarddata);
                        break;
                }
            }
        }

        public void ParseReward(string dataPack)
        {
            IDictionary data = (IDictionary)(Json.Deserialize(dataPack));
            ParseReward(data);
        }
		
        public void Parse(RewardInfoData rewardInfoData)
		{
			string data = rewardInfoData.rewardStr;
            ParseReward(data);
		}

        public void ParseDefaultItem(string dataPack, RewardItem rewardItem)
        {
            ParseReward(dataPack);

            if(items!=null&&0 < items.Count)
            {
                rewardItem.setRewardData(items[0]);
            }
        }

        public void Parse(string dataPack, List<RewardItem> rewardList)
        {
            ParseReward(dataPack);

            for(int i=0;i<rewardList.Count;i++)
            {
                if (i < items.Count)
                {
                    rewardList[i].setRewardData(items[i]);
                }
                else
                {
                    rewardList[i].setEmpty();
                }
            }
        }

        public void Parse(IDictionary data,List<RewardItem> rewardList )
        {
            ParseReward(data);
            for (int i = 0; i < rewardList.Count; i++)
            {
                if (i < items.Count)
                {
                    rewardList[i].setRewardData(items[i]);
                }
                else
                {
                    rewardList[i].setEmpty();
                }
            }
        }

        public void Parse(ShowRewardTemplate showrewardTPL, List<RewardItem> rewardList)
        {
            ParseReward(showrewardTPL);

            for (int i = 0; i < rewardList.Count; i++)
            {
                if (i < items.Count)
                {
                    rewardList[i].setRewardData(items[i]);
                }
                else
                {
                    rewardList[i].setEmpty();
                }
            }
        }

        public long getExp()
		{
			RewardItemData rewardItemData = getRewardItemData(RewardType.EXP);
			if (rewardItemData == null)
			{
				return 0;
			}
			return rewardItemData.lvalue;
		}
		
        public int getCurrencyValue(int currencyType)
		{
			RewardItemData rewardItemData = getRewardItemData(RewardType.CURRENCY,currencyType);
			if (rewardItemData == null)
			{
				return 0;
			}
			return rewardItemData.ivalue;
		}
		
        private RewardItemData getRewardItemData(RewardType rewardType,int currencyType=0)
		{
			for(int i=0;i<items.Count;i++)
			{
                if (items[i].type == rewardType && items[i].currencyType==currencyType)
				{
					return items[i];
				}
			}
			return null;
		}

        public RewardItemData getDefaultRewardItemData()
        {
            if (items!=null&&items.Count>0) return items[0];
            return null;
        }
        /// <summary>
        /// 以 字符串的形式 获得所有奖励
        /// </summary>
        /// <param name="split"></param>
        /// <returns></returns>
        public string GetRewardToString(string split="、")
        {
            string str = "";
            for (int i = 0; items!=null&&i < items.Count; i++)
            {
                str += items[i].ToString()+((i!=items.Count-1)?split:"");
            }
            return str;
        }
    }
}

