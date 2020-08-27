using BetaFramework;
using UnityEngine;

public class HomeStartState : HomeState
{
    public override void Enter()
    {
        base.Enter();
        HomeFsmManager.BanClick(true);
        TimersManager.SetTimer(0.3f, OnCompleted);
    }
}