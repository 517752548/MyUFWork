using BetaFramework;
using UnityEngine;

public class HomeSubWorldBoxState : HomeState
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
        if (AppEngine.SyncManager.Data.ClassicLevel.IsChanged)
        {
            
            HomeRoot.GetHomeUi<HomeThemeRoot>()._HomeAnimatorController.FlyLevel(() =>
            {
                HomeRoot.GetHomeUi<LevelTaskPanel>().PlayProgressAni(OnCompleted);
            });
        }
        else
            OnCompleted();
    }
}