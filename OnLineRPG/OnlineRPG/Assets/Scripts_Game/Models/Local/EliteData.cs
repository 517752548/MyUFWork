using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using UnityEngine;

/// <summary>
/// 精英关卡存档
/// </summary>
public class EliteData :BaseSyncHandData
{
    public Dictionary<int,ElitePref> elitedata = new Dictionary<int, ElitePref>();

    public ElitePref GetElitePref(int id)
    {
        if (elitedata.ContainsKey(id))
        {
            return elitedata[id];
        }

        return null;
    }

    public void AddElitePref(int id,ElitePref elitePref)
    {
        if (elitedata.ContainsKey(id))
        {
            elitedata[id] = elitePref;
        }
        else
        {
            elitedata[id] = elitePref;
        }

        AppEngine.SyncManager.Data.Elitedata.Value = this;
    }
}

public class ElitePref
{
    
}
