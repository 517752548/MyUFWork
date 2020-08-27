using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetIdle : PetBase
{

	private int times = 0;

	public override void Enter()
	{
		targetSkeleton.AnimationState.SetAnimation(0, PetCommonAnim_idle, true);
		targetSkeleton.AnimationState.Complete += AnimComplete;
	}

	void AnimComplete(Spine.TrackEntry state)
	{
//		times++;
//		if (times >= 5)
//		{
//			times = 0;
//			manager.TransTo(PetStates.i);
//		}
		
	}
	public override void Leave()
	{
//		times = 0;
		targetSkeleton.AnimationState.Complete -= AnimComplete;
		targetSkeleton.Skeleton.SetToSetupPose();
	}
}
