using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCollectData
{
    public int levelID;
    public int hint1num;
    public int hint2num;
    public int hint3num;
    public int hint4num;
    public int hint5num;
    public int buyCoin;
    public int freeCoin;
    public int m_videocoin;
    public int bonusWordCount;
    public int openShopTimes = 0;
    public int Conjunction = 0;
    public int watchVideoCount = 0;
    public int leftMove = -1;
    public int dailyGetStar = -1;

    public bool isLevelFinish;

    //是否是锦标赛玩法
    public bool isFRClassic = false;
    public string dailyType;

    // 关卡开始时间
    protected DateTime startTime;

    // 关卡结束时间
    protected DateTime endTime;

    //无用时间
    protected TimeSpan uselessTime;

    //丢失焦点时间
    protected DateTime LoseFocusTime = DateTime.MinValue;

    protected DateTime lastRightTime = DateTime.Now;

    public int WrongTimesForTip;
    public float WordStayTimeForTip;
    public float ExcludeStaySecondsForTip;

    //正向反馈参数
    // public List<String> PRWords = new List<String>(); // 记录位置，从而进行正反馈
    // public List<String> PRSounds;
    // public bool isPRSoundFirst;

    private bool firstInput = true;

    public void Init()
    {
        startTime = DateTime.Now;
        WrongTimesForTip = 0;
        if (DataManager.ProcessData._GameMode == GameMode.Daily)
        {
            List<int> today = AppEngine.SSystemManager.GetSystem<DailySystem>().GetTodayLevelCategory();
            for (int i = 0; i < today.Count; i++)
            {
                dailyType += today[i].ToString();
            }
        }

        try
        {
            string gamemodel = DataManager.ProcessData._GameMode.ToString();
            GameAnalyze.LoglevelPass(levelID.ToString(), "0",
                AppEngine.SyncManager.Data.Coin.Value.ToString(),
                AppEngine.SyncManager.Data.Hint1.Value.ToString(),
                AppEngine.SyncManager.Data.Hint2.Value.ToString(),
                AppEngine.SyncManager.Data.Hint3.Value.ToString(),
                AppEngine.SyncManager.Data.Hint4.Value.ToString(), "2", gamemodel, dailyType,
                AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().GetAbTestSpecialId(),
                AppEngine.SSystemManager.GetSystem<TestABWordLibSystem>().GetUserTestLib(),
                AppEngine.SSystemManager.GetSystem<RewardABSystem>().GetUserRewardLib(),
                AppEngine.SSystemManager.GetSystem<RewardABSystem>().GetABReportStr(),
                AppEngine.SSystemManager.GetSystem<PlayerLoginSystem>().playerCrazeID.Value,
                AppEngine.SSystemManager.GetSystem<PlayerInfoSystem>().PlsyerFBID.Value,
                isFRClassic.ToString(),
                hint5num.ToString(),
                AppEngine.SyncManager.Data.Bee.Value.ToString(),
                ClassicVoiceKeyboard.VoiceProportion.ToString(),
                AppEngine.SSystemManager.GetSystem<CellTipABSystem>().GetUserRewardLib()
            );
        }
        catch (Exception e)
        {
            Debug.LogError("levelpass error");
        }
        
        // 初始化正反馈数据
        // PRWords.Clear();
        // PRSounds = new List<string>
        // {
        //     ViewConst.wav_PRTon1,
        //     ViewConst.wav_PRTon2,
        //     ViewConst.wav_PRTon3
        // };
        // isPRSoundFirst = true;
    }

    public void PlayerInput()
    {
        if (firstInput)
        {
            firstInput = false;
            GameAnalyze.LogClassicLevelStep(levelID.ToString(), "2");
        }
    }

    public void GameWin()
    {
        isLevelFinish = true;
        endTime = DateTime.Now;
        TimeSpan gameSpendTime = endTime - startTime - uselessTime;
        if (gameSpendTime < TimeSpan.Zero)
        {
            gameSpendTime = TimeSpan.Zero;
        }

        GameAnalyze.LogClassicLevelStep(levelID.ToString(), "3");
        ReportWin(gameSpendTime);
    }

    public void ClassicAnswerRight(List<BaseWord> words, string playSeq, int hint1, int hint2, int hint3, int hint4)
    {
        TimeSpan gameSpendTime = DateTime.Now - lastRightTime;
        lastRightTime = DateTime.Now;
        for (int i = 0; i < words.Count; i++)
        {
            if (words[i] is BaseNormalWord)
            {
                BQReport.LogclassicLevelWords(levelID.ToString(),
                    ((BaseNormalWord) words[i]).BaseQuestion.ID.ToString(),
                    playSeq, words[i].Answer, "1", gameSpendTime.Seconds.ToString(), hint1.ToString(),
                    hint2.ToString(), hint3.ToString(), hint4.ToString(), "");
            }
            else
            {
                break;
            }
        }

        DataManager.businessGiftData.WordWrongOrRight(false);
    }

    public void DailyAnswerRight(List<BaseWord> words, string playSeq, int hint1, int hint2, int hint3, int hint4)
    {
        TimeSpan gameSpendTime = DateTime.Now - lastRightTime;
        lastRightTime = DateTime.Now;
        for (int i = 0; i < words.Count; i++)
        {
            BQReport.LogDailyLevelWords(levelID.ToString(), ((BaseNormalWord) words[i]).BaseQuestion.ID.ToString(),
                playSeq, words[i].Answer, "1", gameSpendTime.Seconds.ToString(), hint1.ToString(),
                hint2.ToString(), hint3.ToString(), hint4.ToString(), "");
        }

        DataManager.businessGiftData.WordWrongOrRight(false);
    }
    
    public void CrossAnswerRight(List<BaseWord> words, string playSeq, int hint1, int hint2, int hint3, int hint4)
    {
        TimeSpan gameSpendTime = DateTime.Now - lastRightTime;
        lastRightTime = DateTime.Now;
        // for (int i = 0; i < words.Count; i++)
        // {
        //     BQReport.LogDailyLevelWords(levelID.ToString(), ((BaseNormalWord) words[i]).BaseQuestion.ID.ToString(),
        //         playSeq, words[i].Answer, "1", gameSpendTime.Seconds.ToString(), hint1.ToString(),
        //         hint2.ToString(), hint3.ToString(), hint4.ToString(), "");
        // }

        DataManager.businessGiftData.WordWrongOrRight(false);
    }

    public void DailyAnswerWrong(BaseWord word, string wrongword, int hint1, int hint2, int hint3, int hint4)
    {
        TimeSpan gameSpendTime = DateTime.Now - lastRightTime;
        BQReport.LogDailyLevelWords(levelID.ToString(), ((BaseNormalWord) word).BaseQuestion.ID.ToString(), "-1",
            word.Answer, "2", gameSpendTime.Seconds.ToString(), hint1.ToString(), hint2.ToString(),
            hint3.ToString(), hint4.ToString(), wrongword);
        DataManager.businessGiftData.WordWrongOrRight(true);
    }

    public void ClassicAnswerWrong(BaseWord word, string wrongword, int hint1, int hint2, int hint3, int hint4)
    {
        TimeSpan gameSpendTime = DateTime.Now - lastRightTime;
        BQReport.LogclassicLevelWords(levelID.ToString(), ((BaseNormalWord) word).BaseQuestion.ID.ToString(), "-1",
            word.Answer, "2", gameSpendTime.Seconds.ToString(), hint1.ToString(), hint2.ToString(),
            hint3.ToString(), hint4.ToString(), wrongword);
        DataManager.businessGiftData.WordWrongOrRight(true);
    }
    
    public void CrossAnswerWrong(BaseWord word, string wrongword, int hint1, int hint2, int hint3, int hint4)
    {
        // TimeSpan gameSpendTime = DateTime.Now - lastRightTime;
        // BQReport.LogDailyLevelWords(levelID.ToString(), ((BaseNormalWord) word).BaseQuestion.ID.ToString(), "-1",
        //     word.Answer, "2", gameSpendTime.Seconds.ToString(), hint1.ToString(), hint2.ToString(),
        //     hint3.ToString(), hint4.ToString(), wrongword);
        DataManager.businessGiftData.WordWrongOrRight(true);
    }

    public virtual void ReportWin(TimeSpan gameSpendTime)
    {
        string gamemodel = DataManager.ProcessData._GameMode.ToString();
        GameAnalyze.LoglevelPass(levelID.ToString(), ((int) gameSpendTime.TotalSeconds).ToString(),
            AppEngine.SyncManager.Data.Coin.Value.ToString(),
            AppEngine.SyncManager.Data.Hint1.Value.ToString(),
            AppEngine.SyncManager.Data.Hint2.Value.ToString(),
            AppEngine.SyncManager.Data.Hint3.Value.ToString(),
            AppEngine.SyncManager.Data.Hint4.Value.ToString(), "1", gamemodel, dailyType,
            AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().GetAbTestSpecialId(),
            AppEngine.SSystemManager.GetSystem<TestABWordLibSystem>().GetUserTestLib(),
            AppEngine.SSystemManager.GetSystem<RewardABSystem>().GetUserRewardLib(),
            AppEngine.SSystemManager.GetSystem<RewardABSystem>().GetABReportStr(),
            AppEngine.SSystemManager.GetSystem<PlayerLoginSystem>().playerCrazeID.Value,
            AppEngine.SSystemManager.GetSystem<PlayerInfoSystem>().PlsyerFBID.Value,
            isFRClassic.ToString(),
            hint5num.ToString(),
            AppEngine.SyncManager.Data.Bee.Value.ToString(),
            ClassicVoiceKeyboard.VoiceProportion.ToString(),
            AppEngine.SSystemManager.GetSystem<CellTipABSystem>().GetUserRewardLib()
        );
        
        AOEReport.LevelPass(levelID);
    }

    /// <summary>
    /// 退出关卡
    /// </summary>
    public virtual void ReportOutLevel()
    {
        endTime = DateTime.Now;
        TimeSpan gameSpendTime = endTime - startTime - uselessTime;
        if (gameSpendTime < TimeSpan.Zero)
        {
            gameSpendTime = TimeSpan.Zero;
        }

        string gamemodel = DataManager.ProcessData._GameMode.ToString();
        GameAnalyze.LoglevelPass(levelID.ToString(), ((int) gameSpendTime.TotalSeconds).ToString(),
            AppEngine.SyncManager.Data.Coin.Value.ToString(),
            AppEngine.SyncManager.Data.Hint1.Value.ToString(),
            AppEngine.SyncManager.Data.Hint2.Value.ToString(),
            AppEngine.SyncManager.Data.Hint3.Value.ToString(),
            AppEngine.SyncManager.Data.Hint4.Value.ToString(), "0", gamemodel, "",
            AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().GetAbTestSpecialId(),
            AppEngine.SSystemManager.GetSystem<TestABWordLibSystem>().GetUserTestLib(),
            AppEngine.SSystemManager.GetSystem<RewardABSystem>().GetUserRewardLib(),
            AppEngine.SSystemManager.GetSystem<RewardABSystem>().GetABReportStr(),
            AppEngine.SSystemManager.GetSystem<PlayerLoginSystem>().playerCrazeID.Value,
            AppEngine.SSystemManager.GetSystem<PlayerInfoSystem>().PlsyerFBID.Value,
            isFRClassic.ToString(),
            hint5num.ToString(),
            AppEngine.SyncManager.Data.Bee.Value.ToString(),
            ClassicVoiceKeyboard.VoiceProportion.ToString(),
            AppEngine.SSystemManager.GetSystem<CellTipABSystem>().GetUserRewardLib()
        );
    }

    public void GameOnApplicationFocus(bool focus)
    {
        if (focus)
        {
            if (LoseFocusTime != DateTime.MinValue)
            {
                uselessTime += (DateTime.Now - LoseFocusTime);
                LoseFocusTime = DateTime.MinValue;
            }
            else
            {
                LoseFocusTime = DateTime.MinValue;
            }
        }
        else
        {
            LoseFocusTime = DateTime.Now;
        }
    }
}