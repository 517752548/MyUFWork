using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using EventUtil;
using Scripts_Game.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.Purchasing;

public class InShopLimitItem : MonoBehaviour
{
    public TextMeshProUGUI limitTime;
    public ShopLimitItem[] ShopLimitItems;
    public GameObject flashGameObject;
    private void Start()
    {
        limitTime.text = "";
        AppEngine.SSystemManager.GetSystem<BusinessSystem>().timeLoop += SHowTime;
        for (int i = 0; i < ShopLimitItems.Length; i++)
        {
            ShopLimitItems[i].SetGiftItem(DataManager.businessGiftData.shopItem[i], CloseLimitPanel);
        }
        EventDispatcher.AddEventListener<IapProductConfig_Data>(GlobalEvents.PurchaseSuccessful, PlayerPurchSuccessful);
    }

    private void PlayerPurchSuccessful(IapProductConfig_Data data)
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
        CloseLimitPanel();
    }

    private void OnDestroy()
    {
        EventDispatcher.RemoveEventListener<IapProductConfig_Data>(GlobalEvents.PurchaseSuccessful,
            PlayerPurchSuccessful);
        AppEngine.SSystemManager.GetSystem<BusinessSystem>().timeLoop -= SHowTime;
    }


    private void SHowTime(string time,int lastseconds)
    {
        limitTime.text = time;
        if (time == "00:00:00")
        {
            CloseLimitPanel();
        }

        if (lastseconds > 0 && lastseconds < DataManager.businessGiftData.flashTime)
        {
            flashGameObject.SetActive(true);
        }
    }

    public void CloseLimitPanel()
    {
        gameObject.SetActive(false);
    }
}