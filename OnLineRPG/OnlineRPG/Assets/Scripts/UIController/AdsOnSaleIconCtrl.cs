using EventUtil;
using System;
using System.Collections;
using BetaFramework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class AdsOnSaleIconCtrl : MonoBehaviour
{
    public Image saleIcon;
    public Animator RubyBalanceAni;

    [SerializeField] private Transform coinTransform;

    [SerializeField] private Transform ShopCoinTransform;

    [NonSerialized] public Transform ShopCoinOverrideTransform; //当商店打开的时候被赋值

    public AnimationCurve CoinAnimCurve;

    public GameObject adView;

    private static bool s_OpenShop;

    private void Awake()
    {
        EventDispatcher.AddEventListener(GlobalEvents.GiftDataRev, OnRevGiftData);
    }

    public Transform GetCoinTransform()
    {
        if (ShopCoinOverrideTransform != null) return ShopCoinOverrideTransform;
        string sceneName = SceneManager.GetActiveScene().name;
        if (sceneName == WordScene.MainScene)
        {
            return coinTransform;
        }

        return coinTransform;
    }

    public Transform GetShopCoinTransform()
    {
        if (ShopCoinOverrideTransform != null) return ShopCoinOverrideTransform;
        return ShopCoinTransform;
    }

    // Use this for initialization
    private void Start()
    {
        UpdateVideoAdView();
        EventDispatcher.AddEventListener(GlobalEvents.ShopVideoAdReady, ShowVideoFlag);
        EventDispatcher.AddEventListener(GlobalEvents.ShowVideoAD, OnVideoShow);
        //StartCoroutine(CheckAd());
        if (DataManager.GiftData == null
            || DataManager.GiftData.Config == null
            || string.IsNullOrEmpty(DataManager.GiftData.Config.Id))
        {
            HideSaleIcon();
            return;
        }

        if (s_OpenShop)
        {
            HideSaleIcon();
        }
        else
        {
            ShowSaleIcon();
        }
    }

    private void UpdateVideoAdView()
    {
        if (adView)
        {
            if (AppEngine.SAdManager.CanShowRewardVideo(AdManager.RewardVideoCallPlace.ShopBottom))
            {
                adView.SetActive(true);
            }
            else
            {
                adView.SetActive(false);
            }
        }
    }

    private void ShowVideoFlag()
    {
        if (adView)
            adView.SetActive(true);
    }

    private void OnVideoShow()
    {
        if (adView)
            adView.SetActive(false);
    }

    private void OnDestroy()
    {
        EventDispatcher.RemoveEventListener(GlobalEvents.ShopVideoAdReady, ShowVideoFlag);
        EventDispatcher.RemoveEventListener(GlobalEvents.ShowVideoAD, OnVideoShow);
        EventDispatcher.RemoveEventListener(GlobalEvents.GiftDataRev, OnRevGiftData);
    }

    public void OnClickStore()
    {
        TimersManager.SetTimer(0.5f, () => { clickHome = false; });
        if (DataManager.ShopData.ShowNoAdsSale)
            DataManager.ShopData.ShowNoAdsSale = false;

        if (saleIcon != null && saleIcon.enabled)
        {
            HideSaleIcon();
            s_OpenShop = true;
        }

        //Sound.instance.Play(Sound.Others.PanelShow);
    }

    private bool clickHome = false;

    public void HomeClick()
    {
        if (clickHome)
            return;
        clickHome = true;
        TimersManager.SetTimer(0.5f, () => { clickHome = false; });
        UIManager.OpenUIAsync(ViewConst.prefab_StoreDialog);
    }

    public void TriggerRubyAni(RubyAniType type)
    {
        if (RubyBalanceAni == null)
        {
            RubyBalanceAni = transform.Find("AniPack").GetComponent<Animator>();
        }

        if (RubyBalanceAni != null)
        {
            switch (type)
            {
                case RubyAniType.SingleCoin:
                    RubyBalanceAni.SetTrigger("Shake");
                    break;
                case RubyAniType.MoreCoin:
                    RubyBalanceAni.SetTrigger("Coinmore");
                    break;
                case RubyAniType.PromoUp:
                    RubyBalanceAni.SetTrigger("Shadow");
                    break;
                default:
                    break;
            }
        }
    }

    public void ShowSaleIcon()
    {
        if (saleIcon)
        {
            saleIcon.gameObject.SetActive(true);
            saleIcon.transform.GetComponent<CanvasGroup>().DOFade(1, 0.3f);
        }
    }

    public void HideSaleIcon()
    {
        if (saleIcon)
        {
            saleIcon.transform.GetComponent<CanvasGroup>().DOFade(0, 0.3f);
        }
    }

    private void OnRevGiftData()
    {
        if (s_OpenShop) return;

        ShowSaleIcon();
    }

    /// <summary>
    /// 高亮金币
    /// </summary>
    public void HighLightUI()
    {
    }

    /// <summary>
    /// 不高亮金币
    /// </summary>
    public void UnHighLightUI()
    {
    }
}

public enum RubyAniType
{
    SingleCoin, //一串金币的效果
    MoreCoin, //一堆金币的效果
    PromoUp, //促销面板贴过来的动画
    Reduce,
    None
}