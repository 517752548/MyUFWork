using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using UnityEngine;

public abstract class ISystem : BaseState
{
    
    //private string m_ModuleName;
    private DateTime leavetime = DateTime.MinValue;
    public override void Enter()
    {
        base.Enter();
        InitSystem();
    }

    public virtual void InitSystem()
    {
        OnCompleted();
    }

    public virtual void Execute(float deltaTime)
    {

    }

    public virtual void Shut()
    {

    }

    public virtual void Pause(bool pause)
    {
        if (pause)
        {
            leavetime = DateTime.Now;
        }
        else
        {
            if (leavetime != DateTime.MinValue && DateTime.Now.Subtract(leavetime).Hours > 1)
            {
                LeaveOneHours();
            }
        }
    }

    public virtual void LeaveOneHours()
    {
        
    }

    public virtual void OnEnterUI(GameUI UiToSwitch)
    {
    }
};
