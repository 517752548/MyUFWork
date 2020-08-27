using Newtonsoft.Json;

/// <summary>
/// 线上广告策略读取结构
/// </summary>
public class RewardVideoData
{
    [JsonProperty("MinSubWorld")]
    public string MinSubWorld { get; set; }

    [JsonProperty("MaxSubWorld")]
    public string MaxSubWorld { get; set; }

    [JsonProperty("GameRewardVideoWaitTime")]
    public string GameRewardVideoWaitTime { get; set; }

    [JsonProperty("GameVideoShowTimes")]
    public string GameVideoShowTimes { get; set; }

    [JsonProperty("ShopRewardVideoWaitTime")]
    public string ShopRewardVideoWaitTime { get; set; }

    [JsonProperty("ShopVideoShowTimes")]
    public string ShopVideoShowTimes { get; set; }

    [JsonProperty("WinRewardVideoWaitTime")]
    public string WinRewardVideoWaitTime { get; set; }

    [JsonProperty("WinVideoShowTimes")]
    public string WinVideoShowTimes { get; set; }

    [JsonProperty("ExtraRewardVideoWaitTime")]
    public string ExtraRewardVideoWaitTime { get; set; }

    [JsonProperty("ExtraVideoShowTimes")]
    public string ExtraVideoShowTimes { get; set; }

    public RewardVideoData()
    {
        this.MinSubWorld = "1";
        this.MaxSubWorld = "10000";
        this.GameRewardVideoWaitTime = "120";
        this.GameVideoShowTimes = "10";

        this.ShopRewardVideoWaitTime = "120";
        this.ShopVideoShowTimes = "10";

        this.WinRewardVideoWaitTime = "120";
        this.WinVideoShowTimes = "10";

        this.ExtraRewardVideoWaitTime = "120";
        this.ExtraVideoShowTimes = "10";
    }
}