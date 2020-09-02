using BetaFramework;
using DG.Tweening;
using EventUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using com.forads.sdk;
using Newtonsoft.Json;
using Scripts_Game.Controllers.Dialog;
using UnityEngine.Events;

public enum Term
{
    none,
    prophase,
    mid,
    late
}

public class AdManager : IModule
{
#if UNITY_ANDROID
    private const string Reward_SpaceId = "1024";
    private const string Interstitial_SpaceId = "1022";
#else
    private const string Interstitial_SpaceId = "141";
    private const string Reward_SpaceId = "143";
#endif

    public const string Location_Interstitial = "interstitial";
    public const string Location_Banner = "banner";
    public const string Location_RewardVideo = "reward_video";
    public const string Location_Reward_Shop = "shop_rewarded_video";
    public const string Location_Reward_Game = "game_rewarded_video";
    public const string Location_Reward_ShopPacket = "shopPacket_rewarded_video";

    private static readonly string ShowFailMsg = "No internet connection";
    
    private bool isInit = false;
    private AdsConfig _adsConfig;
    private string curPlayerTag = null;
    private AdsConfig_Data _configData;
    
    Term interstitialTerm = Term.none;//插屏分期
    struct MixedLevel
    {
        public int levels;//记录因为广告未填充而错位的关卡
        public int checkRegionBegin;
    }
    MixedLevel mixedLevel;
    int inLastWatchLevel = -1;

    private event Action<bool> _onRewardedVideoAvailabilityChangedEvent;
    public event Action<bool> onRewardedVideoAvailabilityChangedEvent
    {
        add
        {
            if (_onRewardedVideoAvailabilityChangedEvent == null ||
                !_onRewardedVideoAvailabilityChangedEvent.GetInvocationList().Contains(value))
            {
                _onRewardedVideoAvailabilityChangedEvent += value;
            }
        }

        remove
        {
            if (_onRewardedVideoAvailabilityChangedEvent != null &&
                _onRewardedVideoAvailabilityChangedEvent.GetInvocationList().Contains(value))
            {
                _onRewardedVideoAvailabilityChangedEvent -= value;
            }
        }
    }
    
    public UnityEvent onAdClosed = new UnityEvent();

    public static void InitAD()
    {
#if UNITY_IOS
        FORADS.init("100084", !PlatformUtil.GetAppIsRelease());
#elif UNITY_ANDROID
        FORADS.init("100083", !PlatformUtil.GetAppIsRelease());
#endif
    }
    
    private void InitAdlib()
    {
        if (isInit)
            return;
        isInit = true;
        
        mixedLevel.levels = 0;
        mixedLevel.checkRegionBegin = -1;
        
        LoggerHelper.Log("AD manager do init");
        FORADS.getInstance().onAdDisplayedAction += OnAdDisplayed;
        FORADS.getInstance().onAdFailedToDisplayAction = new System.Action<ForAd>(onAdFailedToDisplay);
        FORADS.getInstance().onAdClosedAction += OnAdClosed;
        FORADS.getInstance().onUserEarnedReward = new System.Action<ForRewardItem>(onUserEarnedReward);
        UIManager.PreloadUI(adWaitMaskPrefabName);
    }

    public RepAdsData ADsConfig => DataManager.AdsData;
    // public AdsConfig_Data ADsConfig 
    // {
    //     get
    //     {
    //         if (_adsConfig == null)
    //             return new AdsConfig_Data();
    //         // if (_configData == null || _configData.ID != DataManager.BusinessData.PlayerTag)
    //         // {
    //         //     _configData = _adsConfig.dataList.Find(data => data.ID == DataManager.BusinessData.PlayerTag);
    //         // }
    //         if (_configData == null)
    //             _configData = _adsConfig.dataList[0];
    //         return _configData;
    //     }
    // }

    private void OnPurchaseSucceed(IapProductConfig_Data item)
    {
    }

    public void DisableAD()
    {
        AppEngine.SyncManager.Data.IsRemoveAd.Value = true;
    }

    #region 插屏广告相关
    /*************************************************Interstital*********************************************************/

