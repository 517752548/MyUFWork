using System.Collections.Generic;

public class WndParam
{
    public const string SelectTab = "SelectTab";
    public const string RelationViewSelectZuijinLianxiren = "RelationViewSelectZuijinLianxiren";
    public const string LINK_TO_FUNC = "LINK_TO_FUNC";

    public static Dictionary<string,object> CreateWndParam(string key,object value)
    {
        Dictionary<string,object> param = new Dictionary<string, object>();
        param.Add(key,value);
        return param;
    }
    /// <summary>
    /// 获得窗口参数
    /// </summary>
    /// <param name="e"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    public static object GetWndParam(RMetaEvent e,string key)
    {
        if (e==null||e.data==null)
        {
            return null;
        }
        Dictionary<string, object> dic = e.data as Dictionary<string, object>;
        if (dic==null)
        {
            return null;
        }
        foreach (KeyValuePair<string, object> pair in dic)
        {
            if (pair.Key == key)
            {
                return pair.Value;
            }
        }
        return null;
    }
}
