using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using TMPro;
using UnityEngine;

public class DailyController : BaseHomeUI
{
    public GameObject LockGamobject;
    public GameObject newDailyGameobject;

    public override void OnShow()
    {
        base.OnShow();
        CheckDailyButton();
    }

    public override void OnHidden()
    {
        base.OnHidden();
    }

    public void DailyAnimator()
    {
    }

    private void CheckDailyButton()
    {
        HomeRootFsmManager.GiveMessage(BaseThemeFsmManager.Event_GuideClose);
        if (AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value >= Const.DailyUnlockLevel)
        {
            if (LockGamobject)
                LockGamobject.SetActive(false);
        }
        else
        {
            if (LockGamobject)
                LockGamobject.SetActive(true);
        }

        if (!AppEngine.SyncManager.Data.ToadyFinished.Value && AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value >= Const.DailyUnlockLevel)
        {
            if (AppEngine.SSystemManager.GetSystem<DailySystem>().GetTodayLevelCategory().Count > 0)
            {
                if (newDailyGameobject)
                    newDailyGameobject.gameObject.SetActive(false);
            }
            else
            {
                if (newDailyGameobject)
                    newDailyGameobject.gameObject.SetActive(true);
            }
            
        }
        else
        {
            if (newDailyGameobject)
                newDailyGameobject.gameObject.SetActive(false);
        }
    }

    private bool clickHome = false;

    public void ClickDailyButton()
    {
        TimersManager.SetTimer(0.5f, () => { clickHome = false; });
        if (AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value < Const.DailyUnlockLevel)
        {
            //UIManager.ShowMessage(string.Format("Unlock Level {0}",Const.DailyUnlockLevel));
            UIManager.OpenUIAsync(ViewConst.prefab_DailyNotice, OpenType.Replace,
                null, string.Format("LEVEL {0}", Const.DailyUnlockLevel));
            return;
        }

        if (AppEngine.SyncManager.Data.ToadyFinished.Value)
        {
            UIManager.OpenUIAsync(ViewConst.prefab_DailyChallengeEventDialog);
            return;
        }

        if (AppEngine.SSystemManager.GetSystem<DailySystem>().GetTodayLevelCategory().Count == 0)
        {
            UIManager.OpenUIAsync(ViewConst.prefab_DailyChallengeWheelDialog);
        }
        else
        {
            AppEngine.SSystemManager.GetSystem<DailySystem>().PlayDailyGame();
            //UIManager.OpenUIAsync(ViewConst.prefab_DailyChallengeEventDialog);
        }

        return;
    }
}