/// <summary>
/// 线上配置的经济系统
/// </summary>
public class EconomicData
{
    public EconomicData()
    {
        NormalHint = 50;
        SpecificHint = 100;
        MultiHint = 280;
        RewardVideoRatio = 1;
        ProductHintIndex = 0;
        ButterflyMoveCoin = 280;
        HalloweenMoveCoin = 280;
    }

    public int NormalHint { get; set; }
    public int SpecificHint { get; set; }
    public int MultiHint { get; set; }
    public float RewardVideoRatio { get; set; }
    public int ProductHintIndex { get; set; }
    public int ButterflyMoveCoin { get; set; }
    public int HalloweenMoveCoin { get; set; }
}

public class EconomicServerEntities
{
    public string tid;
    public string gid;
    public string data;
    public int code;
}