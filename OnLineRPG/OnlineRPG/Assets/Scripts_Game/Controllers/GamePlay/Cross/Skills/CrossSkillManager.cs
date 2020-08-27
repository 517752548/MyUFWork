using UnityEngine;

namespace Scripts_Game.Controllers.GamePlay.Cross
{
    public class CrossSkillManager : BaseSkillManager
    {
        private CrossQuestionDisplay questionDisplay => GameManager.GetEntity<CrossQuestionDisplay>();

        public override void OnHintStart(BaseHint hint)
        {
            base.OnHintStart(hint);
            questionDisplay.picBox.SetVisible(false);
        }

        public override void OnHintEnd(BaseHint hint)
        {
            questionDisplay.picBox.SetVisible(true);
            base.OnHintEnd(hint);
        }
    }
}