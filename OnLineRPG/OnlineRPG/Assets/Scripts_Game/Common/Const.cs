using System.Collections.Generic;
using BetaFramework;
using UnityEngine;

/// <summary>
/// 评价链接和邮箱链接的改动在这里
/// 还需要改动的地方有
/// sheet.xml
/// gamecontroller本地推送文本
/// rate界面文本
/// 活动界面--这里不开启活动的话不需要改
/// </summary>
public partial class Const
{
    const string iOSVersion = "1.1.8";
    const string AndroidVersion = "1.10";
    public static string Version
    {
        get
        {
#if UNITY_IOS
            return iOSVersion;
#else
            return AndroidVersion;
#endif
        }
    }

    public const string Android = "Android";
    public const string iOS = "Ios";

    public static string Platform
    {
        get
        {
#if UNITY_IOS
            return iOS;
#else
            return Android;
#endif
        }
    }

    public static bool reportFB = true;
    public static bool AutoPlay = false;

    public static bool UseInput = false;

    //视频广告奖励
    public const int VIDEO_REWARD = 25;

    public const string DefaultTag = "campaign";
    public const string defaultPet = "1000001";

    public const string GooglePublicKey =
        "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAjs7egYtyvLzzwaQmnddZbMCXH+HvPWOm9uuW9VEpKH0pDfM3GryLXRh2QuoFOud3SwpCElHri0nzcn/TyK2jJRuxvzUcvySiru4wmqNc0Xdcz8PL0AUeTXN1N3ZKeK/tJBCIjGV3aMsRn4bdyVvxuJWwF4mwXed8MYkq8caRXnxs3MI/mY68yFA7fel4bmsTdeSKy5by9oreggDfMe7EuxQfyq6cDbkPn0rm7Tgh7wfbfYo1ongtQj7rOHCpSOyKAy/BBZJG/47fcj5W82WyEJB5pAQ5F+FNyNguSoPyJmq9g+Vsh4xbvsBvxNAWs0KxvC4mxwn5YIGkf6YrWA0F8wIDAQAB";

    //email链接
    public const string APP_EMAIL = "wordcraze@outlook.com";

    public const int emailversion = 1;

#if UNITY_ANDROID
    //appstore评价链接
    public const string APPSTORE_URL = "market://details?id=com.wordgame.newcross.android.en";

    public const string FACEBOOKMAINURL = "https://www.facebook.com/434318770297972/";
#else
    //appstore评价链接
    public const string APPSTORE_URL = "https://itunes.apple.com/app/id1473573813?mt=8";

    public const string FACEBOOKMAINURL = "https://www.facebook.com/434318770297972/";
#endif

    public const string FanPage_URL = "https://www.facebook.com/wordcraze.game/";

    public const int DailyUnlockLevel = 29;


    //邮箱收集与兑奖码

    public static string ServerRootUrl = "http://wapifiles.wordzhgame.net/zhongyuan/Android/";
    public static string OnLineBundleUrl = "https://wapifiles.wordzhgame.net/activityfiles";

    public const int FacebookLoginCoin = 100;
    public const int OnlineBundleVersion = 4;


    public static string ServerUrl
    {
        get
        {
            if (PlatformUtil.GetAppIsRelease())
            {
                return "https://wcraze.wordzhgame.net/api";
            }
            else
            {
                return "https://wcrazesandbox.wordzhgame.net/api";
            }
        }
    }

    //精英关卡版本玩法相关数据服务器地址
    public static string Elite_ServerUrl
    {
        get
        {
            //程江改回了原来的服务器地址
            return ServerUrl;
            if (PlatformUtil.GetAppIsRelease())
            {
                return "https://crazevs.wordzhgame.net/api";
            }
            else
            {
                return "https://crazevssabdbox.wordzhgame.net/api";
            }
        }
    }

    public static string AsyncServerUrl
    {
        get
        {
            if (PlatformUtil.GetAppIsRelease())
            {
                return "https://us-central1-word-craze-ea3c1.cloudfunctions.net/syncData";
            }
            else
            {
                return "https://us-central1-wordcalmendemo.cloudfunctions.net/syncData";
            }
        }
    }
}


