using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using DG.Tweening;
using EventUtil;
using Scripts_Game.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.Purchasing;

public class ShopLimitDialog : UIWindowBase
{
    private ConstDelegate.CloseUI closeAction;
    public TextMeshProUGUI limitTime;
    public ShopLimitItem[] ShopLimitItems;

    public override void OnOpen()
    {
        base.OnOpen();
        if (objs.Length > 0)
        {
            closeAction = objs[0] as ConstDelegate.CloseUI;
        }
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

    public override void OnClose()
    {
        base.OnClose();
        EventDispatcher.RemoveEventListener<IapProductConfig_Data>(GlobalEvents.PurchaseSuccessful,
            PlayerPurchSuccessful);
        AppEngine.SSystemManager.GetSystem<BusinessSystem>().timeLoop -= SHowTime;
    }

    private void SHowTime(string time, int lastseconds)
    {
        limitTime.text = time;
        if (time == "00:00:00")
        {
            CloseLimitPanel();
        }
    }

    public override IEnumerator ExitAnim(UICallBack l_callBack, params object[] objs)
    {
        LimitTimeEnter[] enters = FindObjectsOfType<LimitTimeEnter>();
        anim.enabled = false;
        anim.gameObject.transform.DOScale(Vector3.one * 0.1f, 0.3f).SetEase(Ease.Linear).OnComplete(() =>
        {
            AdsOnSaleIconCtrl adsOnSaleIconCtrl = FindObjectOfType<AdsOnSaleIconCtrl>();
            if (adsOnSaleIconCtrl)
                adsOnSaleIconCtrl.TriggerRubyAni(RubyAniType.MoreCoin);
        });
        if (enters.Length > 0)
        {
            Vector3 targetpos = new Vector3(enters[enters.Length - 1].transform.position.x,enters[enters.Length - 1].transform.position.y,transform.position.z);
            anim.gameObject.transform.DOMove(targetpos,0.5f);
        }
        yield return new WaitForSeconds(0.5f);
        //默认无动画
        ExitSuccess();
    }

    public void CloseLimitPanel()
    {
        closeAction?.Invoke();
        Close();
    }
}