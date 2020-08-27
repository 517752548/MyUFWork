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
        if (AppEngine.SyncManager.Data.fansNumber.IsChanged)
        {
            HomeRoot.GetHomeUi<HomeThemeRoot>()._HomeAnimatorController.FlyWeb(() =>
            {
                HomeRoot.GetHomeUi<WebController>().DoIncreaseAnimator(OnCompleted);
            });
        }
        else
            OnCompleted();
    }
}