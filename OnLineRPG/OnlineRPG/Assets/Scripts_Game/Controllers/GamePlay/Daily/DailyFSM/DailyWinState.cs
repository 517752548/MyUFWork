using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using UnityEngine;

public class DailyWinState : BaseWinState
{

    public override void Enter()
    {
        //fsmManager.m_baseGameManager.GetEntity<NewWinDialog>().WinDialogStart();
        AppEngine.SSystemManager.GetSystem<DailySystem>().TodayWin();
        // CommonRewardData _commonRewardData = new CommonRewardData();
        // _commonRewardData.boxType = RewardBoxType.DailyWin;
        // _commonRewardData.coin = 20;
        // _commonRewardData.callback = DailyCallBack;
        // UIManager.OpenUIAsync(ViewConst.prefab_CommonRewardDialog,OpenType.Replace,null,_commonRewardData);
        UIManager.OpenUIAsync(ViewConst.prefab_DailyWinDialog);
        DailyCallBack();
        base.Enter();
    }

    private void DailyCallBack()
    {
        TimersManager.SetTimer(1.5f, () =>
        {
            MainSceneDirector.Instance.SwitchUi(GameUI.Home,null);
        });

    }

    public override void Leave()
    {
        base.Leave();
    }
}
