using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopLimitItem : MonoBehaviour
{
    public GameObject multiPanel, singleCoinPanel, singleBeePanel;
    public GameObject coin, hint1, hint2, hint3, hint4, hint5, removead;

    public Text[] coinText, hint5Text;
    public Text hint1Text, hint2Text, hint3Text, hint4Text;

    public TextMeshProUGUI[] moneyText;
    public TextMeshProUGUI moreText;
    public GameObject purched;
    private IapProductConfig_Data targetIap;

    public void SetGiftItem(BusShopItem shopItem, Action close)
    {
        List<IapProductConfig_Data> config =
            DataManager.IapData.GetIapProductConfig(true);
        targetIap = config.Find(x => x.ItemID == shopItem.giftId);
        int removeAD = targetIap.removeAd;
        if (AppEngine.SyncManager.Data.IsRemoveAd.Value)
            removeAD = 0;
        if (targetIap.ProductHint1 + targetIap.ProductHint2 + targetIap.ProductHint3 + targetIap.ProductHint4 +
            targetIap.ProductHint5 + removeAD == 0 && targetIap.ProductCoins > 0)
        {
            if (multiPanel)
                multiPanel.SetActive(false);
            if (singleBeePanel)
                singleBeePanel.SetActive(false);
            if (singleCoinPanel)
                singleCoinPanel.SetActive(true);
        }
        else if (targetIap.ProductHint1 + targetIap.ProductHint2 + targetIap.ProductHint3 + targetIap.ProductHint4 +
            targetIap.ProductCoins + removeAD == 0 && targetIap.ProductHint5 > 0)
        {
            if (multiPanel)
                multiPanel.SetActive(false);
            if (singleBeePanel)
            {
                singleBeePanel.SetActive(true);
                Transform bee = transform.Find("Buyed_Bee");
                if (bee != null)
                    purched = bee.gameObject;
            }

            if (singleCoinPanel)
                singleCoinPanel.SetActive(false);
        }
        else
        {
            if (multiPanel)
                multiPanel.SetActive(true);
            if (singleBeePanel)
                singleBeePanel.SetActive(false);
            if (singleCoinPanel)
                singleCoinPanel.SetActive(false);
        }

        if (targetIap)
        {
            if (targetIap.ProductCoins > 0)
            {
                if (coin)
                    coin.SetActive(true);
                if (coinText.Length > 0)
                {
                    for (int i = 0; i < coinText.Length; i++)
                    {
                        coinText[i].text = targetIap.ProductCoins.ToString();
                    }
                }
            }
            else
            {
                if (coin)
                    coin?.SetActive(false);
            }

            if (targetIap.ProductHint1 > 0)
            {
                if (hint1)
                    hint1?.SetActive(true);
                if (hint1Text)
                    hint1Text.text = targetIap.ProductHint1.ToString();
            }
            else
            {
                if (hint1)
                    hint1?.SetActive(false);
            }

            if (targetIap.ProductHint2 > 0)
            {
                if (hint2)
                    hint2?.SetActive(true);
                if (hint2Text)
                    hint2Text.text = targetIap.ProductHint2.ToString();
            }
            else
            {
                if (hint2)
                    hint2?.SetActive(false);
            }

            if (targetIap.ProductHint3 > 0)
            {
                if (hint3)
                    hint3?.SetActive(true);
                if (hint3Text)
                    hint3Text.text = targetIap.ProductHint3.ToString();
            }
            else
            {
                if (hint3)
                    hint3?.SetActive(false);
            }

            if (targetIap.ProductHint4 > 0)
            {
                if (hint4)
                    hint4?.SetActive(true);
                if (hint4Text)
                    hint4Text.text = targetIap.ProductHint4.ToString();
            }
            else
            {
                if (hint4)
                    hint4?.SetActive(false);
            }

            if (targetIap.ProductHint5 > 0)
            {
                if (hint5)
                    hint5?.SetActive(true);
                if (hint5Text.Length > 0)
                {
                    for (int i = 0; i < hint5Text.Length; i++)
                    {
                        hint5Text[i].text = targetIap.ProductHint5.ToString();
                    }
                }
            }
            else
            {
                if (hint5)
                    hint5?.SetActive(false);
            }

            if (moreText)
            {
                moreText.text = $"{targetIap.PercentMore}%";
            }

            if (targetIap.removeAd == 0 || AppEngine.SyncManager.Data.IsRemoveAd.Value)
            {
                if (removead)
                    removead?.SetActive(false);
            }
            else
            {
                if (removead)
                    removead?.SetActive(true);
            }
        }
        else
        {
            close?.Invoke();
        }

        if (moneyText.Length > 0)
            for (int i = 0; i < moneyText.Length; i++)
            {
                moneyText[i].text = CommUtil.GetPrice(targetIap);
            }

        if (DataManager.businessGiftData.buyitem.Contains(shopItem.giftId))
        {
            if (purched)
                purched?.SetActive(true);
        }
        else
        {
            if (purched)
                purched?.SetActive(false);
        }
    }

    private bool canclick = true;
    public void ClickBuy()
    {
        if (!canclick)
        {
            return;
        }

        canclick = false;
        TimersManager.SetTimer(1, () =>
        {
            canclick = true;
        });
        AppEngine.SPurchaserManager.BuyProductId(targetIap);
    }
}