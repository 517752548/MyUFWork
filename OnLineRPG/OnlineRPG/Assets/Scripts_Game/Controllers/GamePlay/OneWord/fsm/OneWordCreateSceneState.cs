using UnityEngine;

namespace Scripts_Game.Controllers.GamePlay.OneWord
{
    public class OneWordCreateSceneState : BaseCreatSceneState
    {
        public override void Enter()
        {
            base.Enter();
            CreatScene();
        }
    
        private void CreatScene()
        {
            GameManager.GetEntity<OneWordCellManager>().Init();
            GameManager.GetEntity<OneWordSkillManager>().Init();
            GameManager.GetEntity<OneWordRewardVideo>().Init();
            GameManager.BanClick(true);
            OnCompleted();
        }
    }
}