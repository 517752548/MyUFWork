using System.Collections.Generic;

public class AssetBundleInfo
{
    public int version;
    public Dictionary<string, AssetBundleProp> metaData = new Dictionary<string, AssetBundleProp>();
}

public class AssetBundleProp
{
    public string hashCode;
}