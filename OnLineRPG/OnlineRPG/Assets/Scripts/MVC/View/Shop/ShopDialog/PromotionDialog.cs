using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PromotionDialog : ShopBaseDialog
{
    protected ShopBaseItem PromotionItem;

    public GameObject LoadingObj;
    public GameObject EffectObject;

    protected override void Init()
    {
        var data = DataManager.IapData;
        var repGiftData = DataManager.GiftData;
        var productData = data.GetProductDataById(repGiftData.Config.Id);
        if (productData == null) return;

        productData.ProductCoins = repGiftData.Config.Coin;
        productData.ProductHint1 = repGiftData.Config.Hint1;
        productData.ProductHint2 = repGiftData.Config.Hint2;
        productData.ProductHint3 = repGiftData.Config.Hint3;
        productData.IapType = repGiftData.Type;
        productData.PercentMore = repGiftData.Config.More;

        PromotionItem = GetComponentInChildren<ShopBaseItem>();
        PromotionItem.IapItem = productData;

        PromotionItem.Initialize();
        if (EffectObject)
            EffectObject.SetActive(true);
    }

    public override void StartLoading()
    {
        if (LoadingObj != null)
        {
            LoadingObj.SetActive(true);
        }
    }

    public override void StopLoading()
    {
        if (LoadingObj != null)
        {
            LoadingObj.SetActive(false);
        }
    }

    public override void OnClose()
    {
        base.OnClose();
        if (EffectObject)
            EffectObject.SetActive(false);
    }

    public override IEnumerator ExitAnim(UICallBack l_callBack, params object[] objs)
    {
        transform.Find("Mask").gameObject.SetActive(false);
        CurrencyBallance currencyBallance = GameObject.FindObjectOfType<CurrencyBallance>();
        Transform targetPos = transform;
        if (currencyBallance != null)
        {
            targetPos = currencyBallance.transform;
        }
        anim.SetTrigger("hide");
        transform.Find("Content")
            .DOMove(new Vector3(targetPos.position.x, targetPos.position.y, transform.Find("Content").position.z), 0.5f)
            .SetEase(Ease.InCubic);
        yield return new WaitForSeconds(0.4f);
        
        AdsOnSaleIconCtrl adsOnSaleIconCtrl = FindObjectOfType<AdsOnSaleIconCtrl>();
        if (adsOnSaleIconCtrl)
            adsOnSaleIconCtrl.TriggerRubyAni(RubyAniType.PromoUp);
        yield return new WaitForSeconds(0.1f);
        ExitSuccess();
    }
}