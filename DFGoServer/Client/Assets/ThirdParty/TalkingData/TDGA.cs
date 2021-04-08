using UnityEngine;
using System.Collections.Generic;

public static class TDGA
{

    public static void Init()
    {
        TalkingDataGA.BackgroundSessionEnabled();
        TalkingDataGA.OnStart("587B0A843E3E433D91A87147673B1FC6", "android");
        TDGAProfile.SetProfile("User" + TalkingDataGA.GetDeviceId() + "_" + TalkingDataGA.GetOAID());
    }

    public static void Report(string eventName,Dictionary<string, object> dic)
    {
        TalkingDataGA.OnEvent(eventName,dic);
    }
    
}
