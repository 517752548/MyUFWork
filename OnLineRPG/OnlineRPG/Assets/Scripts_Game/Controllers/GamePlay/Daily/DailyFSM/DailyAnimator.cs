using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyAnimator : BaseAnimationState
{
    public override void Enter()
    {
        GameManager.BanClick(true);
        base.Enter();
    }

    public override void Leave()
    {
        GameManager.BanClick(false);
        base.Leave();
    }
}
