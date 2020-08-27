
public class FsmState
{
    protected FsmManager fsm;
    public bool IsCompleted { get; protected set; }
    public bool IsLeft { get; protected set; }
    public string StateId { get; private set; }

    public virtual void Init(FsmManager fsmManager, string stateId)
    {
        this.fsm = fsmManager;
        IsCompleted = false;
        this.StateId = stateId;
    }

    public virtual void Enter()
    {
        IsLeft = false;
        IsCompleted = true;
    }

    public virtual void Leave()
    {
        IsLeft = true;
    }

    public virtual void UpdateData()
    {

    }
}
