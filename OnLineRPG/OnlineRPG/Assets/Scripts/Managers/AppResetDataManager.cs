using BetaFramework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppResetDataManager : MonoBehaviour
{
    private DateTime playergoHomeDateTime;

    private void Awake()
    {
        playergoHomeDateTime = DateTime.Now;
    }

    // Use this for initialization
    private void Start()
    {

    }



    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            TimeSpan span1 = DateTime.Now.Subtract(playergoHomeDateTime);
            if (span1.TotalHours > 2)
            {
//                DailyChallengeData.NEED_POP_PANEL = false;
                CommandBinder.DispatchBinding(GameEvent.AppRestart);
            }
            if (span1.TotalMinutes > 5)
            {
                //BQAnalyReport.PostUserActiveNEW();
            }

            CommandBinder.DispatchBinding(GameEvent.LocalNotification) ;
        }
        else
        {
            playergoHomeDateTime = DateTime.Now;
        }
        //SetFocus(focus);
    }

    private void OnApplicationPause(bool pause)
    {
    }

}