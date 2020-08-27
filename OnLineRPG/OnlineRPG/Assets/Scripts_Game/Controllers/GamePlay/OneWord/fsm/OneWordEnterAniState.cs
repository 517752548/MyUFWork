using System.Collections;
using UnityEngine;

namespace Scripts_Game.Controllers.GamePlay.OneWord
{
    public class OneWordEnterAniState : BaseEnterAnimationState
    {
        protected override IEnumerator EnterAnim()
        {
            yield return new WaitForSeconds(0.5f);
            GameManager.GetEntity<BaseSkillManager>().Appear();
            OnCompleted();
        }
    }
}