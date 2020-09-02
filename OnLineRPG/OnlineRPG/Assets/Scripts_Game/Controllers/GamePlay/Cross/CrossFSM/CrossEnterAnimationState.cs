using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using BetaFramework.Variable;
using UnityEngine;

namespace Scripts_Game.Controllers.GamePlay.Cross
{
    public class CrossEnterAnimationState : BaseEnterAnimationState
    {
        public override void Enter()
        {
            base.Enter();
        }

        protected override IEnumerator EnterAnim()
        {
            yield return new WaitForSeconds(0.5f);
            GameManager.GetEntity<BaseSkillManager>().Appear();
            yield return new WaitForSeconds(0.2f);
            //OnCompleted();
            if ((GameManager as CrossGameManager).TipReplay)
                UIManager.OpenUIAsync(ViewConst.prefab_EliteLevelContinueDialog, OpenType.Replace, null, (Action<int>)OnChoose);
            else
            {
                FsmManager.SetData<VarBool>("play", true);
                OnCompleted();
            }
        }

        public override void Leave()
        {
            base.Leave();
        }

        private void OnChoose(int result)
        {
            FsmManager.SetData<VarBool>("play", result > 0);
            OnCompleted();
        }
    }
}
