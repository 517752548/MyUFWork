using BetaFramework;

public class RankRootBaseState : BaseState
{
    protected RankFsmManager fsm => stateMachine as RankFsmManager;
    protected RankThemeRoot homeRoot => fsm.root;
}
