public class RankThemeRoot : BaseThemeRoot
{

    public RankFsmManager FsmManager => fsmManager as RankFsmManager;
    void Awake()
    {
        if (fsmManager == null)
        {
            fsmManager = gameObject.AddComponent<RankFsmManager>();
            FsmManager.Init(this);
        }
    }

    public override void OnEnter()
    {
        base.OnEnter();
        FsmManager.Enter();
    }
}