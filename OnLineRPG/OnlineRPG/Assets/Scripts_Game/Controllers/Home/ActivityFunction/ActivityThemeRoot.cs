using System;

public class ActivityThemeRoot : BaseThemeRoot
{
    public ActivityFsmManager FsmManager => fsmManager as ActivityFsmManager;
    void Awake()
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
    }
    public override bool IsIdle()
    {
        return FsmManager.IsIdle();
    }
    public override void OnEnter()
    {
        base.OnEnter();
        FsmManager.Enter();
    }
}