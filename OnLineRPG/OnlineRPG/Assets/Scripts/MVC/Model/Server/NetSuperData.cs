using System.Collections.Generic;

public class NetSuperData
{
    /// <summary>
    /// 线上json配置读取结构
    /// </summary>
    public NetConfigData data;

    public int code;
}

public class NetConfigData
{
    public string groupId;
    public List<NetBusinessLevel> records;

    public void DESEncryptBusiness()
    {
        for (int i = 0; i < records.Count; i++)
        {
            records[i].DESEncryptProperty();
        }
    }
}

public class NetBusinessLevel
{
    public string initUrl;
    public string userLevel;

    public void DESEncryptProperty()
    {
        this.userLevel = DESEncrypt.DesDecryptECB(this.userLevel);
        this.initUrl = DESEncrypt.DesDecryptECB(this.initUrl);
    }
}

public class NetIapData
{
    /// <summary>
    /// 线上json配置读取结构
    /// </summary>
    public NetConfigIapData data;

    public int code;
}

public struct NetConfigIapData
{
    public string groupId;
    public string initUrl;
}