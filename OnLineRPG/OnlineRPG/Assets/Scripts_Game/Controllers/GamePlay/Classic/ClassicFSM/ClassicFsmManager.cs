using System.Collections;
using System.Collections.Generic;
using Scripts_Game.Controllers.GamePlay.Classic.ClassicFSM;
using UnityEngine;

public class ClassicFsmManager : BaseFSMManager
{
    private ClassicPreSkillState state_preSkill;

    protected override void InstantiateState()
    {
        state_createScene = CreateState<ClassicCreatSceneState>();
        state_enterAni = CreateState<ClassicEnterAnimationState>();
        state_aniPlay = CreateState<ClassicAnimator>();
        state_guide = CreateState<ClassicPlayerGuideState>();
        state_popup = CreateState<ClassicPopupState>();
        state_playing = CreateState<ClassicPlayingState>();
        state_exitAni = CreateState<ClassicExitAnimState>();
        state_win = CreateState<ClassicWinState>();
        state_preSkill = CreateState<ClassicPreSkillState>();
    }

    protected override void OnInit()
    {
        base.OnInit();
        BreakLinkState(state_enterAni, state_playing);
        LinkState(state_enterAni, state_preSkill);
        LinkState(state_preSkill, state_playing);
    }

    public override void TriggerEvent(string eventName)
    {
        base.TriggerEvent(eventName);
    }
}
