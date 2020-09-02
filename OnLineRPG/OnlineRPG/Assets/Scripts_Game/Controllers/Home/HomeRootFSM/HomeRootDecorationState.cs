public class HomeRootDecorationState : HomeRootBaseState 
{
    public override void Enter()
    {
        base.Enter();
        homeRoot.GetHomeUi<DecorationThemeRoot>().FsmManager.StartRun();
    }

    public override void Leave()
    {
        base.Leave();
        homeRoot.GetHomeUi<DecorationThemeRoot>().FsmManager.Pause();
    }
    
    public override void Refresh()
    {
        base.Refresh();
        homeRoot.GetHomeUi<DecorationThemeRoot>().FsmManager.TriggerEvent(BaseThemeFsmManager.Event_CheckRefresh);
    }
}