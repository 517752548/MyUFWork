using System.Collections.Generic;

public class FBFriendJsonItem
{
    /// <summary>
    /// 
    /// </summary>
    public string path { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string photo { get; set; }
    /// <summary>
    /// 金鑫 刘金鑫 Adrian Lau
    /// </summary>
    public string text { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long uid { get; set; }
    /// <summary>
    /// 刘金鑫 (Adrian Lau)
    /// </summary>
    public string display { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public List<string> paths { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int bootstrap { get; set; }
}

public class Bootloadable
{
}

public class IxData
{
}

public class FBFriendJson
{
    /// <summary>
    /// 
    /// </summary>
    public int __ar { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string __sf { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public List<FBFriendJsonItem> payload { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public Bootloadable bootloadable { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public IxData ixData { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string lid { get; set; }
}