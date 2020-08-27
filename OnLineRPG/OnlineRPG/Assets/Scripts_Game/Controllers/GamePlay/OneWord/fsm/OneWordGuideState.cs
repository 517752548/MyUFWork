using UnityEngine;

namespace Scripts_Game.Controllers.GamePlay.OneWord
{
    public class OneWordGuideState : BasePlayerGuideState
    {
        public override bool CheckCondition()
        {
            return false;
        }

        public override void Enter()
        {
            base.Enter();
            OnCompleted();
        }
    }
}