using BetaFramework;
using DG.Tweening;
using Scripts_Game.Controllers.Home.Elements;
using UnityEngine;

public class HomeRefreshUIState : HomeState
{
    public override bool CheckCondition()
    {
        return true;
    }

    public override void Enter()
    {
        base.Enter();
        
        if (AppEngine.SyncManager.Data.ClassicLevel.IsChanged)
        {
            var home = HomeRoot.GetHomeUi<LevelPlayButton>();
            home.HomeLevelBtn.SetTrigger("next");
            DOTween.Sequence().InsertCallback(0.5f, RefreshLevelBtn)
                .InsertCallback(1.5f, OnCompleted);
        }
        else
        {
            HomeRoot.GetHomeUi<LevelPlayButton>().RefreshBtnText(AppEngine.SyncManager.Data.ClassicLevel.Value);
            OnCompleted();
        }
    }

    private void RefreshLevelBtn()
    {
        HomeRoot.GetHomeUi<LevelPlayButton>().RefreshBtnText(AppEngine.SyncManager.Data.ClassicLevel.Value);
        AppEngine.SSoundManager.PlaySFX(ViewConst.ogg_level_btn_addNum);
    }
}