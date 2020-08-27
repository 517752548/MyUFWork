using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using Newtonsoft.Json;
using UnityEngine;

public class ClassicGameManager : BaseGameManager
{
    public ClassicLevelProgressData ProgressData = null;

    private ClassicLevelEntity _classicLevelEntity;

    private int[] tipConfig;
    
    public override BaseFSMManager InstantiateFSM()
    {
        ClassicFsmManager manager = gameObject.GetComponent<ClassicFsmManager>();
        if (manager == null)
            manager = gameObject.AddComponent<ClassicFsmManager>();
        manager.Init(this);
        return manager;
    }

    public override void ShowGameADVideo()
    {
        // TimersManager.SetTimer(0.5f, () =>
        // {
        //     if (AppEngine.SAdManager.ShowInterstitialByCondition(AdManager.InterstitialCallPlace.ClassicLevelEnter))
        //     {
        //         //GameAnalyze.LogClassicLevelStep(_classicLevelEntity.ID.ToString(), "1");
        //     }
        // });
    }

    /// <summary>
    /// 局内游戏的入口方法
    /// </summary>
    public override void Init()
    {
        ProgressData = Record.GetObject(PrefKeys.ClassicLevelProgress,new ClassicLevelProgressData());
        int level = AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value;
        _classicLevelEntity = AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().GetClassicLevel(level);
        GameTempData.levelID = _classicLevelEntity.ID;
        if (ProgressData.LevelID > 0 && ProgressData.LevelID != _classicLevelEntity.ID)
            ProgressData = new ClassicLevelProgressData();
        ProgressData.LevelID = _classicLevelEntity.ID;
        tipConfig = PreLoadManager.GetPreLoadConfig<AnswerTips>(ViewConst.asset_AnswerTips_AnswerTip)
            .GetTargetLevelConfig(level);
        base.Init();
    }

    public override void OnWordChangeFocus(BaseWord word)
    {
        GetEntity<BasePet>().CloseAnswerTip();
        GetEntity<BasePet>().CloseCellTip();
        base.OnWordChangeFocus(word);
        GetEntity<ClassicQuestionRate>().OnWordChanged(word);
    }

    public override void ClearLevelProgress()
    {
        Record.DeleteKey(PrefKeys.ClassicLevelProgress);
        ProgressData = null;
    }

    public ClassicLevelEntity GetLevel()
    {
        return _classicLevelEntity;
    }

    public virtual void SaveLocal()
    {
        Record.SetObject(PrefKeys.ClassicLevelProgress, ProgressData);
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

    protected override void CheckAnswerTip()
    {
        base.CheckAnswerTip();
        if (curWord != null && !curWord.IsComplete && curWord is ClassicNormalWord
                            && (tipConfig[0] <= GameTempData.WrongTimesForTip 
                                || tipConfig[1] <= GameTempData.WordStayTimeForTip))
        {
            GameTempData.WrongTimesForTip = 0;
            GameTempData.WordStayTimeForTip = 0;
            GetEntity<BasePet>().ShowAnswerTip(curWord.Answer);
        }
    }
}
