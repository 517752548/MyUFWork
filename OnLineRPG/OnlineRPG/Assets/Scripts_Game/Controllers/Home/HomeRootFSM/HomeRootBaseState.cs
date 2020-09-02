using BetaFramework;

public class HomeRootBaseState : BaseState
{
    protected HomeRootFsmManager fsm => stateMachine as HomeRootFsmManager;
    protected HomeRoot homeRoot => fsm.homeRoot;

    public virtual void Refresh()
    {
        
    }
}