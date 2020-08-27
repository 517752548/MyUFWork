
using BetaFramework;

public abstract class BaseFSMState : BaseState
{
    protected BaseFSMManager FsmManager { get { return stateMachine as BaseFSMManager; } }
    protected BaseGameManager GameManager { get { return (stateMachine as BaseFSMManager).GameManager; } }
}

public abstract class BaseCountState : BaseFSMState
{
    private int count = 0;

    public override bool CheckCondition()
    {
        return false;
    }

    public override void Enter()
    {
        count = 0;
        base.Enter();
        AddCount();
    }

    public override void Leave()
    {
        base.Leave();
        count = 0;
    }

    public virtual void AddCount()
    {
        count++;
    }

    public virtual void ReduceCount()
    {
        count--;
        if (count == 0)
        {
            OnCompleted();
        }
    }
}
