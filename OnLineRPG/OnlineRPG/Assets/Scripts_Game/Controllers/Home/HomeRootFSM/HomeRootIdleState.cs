using System;
using BetaFramework;
using DG.Tweening;
using UnityEngine;

public class HomeRootIdleState : HomeRootBaseState
{
    public override void Enter() {
        base.Enter();
        OnCompleted();
    }
}