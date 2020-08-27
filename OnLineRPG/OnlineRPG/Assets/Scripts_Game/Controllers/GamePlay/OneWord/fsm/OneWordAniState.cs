using BetaFramework;
using UnityEngine;

namespace Scripts_Game.Controllers.GamePlay.OneWord
{
    public class OneWordAniState : BaseAnimationState
    {
        public override void Enter()
        {
            GameManager.BanClick(true);
            base.Enter();
        }

        public override void Leave()
        {
            GameManager.BanClick(false);
            base.Leave();
        }
    }
}