    public enum InterstitialCallPlace
    {
        none = 0,
        ClassicLevelEnter = 1,
        DailyLevelEnter,
        OneWordEnter,
        BackGame,
        ClassicLevelComplete,
        DailyLevelComplete,
    }
    
    private InterstitialCallPlace _interstitialCallPlace;
    private Action<bool> interstitialShowCallback;
    private bool waitInterstitialDisplayCallback = false;

    public bool ShowInterstitialByCondition(InterstitialCallPlace callPlace, Action<bool> callback = null, string location = Location_Interstitial)
    {
        CheckToResetDayData();
        //检查是否去广告
        if (AppEngine.SyncManager.Data.IsRemoveAd.Value)
        {
            BetaFramework.LoggerHelper.Log("ShowInterstitialByCondition - ad removed");
            goto fail;
            return false;
        }

        //检查总开关
        if (ADsConfig.inSwitch == false)
        {
            BetaFramework.LoggerHelper.Log("ShowInterstitialByCondition - 配置里看插屏是关闭的");
            goto fail;
            return false;
        }

        //检查开启的主线关卡条件
        int unlockLevel = AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value;
        if (unlockLevel < ADsConfig.IN_BeginLevel)
        {
            BetaFramework.LoggerHelper.LogFormat("ShowInterstitialByCondition 在 level {0} 开始, now is {1}", 
                ADsConfig.IN_BeginLevel, unlockLevel);
            goto fail;
            return false;
        }
        
        //检查时间间隔
        if (!IsLocationOutCD(location, ADsConfig.IN_CD))
        {
            LoggerHelper.Log("ShowInterstitialByCondition - in cd");
            goto fail;
            return false;
        }
        
        //检查最大次数
        if (DataManager.UserGenAdData.InterstitialShowTimesOfDay.Value >= ADsConfig.IN_MaxCount)
        {
            LoggerHelper.Log("ShowInterstitialByCondition - reach max count " 
                                           + DataManager.UserGenAdData.InterstitialShowTimesOfDay.Value + "/" 
                                           + ADsConfig.IN_MaxCount);
            goto fail;
            return false;
        }

        //区分位置独立条件检查
        switch (callPlace)
        {
            case InterstitialCallPlace.BackGame:
                // if (!ADsConfig.IN_Back_Switch)
                // {
                //     LoggerHelper.Log("ShowInterstitialByCondition - 后台返回插屏是关闭的");
                //     return false;
                // }
                break;
            case InterstitialCallPlace.ClassicLevelEnter:
            case InterstitialCallPlace.ClassicLevelComplete:
                if (!XUtils.SameDay(DataManager.UserGenAdData.mainlineWatchINDate.Value, DateTime.Now))
                {
                    LoggerHelper.Log("第一天第一关不能看插屏");
                    DataManager.UserGenAdData.mainlineWatchINDate.Value = DateTime.Now;
                    DataManager.UserGenAdData.mainlineFirstLevelofDay.Value = unlockLevel;
                    goto fail;
                    return false;
                }
                else
                {
                    if (unlockLevel == DataManager.UserGenAdData.mainlineFirstLevelofDay.Value)
                    {
                        LoggerHelper.Log("第一天第一关不能看插屏-");
                        goto fail;
                        return false;
                    }
                }
                bool termChanged = false;
                    int termBeginLevel = 0;
                    int termEndLevel = 0;
                    int termCD = 0;

                    termBeginLevel = ADsConfig.inEarlyBL;
                    termEndLevel = ADsConfig.inEarlyEL;
                    termCD = ADsConfig.inEarlyCD;

                    if (unlockLevel >= ADsConfig.inEarlyBL && unlockLevel <= ADsConfig.inEarlyEL)
                    {
                        termChanged = interstitialTerm != Term.prophase;
                        interstitialTerm = Term.prophase;
                        termBeginLevel = ADsConfig.inEarlyBL;
                        termEndLevel = ADsConfig.inEarlyEL;
                        termCD = ADsConfig.inEarlyCD;
                    }
                    else if (unlockLevel >= ADsConfig.inMidBL && unlockLevel <= ADsConfig.inMidEL)
                    {
                        termChanged = interstitialTerm != Term.mid;
                        interstitialTerm = Term.mid;

                        termBeginLevel = ADsConfig.inMidBL;
                        termEndLevel = ADsConfig.inMidEL;
                        termCD = ADsConfig.inMidCD;
                    }
                    else if (unlockLevel >= ADsConfig.inLateBL && unlockLevel <= ADsConfig.inLateEL)
                    {
                        termChanged = interstitialTerm != Term.late;
                        interstitialTerm = Term.late;

                        termBeginLevel = ADsConfig.inLateBL;
                        termEndLevel = ADsConfig.inLateEL;
                        termCD = ADsConfig.inLateCD;
                    }

                    if (mixedLevel.checkRegionBegin != -1)
                    {
                        mixedLevel.levels += unlockLevel - mixedLevel.checkRegionBegin;
                    }
                    if (termChanged)
                    {
                        LoggerHelper.Log("term Change " + unlockLevel);
                        if ((unlockLevel - termBeginLevel - mixedLevel.levels) % termCD != 0)//防止连续观看的情况；同时尽可能保证观看的数量
                        {
                            goto fail;
                            return false;
                        }
                    }
                    else
                    {
                        LoggerHelper.Log("term not Change " + unlockLevel + " - " + inLastWatchLevel);
                        int playerPassed = unlockLevel - inLastWatchLevel;
                        if (playerPassed <= 0 || playerPassed % termCD != 0)
                        {
                            goto fail;
                            return false;
                        }
                    }
                break;
            case InterstitialCallPlace.DailyLevelEnter:
            case InterstitialCallPlace.DailyLevelComplete:
                if (!ADsConfig.inDailySwitch)
                {
                    LoggerHelper.Log("ShowInterstitialByCondition - 每日挑战插屏是关闭的");
                    goto fail;
                    return false;
                }
                if (XUtils.DaysApart(DataManager.UserGenAdData.dailyWatchINDate.Value, DateTime.Now) < ADsConfig.inDailyCD) {
                    LoggerHelper.Log("ShowInterstitialByCondition - 每日挑战插屏CD");
                    goto fail;
                    return false;
                }
                break;
            case InterstitialCallPlace.OneWordEnter:
                if (!ADsConfig.inFlashSwitch)
                {
                    LoggerHelper.Log("ShowInterstitialByCondition - 每日一词插屏是关闭的");
                    goto fail;
                    return false;
                }
                if (XUtils.DaysApart(DataManager.UserGenAdData.flashWatchINDate.Value, DateTime.Now) < ADsConfig.inFlashCD)
                {
                    LoggerHelper.Log("ShowInterstitialByCondition - 每日一词插屏CD");
                    goto fail;
                    return false;
                }
                break;
        }
        
        //检查广告平台是否已缓存广告
        if (!IsInterstitialReady())
        {
            if (mixedLevel.checkRegionBegin == -1)
            {
                mixedLevel.checkRegionBegin = unlockLevel;
            }
            BetaFramework.LoggerHelper.Log("ShowInterstitialByCondition - no cache");
            LoadInterstitial();
            goto fail;
            return false;
        }

        //条件满足，展示广告
        //ShowInterstitial(callPlace, location, Interstitial_SpaceId, 0.5f);
        WaitDialog.StartWait(1f, () => ShowInterstitial(callPlace, callback, location, Interstitial_SpaceId, 0f));
        return true;
        fail:callback?.Invoke(false);
        return false;
    }

