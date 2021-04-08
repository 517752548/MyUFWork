using System;
using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using UnityEngine;

public class AdmobAD
{
    private BannerView bannerView;
    private InterstitialAd interstitial;
    private RewardedAd rewardedAd;
    private Action<bool> callback;

    public void Init()
    {
        MobileAds.Initialize(initStatus => { Debug.Log("init"); });
        RequestBanner();
        RequestRewardAD();
    }

    private void RequestRewardAD()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-5075838870092598/7116330623";
#elif UNITY_IPHONE
            string adUnitId = "unexpected_platform";
#else
            string adUnitId = "unexpected_platform";
#endif
        this.rewardedAd = new RewardedAd(adUnitId);
        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;
        LoadRewardAD();
    }

    private void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
    }

    private void HandleUserEarnedReward(object sender, EventArgs args)
    {
        callback?.Invoke(true);
        callback = null;
    }

    private void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        LoadRewardAD();
    }

    private void RequestBanner()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-5075838870092598/5320867371";
#elif UNITY_IPHONE
            string adUnitId = "unexpected_platform";
#else
            string adUnitId = "unexpected_platform";
#endif

        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
    }

    public void ShowBanner()
    {
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the banner with the request.
        this.bannerView.LoadAd(request);
        this.bannerView.Show();
    }

    public void CloseBanner()
    {
        this.bannerView.Hide();
    }

    public void LoadRewardAD()
    {
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);
    }

    public void ShowADVideo(Action<bool> back)
    {
        if (this.rewardedAd.IsLoaded())
        {
            this.callback = back;
            this.rewardedAd.Show();
        }
        else
        {
            LoadRewardAD();
            back.Invoke(false);
        }
    }
}