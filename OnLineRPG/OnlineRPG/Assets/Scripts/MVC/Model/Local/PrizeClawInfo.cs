using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using UnityEngine;

public class PrizeClawInfo
{
    public bool loadSuccessful = false;
    public PrizeClawOnLineData _onlineData;

    public Action ConfigLoadCallback;
    public void Init()
    {
        Timer.Schedule(AppThreadController.instance, 0.3f,()=>
        {
            LoadOnLineConfig();
        });

    }

    public void LoadOnLineConfig()
    {
        Action<bool, PrizeClawOnLineData> a = (b, i) =>
        {
            if (b)
            {
                _onlineData = i;
                loadSuccessful = true;
                if (ConfigLoadCallback != null)
                {
                    ConfigLoadCallback.Invoke();
                }
            }
            else
            {
                loadSuccessful = false;
            }
            
        };
//        CommandBinder.DispatchBinding(GameEvent.PrizeClaw, new CmdParamData(0, 1, a));
    }
}