    public bool ShowInterstitialNoCondition(InterstitialCallPlace callPlace, string location = Location_Interstitial)
    {
        CheckToResetDayData();
        //检查广告平台是否已缓存广告
        if (!IsInterstitialReady())
        {
            BetaFramework.LoggerHelper.Log("ShowInterstitialByCondition - no cache");
            LoadInterstitial();
            return false;
        }
        
        //条件满足，展示广告
        ShowInterstitial(callPlace, null, location, Interstitial_SpaceId, 0.5f);
        return true;
    }
    
    private void ShowInterstitial(InterstitialCallPlace callPlace, Action<bool> callback, string location = Location_Interstitial, string adSpaceId = Interstitial_SpaceId, float delay = 0)
    {
        _interstitialCallPlace = callPlace;
        interstitialShowCallback = callback;
        
        DOTween.Sequence().InsertCallback(delay, () =>
        {
            waitInterstitialDisplayCallback = true;
            FORADS.getInstance().displayAd(adSpaceId);
            ShowAdWaitMask(1); 
            Timer.Schedule(AppThreadController.instance, 1f, () =>
            {
                if (waitInterstitialDisplayCallback)
                {
                    waitInterstitialDisplayCallback = false;
                    // interstitialShowCallback?.Invoke(false);
                    // interstitialShowCallback = null;
                }
            });
        });

        LocationStartShow(location);
        switch (callPlace)
        {
            case InterstitialCallPlace.ClassicLevelEnter:
            case InterstitialCallPlace.ClassicLevelComplete:
            {
                inLastWatchLevel = AppEngine.SyncManager.Data.ClassicLevel.Value;
                break;
            }
            case InterstitialCallPlace.DailyLevelEnter:
            case InterstitialCallPlace.DailyLevelComplete:
            {
                DataManager.UserGenAdData.dailyWatchINDate.Value = DateTime.Now;
                break;
            }
            case InterstitialCallPlace.OneWordEnter:
            {
                DataManager.UserGenAdData.flashWatchINDate.Value = DateTime.Now;
                break;
            }
            default: break;
        }
        
        GameAnalyze.LogInsertVideoData("1", GetDataModeForEventLog(), AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value.ToString(),
            AppEngine.SSystemManager.GetSystem<TestABWordLibSystem>().GetUserTestLib());
        
        // int deltaSec = (int)DateTime.Now.Subtract(DataManager.AdData.LastInterstitialAdDisplayTime.Value).TotalSeconds;
        // int deltaLevel = DataManager.LevelData.CurrentAbsUnlockLevel - DataManager.AdData.LastInterstitialAdDisplayClassicLevel.Value;
        // CustomFTDSdk.AD_Interstitial_Show(deltaSec, deltaLevel);
    }

