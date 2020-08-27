using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetClick : PetBase
{

    public override void Enter()
    {
        targetSkeleton.AnimationState.SetAnimation(0, PetCommonAnim_click, false);
        targetSkeleton.AnimationState.Complete += AnimComplete;
    }

    void AnimComplete(Spine.TrackEntry state)
    {
        manager.TransTo(PetStates.Idle);
    }
    public override void Leave()
    {
        targetSkeleton.AnimationState.Complete -= AnimComplete;
        targetSkeleton.Skeleton.SetToSetupPose();
    }
}