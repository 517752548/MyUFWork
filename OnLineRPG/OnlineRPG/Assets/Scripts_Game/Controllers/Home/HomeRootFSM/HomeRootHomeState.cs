using UnityEngine;

public class HomeRootHomeState : HomeRootBaseState
{
    public override void Enter()
    {
        base.Enter();
        homeRoot.GetHomeUi<HomeThemeRoot>().HomeFsmManager.StartRun();
    }

    public override void Leave()
    {
        base.Leave();
        homeRoot.GetHomeUi<HomeThemeRoot>().HomeFsmManager.Pause();
    }
    
    public override void Refresh()
    {
        base.Refresh();
        homeRoot.GetHomeUi<HomeThemeRoot>().HomeFsmManager.TriggerEvent(BaseThemeFsmManager.Event_CheckRefresh);
    }
}