    public void LoadInterstitial(string adSpaceId = Interstitial_SpaceId)
    {
        FORADS.getInstance().loadAd(adSpaceId);
    }

    public bool IsInterstitialReady(string adSpaceId = Interstitial_SpaceId)
    {
        return FORADS.getInstance().isLoaded(adSpaceId);
    }

    private string GetDataModeForEventLog()
    {
        string inDataMode = "1";
        switch (_interstitialCallPlace)
        {
            case InterstitialCallPlace.ClassicLevelEnter:
            case InterstitialCallPlace.ClassicLevelComplete:
                inDataMode = "1";
                break;
            case InterstitialCallPlace.DailyLevelEnter:
            case InterstitialCallPlace.DailyLevelComplete:
                inDataMode = "2";
                break;
            case InterstitialCallPlace.OneWordEnter:
                inDataMode = "3";
                break;
            case InterstitialCallPlace.BackGame:
                inDataMode = "4";
                break;
        }

        return inDataMode;
    }

    private const string adWaitMaskPrefabName = ViewConst.prefab_AdWaitDialog;
    private AdWaitMaskDialog adWaitMask = null;
    private void ShowAdWaitMask(int adType)
    {
        if (adWaitMask != null)
            return;
        adWaitMask = (AdWaitMaskDialog) UIManager.OpenUIWindow(adWaitMaskPrefabName, 
            null, null, null, OpenType.Stack, (Action<int>)OnClickAdWaitMaskClose);
        adWaitMask.adType = adType;
    }

    private void CloseAdWaitMask(int adType)
    {
        if (adWaitMask != null)
        {
            adWaitMask.Close();
            adWaitMask = null;
        }

        if (adType == 1)
        {
            interstitialShowCallback?.Invoke(true);
            interstitialShowCallback = null;
        }
        else if (adType == 2)
        {
            DoVideoReward();
            _onRewardedVideoAvailabilityChangedEvent?.Invoke(IsRewardVideoReady());
        }
    }

