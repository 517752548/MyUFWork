using BetaFramework;

public class DecorationFsmManager : BaseThemeFsmManager
{
    public DecorationThemeRoot root;
    public void Init(DecorationThemeRoot homeRoot)
    {
        this.root = homeRoot;
        start = CreateState<DecorationRootStartState>();
        idle = CreateState<DecorationRootIdleState>();
        guide = CreateState<DecorationRootGuideState>();
        message = CreateState<DecorationRootMessageState>();
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
