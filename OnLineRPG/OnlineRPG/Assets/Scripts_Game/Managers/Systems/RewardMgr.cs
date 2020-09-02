﻿using BetaFramework;
using System.Collections.Generic;
 using UnityEngine;

 namespace Scripts_Game.Managers
{
    public class RewardMgr
    {
        public static void RewardInventory(InventoryType inventoryType, int inventoryCount, RewardSource rewardSource, string buyProductId = "",
            string moneyCost = "", string payType = "")
        {
            Debug.LogError("RewardInventory");
            int coin = 0;
            int hint1 = 0;
            int hint2 = 0;
            int hint3 = 0;
            int hint4 = 0;
            int hint5 = 0;

            switch (inventoryType)
            {
                case InventoryType.Fans:
                    AppEngine.SyncManager.Data.fansNumber.Value += inventoryCount;
                    break;
                case InventoryType.Hint1:
                    hint1 = inventoryCount;
                    AppEngine.SyncManager.Data.Hint1.Value += inventoryCount;
                    AppEngine.SyncManager.Data.Hint1Unlock.Value = true;
                    break;
                case InventoryType.Hint2:
                    hint2 = inventoryCount;
                    AppEngine.SyncManager.Data.Hint2.Value += inventoryCount;
                    AppEngine.SyncManager.Data.Hint2Unlock.Value = true;
                    break;
                case InventoryType.Hint3:
                    hint3 = inventoryCount;
                    AppEngine.SyncManager.Data.Hint3.Value += inventoryCount;
                    AppEngine.SyncManager.Data.Hint3Unlock.Value = true;
                    break;
                case InventoryType.Hint4:
                    hint4 = inventoryCount;
                    AppEngine.SyncManager.Data.Hint4.Value += inventoryCount;
                    AppEngine.SyncManager.Data.Hint4Unlock.Value = true;
                    break;
                case InventoryType.Bee:
                    hint5 = inventoryCount;
                    AppEngine.SyncManager.Data.Bee.Value += inventoryCount;
                    //AppEngine.SyncManager.Data..Value = true;
                    break;
                case InventoryType.Coin:
                    coin = inventoryCount;
                    AppEngine.SyncManager.Data.Coin.Value += inventoryCount;
                    break;
                case InventoryType.Cup:
                    //coin = inventoryCount;
                    AppEngine.SyncManager.Data.Cup.Value += inventoryCount;
                    break;
                case InventoryType.EliteTicket:
                    //coin = inventoryCount;
                    AppEngine.SyncManager.Data.EliteTicket.Value += inventoryCount;
                    break;
            }
            
            GameAnalyze.LoggetReward(
                AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value.ToString(),
                "NULL",hint1.ToString(),hint2.ToString(),
                hint3.ToString(),hint4.ToString(),coin.ToString(),
                "",rewardSource.ToString(), buyProductId, moneyCost, payType,hint5.ToString(),AppEngine.SSystemManager.GetSystem<RewardABSystem>().GetUserRewardLib(),AppEngine.SSystemManager.GetSystem<RewardABSystem>().GetABReportStr());

            AppEngine.SyncManager.DoSync(null);
        }

        public static void RewardInventoryWithSudId(InventoryType inventoryType, string subId, 
            RewardSource rewardSource, string buyProductId = "", string moneyCost = "", string payType = "")
        {
            Debug.LogError("RewardInventory");
            switch (inventoryType)
            {
                case InventoryType.Pet:
                    AppEngine.SyncManager.Data.Pets.UpdateValue(petData =>
                    {
                        petData.AddPet(subId);
                        return petData;
                    });
                    break;
                case InventoryType.Title:
                    
                    break;
            }
            
            GameAnalyze.LoggetReward(
                AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value.ToString(),
                "NULL","0", "0", "0", "0", "0",
                subId,rewardSource.ToString(), buyProductId, moneyCost, payType,"0",
                AppEngine.SSystemManager.GetSystem<RewardABSystem>().GetUserRewardLib(),AppEngine.SSystemManager.GetSystem<RewardABSystem>().GetABReportStr());

            AppEngine.SyncManager.DoSync(null);
        }

