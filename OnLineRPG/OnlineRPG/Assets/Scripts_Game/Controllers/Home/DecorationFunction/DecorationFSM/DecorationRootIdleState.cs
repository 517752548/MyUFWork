using System;
using BetaFramework;
using DG.Tweening;
using UnityEngine;

public class DecorationRootIdleState : DecorationRootBaseState
{
    public override void Enter() {
        base.Enter();
        OnCompleted();
    }
}
