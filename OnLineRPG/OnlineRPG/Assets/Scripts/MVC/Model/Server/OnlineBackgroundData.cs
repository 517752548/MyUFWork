using System;
using System.Collections.Generic;

public class OnlineBackgroundData
{
    public int id;
    public string name;
    public string url;
}

[Serializable]
public class LocalBackgroundEffectData
{
    public string LevelId;
    public string EffectName;
}

public class OnlineBackgroundList
{
    public List<OnlineBackgroundData> data = new List<OnlineBackgroundData>();
    public int code;

    public string GetUrlByBackgroundName(string name)
    {
        for (int i = 0; i < data.Count; i++)
        {
            if (data[i].name.Equals(name))
            {
                return data[i].url;
            }
        }

        return "";
    }

    public string GetNameByBackgroundUrl(string url)
    {
        for (int i = 0; i < data.Count; i++)
        {
            if (data[i].url.Equals(url))
            {
                return data[i].name;
            }
        }

        return "";
    }
}