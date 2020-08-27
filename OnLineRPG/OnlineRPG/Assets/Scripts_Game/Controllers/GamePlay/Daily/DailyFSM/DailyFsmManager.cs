using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyFsmManager : BaseFSMManager
{
    protected override void InstantiateState()
    {
        state_createScene = CreateState<DailyCreatSceneState>();
        state_enterAni = CreateState<DailyEnterAnimationState>();
        state_aniPlay = CreateState<DailyAnimator>();
        state_guide = CreateState<DailyPlayerGuideState>();
        state_popup = CreateState<DailyPopupState>();
        state_playing = CreateState<DailyPlayingState>();
        state_exitAni = CreateState<DailyExitAnimState>();
        state_win = CreateState<DailyWinState>();
    }

    protected override void OnInit()
    {
        base.OnInit();
    }

    public override void TriggerEvent(string eventName)
    {
        base.TriggerEvent(eventName);
    }
}