        public static void RewardInventory(List<RewardInventory> rewards, RewardSource rewardSource, string buyProductId = "", string moneyCost = "",
            string payType = "")
        {
            if (rewards.Count == 0)
                return;
            int coin = 0;
            int hint1 = 0;
            int hint2 = 0;
            int hint3 = 0;
            int hint4 = 0;
            int hint5 = 0;
            for (int i = 0; i < rewards.Count; i++)
            {
                int count = rewards[i].count;
                switch (rewards[i].type)
                {
                    case InventoryType.Fans:
                        AppEngine.SyncManager.Data.fansNumber.Value += count;
                        break;
                    case InventoryType.Hint1:
                        hint1 = count;
                        AppEngine.SyncManager.Data.Hint1.Value += count;
                        AppEngine.SyncManager.Data.Hint1Unlock.Value = true;
                        break;
                    case InventoryType.Hint2:
                        hint2 = count;
                        AppEngine.SyncManager.Data.Hint2.Value += count;
                        AppEngine.SyncManager.Data.Hint2Unlock.Value = true;
                        break;
                    case InventoryType.Hint3:
                        hint3 = count;
                        AppEngine.SyncManager.Data.Hint3.Value += count;
                        AppEngine.SyncManager.Data.Hint3Unlock.Value = true;
                        break;
                    case InventoryType.Hint4:
                        hint4 = count;
                        AppEngine.SyncManager.Data.Hint4.Value += count;
                        AppEngine.SyncManager.Data.Hint4Unlock.Value = true;
                        break;
                    case InventoryType.Bee:
                        hint5 = count;
                        AppEngine.SyncManager.Data.Bee.Value += count;
                        break;
                    case InventoryType.Coin:
                        coin = count;
                        AppEngine.SyncManager.Data.Coin.Value += count;
                        break;
                    case InventoryType.Cup:
                        //coin = count;
                        AppEngine.SyncManager.Data.Cup.Value += count;
                        break;
                    case InventoryType.EliteTicket:
                        //coin = count;
                        AppEngine.SyncManager.Data.EliteTicket.Value += count;
                        break;
                    default:
                        break;
                }
            }

            GameAnalyze.LoggetReward(
                AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value.ToString(),
                "NULL",hint1.ToString(),hint2.ToString(),
                hint3.ToString(),hint4.ToString(),coin.ToString(),
                "",rewardSource.ToString(),buyProductId,moneyCost,payType,hint5.ToString(),AppEngine.SSystemManager.GetSystem<RewardABSystem>().GetUserRewardLib(),AppEngine.SSystemManager.GetSystem<RewardABSystem>().GetABReportStr());
            
            AppEngine.SyncManager.DoSync(null);
        }

        public static List<RewardInventory> GetRewards(string rewardId)
        {
            var rewards = new List<RewardInventory>();
            var allReward = AppEngine.SSystemManager.GetSystem<RewardABSystem>().GetRewardInfoTable();
            if (allReward == null)
            {
                rewards.Add(new RewardInventory()
                {
                    type = InventoryType.Coin,
                    count = 25,
                });
                return rewards;
            }
            foreach (var reward in allReward.dataList)
            {
                if (reward.ID == rewardId)
                {
                    if (reward.ITEMID1 > 5)
                    {
                        rewards.Add(new RewardInventory()
                        {
                            type = (InventoryType) reward.ITEMID1,
                            count = reward.Quantity1,
                        });
                    }

                    if (reward.ITEMID2 > 5)
                    {
                        rewards.Add(new RewardInventory()
                        {
                            type = (InventoryType) reward.ITEMID2,
                            count = reward.Quantity2,
                        });
                    }

                    if (reward.ITEMID3 > 5)
                    {
                        rewards.Add(new RewardInventory()
                        {
                            type = (InventoryType) reward.ITEMID3,
                            count = reward.Quantity3,
                        });
                    }

                    if (reward.ITEMID4 > 5)
                    {
                        rewards.Add(new RewardInventory()
                        {
                            type = (InventoryType) reward.ITEMID4,
                            count = reward.Quantity4,
                        });
                    }

                    if (reward.ITEMID5 > 5)
                    {
                        rewards.Add(new RewardInventory()
                        {
                            type = (InventoryType) reward.ITEMID5,
                            count = reward.Quantity5,
                        });
                    }
                }
            }

            return rewards;
        }
        
        public static List<RewardInventory> GetVideoRewards(string rewardId)
        {
            var rewards = new List<RewardInventory>();
            var allReward = AppEngine.SSystemManager.GetSystem<RewardABSystem>().GetRewardInfoTable();
            foreach (var reward in allReward.dataList)
            {
                if (reward.ID == rewardId)
                {
                    if (reward.VIDEOITEM > 5)
                    {
                        rewards.Add(new RewardInventory()
                        {
                            type = (InventoryType) reward.VIDEOITEM,
                            count = reward.VIDEOQuantity,
                        });
                    }
                }
            }

            return rewards;
        }

        public static BagItems_Data GetInventoryConfig(InventoryType type)
        {
            var items = PreLoadManager.GetPreLoadConfig<BagItems>(ViewConst.asset_BagItems_ItemReward);
            if (items != null)
            {
                string id = ((int) type).ToString();
                for (int i = 0; i < items.dataList.Count; i++)
                {
                    if (items.dataList[i].ID == id)
                    {
                        return items.dataList[i];
                    }
                }
            }

            return null;
        }
    }

    public class RewardInventory
    {
        public InventoryType type;
        public int count;
    }

    public enum RewardSource
    {
        unknown,
        inShopAD,
        closeShopAD,
        shop,
        fbLogin,
        sign,
        signAd,
        queFeedback,
        email,
        CupBox,
        WebBoxAd,
        subWorld,
        subWorldAd,
        DailyWin,
        DailyStepReward0,
        DailyStepReward1,
        DailyStepReward2,
        DailyStepReward3,
        OneWord,
        FastRace,
        BeeCoin,
        FastRaceReward,
        LimitShop,
        Happiness,
        elite,
        classic,
    }
}