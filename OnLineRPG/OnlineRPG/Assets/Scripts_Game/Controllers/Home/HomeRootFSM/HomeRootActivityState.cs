public class HomeRootActivityState : HomeRootBaseState
{
    public override void Enter()
    {
        base.Enter();
        homeRoot.GetHomeUi<ActivityThemeRoot>().FsmManager.StartRun();
    }

    public override void Leave()
    {
        base.Leave();
        homeRoot.GetHomeUi<ActivityThemeRoot>().FsmManager.Pause();
    }

    public override void Refresh()
    {
        base.Refresh();
        homeRoot.GetHomeUi<ActivityThemeRoot>().FsmManager.TriggerEvent(BaseThemeFsmManager.Event_CheckRefresh);
    }
}