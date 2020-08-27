using BetaFramework;
using DG.Tweening;
using UnityEngine;

public class HomeRootStartState : HomeRootBaseState
{
    public override void Enter()
    {
        base.Enter();
        Debug.Log($"HomeRootStartState Enter--");
        // homeRoot.MoveTo(HomeRootTab.home, false);
        // DOTween.Sequence().InsertCallback(1, () =>
        // {
        //     // homeRoot.MoveTo(HomeRootTab.decoration);
        // });
        OnCompleted();
    }
}