
using System;
using BetaFramework;

public class HomeSignState : HomeState
{
    public override bool CheckCondition()
    {
        if (Const.AutoPlay)
        {
            return false;
        }
        bool canSign = AppEngine.SSystemManager.GetSystem<PlayerSignSystem>().IsCanSign();
        if (!canSign)
            AppEngine.SSystemManager.GetSystem<PlayerSignSystem>().DelayRefresh();
        return canSign;
    }

    public override void Enter()
    {
        base.Enter();
        UIManager.OpenUIAsync(ViewConst.prefab_SignDialog, null, true, (Action)OnCompleted);
        //OnCompleted();
    }
}