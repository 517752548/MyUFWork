using UnityEngine;
using System.Collections;

public class BaseCheckPlayerGuideState : BaseFSMState
{
    public override void Enter()
    {
        base.Enter();
    }

    public override void Leave()
    {
        base.Leave();
    }

    public virtual bool CheckUserGuide()
    {
        return false;
    }
}
