using BetaFramework;

public class DecorationFsmManager : BaseThemeFsmManager
{
    private BaseState start, idle, guide, popup;
    public DecorationThemeRoot root;
    public void Init(DecorationThemeRoot homeRoot)
    {
        this.root = homeRoot;
        start = CreateState<DecorationRootStartState>();
        idle = CreateState<DecorationRootIdleState>();
        guide = CreateState<DecorationRootGuideState>();
        popup = CreateState<DecorationRootPopupState>();
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
