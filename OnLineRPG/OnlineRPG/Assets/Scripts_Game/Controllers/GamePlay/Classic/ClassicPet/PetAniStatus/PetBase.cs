using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public abstract class PetBase
{
    protected SkeletonGraphic targetSkeleton;
    protected PetStatesManager manager;
    protected const string PetCommonAnim_idle = "idle";
    protected const string PetCommonAnim_click = "click";
    protected const string PetCommonAnim_hint = "hint";
    public void Init(SkeletonGraphic targetSkeleton,PetStatesManager manager)
    {
        this.targetSkeleton = targetSkeleton;
        this.manager = manager;
    }
    
    public abstract void Enter();
    public abstract void Leave();
    public enum PetStates
    {
        Idle,
        click,
        hint
    }
}