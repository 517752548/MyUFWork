using System;
using BetaFramework;
using DG.Tweening;
using UnityEngine;

public class ActivityRootIdleState : ActivityRootBaseState
{
    public override void Enter() {
        base.Enter();
        OnCompleted();
    }
}