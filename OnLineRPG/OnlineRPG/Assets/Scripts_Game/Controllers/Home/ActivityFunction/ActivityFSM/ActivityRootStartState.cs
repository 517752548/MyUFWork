using BetaFramework;
using DG.Tweening;
using UnityEngine;

public class ActivityRootStartState : ActivityRootBaseState
{
    public override void Enter()
    {
        base.Enter();
        //Debug.LogError($"HomeRootStartState Enter--");
        // homeRoot.MoveTo(HomeRootTab.home, false);
        // DOTween.Sequence().InsertCallback(1, () =>
        // {
        //     // homeRoot.MoveTo(HomeRootTab.decoration);
        // });
        OnCompleted();
    }
}