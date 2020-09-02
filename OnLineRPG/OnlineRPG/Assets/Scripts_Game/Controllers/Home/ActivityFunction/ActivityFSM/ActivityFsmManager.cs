using BetaFramework;

public class ActivityFsmManager : BaseThemeFsmManager
{
    public ActivityThemeRoot root;
    public void Init(ActivityThemeRoot homeRoot)
    {
        this.root = homeRoot;
        start = CreateState<ActivityRootStartState>();
        idle = CreateState<ActivityRootIdleState>();
        guide = CreateState<ActivityRootGuideState>();
        message = CreateState<ActivityRootMessageState>();
        InitStateMachine();
    }
    protected override void OnInit()
    {
        base.OnInit();
    }

    public override void TriggerEvent(string eventName)
    {
        base.TriggerEvent(eventName);
    }
}