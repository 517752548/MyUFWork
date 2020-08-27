using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePopupState : BaseCountState
{
    public override bool CheckCondition()
    {
        return false;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Leave()
    {
        base.Leave();
    }
}
