using System.Collections.Generic;
/// <summary>
/// 列表
/// 本地缓存数据类,用于读取缓存数据
/// </summary>
public class PlayerDataList
{
    private int maxLen = 10;
    private List<PlayerData> list;

    public PlayerDataList(int maxlength)
    {
        maxLen = maxlength;
    }

    public List<PlayerData> List
    {
        get { return list; }
    }

    /// <summary>
    /// 浅拷贝列表数据。
    /// </summary>
    public List<PlayerData> ShallowCopyList
    {
        get
        {
            List<PlayerData> clist = new List<PlayerData>();
            if (list != null)
            {
                int len = list.Count;
                for (int i = 0; i < len; i++)
                {
                    clist.Add(list[i]);
                }
            }
            return clist;
        }
    }

    public List<Dictionary<string, string>> ListDic()
    {
        List<Dictionary<string, string>> listdic = new List<Dictionary<string, string>>();
        for (int i = 0; list != null && i < list.Count; i++)
        {
            listdic.Add(list[i].Dic);
        }
        return listdic;
    }

    public void addData(PlayerData playerdata)
    {
        if (list == null)
        {
            list = new List<PlayerData>();
        }
        list.Add(playerdata);
        if (list.Count > maxLen)
        {
            list.RemoveAt(0);
        }
    }

    public void Destroy()
    {
        if (list != null)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i] = null;
            }
            list.Clear();
        }
    }

}
