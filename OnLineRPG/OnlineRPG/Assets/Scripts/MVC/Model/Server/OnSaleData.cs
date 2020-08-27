public class OnLevelSaleData
{
    public string ActionName;
    public string WorldId;
    public string SubWorldId;
    public string Duration;

    public OnLevelSaleData()
    {
        ActionName = "Level_On_Sale";
        WorldId = "1";
        SubWorldId = "1";
        Duration = "24";
    }
}

public class OnTimeSaleData
{
    public string ProductId;
    public string BegainTime;
    public string EndTime;
}