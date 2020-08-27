using System.Collections;
using BetaFramework;
using BetaFramework.Variable;
using UnityEngine;

namespace Scripts_Game.Controllers.GamePlay.Cross
{
    public class CrossPreSkillState : BaseFSMState
    {
        public override bool CheckCondition()
        {
            return FsmManager.GetData<VarBool>("play", true);
        }

        public override void Enter()
        {
            base.Enter();
            GameManager.BanClick(true);
            StartCoroutine(UseProcess());
        }

        private IEnumerator UseProcess()
        {
            var mgr = GameManager as CrossGameManager;
            if (AppEngine.SyncManager.Data.Bee.Value > 0 && mgr.ProgressData.Value.BeeUsedCount < mgr.GetBeeMaxCount())
            {
                GameManager.GetEntity<CrossCellManager>().UseBee(OnCompleted);
                yield return new WaitForSeconds(1f);
            }
            else
            {
                OnCompleted();
            }
        }

        public override void Leave()
        {
            GameManager.BanClick(false);
            base.Leave();
        }
    }
}