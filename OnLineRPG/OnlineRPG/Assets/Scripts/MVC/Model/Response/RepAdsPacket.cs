
using Data.Request;
using Newtonsoft.Json;

public class AdsConfigRequestParam : BaseRequestParam
{
    public string platform;
    public string ver;
    public string group;
    public AdsConfigRequestParam(ServerCode MId, string platform, string ver, string group) : base(MId)
    {
        this.platform = platform;
        this.ver = ver;
        this.group = group;
    }
}

public class AdsConfigServerResponse
{
    public int code;
    public RepAdsData data;
}


public class RepAdsData
{
    [JsonProperty("rvCD")]
    public int RV_CD;
    [JsonProperty("rvRewardCoin")]
    public int RV_RewardCoin;
    [JsonProperty("rvMaxCount")]
    public int RV_MaxCount;
    [JsonProperty("gpRvBeginLevel")]
    public int GP_RV_BeginLevel;
    [JsonProperty("gpRvSwitch")]
    public bool GP_RV_IsShown;
    [JsonProperty("spRvSwitch")]
    public bool S_RV_IsShown;
    [JsonProperty("spRvBeginLevel")]
    public int S_RV_BeginLevel;
    [JsonProperty("csRvBeginLevel")]
	public int CS_RV_BeginLevel;
    [JsonProperty("csRvSwitch")]
	public bool CS_RV_IsShown;
    [JsonProperty("inShopOpenTimes")]
    public int IN_ShopOpenTimes;
    [JsonProperty("inCD")]
    public int IN_CD;
    [JsonProperty("inBeginLevel")]
    public int IN_BeginLevel;
    [JsonProperty("inMaxCount")]
    public int IN_MaxCount;

    /// <summary>
    /// 新添加
    /// </summary>
    public bool tcRvSwitch;
    public bool flashRvSwitch;
    public bool signRvSwitch;

    public bool inSwitch;
    public int inEarlyBL;
    public int inEarlyEL;
    public int inEarlyCD;
    public int inMidBL;
    public int inMidEL;
    public int inMidCD;
    public int inLateBL;
    public int inLateEL;
    public int inLateCD;

    public bool inDFirstSwitch;
    public int inDailyCD;
    public int inFlashCD;

    public bool inDailySwitch;
    public bool inFlashSwitch;

    public bool blogRvSwitch;

    public void ConvertToThis(AdsConfig_Data data)
    {
		this.S_RV_IsShown = data.SP_RV_IsShown;
		this.S_RV_BeginLevel = data.SP_RV_BeginLevel;
		this.RV_RewardCoin = data.RV_RewardCoin;
		this.RV_CD = data.RV_CD;
		this.GP_RV_IsShown = data.GP_RV_IsShown;
		this.GP_RV_BeginLevel = data.GP_RV_BeginLevel;
		this.RV_MaxCount = data.RV_MaxCount;
		this.IN_ShopOpenTimes = data.inShopOpenTimes;
		this.IN_CD = data.inCD;
		this.IN_BeginLevel = data.IN_BeginLevel;
		this.IN_MaxCount = data.inMaxCount;
		this.CS_RV_BeginLevel = data.CS_RV_BeginLevel;
		this.CS_RV_IsShown = data.CS_RV_IsShown;

        this.tcRvSwitch = data.tcRvSwitch;
        this.flashRvSwitch = data.flashRvSwitch;
        this.signRvSwitch = data.signRvSwitch;
        this.inSwitch = data.inSwitch;
        this.inEarlyBL = data.inEarlyBL;
        this.inEarlyEL = data.inEarlyEL;
        this.inEarlyCD = data.inEarlyCD;
        this.inMidBL = data.inMidBL;
        this.inMidEL = data.inMidEL;
        this.inMidCD = data.inMidCD;
        this.inLateBL = data.inLateBL;
        this.inLateEL = data.inLateEL;
        this.inLateCD = data.inLateCD;
        this.inDFirstSwitch = data.inDFirstSwitch;
        this.inDailyCD = data.inDailyCD;
        this.inFlashCD = data.inFlashCD;

        this.inDailySwitch = data.inDailySwitch;
        this.inFlashSwitch = data.inFlashSwitch;
        this.blogRvSwitch = data.blogRvSwitch;
    }

   

}