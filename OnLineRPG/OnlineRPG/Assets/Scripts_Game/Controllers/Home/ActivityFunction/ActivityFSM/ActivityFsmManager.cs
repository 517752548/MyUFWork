using BetaFramework;

public class ActivityFsmManager : BaseThemeFsmManager
{
    private BaseState start, idle, guide, popup;
    public ActivityThemeRoot root;
    public void Init(ActivityThemeRoot homeRoot)
    {
        this.root = homeRoot;
        start = CreateState<ActivityRootStartState>();
        idle = CreateState<ActivityRootIdleState>();
        guide = CreateState<ActivityRootGuideState>();
        popup = CreateState<ActivityRootPopupState>();
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