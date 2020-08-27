using Newtonsoft.Json;

public class ServerTimeData
{
    public NetTime data;
    public int code;
    // Use this for initialization
}

public class NetTime
{
    [JsonProperty("time")]
    public string time { get; set; }

    public NetTime()
    {
        this.time = "0";
    }
}