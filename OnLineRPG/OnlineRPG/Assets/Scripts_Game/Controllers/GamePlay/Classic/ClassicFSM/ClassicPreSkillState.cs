using System.Collections;
using BetaFramework;
using UnityEngine;

namespace Scripts_Game.Controllers.GamePlay.Classic.ClassicFSM
{
    public class ClassicPreSkillState : BaseFSMState
    {
        public override void Enter()
        {
            base.Enter();
            GameManager.BanClick(true);
            StartCoroutine(UseProcess());
        }

        private IEnumerator UseProcess()
        {
            //(GameManager as ClassicGameManager).ProgressData.BeeUsed = false;
            CommConfig_Data config = PreLoadManager.GetPreLoadConfig<CommConfig>(ViewConst.asset_CommConfig_config)
                ?.dataList[0];
            if ((GameManager as ClassicGameManager).ProgressData.BeeUsed)
                (GameManager as ClassicGameManager).ProgressData.BeeUsedCount = config.BeeUseMax;
            if (AppEngine.SyncManager.Data.Bee.Value > 0 && (GameManager as ClassicGameManager).ProgressData.BeeUsedCount < config.BeeUseMax)
            {
                var word = GameManager.GetEntity<BaseCellManager>().Words.Find(x => !x.IsComplete);
                GameManager.GetEntity<BaseCellManager>().MoveToWord(word);
                yield return new WaitForSeconds(0.5f);
                //(GameManager as ClassicGameManager).ProgressData.BeeUsed = true;
                GameManager.GetEntity<ClassicCellManager>().UseBee(OnCompleted);
                yield return new WaitForSeconds(1f);
            }
            else
            {
                OnCompleted();
                yield break;
            }
        }

        public override void Leave()
        {
            GameManager.BanClick(false);
            base.Leave();
        }
    }
}