    private void OnClickAdWaitMaskClose(int adType)
    {
        adWaitMask = null;
        if (adType == 1)
        {
            interstitialShowCallback?.Invoke(true);
            interstitialShowCallback = null;
        }
        else if (adType == 2)
        {
            DoVideoReward();
            _onRewardedVideoAvailabilityChangedEvent?.Invoke(IsRewardVideoReady());
        }
        onAdClosed.Invoke();
    }

    #endregion 插屏广告相关

    #region 激励视频广告
    /*************************************************RewardVideo*********************************************************/

    public enum RewardVideoCallPlace
    {
        none,
        ShopBottom,
        ShopClose,
        BlogGiftPanel,
        SubWorldGiftPanel,
        SignGiftPanel,
        OneWordExtraLevel,
    }

    private RewardVideoCallPlace _rewardVideoCallPlace = RewardVideoCallPlace.none;
    private Action<bool> rewardVideoCallback;

    public bool CanShowRewardVideo(RewardVideoCallPlace callPlace, string location = Location_RewardVideo)
    {
        CheckToResetDayData();
        
        if (AppEngine.SSystemManager == null 
            || AppEngine.SSystemManager.GetSystem<ClassicGameSystem>() == null 
            || AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel == null 
            || ADsConfig == null)
        {
            LoggerHelper.Log("广告config null");
            return false;
        }
        
        if (AppEngine.SyncManager.Data.VideoShowTimes.Value >= ADsConfig.RV_MaxCount)
        {
            BetaFramework.LoggerHelper.Log("reward video invalid - reach max count " +
                                           AppEngine.SyncManager.Data.VideoShowTimes.Value + "/" + ADsConfig.RV_MaxCount);
            return false;
        }
        
        
        if (!IsLocationOutCD(location, ADsConfig.RV_CD))
        {
            LoggerHelper.Log("reward video invalid - in cd");
            return false;
        }
   
        if (!IsRewardVideoReady())
        {
            BetaFramework.LoggerHelper.Log("reward video invalid - ad not cached");
            LoadRewardVideo();
            return false;
        }

        int unlockLevel = AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value;
        switch (callPlace)
        {
            case RewardVideoCallPlace.ShopBottom:
            {
                if (!ADsConfig.S_RV_IsShown)
                {
                    LoggerHelper.Log("reward video invalid - shop switch off");
                    return false;
                }
                if (unlockLevel < ADsConfig.S_RV_BeginLevel)
                {
                    LoggerHelper.Log("reward video invalid - shop begin at " + unlockLevel + "/" + ADsConfig.S_RV_BeginLevel);
                    return false;
                }
                break;
            }
            case RewardVideoCallPlace.ShopClose:
            {
                if (!ADsConfig.CS_RV_IsShown)
                {
                    LoggerHelper.Log("reward video invalid - shop switch off");
                    return false;
                }
                if (unlockLevel < ADsConfig.CS_RV_BeginLevel)
                {
                    LoggerHelper.Log("reward video invalid - shop begin at " + unlockLevel + "/" + ADsConfig.CS_RV_BeginLevel);
                    return false;
                }
                break;
            }
            case RewardVideoCallPlace.BlogGiftPanel:
                if (!ADsConfig.blogRvSwitch)
                {
                    LoggerHelper.Log("reward video invalid - blog switch off");
                    return false;
                }
                break;
            case RewardVideoCallPlace.SignGiftPanel:
                if (!ADsConfig.signRvSwitch)
                {
                    LoggerHelper.Log("reward video invalid - sign switch off");
                    return false;
                }
                break;
            case RewardVideoCallPlace.SubWorldGiftPanel:
                if (!ADsConfig.tcRvSwitch)
                {
                    LoggerHelper.Log("reward video invalid - subworld switch off");
                    return false;
                }
                break;
            case RewardVideoCallPlace.OneWordExtraLevel:
                if (!ADsConfig.flashRvSwitch)
                {
                    LoggerHelper.Log("reward video invalid - blog switch off");
                    return false;
                }
                break;
        }
        
        return true;
    }
    
