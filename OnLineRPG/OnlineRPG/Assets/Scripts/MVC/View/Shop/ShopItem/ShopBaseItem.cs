using System;
using BetaFramework;
using DG.Tweening;
using EventUtil;
using System.Collections;
using System.Collections.Generic;
using Scripts_Game.Managers;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;
using TMPro;

public class ShopBaseItem : MonoBehaviour
{
    public TextMeshProUGUI[] TextPrice;
    public IapProductConfig_Data IapItem { get; set; }
    public bool IsRemoveAds { get; set; } //是否已经去广告
    public ShopBaseDialog Dialog { get; set; }
    public Transform flyCoinPosition;
    public RubyType flyCoinType = RubyType.single;

    // Use this for initialization
    protected virtual void OnEnable()
    {
        GetComponentInChildren<Button>().onClick.AddListener(BuyProduct);
        EventDispatcher.AddEventListener<IapProductConfig_Data>(GlobalEvents.PurchaseSuccessful, OnPurchaseSucceed);
        EventDispatcher.AddEventListener(GlobalEvents.PurchaseFailed, OnPurchaseFailed);
    }

    protected virtual void OnDisable()
    {
        GetComponentInChildren<Button>().onClick.RemoveListener(BuyProduct);
        EventDispatcher.RemoveEventListener<IapProductConfig_Data>(GlobalEvents.PurchaseSuccessful, OnPurchaseSucceed);
        EventDispatcher.RemoveEventListener(GlobalEvents.PurchaseFailed, OnPurchaseFailed);
    }

    public virtual void Initialize()
    {
#if UNITY_EDITOR
        for (int i = 0; i < TextPrice.Length; i++)
        {
            TextPrice[i].text = IapItem.ProductDollarPrice;
        }
#else
            for (int i = 0; i < TextPrice.Length; i++)
            {
                TextPrice[i].text = CommUtil.GetPrice(IapItem);
            }

#endif

        GetComponentInChildren<Button>().interactable = true;

        InitilizeSource();
    }

    protected virtual void BuyProduct()
    {
        if (Dialog != null)
        {
            Dialog.StartLoading();
        }
#if !UNITY_EDITOR
        if (Dialog != null && Application.internetReachability == NetworkReachability.NotReachable)
        {
            UIManager.ShowMessage("Please check your connection and try again later");
            Dialog.StopLoading();
            Dialog.SetCloseButtonCanClick();

            return;
        }
#endif

        if (Dialog != null)
        {
            Dialog.CloseInteractable();
        }

        GetComponentInChildren<Button>().interactable = false;

        ReportData();


        AppEngine.SPurchaserManager.BuyProductId(IapItem);

        AppEngine.SSoundManager.PlaySFX(ViewConst.wav_btn_normal);
        //CommandChannel.GetInstance().PostCommand(CommonCommandConst.PLAY_SFX, ViewConst.wav_btn_normal);
    }

    protected virtual void OnPurchaseSucceed(IapProductConfig_Data item)
    {
        if (ReferenceEquals(item, null)) return;

        if (DataManager.businessGiftData.shopItem != null)
            for (int i = 0; i < DataManager.businessGiftData.shopItem.Length; i++)
            {
                if (DataManager.businessGiftData.shopItem[i].giftId == item.ItemID)
                {
                    return;
                }
            }

        if (item.ProductID.Equals(IapItem.ProductID))
        {
            PlayCoinAnimation();
            GetComponentInChildren<Button>().interactable = true;
        }
    }

    protected virtual void OnPurchaseFailed()
    {
        GetComponentInChildren<Button>().interactable = true;
    }

    protected virtual void OnClose()
    {
        if (Dialog != null)
        {
            Dialog.Close();
        }
    }

    protected virtual void PlayCoinAnimation()
    {
        ProductType type = (ProductType) IapItem.ProductType;
        switch (type)
        {
            case ProductType.Consumable:

                CommonRewardData _commonRewardData = new CommonRewardData();
                _commonRewardData.Tittle = IapItem.TitleName;
                _commonRewardData.boxType = (RewardBoxType) IapItem.RewardBox;
                _commonRewardData.RewardSource = RewardSource.shop;
                _commonRewardData.coin = IapItem.ProductCoins;
                _commonRewardData.hint1 = IapItem.ProductHint1;
                _commonRewardData.hint2 = IapItem.ProductHint2;
                _commonRewardData.hint3 = IapItem.ProductHint3;
                _commonRewardData.hint4 = IapItem.ProductHint4;
                _commonRewardData.hint5 = IapItem.ProductHint5;
                _commonRewardData.buyItem = IapItem.ProductID;
                _commonRewardData.moneyCoast = IapItem.ProductDollarPrice;
                _commonRewardData.payType = IapItem.IapType.ToString();
                Debug.LogError("内购奖励");
                UIManager.OpenUIAsync(ViewConst.prefab_CommonRewardDialog, OpenType.Replace, null, _commonRewardData);

                break;

            case ProductType.NonConsumable:
                UIManager.OpenUIAsync(ViewConst.prefab_ShopRemoveAdsDialog, OpenType.Replace);
                break;

            case ProductType.Subscription:
                break;

            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    protected virtual void ReportData()
    {
        string campaign = DataManager.BusinessData.PlayerTag;
//        ReportDataManager.ShopItemButtonClick(campaign, IapItem.IapType.ToString(), IapItem.ProductID);
    }

    protected virtual void InitilizeSource()
    {
        IapItem.PayType = PayType.RestoreType;
    }

    public virtual void ChangeColor(bool isChange)
    {
    }
}