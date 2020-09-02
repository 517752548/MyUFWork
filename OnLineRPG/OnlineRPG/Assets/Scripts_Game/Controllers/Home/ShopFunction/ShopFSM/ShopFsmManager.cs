using BetaFramework;

public class ShopFsmManager : BaseThemeFsmManager
{
    public ShopThemeRoot root;
    public void Init(ShopThemeRoot homeRoot)
    {
        this.root = homeRoot;
        start = CreateState<ShopRootStartState>();
        idle = CreateState<ShopRootIdleState>();
        guide = CreateState<ShopRootGuideState>();
        message = CreateState<ShopRootMessageState>();
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
