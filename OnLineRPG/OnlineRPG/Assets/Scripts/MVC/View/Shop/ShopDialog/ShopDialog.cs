using DG.Tweening;
using EventUtil;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using Scripts_Game.Managers;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopDialog : ShopBaseDialog
{
	
	//public ShopView shopView;
	public CoinPanel CoinPanel;
	public GameObject VideoButton;
    public TextMeshProUGUI[] adCoin;
	private void Awake()
	{
		//shopView = transform.Find("Content").GetComponent<ShopView>();
		//shopView.OnAwake();
		CoinPanel.OnAwake();
	}

	public override void OnOpen()
    {
	    AppEngine.SSoundManager.PlaySFX(ViewConst.wav_panel_show);
        KeyEventManager.Instance.AddBackPressListener(KeyEventManager.Priority.hppp, onBackPressed);
        EventDispatcher.AddEventListener(GlobalEvents.PurchaseInitSuccessful, OnPurchaseInitSucceed);
        EventDispatcher.AddEventListener(GlobalEvents.PurchaseInitFailer, OnPurchaseInitFailed);
        EventDispatcher.AddEventListener<IapProductConfig_Data>(GlobalEvents.PurchaseSuccessful, OnPurchaseSucceed);
        EventDispatcher.AddEventListener(GlobalEvents.PurchaseFailed, OnPurchaserFailed);
        EventDispatcher.AddEventListener(GlobalEvents.ShopVideoAdReady, ShowVideoButton);
        CloseButton.onClick.AddListener(CloseButtonClick);
		//shopView.Init();
		CoinPanel.Init();
		if (BetaFramework.AppEngine.SAdManager.CanShowRewardVideo(AdManager.RewardVideoCallPlace.ShopBottom))
		{
			VideoButton.transform.gameObject.SetActive(true);
			ADAnalyze.ADBtnShow("Shop");
		}
		else
		{
			VideoButton.transform.gameObject.SetActive(false);
		}
        foreach (var aElement in adCoin)
        {
            aElement.text = string.Format("+{0}", DataManager.AdsData.RV_RewardCoin);
        }
        //EventDispatcher.TriggerEvent(GlobalEvents.HideBanner);
    }

	private void ShowVideoButton()
	{
		VideoButton.transform.gameObject.SetActive(true);
		ADAnalyze.ADBtnShow("Shop");
	}

    public override void OnClose()
    {
        KeyEventManager.Instance.RemoveBackPressListener(KeyEventManager.Priority.hppp, onBackPressed);
        EventDispatcher.RemoveEventListener(GlobalEvents.PurchaseInitSuccessful, OnPurchaseInitSucceed);
        EventDispatcher.RemoveEventListener(GlobalEvents.PurchaseInitFailer, OnPurchaseInitFailed);
        EventDispatcher.RemoveEventListener<IapProductConfig_Data>(GlobalEvents.PurchaseSuccessful, OnPurchaseSucceed);
        EventDispatcher.RemoveEventListener(GlobalEvents.PurchaseFailed, OnPurchaserFailed);
        EventDispatcher.RemoveEventListener(GlobalEvents.ShopVideoAdReady, ShowVideoButton);
        CloseButton.onClick.RemoveListener(CloseButtonClick);
        EventUtil.EventDispatcher.TriggerEvent(GlobalEvents.CloseUI, UIName);
        m_CloseCallback?.Invoke(this);
    }

    protected override void CloseByBackPress()
    {
        CloseButtonClick();
    }

    public void CloseButtonClick()
    {
        if (!ResponseClick) return;
        AppEngine.SSoundManager.PlaySFX(ViewConst.wav_btn_normal);

		if (BetaFramework.AppEngine.SAdManager.CanShowRewardVideo(AdManager.RewardVideoCallPlace.ShopClose)) {
			ADAnalyze.ADBtnShow("ShopClose");
			UIManager.OpenUIAsync(ViewConst.prefab_RewardVideoDialog, OpenType.Replace, null, DataManager.AdsData.RV_RewardCoin);
		} else {
			AppEngine.SAdManager.LoadRewardVideo();
			Close();
// #if UNITY_EDITOR
// 			UIManager.OpenUIAsync(ViewConst.prefab_RewardVideoDialog, OpenType.Replace, null, DataManager.AdsData.RV_RewardCoin);
// #else
//             Close();
// #endif
		}
	}

    public void ClickShopVideo()
    {
	    ADAnalyze.AdBtnClick("Shop");
	    DataManager.ProcessData.advideosource = RewardSource.closeShopAD;
	    BetaFramework.AppEngine.SAdManager.ShowRewardVideo(AdManager.RewardVideoCallPlace.ShopBottom);
	    Close();
    }
	public void ClickRestore() {
		AppEngine.SPurchaserManager.RestorePurchases();
	}
}