using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using UnityEngine;

public class PromotionNoviceDialog : PromotionDialog
{
    protected override void Init()
    {
        var data = DataManager.IapData;
        var item = data.GetNoviceProductData();

        PromotionItem = GetComponentInChildren<ShopBaseItem>();
        PromotionItem.IapItem = item;

        PromotionItem.Initialize();

        string playerTag = DataManager.GiftData.Belong;
        string giftId = DataManager.GiftData.GiftId.ToString();
    }
}