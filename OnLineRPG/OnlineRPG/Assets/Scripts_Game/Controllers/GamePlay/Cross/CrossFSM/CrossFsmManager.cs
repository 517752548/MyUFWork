using BetaFramework;
using UnityEngine;

namespace Scripts_Game.Controllers.GamePlay.Cross
{
    public class CrossFsmManager : BaseFSMManager
    {
        private CrossPreSkillState state_preSkill;
        private CrossDisplayOnlyState state_display;
        
        protected override void InstantiateState()
        {
            state_createScene = CreateState<CrossCreatSceneState>();
            state_enterAni = CreateState<CrossEnterAnimationState>();
            state_aniPlay = CreateState<CrossAnimator>();
            state_guide = CreateState<CrossPlayerGuideState>();
            state_popup = CreateState<CrossPopupState>();
            state_playing = CreateState<CrossPlayingState>();
            state_exitAni = CreateState<CrossExitAnimState>();
            state_win = CreateState<CrossWinState>();
            state_preSkill = CreateState<CrossPreSkillState>();
            state_display = CreateState<CrossDisplayOnlyState>();
        }

        protected override void OnInit()
        {
            base.OnInit();
            BreakLinkState(state_enterAni, state_playing);
            LinkState(state_enterAni, state_preSkill);
            LinkState(state_preSkill, state_playing);
            LinkState(state_enterAni, state_display);
        }
    }
}