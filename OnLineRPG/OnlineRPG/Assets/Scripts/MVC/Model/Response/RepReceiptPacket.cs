using BetaFramework;

public class RepReceiptPacket : SerializablePacket
{
    public int code;
    public string belong;

    public int purchase_status;

    public string purchase_date;

    public string productId;

    public string purchase_env;
}

public class PurchaseEnv
{
    public const string SandBox = "sandbox";
    public const string OnLine = "online";
}