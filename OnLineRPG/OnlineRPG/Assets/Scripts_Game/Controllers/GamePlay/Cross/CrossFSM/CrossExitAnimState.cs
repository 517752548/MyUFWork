using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts_Game.Controllers.GamePlay.Cross
{
    public class CrossExitAnimState : BaseExitAnimState
    {

        public override void Enter()
        {
            base.Enter();
        }

        protected override IEnumerator ExitAnim()
        {
            yield return new WaitForSeconds(1);
            GameManager.GetEntity<CrossCellManager>().DisAppear();
            //yield return new WaitForSeconds(GameManager.GetEntity<ClassicCellManager>().Words.Count * 0.1f);
            OnCompleted();
        }

        public override void Leave()
        {
            base.Leave();
        }
    }
}
