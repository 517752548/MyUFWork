using BetaFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Scripts_Game.Controllers.Guides;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts_Game.Controllers.GamePlay.Cross
{
    public class CrossPlayerGuideState : BasePlayerGuideState
    {
        enum CrossGuide
        {
            none,
        }

        CrossGuide guide = CrossGuide.none;

        public override bool CheckCondition()
        {
            guide = CheckToShowGuide();
            return guide != CrossGuide.none;
        }

        private CrossGuide CheckToShowGuide()
        {
            if (Const.AutoPlay)
            {
                return CrossGuide.none;
            }

            return CrossGuide.none;
        }

        public override void Enter()
        {
            base.Enter();
            //GameManager.BanClick(true);
            if (guide == CrossGuide.none)
            {
                guide = CheckToShowGuide();
                if (guide == CrossGuide.none)
                {
                    OnCompleted();
                    return;
                }
            }

            ShowGuide();
        }

        public override void Leave()
        {
            if (guide != CrossGuide.none)
            {
                guide = CrossGuide.none;
                CloseCurrentGuide();
            }

            //GameManager.BanClick(false);
            base.Leave();
        }

        private void OnGuideClickGot()
        {
            guide = CrossGuide.none;
            OnCompleted();
        }

        private void OnGuideClose()
        {
            if (guide != CrossGuide.none)
            {
                guide = CrossGuide.none;
                OnCompleted();
            }
        }

        private void ShowGuide()
        {
            switch (guide)
            {
                default:
                    break;
            }
        }


        public override void HandleEvent(string eventName)
        {
            base.HandleEvent(eventName);
            switch (eventName)
            {
                default:
                    break;
            }
        }
    }
}
