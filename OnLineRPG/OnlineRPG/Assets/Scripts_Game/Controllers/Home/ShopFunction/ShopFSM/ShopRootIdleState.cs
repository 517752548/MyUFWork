using System;
using BetaFramework;
using DG.Tweening;
using UnityEngine;

public class ShopRootIdleState : ShopRootBaseState
{
    public override void Enter() {
        base.Enter();
        OnCompleted();
    }
}
