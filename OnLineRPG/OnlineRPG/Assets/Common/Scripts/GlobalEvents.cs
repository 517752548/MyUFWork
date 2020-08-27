using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalEvents
{

    public static readonly string PurchaseSuccessful = "OnPurchaseSuccessful";
    public static readonly string PurchaseInitSuccessful = "PurchaseInitSuccessful";
    public static readonly string PurchaseInitFailer = "PurchaseInitFailer";
    public static readonly string PurchaseFailed = "OnPurchaseFailed";

    public static readonly string FaceBookInitOver = "FaceBookInitOver";
    public static readonly string FaceBookLoginedSuccessful = "FaceBookLoginedSuccessful";
    public static readonly string ShopCoinAniPack = "ShopCoinAniPack";
    public static readonly string RemoveAd = "RemoveAd";
    public static readonly string FaceBookUserInfoLoaded = "FaceBookUserInfoLoaded";

    public static readonly string FirebaseInitSuccess = "FirebaseInitSuccess";

    //商业化配置相关
    public static readonly string BusinessConfigDataRequestSuccess = "BusinessConfigDataRequestSuccess";
    public static readonly string BusinessConfigDataRequestFail = "BusinessConfigDataRequestFail";
    public static readonly string BusinessConfigDataLocalInit = "BusinessConfigDataLocalInit";
    
    public const string SkipBalanceAni = "SkipBalanceAni";
    public const string SkipBalanceUpdate = "SkipBalanceUpdate";
    
    public static readonly string SceneChanged = "SceneChanged";

    //ad
    public static readonly string ShowBanner = "ShowBanner";
    public static readonly string HideBanner = "HideBanner";
    public static readonly string RewardVideoRunOutOf = "RewardVideoRunOutOf";
    public static readonly string BannerAppeared = "BannerAppeared";//banner 出现
    public static readonly string BannerDisaAppeared = "BannerDisaAppeared";//banner 消失
    public const string ShowVideoAD = "ShowVideoAD";
    public const string VideoAdReady = "VideoAdReady";
    public const string ShopVideoAdReady = "ShopVideoAdReady";

    public const string CheckTaskQueue = "CheckTaskQueue";

    public const string GiftDataRev = "GiftDataRev";

    public const string PrizeClawRoll = "PrizeClawRoll";
  
    public const string HeadChanged = "HeadChanged";
    public const string NickNameChanged = "NickNameChanged";

    public const string RefreshPetsDialog = "RefreshPetsDialog";
    public const string RefreshTitleDialog = "RefreshTitleDialog";

    public const string PetAdd = "PetAdd";

    public const string OpenUI = "OpenUI";
    public const string CloseUI = "CloseUI";
    public const string LoginStatusRefresh = "LoginStatusRefresh";
    public const string FRConfigInited = "FRConfigInited";
    public const string NewRoomEnter = "NewRoomEnter";
    /// <summary>
    /// 向homeroot 状态机发消息
    /// </summary>
    public const string TriggerHomeRootFsm = "TriggerHomeRootFsm";




    public const string EliteConfigLoad = "EliteConfigLoad";
    public const string HomeRootBanClick = "HomeRootBanClick";
}