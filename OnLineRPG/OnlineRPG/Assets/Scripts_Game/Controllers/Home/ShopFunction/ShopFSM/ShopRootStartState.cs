using BetaFramework;
using DG.Tweening;
using UnityEngine;

public class ShopRootStartState : ShopRootBaseState
{
    public override void Enter()
    {
        base.Enter();
        OnCompleted();
    }
}