//{PathC.PathConst.BundleReleaseUrl}
namespace PathC
{
#if UNITY_IOS
    public static class PathConst
    {
        public static string BundleReleaseUrl
        {
            get
            {
                if (PlatformUtil.GetAppIsRelease())
                {
                    return "https://wfs.wordzhgame.net/activityfiles/CodyLevel/iOS/Release/" + Const.Version;
                }
                else
                {
                    return "https://wfs.wordzhgame.net/activityfiles/CodyLevel/iOS/Debug/" + Const.Version;
                }
            }
        }

#else
    public static class PathConst
    {

        public static string BundleReleaseUrl
        {
            get
            {

                {
                    if (PlatformUtil.GetAppIsRelease())
                    {
                        return "https://wapifiles.wordzhgame.net/activityfiles/CodyLevel/Android/Release/" +
                               Const.Version;
                    }
                    else
                    {
                        return "https://wapifiles.wordzhgame.net/activityfiles/CodyLevel/Android/Debug/" +
                               Const.Version;
                    }
                }
            }
        }

#endif
    }


    public static class PathLevelConst
    {
        public static string ServerLevelURL
        {
            get
            {
                string platform = "iOS/";
#if UNITY_ANDROID
                platform = "Android/";
#endif
                if (PlatformUtil.GetAppIsRelease())
                {
                    return "https://wfs.wordzhgame.net/activityfiles/CrazeLevel/Release/Level/" + platform +
                           Const.Version;
                }
                else
                {
                    return "https://wfs.wordzhgame.net/activityfiles/CrazeLevel/Debug/Level/" + platform +
                           Const.Version;
                }
            }
        }

        public static string ServerImageURL
        {
            get
            {
                if (PlatformUtil.GetAppIsRelease())
                {
                    return "https://wfs.wordzhgame.net/activityfiles/CrazeLevel/Release/Image/";
                }
                else
                {
                    return "https://wfs.wordzhgame.net/activityfiles/CrazeLevel/Debug/Image/";
                }
            }
        }
    }
}


public enum GameMode
{
    Classic,
    Daily,
    OneWord,
    Pve,
    Elite
}

public enum UILayer
{
    Default,
    UI,
    UI2,
    Toast,
    BG
}

public enum UiLayerOrder
{
    Cells = -50,
    def = 0,
    low = 100,
    Noamrl = 200,
    High = 300,
    Guide = 601
}

public enum BatItem
{
    Pet = 21,
    Fans = 16,
    Hint5 = 15,
    Hint4 = 14,
    Hint3 = 13,
    Hint2 = 12,
    Hint1 = 11,
    Coin = 10
}

public enum InventoryType
{
    Coin = 10,
    Hint1 = 11,
    Hint2 = 12,
    Hint3 = 13,
    Hint4 = 14,
    Fans = 16,
    Cup = 17,
    EliteTicket = 18,
    Pet = 21,
    Bee = 22,
    Title = 23,
}

public enum ServerCode
{
    Test = 5,
    DailyLib = 101,
    TestADAB = 102,
    ServerTime = 103,
    CreatAccount = 110,
    CreatFBAccount = 111,
    FBLoginOut = 112,
    GetPlayerOnlineData = 113,
    ChangePlayerInfo = 114,
    DataSync = 116,
    GetEmail = 117,
    ChangeEmail = 118,
    AdConfig = 119,
    TestWordAB = 121,
    OneWordLib = 122,
    RewardAB = 123,
    ChampionChallenge = 125,
    BusinessGift = 126,
    PlayerBuy = 127,
    PlayerLayer = 128,
    FastRace = 201,
    JoinFastRaceRoom = 202,
    FRUploadScore = 203,
    GetFastRaceList = 204,
    GetFastRaceRank = 205,
    GetFastRaceReward = 206,
    EliteConfig = 600,
    TitleConfig = 601,
    GetOwendTitle = 602,
    UploadTitleData = 603,
    DeleteTitle = 604,
}

public enum CardPieceMode
{
    none,
    one = 1,
    two_12 = 200,
    two_21 = 201,
    three_123 = 300,
    three_132 = 301,
    four_1243 = 400,
    circle_four_1423 = 401,
    four_1324 = 402,
    four_1432 = 403,
    four_4231 = 404,
    five_14235 = 500,
    five_12435 = 501,
    five_12534 = 502,
    five_12543 = 503,
    five_12345 = 504,
    six_163425 = 600,
    six_123654 = 601,
    six_123456 = 602,
}