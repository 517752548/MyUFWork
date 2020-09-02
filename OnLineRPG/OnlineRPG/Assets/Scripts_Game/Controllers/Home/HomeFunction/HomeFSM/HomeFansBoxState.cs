using BetaFramework;
using UnityEngine;

public class HomeFansBoxState : HomeState
{
    public override bool CheckCondition()
    {
        return true;
    }

    public override void Enter()
    {
        base.Enter();
        if (Const.AutoPlay)
        {
            OnCompleted();
            return;
        }
        HomeRoot.GetHomeUi<WebController>().OnShow();
        OnCompleted();
    }
}