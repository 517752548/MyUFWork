using System.Reflection.Emit;

public class PrefKeys
{
    /// <summary>
    /// 内购相关
    /// </summary>
    public const string PromotionPopupTimesPerDay = "P_PopupTimesPerDay";
    public const string PurchasedItem = "PurchasedItem";
    public const string ShowNoAdsSale = "ShowNoAdsSale";
    public const string ShopPendingList = "ShopBuyPendingListItem";
    public const string ShopPendingReceiptList = "ShopPendingReceiptList";

    /// <summary>
    /// 用户信息存档
    /// </summary>
    public const string Player_Near_Login_Time = "Info_playernearloginPayTime";

    public const string Player_CompleteLevel_PerDay = "player_complete_level_per_day";
    public const string Player_Login_Days = "player_login_days";
    public const string Player_MaxLoginConsecutiveDays = "player_max_login_consecutive_days";
    public const string Player_LoginConsecutiveDays = "player_login_consecutive_days";
    public const string Player_Install_Day = "FirstInstallDay";
    public const string Player_Open_Shop_Times = "info_playerOpenShopTimes";

    public const string Player_PlayerTag = "Player_PlayerTag";//用户标签
    public const string PlayerPopFacebookPanelTimes = "PlayerPopFacebookPanelTimes";
    public const string PlayerTheLastPayTime = "PlayerTheLastPayTime";//用户上一次付费时间
    public const string PlayerDistanceInTwoPay = "playerDistanceInTwoPay";//两次付费间隔
    public const string PlayerOpenGameTimes = "PlayerOpenGameTimes";//玩家打开游戏的次数
    public const string PlayerFirstTag = "PlayerFirstTag";

    /// <summary>
    /// 广告相关
    /// </summary>
    public const string RewardVideo_TotalShowTimes = "reward_video_total_showtimes";
    public const string RewardVideo_ShowTimes = "shop_video_showtimes";
    public const string RewardVideo_ShowFailTimes = "reward_video_show_fail_count";
    public const string Remove_Ads = "remove_ads";
    public const string DayAdDataStartDate = "ad_day_data_date";
    public const string Interstitial_TotalDisplayTimes = "ad_inter_display_count";
    public const string Interstitial_DayDisplayTimes = "ad_inter_day_display_count";

    public const string ChannelGroup = "channel_organic";
    public const string ChannelConversion = "channel_conversion";
    public const string AppsflyerAllData = "AppsflyerAllData";

    //firebase fb 相关
    public const string FaceBookLogined = "PlayerFaceBookLogined";
    public const string FbLoginGiftClaimed = "GetFacebookLoginGift";
    public const string FaceBookID = "FaceBookID";
    public const string FaceBookUserEmail = "FaceBookUserEmail";
    public const string FaceBookName = "FaceBookName";
    public const string FaceBookImageURL = "FaceBookImageURL";
    public const string FaceBookImageCache = "FaceBookImageCache";

    /// <summary>
    /// 评分是否给过金币
    /// </summary>
    public const string rateGiveCoin = "rateGiveCoin";


    public const string PrivacyPolicyShown = "PrivacyPolicyShown";
    public const string FirstLogin = "FirstLogin";

    public const string DeviceId = "DeviceId";

    public const string DDL_OnlineConfig = "DDL_OnlineConfig";
    public const string DDL_LevelMap = "DDL_LevelMap";
    public const string DDL_TurnIndex = "DDL_TurnIndex";
    public const string DDL_TurnTime = "DDL_TurnTime";

    public const string ClassicLevelProgress = "ClassicLevelProgress";
	public const string OneWordLevelProgress = "OneWordLevelProgress";
	public const string DailyLevelProgress = "DailyLevelProgress";
	public const string DailyMon = "DailyMon";
	public const string DailyDay = "DailyDay";
	public const string DailyYear = "DailyYear";
	public const string DailyMonth = "DailyMonth";
	public const string DailyStars = "DailyStars";
	public const string TodayCategory = "TodayCategory";
	public const string TodayLevelEntitys = "TodayLevelEntitys";
	public const string DailyFinished = "DailyFinished";
	public const string ClassicGameLevelIndex = "ClassicGameLevelIndex";
	public const string WordLibraryDailyPrefix = "WLDailyP";
	
	public const string KCDFirst = "kcdfirst";
	public const string ADTestAB = "ADTestAB";
	public const string RewardAB = "RewardAB";
	public const string DailyAB = "DailyAB";
	public const string PropAB = "PropAB";
	public const string CellTipAB = "CellTAB";
	public const string WordTestAB = "WordTestAB";
	public const string CurrentPetId = "CurrentPetId";
	
	public const string playerCrazeId = "playerCrazeId";
	public const string deviceId = "deviceId";
	public const string tokenID = "tokenID";
	public const string fbOnline = "fbOnline";

    public const string dailyInStamp = "dailyInStamp";
    public const string flashInStamp = "flashInStamp";
    public const string mainlineInStamp = "mainlineInStamp";
    public const string mainlineFirstLineOfDay = "mainlineFirstLineOfDay";
    
    
    public const string FastRaceRoomID = "FRRoomID";
    public const string FastRaceRoomGroup = "FRRoomGroup";
    public const string FastRaceACID = "FastRaceACID";
    public const string FastRaceScore = "FastRaceScore";
}