using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseExitAnimState : BaseFSMState
{
    public override bool CheckCondition()
    {
        return GameManager.GetEntity<BaseCellManager>().CheckIsFull();
    }

    public override void Enter()
    {
        base.Enter();
        GameManager.BanClick(true);
        // GameManager.GetEntity<BaseCellManager>().OnGameCompleted();
        // GameManager.GetEntity<BaseSkillManager>().OnGameCompleted();
        // GameManager.GetEntity<BaseQuestionDisplay>().OnGameCompleted();
        GameManager.EndGame();
        StartCoroutine(ExitAnim());
    }

    protected virtual IEnumerator ExitAnim()
    {
        yield return new WaitForSeconds(0.5f);
        OnCompleted();
    }

    public override void Leave()
    {
        GameManager.BanClick(false);
        base.Leave();
    }
}
