using BetaFramework;
using DG.Tweening;
using UnityEngine;

public class RankRootStartState : RankRootBaseState
{
    public override void Enter()
    {
        base.Enter();
        
        OnCompleted();
    }
}
