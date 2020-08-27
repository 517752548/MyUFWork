using UnityEngine;

namespace Scripts_Game.Controllers.GamePlay.OneWord
{
    public class OneWordFsmManager : BaseFSMManager
    {
        protected override void InstantiateState()
        {
            state_createScene = CreateState<OneWordCreateSceneState>();
            state_enterAni = CreateState<OneWordEnterAniState>();
            state_aniPlay = CreateState<OneWordAniState>();
            state_guide = CreateState<OneWordGuideState>();
            state_popup = CreateState<OneWordPopupState>();
            state_playing = CreateState<OneWordPlayingState>();
            state_exitAni = CreateState<OneWordExitAniState>();
            state_win = CreateState<OneWordWinState>();
        }

        protected override void OnInit()
        {
            base.OnInit();
            LinkState(state_playing, state_win);
        }
    }
}