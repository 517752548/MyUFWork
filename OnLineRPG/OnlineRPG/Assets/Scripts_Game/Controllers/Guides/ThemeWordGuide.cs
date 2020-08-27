using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts_Game.Controllers.Guides
{
    public class ThemeWordGuide : AdjustBoardArrowGuide
    {
        public RectTransform targetArea;
        private ThemeWordGuideParam param => guideParam as ThemeWordGuideParam;

        public override void OnOpen()
        {
            base.OnOpen();
            targetArea.SetLocalX(param.targetRect.x + param.targetRect.width / 2);
            targetArea.SetLocalY(param.targetRect.y - param.targetRect.height / 2);
            targetArea.sizeDelta = new Vector2(param.targetRect.width, param.targetRect.height);
        }

        protected override void ShowMask()
        {
            //base.ShowMask();
            if (curRoot != null)
                curRoot._imageMask.ShowRect(param.targetRect, false);
        }

        protected override void HighLightUIs()
        {
            //base.HighLightUIs();
        }
    }
    
    public class ThemeWordGuideParam : GuideParam
    {
        public Rect targetRect;

        public ThemeWordGuideParam(UILayerTarget target, Rect rt, Action clickGotIt, Action onClose) 
            : base(target, clickGotIt, onClose, null)
        {
            this.targetRect = rt;
        }
    }
}