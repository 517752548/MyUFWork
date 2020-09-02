﻿using BetaFramework.Variable;

namespace Scripts_Game.Controllers.GamePlay.Cross
{
    public class CrossDisplayOnlyState : BaseFSMState
    {
        public override bool CheckCondition()
        {
            return !FsmManager.GetData<VarBool>("play", true);
        }

        public override void Enter()
        {
            base.Enter();
            GameManager.GetEntity<CrossCellManager>().OnlyDisplay();
        }

        public override void Leave()
        {
            base.Leave();
        }
    }
}