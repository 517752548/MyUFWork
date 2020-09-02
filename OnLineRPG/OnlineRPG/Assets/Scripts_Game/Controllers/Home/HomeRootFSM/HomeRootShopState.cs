public class HomeRootShopState : HomeRootBaseState
{
    public override void Enter()
    {
        base.Enter();
        homeRoot.GetHomeUi<ShopThemeRoot>().FsmManager.StartRun();
    }

    public override void Leave()
    {
        base.Leave();
        homeRoot.GetHomeUi<ShopThemeRoot>().FsmManager.Pause();
    }
    
    public override void Refresh()
    {
        base.Refresh();
        homeRoot.GetHomeUi<ShopThemeRoot>().FsmManager.TriggerEvent(BaseThemeFsmManager.Event_CheckRefresh);
    }
}