    public void ShowRewardVideo(RewardVideoCallPlace callPlace, Action<bool> onReward = null, string location = Location_RewardVideo)
    {
        if (Application.internetReachability == NetworkReachability.NotReachable) //没网的情况直接不显示广告
        {
            BetaFramework.LoggerHelper.Log("reward video invalid - no net");
            onReward?.Invoke(false);
            return;
        }

        ShowRewardVideoAD(callPlace, onReward, location);
    }

    private void ShowRewardVideoAD(RewardVideoCallPlace callPlace, Action<bool> onReward, string location = Location_RewardVideo,
        string spaceId = Reward_SpaceId)
    {
        if (!IsRewardVideoReady(spaceId))
        {
            BetaFramework.LoggerHelper.Log("reward video invalid - ad not cached");
            LoadRewardVideo(spaceId);
            onReward?.Invoke(false);
            _onRewardedVideoAvailabilityChangedEvent?.Invoke(false);
            return;
        }
#if !UNITY_EDITOR
        AppEngine.SSoundManager.BgmPause();
#endif
        LocationStartShow(location);
        _rewardVideoCallPlace = callPlace;
        rewardVideoCallback = onReward;
#if UNITY_EDITOR
        onUserEarnedReward(null);
#else
		FORADS.getInstance().displayAd(spaceId);
#endif
        EventDispatcher.TriggerEvent(GlobalEvents.ShowVideoAD);
        time = -30;
        time2 = -30;
    }
    
    public void LoadRewardVideo(string spaceId = Reward_SpaceId)
    {
        if (IsRewardVideoReady(spaceId))
        {
            return;
        }

        FORADS.getInstance().loadAd(spaceId);
    }

    public bool IsRewardVideoReady(string spaceId = Reward_SpaceId)
    {
#if UNITY_EDITOR
        return true;
#endif
        return FORADS.getInstance().isLoaded(spaceId);
    }

    private void DoVideoReward()
    {
        bool executeRewardCoin = false;
        switch (_rewardVideoCallPlace)
        {
            case RewardVideoCallPlace.ShopBottom:
            case RewardVideoCallPlace.ShopClose:
                executeRewardCoin = true;
                break;
            case RewardVideoCallPlace.BlogGiftPanel:
                executeRewardCoin = false;
                break;
            case RewardVideoCallPlace.SubWorldGiftPanel:
                executeRewardCoin = false;
                break;
            case RewardVideoCallPlace.SignGiftPanel:
                executeRewardCoin = false;
                break;
            case RewardVideoCallPlace.OneWordExtraLevel:
                executeRewardCoin = false;
                break;
            default:
                break;
        }

        DataManager.UserGenAdData.VideoTotalShowTimes.Value++;
        AppEngine.SyncManager.Data.VideoShowTimes.Value++;
        
        rewardVideoCallback?.Invoke(true);
        rewardVideoCallback = null;

        _rewardVideoCallPlace = RewardVideoCallPlace.none;

        if (executeRewardCoin)
        {
            DOTween.Sequence().InsertCallback(0.1f, () =>
            {
                int RewardCoin = ADsConfig.RV_RewardCoin;
                RewardCoin = Mathf.RoundToInt(RewardCoin);
                UIManager.OpenUIAsync(ViewConst.prefab_VideoGiftDialog, OpenType.Replace, null, RewardCoin);
            });
        }
    }

    #endregion

    #region banner广告相关

    /*************************************************Banner*********************************************************/

    public bool IsBannerAvailable()
    {
        return false;
    }

    public void ShowBanner()
    {
        return;
    }

    public void HideBanner()
    {
    }

    public int GetBannerHeight()
    {
        return 0;
    }

    #endregion banner广告相关

    public AdManager()
    {
        EventDispatcher.AddEventListener<IapProductConfig_Data>(GlobalEvents.PurchaseSuccessful, OnPurchaseSucceed);
    }

    public override void Init()
    {
        CheckToResetDayData();
        InitAdlib();
        Timer.Schedule(AppThreadController.instance, 2, () =>
        {
            LoadServerConfig(null);
//             var group = AppEngine.SSystemManager.GetSystem<TestABSystem>().GetUserTestLib();
//
// #if UNITY_ANDROID
//             _adsConfig = PreLoadManager.GetPreLoadConfig<AdsConfig>(ViewConst.asset_AdsConfig_AndroidA);
// #elif UNITY_IOS
//             _adsConfig = PreLoadManager.GetPreLoadConfig<AdsConfig>(group.Equals("A") ? ViewConst.asset_AdsConfig_IosA : ViewConst.asset_AdsConfig_IosB);
// #endif
        });
    }

