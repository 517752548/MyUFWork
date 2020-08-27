using System;

public class DecorationThemeRoot : BaseThemeRoot
{
    public DecorationFsmManager FsmManager => fsmManager as DecorationFsmManager;
    void Awake()
    {
        if (fsmManager == null)
        {
            fsmManager = gameObject.GetComponent<DecorationFsmManager>();
            if (fsmManager == null)
            {
                fsmManager = gameObject.AddComponent<DecorationFsmManager>();
                FsmManager.Init(this);
            }
        }
    }
    public override bool IsIdle()
    {
        return FsmManager.IsIdle();
    }
    public override void Init(BaseThemeRoot root)
    {
        base.Init(root);
    }

    public override void OnEnter() {
        base.OnEnter();
        FsmManager.Enter();
        GetHomeUi<DecorationDialog>().OnShow();
    }
}