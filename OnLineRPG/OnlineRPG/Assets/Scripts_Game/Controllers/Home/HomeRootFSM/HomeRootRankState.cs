public class HomeRootRankState : HomeRootBaseState 
{
    public override void Enter()
    {
        base.Enter();
        homeRoot.GetHomeUi<RankThemeRoot>().FsmManager.StartRun();
    }

    public override void Leave()
    {
        base.Leave();
        homeRoot.GetHomeUi<RankThemeRoot>().FsmManager.Pause();
    }
    
    public override void Refresh()
    {
        base.Refresh();
        homeRoot.GetHomeUi<RankThemeRoot>().FsmManager.TriggerEvent(BaseThemeFsmManager.Event_CheckRefresh);
    }
}