using BetaFramework;

public class ActivityRootBaseState : BaseState
{
    protected ActivityFsmManager fsm => stateMachine as ActivityFsmManager;
    protected ActivityThemeRoot homeRoot => fsm.root;
}