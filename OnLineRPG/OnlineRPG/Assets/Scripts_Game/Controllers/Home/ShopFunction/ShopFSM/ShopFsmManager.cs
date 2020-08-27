using BetaFramework;

public class ShopFsmManager : BaseThemeFsmManager
{
    private BaseState start, idle, guide, popup;
    public ShopThemeRoot root;
    public void Init(ShopThemeRoot homeRoot)
    {
        this.root = homeRoot;
        start = CreateState<ShopRootStartState>();
        idle = CreateState<ShopRootIdleState>();
        guide = CreateState<ShopRootGuideState>();
        popup = CreateState<ShopRootPopupState>();
        InitStateMachine();
    }
    protected override void OnInit()
    {
        base.OnInit();
        AddHeadState(start);
        LinkState(start, idle);
        LinkState(idle, guide);
        LinkState(guide, popup);
        LinkState(popup, idle);
    }
    public void Enter()
    {
        currentState = null;
        StartRun();
    }

    public void Leave()
    {
        
    }
    public override void TriggerEvent(string eventName)
    {
        base.TriggerEvent(eventName);
    }
    public override bool IsIdle()
    {
        return currentState == idle;
    }
}
