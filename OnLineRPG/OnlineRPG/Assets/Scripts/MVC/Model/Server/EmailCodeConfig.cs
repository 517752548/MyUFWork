using Newtonsoft.Json;

public class EmailCodeConfig
{
    [JsonProperty("Enable")]
    public bool Enable { get; set; }

    [JsonProperty("Levels")]
    public string Levels { get; set; }

    [JsonProperty("RewardCoins")]
    public int RewardCoins { get; set; }

    public EmailCodeConfig()
    {
        Enable = true;
        Levels = "15,25";
        RewardCoins = 1000;
    }
}