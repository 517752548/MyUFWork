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
        // AppEngine.SyncManager.Data.ClassicLevel.Value += 40;
        if (AppEngine.SyncManager.Data.ClassicLevel.IsChanged)
        {
            HomeRoot._HomeAnimatorController.FlyLevel(() =>
            {
                HomeRoot.GetHomeUi<LevelTaskPanel>().PlayProgressAni(OnCompleted);
            });
        }
        else
            OnCompleted();
    }
}