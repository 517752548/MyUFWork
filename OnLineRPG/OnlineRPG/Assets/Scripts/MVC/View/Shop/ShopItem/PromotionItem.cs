using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BetaFramework;
using TMPro;

//限时促销项
public class PromotionItem : ShopBaseItem
{
    public Text TextCoins;
    public TextMeshProUGUI TextPercentMore;
    public Text TextHint1;
    public Text TextHint2;
    public Text TextHint3;
    public Text TextOriginalPrice;

    public GameObject GoCoin;
    public GameObject GoHint1;
    public GameObject GoHint2;
    public GameObject GoHint3;

    public Transform ImgParent;

    public bool IsShop;

    private const string m_RemainTime = "LIMITED  TIME:      {0}";

    public override void Initialize()
    {
        base.Initialize();

        if (IapItem.ProductCoins <= 0)
        {
            GoCoin.SetActive(false);
        }
        else
        {
            GoCoin.SetActive(true);
            TextCoins.text = IapItem.ProductCoins.ToString();
        }

        if (!string.IsNullOrEmpty(IapItem.PercentMore))
        {
            TextPercentMore.text = IapItem.PercentMore.ToString() + "%";
        }

        if (IapItem.ProductHint1 > 0)
        {
            GoHint1.SetActive(true);
            TextHint1.text = IapItem.ProductHint1.ToString();
        }
        else
        {
            GoHint1.SetActive(false);
        }

        if (IapItem.ProductHint2 > 0)
        {
            GoHint2.SetActive(true);
            TextHint2.text = IapItem.ProductHint2.ToString();
        }
        else
        {
            GoHint2.SetActive(false);
        }

        if (IapItem.ProductHint3 > 0)
        {
            GoHint3.SetActive(true);
            TextHint3.text = IapItem.ProductHint3.ToString();
        }
        else
        {
            GoHint3.SetActive(false);
        }

        if (TextOriginalPrice != null)
        {
            var data = DataManager.IapData;
            TextOriginalPrice.text = data.GetOriginPrice(IapItem);
        }

        ImgParent.GetChild(IapItem.ImageType).gameObject.SetActive(true);
    }

    protected override void InitilizeSource()
    {
        if (IsShop)
        {
            IapItem.PayType = PayType.ShopLimitsaleType;
        }
        else
        {
            IapItem.PayType = PayType.DialoglimitsaleType;
        }
    }

    protected override void BuyProduct()
    {
        base.BuyProduct();
    }
}