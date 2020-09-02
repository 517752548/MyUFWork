using System;

public class ActivityThemeRoot : BaseThemeRoot
{
    public ActivityFsmManager FsmManager => fsmManager as ActivityFsmManager;

    public override void Init(HomeRoot root)
    {
        if (fsmManager == null)
        {
            fsmManager = gameObject.GetComponent<ActivityFsmManager>();
            if (fsmManager == null)
            {
                fsmManager = gameObject.AddComponent<ActivityFsmManager>();
                FsmManager.Init(this);
            }
        }
        base.Init(root);
    }

    public override bool IsIdle()
    {
        return FsmManager.IsIdle();
    }
    public override void OnEnter()
    {
        base.OnEnter();
    }
}