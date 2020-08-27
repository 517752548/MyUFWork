using System;
using BetaFramework;
using DG.Tweening;
using UnityEngine;

public class RankRootIdleState : RankRootBaseState
{
    public override void Enter() {
        base.Enter();
        OnCompleted();
    }
}
