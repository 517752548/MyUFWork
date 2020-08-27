public class ShopThemeRoot : BaseThemeRoot
{
    public ShopFsmManager FsmManager => fsmManager as ShopFsmManager;
    void Awake()
    {
        if (fsmManager == null)
        {
            fsmManager = gameObject.AddComponent<ShopFsmManager>();
            FsmManager.Init(this);
        }
    }
    public override void OnEnter()
    {
        base.OnEnter();
        FsmManager.Enter();
    }
}