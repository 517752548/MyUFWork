using Newtonsoft.Json;
using System.Collections.Generic;

public class SubWorldRewardData
{
    public Dictionary<string, SubWorldReward> rewards;

    public SubWorldRewardData()
    {
        rewards = new Dictionary<string, SubWorldReward>();
    }
}

public class SubWorldReward
{
    [JsonProperty("t")]
    public int type { get; set; }

    [JsonProperty("c")]
    public int count { get; set; }

    public SubWorldReward()
    {
        type = 1;
        count = 1;
    }
}