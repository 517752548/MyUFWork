using UnityEngine;
using System.Collections;
using BetaFramework;

public class GuideSystem : ISystem
{
    public BoolSyncField GuideShown_FirstWord => AppEngine.SyncManager.Data.GuideFirstWord;
    public BoolSyncField GuideShown_Welcome => AppEngine.SyncManager.Data.GuideWelcome;
    public BoolSyncField GuideShown_Hint1Unlock => AppEngine.SyncManager.Data.GuideHint1Unlock;
    public BoolSyncField GuideShown_Hint2Unlock => AppEngine.SyncManager.Data.GuideHint2Unlock;
    public BoolSyncField GuideShown_Hint3Unlock => AppEngine.SyncManager.Data.GuideHint3Unlock;
    public BoolSyncField GuideShown_Hint4Unlock => AppEngine.SyncManager.Data.GuideHint4Unlock;
    public BoolSyncField GuideShown_BlogEnter => AppEngine.SyncManager.Data.GuideBlogEnter;
    public BoolSyncField GuideShown_BlogCard => AppEngine.SyncManager.Data.GuideBlogCard;
    public BoolSyncField GuideShown_DailyEnter => AppEngine.SyncManager.Data.GuideDailyEnter;
    public BoolSyncField GuideShown_DailyReward => AppEngine.SyncManager.Data.GuideDailyReward;
    public RecordExtra.BoolPrefData GuideShown_GuideVoice { get; private set; }
    public RecordExtra.BoolPrefData GuideShown_GuideVoice3 { get; private set; }
    public RecordExtra.BoolPrefData FinishWord_GuideVoice3 { get; private set; }
    public RecordExtra.IntPrefData GuideShown_GuideVoice2Step { get; private set; }
    public RecordExtra.BoolPrefData ShowSetting_GuideVoice3 { get; private set; }

    public RecordExtra.BoolPrefData GuideShown_Wiki { get; private set; }

    public override void InitSystem()
    {
        GuideShown_Wiki = new RecordExtra.BoolPrefData("wiki_guide", false);
        GuideShown_GuideVoice = new RecordExtra.BoolPrefData("guide_shown_voice", false);
        GuideShown_GuideVoice3 = new RecordExtra.BoolPrefData("guide_shown_voice3", false);
        FinishWord_GuideVoice3 = new RecordExtra.BoolPrefData("FinishWord_GuideVoice3", false);
        GuideShown_GuideVoice2Step = new RecordExtra.IntPrefData("GuideShown_GuideVoice2Step", 0);//1 已获取权限 2 完成答案 3授权中 4 完成授权
        ShowSetting_GuideVoice3 = new RecordExtra.BoolPrefData("ShowSetting_GuideVoice3", false);
        base.InitSystem();
    }
}
