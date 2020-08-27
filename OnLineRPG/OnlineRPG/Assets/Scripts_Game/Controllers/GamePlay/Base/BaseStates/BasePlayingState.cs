using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayingState : BaseFSMState
{
    private int count = 0;
    public override void Enter()
    {
        GameManager.BanClick(false);
        base.Enter();
        if (count == 0)
            GameManager.GetEntity<BaseCellManager>().OnEnterPlayState();
        count++;
        OnCompleted();
    }

    public override void Leave()
    {
        base.Leave();
    }
}
