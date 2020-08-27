using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyEnterAnimationState : BaseEnterAnimationState
{
    public override void Enter()
    {
        base.Enter();
    }

    protected override IEnumerator EnterAnim()
    {
        yield return new WaitForSeconds(0.5f);
        GameManager.GetEntity<BaseSkillManager>().Appear();
        GameManager.GetEntity<DailyCellManager>().PlayPreviewAni(() => { OnCompleted(); });
        yield return new WaitForSeconds(1.5f);
        //OnCompleted();
    }

    public override void Leave()
    {
        base.Leave();
    }
}
