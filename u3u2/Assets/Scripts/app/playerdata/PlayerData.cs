using System.Collections;
using System.Collections.Generic;
/// <summary>
/// 本地缓存数据类,用于读取缓存数据
/// </summary>
public class PlayerData
{
    private Dictionary<string, string> dic;

    public Dictionary<string, string> Dic
    {
        get { return dic; }
    }

    public void addData(string key,string value)
    {
        if (Dic==null)
        {
            dic = new Dictionary<string, string>();
        }
        if (!Dic.ContainsKey(key))
        {
            Dic.Add(key,value);
        }
        else
        {
            Dic[key] = value;
        }
    }

    public void setData(IDictionary idic)
    {
        if (Dic == null)
        {
            dic = new Dictionary<string, string>();
        }
        else
        {
            dic.Clear();
        }
        foreach (DictionaryEntry entry in idic)
        {
            dic.Add((string)entry.Key,(string)entry.Value);
        }
    }

    public string getData(string key)
    {
        string value = null;
        if (Dic == null)
        {
            dic = new Dictionary<string, string>();
        }
        if (Dic.ContainsKey(key))
        {
            Dic.TryGetValue(key, out value);
        }
        else
        {
            return null;
        }
        return value;
    }

}

