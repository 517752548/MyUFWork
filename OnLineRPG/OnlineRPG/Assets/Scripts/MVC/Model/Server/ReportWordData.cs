using Newtonsoft.Json;

/// <summary>
/// 线上json配置读取结构
/// </summary>
public class ReportWordEntity
{
    public ReportWordData data;
    public int code;
}

public class ReportWordData
{
    [JsonProperty("ReportWordlist")]
    public bool ReportWordlist { get; set; }

    [JsonProperty("ReportWordlistAbslevel")]
    public string ReportWordlistAbslevel { get; set; }

    [JsonProperty("ReprotWordlistDate")]
    public string ReprotWordlistDate { get; set; }

    [JsonProperty("ReportWordlstsHour")]
    public string ReportWordlstsHour { get; set; }

    public ReportWordData()
    {
        this.ReportWordlist = true;
        this.ReportWordlistAbslevel = "1,2|3,4|5,6";
        this.ReprotWordlistDate = "20180112-20180321";
        this.ReportWordlstsHour = "12:00-14:00,11:00-17:00";
    }
}