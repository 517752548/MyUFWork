using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using UnityEngine;

namespace Scripts_Game.Controllers.GamePlay.Cross
{
    public class CrossCreatSceneState : BaseCreatSceneState
    {

        public override void Enter()
        {
            base.Enter();
            CreatScene();
        }


        private void CreatScene()
        {
            GameManager.GetEntity<CrossTittleBar>().Init();
            GameManager.GetEntity<CrossCellManager>().Init();
            GameManager.GetEntity<CrossSkillManager>().Init();
            OnCompleted();
        }

        public override void Leave()
        {
            base.Leave();
        }
    }
}
