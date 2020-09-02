using System;
using System.Collections.Generic;
using BetaFramework;
using EventUtil;
using Scripts_Game.Managers;
using UnityEngine.Purchasing;

#region Documentation

/// <summary>   支付获取金币和道具类. </summary>
/// <remarks>   Administrator, 2019/4/9. </remarks>

#endregion Documentation

public class CurrencyIapCommand : ICommand
{
    public object Data { get; set; }

    public void Initilize()
    {
    }

    public void Execute()
    {
        IapProductConfig_Data productData = (IapProductConfig_Data) Data;
        CheckPlayerPurchLimit(productData);
        ProductType ProductType = (ProductType) productData.ProductType;
        switch (ProductType)
        {
            case ProductType.Consumable:
                PurchaserConsumble(productData);
                break;

            case ProductType.NonConsumable:
                PurchaserNonConsumble(productData);
                break;

            case ProductType.Subscription:
                break;
        }

        DataManager.ShopData.PurchaserSucceed(productData.ProductID);

        EventDispatcher.TriggerEvent(GlobalEvents.PurchaseSuccessful, productData);
    }

    public void Release()
    {
    }

    private void PurchaserConsumble(IapProductConfig_Data data)
    {
        //        DataManager.SkillData.AddNormalHintCount(data.ProductHint1);
        //        DataManager.SkillData.AddSpecificHintCount(data.ProductHint2);
        //        DataManager.SkillData.AddMultiHintCount(data.ProductHint3);
        if (data.removeAd == 1) {
            AppEngine.SAdManager.DisableAD();
        }
        if (DataManager.ShopData.ContainInPendingProduct(data) == false) {
            //UIManager.ShowMessage(LanguageManager.Get("RESTORE_SUCCESSFUL"), 3f, ToastPositionEnum.low);
            return;
        }
        if (data.ProductCoins > 0 || data.ProductHint1 + data.ProductHint2 + data.ProductHint3 + data.ProductHint4 + data.ProductHint5 > 0)
        {
            if (!DataManager.ProcessData.isRestore)
                EventDispatcher.TriggerEvent(GlobalEvents.SkipBalanceUpdate);
            switch (data.IapType)
            {
                case 0:
                    //CurrencyBallance.ignoreAnim = true;
                    RewardMgr.RewardInventory(InventoryType.Coin, data.ProductCoins, RewardSource.shop, 
                        data._customData.p_buyItemId, data._customData.p_moneyCost.ToString(), data.IapType.ToString());
                    break;
                default:
                    var rewards = new List<RewardInventory>
                    {
                        new RewardInventory() {type = InventoryType.Coin, count = data.ProductCoins},
                        new RewardInventory() {type = InventoryType.Hint1, count = data.ProductHint1},
                        new RewardInventory() {type = InventoryType.Hint2, count = data.ProductHint2},
                        new RewardInventory() {type = InventoryType.Hint3, count = data.ProductHint3},
                        new RewardInventory() {type = InventoryType.Hint4, count = data.ProductHint4},
                        new RewardInventory() {type = InventoryType.Bee, count = data.ProductHint5}
                    };
                    RewardMgr.RewardInventory(rewards, RewardSource.shop, data._customData.p_buyItemId, data._customData.p_moneyCost.ToString(), data.IapType.ToString());
                    break;
            }
        }


        DataManager.ShopData.RemovePendingProduct(data.ProductID);
    }

    private void PurchaserNonConsumble(IapProductConfig_Data data)
    {
        EventUtil.EventDispatcher.TriggerEvent(GlobalEvents.RemoveAd);
        AppEngine.SAdManager.DisableAD();

        if (!DataManager.ShopData.RemovePendingProduct(data.ProductID))
        {
            data.PayType = PayType.RestoreType;
			//UIManager.ShowMessage(LanguageManager.Get("RESTORE_SUCCESSFUL"), 3f, ToastPositionEnum.low);
		}
        else
        {
            data.PayType = PayType.RemoveadsType;
        }
    }
    
    /// <summary>
    /// 监测是否是限时奖励活动，是的话就发奖
    /// </summary>
    /// <param name="data"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    private void CheckPlayerPurchLimit(IapProductConfig_Data data)
    {
        bool myself = false;
        for (int i = 0; i < DataManager.businessGiftData.shopItem.Length; i++)
        {
            if (DataManager.businessGiftData.shopItem[i].giftId == data.ItemID)
            {
                DataManager.businessGiftData.BuyItem(data.ItemID);
                myself = true;
            }
        }

        if (!myself)
        {
            return;
        }
        ProductType type = (ProductType) data.ProductType;
        switch (type)
        {
            case ProductType.Consumable:

                CommonRewardData _commonRewardData = new CommonRewardData();
                _commonRewardData.Tittle = data.TitleName;
                _commonRewardData.boxType = (RewardBoxType) data.RewardBox;
                _commonRewardData.RewardSource = RewardSource.LimitShop;
                _commonRewardData.coin = data.ProductCoins;
                _commonRewardData.hint1 = data.ProductHint1;
                _commonRewardData.hint2 = data.ProductHint2;
                _commonRewardData.hint3 = data.ProductHint3;
                _commonRewardData.hint4 = data.ProductHint4;
                _commonRewardData.hint5 = data.ProductHint5;
                _commonRewardData.buyItem = data.ProductID;
                _commonRewardData.moneyCoast = data.ProductDollarPrice;
                _commonRewardData.payType = data.IapType.ToString();
                UIManager.OpenUIAsync(ViewConst.prefab_CommonRewardDialog, OpenType.Replace, null, _commonRewardData);

                break;

            case ProductType.NonConsumable:
                if (DataManager.ShopData.ContainInPendingProduct(data) == false) {
                    //UIManager.ShowMessage(LanguageManager.Get("RESTORE_SUCCESSFUL"), 3f, ToastPositionEnum.low);
                    return;
                }
                UIManager.OpenUIAsync(ViewConst.prefab_ShopRemoveAdsDialog, OpenType.Replace);
                break;

            case ProductType.Subscription:
                break;

            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}