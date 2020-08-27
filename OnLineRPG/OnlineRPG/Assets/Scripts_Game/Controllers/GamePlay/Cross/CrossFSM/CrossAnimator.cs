using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts_Game.Controllers.GamePlay.Cross
{
    public class CrossAnimator : BaseAnimationState
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