    public override void Execute(float deltaTime)
    {
        base.Execute(deltaTime);
        time += deltaTime;
        if (time >= 20)
        {
            time = 0;
            if (IsRewardVideoReady())
            {
                EventDispatcher.TriggerEvent(GlobalEvents.VideoAdReady);
                _onRewardedVideoAvailabilityChangedEvent?.Invoke(true);
                time = -9999999;
            }
        }

        time2 += deltaTime;
        if (time2 >= 20)
        {
            time2 = 0;
            if (CanShowRewardVideo(RewardVideoCallPlace.ShopBottom))
            {
                EventDispatcher.TriggerEvent(GlobalEvents.ShopVideoAdReady);
                time2 = -9999999;
            }
        }
        
        if (Application.platform == RuntimePlatform.Android && Input.GetKeyDown(KeyCode.Home))
        {
            LoggerHelper.Log("HOME press");
            willShowBackInterstitial = true;
            toBackgroundTime = DateTime.Now;
        }
        else if (Application.platform == RuntimePlatform.IPhonePlayer && Input.GetKeyDown(KeyCode.Home))
        {
            LoggerHelper.Log("HOME press");
            willShowBackInterstitial = true;
            toBackgroundTime = DateTime.Now;
        }
    }
    private float time = 0, time2 = 0;

    public override void Shut()
    {
        EventDispatcher.RemoveEventListener<IapProductConfig_Data>(GlobalEvents.PurchaseSuccessful, OnPurchaseSucceed);
    }

    private bool willShowBackInterstitial = false;
    private DateTime toBackgroundTime;
    public override void Pause(bool pause)
    {
        base.Pause(pause);
        //LoggerHelper.Log("ad manager pause " + pause + " && do buy " + DataManager.ProcessData.IgnoreBackInterstitial);
        // if (pause && !DataManager.ProcessData.IgnoreBackInterstitial)
        // {
        //     willShowBackInterstitial = true;
        //     toBackgroundTime = DateTime.Now;
        // }
        // else if (willShowBackInterstitial)
        if (!pause && willShowBackInterstitial)
        {
            LoggerHelper.Log("back from HOME press");
            willShowBackInterstitial = false;
            // if (DateTime.Now.Subtract(toBackgroundTime).TotalSeconds > ADsConfig.IN_Back_WaitTime)
            //     ShowInterstitialByCondition(InterstitialCallPlace.BackGame);
            
            //WaitDialog.StartWait(3f, () => ShowInterstitialByCondition(InterstitialCallPlace.BackGame));
            //ShowInterstitialByCondition(InterstitialCallPlace.BackGame);
        }
    }

    private readonly Dictionary<string, DateTime> locationStartTimeMap = new Dictionary<string, DateTime>();
    private void LocationStartShow(string location)
    {
        if (locationStartTimeMap.ContainsKey(location))
            locationStartTimeMap[location] = DateTime.Now;
        else
            locationStartTimeMap.Add(location, DateTime.Now);
    }

    private bool IsLocationOutCD(string location, int cdTime)
    {
        if (!locationStartTimeMap.ContainsKey(location))
            return true;
        return DateTime.Now.Subtract(locationStartTimeMap[location]).TotalSeconds > cdTime;
    }

    private void CheckToResetDayData()
    {
        if (!XUtils.SameDay(DataManager.UserGenAdData.DayDataStartDate.Value, DateTime.Now))
        {
            DataManager.UserGenAdData.DayDataStartDate.Value = DateTime.Now;
            DataManager.UserGenAdData.InterstitialShowTimesOfDay.Value = 0;
            AppEngine.SyncManager.Data.VideoShowTimes.Value = 0;
        }
    }

    #region Forads CallBack 广告平台回调

    void onUserEarnedReward(ForRewardItem rewardItem)
    {
        LoggerHelper.Log("onUserEarnedReward>>>" + rewardItem);
        ADAnalyze.AdRewarded();
        ShowAdWaitMask(2);
    }

