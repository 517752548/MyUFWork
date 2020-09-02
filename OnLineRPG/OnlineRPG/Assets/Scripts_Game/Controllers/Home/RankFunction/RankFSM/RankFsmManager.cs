using BetaFramework;

public class RankFsmManager : BaseThemeFsmManager
{
    public RankThemeRoot root;
    public void Init(RankThemeRoot homeRoot)
    {
        this.root = homeRoot;
        start = CreateState<RankRootStartState>();
        idle = CreateState<RankRootIdleState>();
        guide = CreateState<RankRootGuideState>();
        message = CreateState<RankRootMessageState>();
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
