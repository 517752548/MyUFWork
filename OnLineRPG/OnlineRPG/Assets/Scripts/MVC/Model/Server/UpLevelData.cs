using Newtonsoft.Json;

public class UpLevelData
{
    [JsonProperty("updateversion")]
    public string updateversion { get; set; }

    [JsonProperty("LevelAbVersioncode")]
    public string LevelAbVersioncode { get; set; }

    [JsonProperty("AppVersion")]
    public string AppVersion { get; set; }

    [JsonProperty("HinkClick")]
    public string HinkClick { get; set; }

    [JsonProperty("UserLogin")]
    public string UserLogin { get; set; }

    [JsonProperty("PassLevel")]
    public string PassLevel { get; set; }

    [JsonProperty("PlayerPay")]
    public string PlayerPay { get; set; }

    [JsonProperty("ChannelDivideWordAB")] //对半分词库的渠道
    public string ChannelDivideWordAB { get; set; } //ChannelOrderWordA

    [JsonProperty("ChannelOrderWordA")]
    public string ChannelOrderWordA { get; set; }

    [JsonProperty("FaceBookSendCoin")]
    public string FaceBookSendCoin { get; set; }

    [JsonProperty("FaceBookSendCoinCD")]
    public string FaceBookSendCoinCD { get; set; }

    [JsonProperty("UpdaWordLibBaseOnBuild")]
    public string UpdaWordLibBaseOnBuild { get; set; }

    [JsonProperty("ENWordLibConfig")]
    public string ENWordLibConfig { get; set; }

    [JsonProperty("DEWordLibConfig")]
    public string DEWordLibConfig { get; set; }

    [JsonProperty("FRWordLibConfig")]
    public string FRWordLibConfig { get; set; }

    [JsonProperty("ENWordABCLibConfig")]
    public string ENWordABCLibConfig { get; set; }

    [JsonProperty("ENWordABCLibprobability")]
    public string ENWordABCLibprobability { get; set; }

    [JsonProperty("ENWordABLibprobability")]
    public string ENWordABLibprobability { get; set; }

    [JsonProperty("DEWordABCLibConfig")]
    public string DEWordABCLibConfig { get; set; }

    [JsonProperty("FRWordABCLibConfig")]
    public string FRWordABCLibConfig { get; set; }

    public UpLevelData()
    {
        updateversion = "1,2";
        LevelAbVersioncode = "1";
        AppVersion = "1";
        HinkClick = "true";
        UserLogin = "true";
        PassLevel = "true";
        PlayerPay = "true";
        ChannelDivideWordAB = "one,two";
        ChannelOrderWordA = "one,two";
        FaceBookSendCoin = "5";
        FaceBookSendCoinCD = "4";
        UpdaWordLibBaseOnBuild = "true";
        ENWordLibConfig = "";
        DEWordLibConfig = "";
        FRWordLibConfig = "";
        ENWordABCLibConfig = "";
        DEWordABCLibConfig = "";
        FRWordABCLibConfig = "";
        ENWordABCLibprobability = "24000,4500,1500";
        ENWordABLibprobability = "10000,10000";
    }
}