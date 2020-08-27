using BetaFramework;
using UnityEngine;

namespace Scripts_Game.Controllers.GameInit.fsm
{
    public class LoginState : BaseState
    {
        public override void Enter()
        {
            base.Enter();
            OnCompleted();
            GameInitLoadBar.CurMaxProgress = 1.0f;
        }
    }
}