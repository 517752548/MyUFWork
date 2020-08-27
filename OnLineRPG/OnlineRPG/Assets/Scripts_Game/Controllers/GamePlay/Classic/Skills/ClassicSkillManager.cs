using UnityEngine;
using System.Collections;

public class ClassicSkillManager : BaseSkillManager
{
    private ClassicCellManager cellManager { get { return GameManager.GetEntity<ClassicCellManager>(); } }
    private ClassicQuestionDisplay questionDisplay { get { return GameManager.GetEntity<ClassicQuestionDisplay>(); } }

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
