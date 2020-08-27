using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using Scripts_Game.Controllers.Home.Elements;
using UnityEngine;

public class HomeIdleState : HomeState
{
    public override void Enter()
    {
        base.Enter();
        HomeFsmManager.BanClick(false);
        if (Const.AutoPlay)
        {
            TimersManager.SetTimer(3, () => { GameObject.FindObjectOfType<LevelPlayButton>().ClickLevelButton(); });
            return;
        }

        OnCompleted();
    }


    public override void Leave()
    {
        base.Leave();
    }
}