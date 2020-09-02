using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using Newtonsoft.Json;
using UnityEngine;

public class EliteConfig : WebConfig<EliteConfigData>
{
    public override ServerCode mId => ServerCode.EliteConfig;
    public override void OnLoadComplete()
    {
        base.OnLoadComplete();
        if (online && loadedCount == 1)
        {
            AppEngine.SSystemManager.GetSystem<EliteSystem>().OnConfigLoaded();
        }
    }
}

public class EliteConfigData
{
    public EliteComConfig init;
    public List<EliteWorld> list;
}

public class EliteComConfig
{
    public int startLevel;
    /// <summary>
    /// new的展示事件
    /// </summary>
    public int showTime;
    public int unlock1;
    public int unlock2;
    public int unlock3;
}

public class EliteWorld
{
    public int id;
    public string name;
    public string stars;
    public long startTime;
    public int order;
    public string reward1;
    public string reward2;
    public string reward3;
    public string img;

    [JsonIgnore]
    public bool isNew;
}
