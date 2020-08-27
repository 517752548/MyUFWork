using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using UnityEngine;

namespace Scripts_Game.Controllers.GamePlay.Cross
{
    public class CrossPlayingState : BasePlayingState
    {
        public override void Enter()
        {
            base.Enter();
            if (Const.AutoPlay)
            {
                if (Const.UseInput)
                {
                    BaseGameManager game = Object.FindObjectOfType<BaseGameManager>();
                    if (game)
                    {
                        game.AutoInputRightAnswer();
                    }
                }
                else
                {
                    TimersManager.SetTimer(3f, () =>
                    {
                        BaseGameManager game = Object.FindObjectOfType<BaseGameManager>();
                        if (game)
                        {
                            game.WinGame();
                        }
                    });
                }
            }
        }

        public override void Leave()
        {
            base.Leave();
        }
    }
}
