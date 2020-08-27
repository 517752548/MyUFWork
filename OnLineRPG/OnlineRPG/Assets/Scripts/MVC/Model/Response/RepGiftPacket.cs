using BetaFramework;

public class RepGiftPacket : SerializablePacket
{
    public int code;
    public RepGiftData data;
}

public class RepGiftData
{
    public int FPL;             // 第一次弹出关卡值
    public int PN;              // 最大弹板次数
    public int PL;              // 每天通过几关后弹出
    public int PT;              // 剩余多长时间弹
    public int GiftId;          // 当前礼包id   如果新手礼包期间 值为0
    public int Type;            // 礼包类型 1新手 2促销 0正常购买项
    public int Time;            // 礼包剩余时间 （当类型为新手时  代表新手期剩余时间）
    public string Belong;       // 分层信息
    public string StoreId;      // AB Test

    public RepGiftProduct Config;
}

public class RepGiftProduct
{
    public string Id;
    public int Coin;
    public int Hint1;
    public int Hint2;
    public int Hint3;
    public string More;
}