    void OnAdDisplayed(ForAd ad)
    {
        LoggerHelper.Log("ad test OnAdDisplayed ");
        if (ad.adType.Equals(ForAdType.REWARDEDAD))
        {
            //Time.timeScale = 0;
            ADAnalyze.AdShowing(ad.platformDesc,ad.PlatformId);
        }
        else if (ad.adType.Equals(ForAdType.INTERSTITIALAD))
        {
            waitInterstitialDisplayCallback = false;
            DataManager.UserGenAdData.InterstitialTotalShowTimes.Value++;
            DataManager.UserGenAdData.InterstitialShowTimesOfDay.Value++;
        }
    }

    void onAdFailedToDisplay(ForAd forAd)
    {
        LoggerHelper.Log("ad test onAdFailedToDisplay ");
        AppEngine.SSoundManager.BgmUnPause();
        LoggerHelper.Log("onAdFailedToDisplay>>>" + forAd);
        
        if (ForAdType.REWARDEDAD.Equals(forAd.AdType))
        {
            UIManager.ShowMessage("Play failed. Please try again.");
            DataManager.UserGenAdData.VideoTotalShowFailTimes.Value++;
            rewardVideoCallback?.Invoke(false);
            rewardVideoCallback = null;
        }
        else if (forAd.adType.Equals(ForAdType.INTERSTITIALAD))
        {
            int unlockLevel = AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value;
            GameAnalyze.LogInsertVideoData("3", GetDataModeForEventLog(), unlockLevel.ToString(),
                AppEngine.SSystemManager.GetSystem<TestABWordLibSystem>().GetUserTestLib());
            CloseAdWaitMask(1);
        }

        ADAnalyze.AdShowFailed();
    }

    void OnAdClosed(ForAd ad)
    {
        LoggerHelper.Log("ad test OnAdClosed ");
        AppEngine.SSoundManager.BgmUnPause();

        if (ad.adType.Equals(ForAdType.INTERSTITIALAD))
        {
            int unlockLevel = AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value;
            GameAnalyze.LogInsertVideoData("2", GetDataModeForEventLog(), unlockLevel.ToString(),
                AppEngine.SSystemManager.GetSystem<TestABWordLibSystem>().GetUserTestLib());
            CloseAdWaitMask(1);
        }
        else if (ForAdType.REWARDEDAD.Equals(ad.AdType))
        {
            //Time.timeScale = 1;
            if (adWaitMask != null)
            {
                CloseAdWaitMask(2);
            }
            rewardVideoCallback?.Invoke(false);
        }
        onAdClosed.Invoke();
    }

    #endregion

    private void LoadServerConfig(Action<bool> callback)
    {
        string platform = "ios";
#if UNITY_ANDROID
		platform = "android";
#endif
        AdsConfigRequestParam request = new AdsConfigRequestParam(ServerCode.AdConfig, platform, "1",
            AppEngine.SSystemManager.GetSystem<TestABSystem>().GetUserTestLib());
        string json = JsonConvert.SerializeObject(request);
        WebRequestPostUtility.Instance.PostJson(Const.ServerUrl, (back) =>
        {
            if (back.isNetworkError || back.isHttpError)
            {
                callback?.Invoke(false);
            }
            else
            {
                try
                {
                    //Debug.LogError("广告配置:" + back.downloadHandler.text);
                    AdsConfigServerResponse rep =
                        JsonConvert.DeserializeObject<AdsConfigServerResponse>(back.downloadHandler.text);
                    if (rep.code != 200)
                    {
                        callback?.Invoke(false);
                    }
                    else
                    {
                        LoggerHelper.Log("AD: using server config ");
                        DataManager.AdsData = rep.data;
                        callback?.Invoke(true);
                    }
                }
                catch (Exception e)
                {
                    BetaFramework.LoggerHelper.Log("AD: load server config--" + e.StackTrace);
                    callback?.Invoke(false);
                }
            }
        }, json, AppEngine.SSystemManager.GetSystem<PlayerLoginSystem>().GetHeaders());
    }
}