using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using Newtonsoft.Json;
using UnityEngine;

public class DailyGameManager : BaseGameManager
{
    public DailyLevelProgressData ProgressData;


    public override void Init()
    {
        ProgressData = Record.GetObject(PrefKeys.DailyLevelProgress,new DailyLevelProgressData());
        if (!ProgressData.IsMatchCurLevel(GetLevel()))
            ProgressData = new DailyLevelProgressData();
        int level = AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value;
        GameTempData.levelID = level;
        base.Init();
    }
    public override void ShowGameADVideo()
    {
        //AppEngine.SAdManager.ShowInterstitialByCondition(AdManager.InterstitialCallPlace.DailyLevelEnter);
    }
    public override BaseFSMManager InstantiateFSM()
    {
        DailyFsmManager manager = gameObject.GetComponent<DailyFsmManager>();
        if (manager == null)
            manager = gameObject.AddComponent<DailyFsmManager>();
        manager.Init(this);
        return manager;
    }
    

    public override void ClearLevelProgress()
    {
        Record.DeleteKey(PrefKeys.DailyLevelProgress);
        ProgressData = null;
    }

    public List<DailyQuestionEntity> GetLevel()
    {
        return AppEngine.SSystemManager.GetSystem<DailySystem>().GetDailyLevel();
    }

    public void SaveLocal()
    {
        Record.SetObject(PrefKeys.DailyLevelProgress, ProgressData);
    }
    
    private void OnApplicationPause(bool pauseStatus)
    {
       SaveLocal();
    }

    private void OnApplicationQuit()
    {
        SaveLocal();
    }

    private void OnDestroy()
    {
        SaveLocal();
    }
    
    public override string GetLevelSeq()
    {
        return AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value.ToString();
    }
}
