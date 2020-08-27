using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnterAnimationState : BaseFSMState
{
    public override void Enter()
    {
        base.Enter();
        GameManager.BanClick(true);
        StartCoroutine(EnterAnim());
    }

    protected virtual IEnumerator EnterAnim()
    {
        yield return new WaitForSeconds(0.5f);
        GameManager.GetEntity<BaseSkillManager>().Appear();
        yield return new WaitForSeconds(0.5f);
        OnCompleted();
    }

    public override void Leave()
    {
        GameManager.BanClick(false);
        base.Leave();
    }
}
