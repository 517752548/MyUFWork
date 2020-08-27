using BetaFramework;
using DG.Tweening;
using UnityEngine;

public class DecorationRootStartState : DecorationRootBaseState
{
    public override void Enter()
    {
        base.Enter();
        // homeRoot.MoveTo(HomeRootTab.home, false);
        // DOTween.Sequence().InsertCallback(1, () =>
        // {
        //     // homeRoot.MoveTo(HomeRootTab.decoration);
        // });
        OnCompleted();
    }
}
