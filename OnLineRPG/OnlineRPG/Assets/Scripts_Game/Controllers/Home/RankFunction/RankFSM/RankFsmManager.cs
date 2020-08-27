using BetaFramework;

public class RankFsmManager : BaseThemeFsmManager
{
    private BaseState start, idle, guide, popup;
    public RankThemeRoot root;
    public void Init(RankThemeRoot homeRoot)
    {
        this.root = homeRoot;
        start = CreateState<RankRootStartState>();
        idle = CreateState<RankRootIdleState>();
        guide = CreateState<RankRootGuideState>();
        popup = CreateState<RankRootPopupState>();
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
