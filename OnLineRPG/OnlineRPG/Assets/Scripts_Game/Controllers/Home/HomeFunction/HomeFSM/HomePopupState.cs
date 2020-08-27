using BetaFramework;
using UnityEngine;

public class HomePopupState : HomeState
{
    private int count = 0;
    
    public override bool CheckCondition()
    {
        if (Const.AutoPlay)
        {
            return false;
        }
        return false;
    }
    
    public override void Enter()
    {
        count = 0;
        base.Enter();
        AddCount();
    }

    public override void Leave()
    {
        base.Leave();
        count = 0;
    }

    public virtual void AddCount()
    {
        count++;
    }

    public virtual void ReduceCount()
    {
        count--;
        if (count == 0)
        {
            OnCompleted();
        }
    }
}