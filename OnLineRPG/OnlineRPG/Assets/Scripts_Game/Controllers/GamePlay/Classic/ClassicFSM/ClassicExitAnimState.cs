using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassicExitAnimState : BaseExitAnimState
{

    public override void Enter()
    {
        base.Enter();
    }

    protected override IEnumerator ExitAnim()
    {
        yield return new WaitForSeconds(1);
        GameManager.GetEntity<ClassicQuestionRate>().OnLevelCompleted();
        GameManager.GetEntity<ClassicCellManager>().DisAppear();
        //yield return new WaitForSeconds(GameManager.GetEntity<ClassicCellManager>().Words.Count * 0.1f);
        if ((GameManager as ClassicGameManager).GetLevel()._SolutionCard == null)
        {
            yield return new WaitForSeconds(0.5f);
        }
        else
        {
            yield return 0;
        }
        OnCompleted();
    }

    public override void Leave()
    {
        base.Leave();
    }
}
