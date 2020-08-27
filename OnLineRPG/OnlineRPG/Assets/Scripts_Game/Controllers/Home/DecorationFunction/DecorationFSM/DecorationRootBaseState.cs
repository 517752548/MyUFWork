using BetaFramework;

public class DecorationRootBaseState : BaseState
{
    protected DecorationFsmManager fsm => stateMachine as DecorationFsmManager;
    protected DecorationThemeRoot homeRoot => fsm.root;
}
