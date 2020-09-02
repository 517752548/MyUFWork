using System.Collections;
using BetaFramework;
using Scripts_Game.Managers;
using UnityEngine;

namespace Scripts_Game.Controllers.GamePlay.OneWord
{
    public class OneWordExitAniState : BaseExitAnimState
    {
        public override bool CheckCondition()
        {
            return !GameManager.GetEntity<OneWordCellManager>().IsCompleted && base.CheckCondition();
        }

        protected override IEnumerator ExitAnim()
        {
            string rewardId = GameManager.GetEntity<OneWordCellManager>().LevelReward();
            yield return new WaitForSeconds(1.9f);
            // CommonRewardData _commonRewardData = new CommonRewardData();
            // _commonRewardData.rewardId = rewardId;
            // _commonRewardData.boxType = RewardBoxType.OneWord;
            // _commonRewardData.RewardSource = RewardSource.OneWord;
            // UIManager.OpenUIAsync(ViewConst.prefab_CommonRewardDialog, OpenType.Stack, OnGiftClosed, null, null, _commonRewardData);
            UIManager.OpenUIAsync(ViewConst.prefab_OneWordRewardDialog, OpenType.Stack, 
                OnGiftClosed, null,null, 
                rewardId, (GameManager as OneWordGameManager).GetLevel().Answer.Length);
        }

        private void OnGiftClosed(UIWindowBase ui)
        {
            OnCompleted();
        }
    }
}