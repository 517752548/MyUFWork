using BetaFramework;

public class ShopRootBaseState : BaseState
{
    protected ShopFsmManager fsm => stateMachine as ShopFsmManager;
    protected ShopThemeRoot homeRoot => fsm.root;
}
