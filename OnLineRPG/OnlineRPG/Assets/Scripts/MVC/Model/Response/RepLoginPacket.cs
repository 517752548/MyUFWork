using BetaFramework;

public class RepLoginPacket : SerializablePacket
{
    // 200：成功第一次分组
    // 201：分组已存在
    public int code;

    public string storeId;
}