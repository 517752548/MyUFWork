using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using BetaFramework;

public class AdjustBoardTwoArrowGuide : AdjustBoardArrowGuide
{
    [SerializeField]
    protected RectTransform arrow2;
    [SerializeField]
    protected Transform arrowTarget2;

    protected TwoArrowGuideParam twoArrowGuideParam;

    public override void OnOpen()
    {
        twoArrowGuideParam = objs[0] as TwoArrowGuideParam;
        base.OnOpen();
        AppEngine.SSystemManager.GetSystem<UiLayerSystem>().HighLightUI(twoArrowGuideParam.target2.target, 
            UILayer.UI, UiLayerOrder.Guide, twoArrowGuideParam.target2.hasRaycaster);
    }

    protected override void AdjustPosition()
    {
        base.AdjustPosition();
        arrowTarget2.position = twoArrowGuideParam.target2.target.position;
        arrowTarget2.SetLocalZ(0);
        AdjustArrowPosition(arrowTarget2, arrow2);
    }

    public override void OnClose()
    {
        base.OnClose();
        AppEngine.SSystemManager.GetSystem<UiLayerSystem>().ResetUiLayer(twoArrowGuideParam.target2.target);
    }
}

public class TwoArrowGuideParam : GuideParam
{
    public UILayerTarget target2;

    public TwoArrowGuideParam(UILayerTarget target, UILayerTarget target2, Action clickGotIt, Action onClose, List<UILayerTarget> highLightUIs) 
        : base(target, clickGotIt, onClose, highLightUIs)
    {
        this.target2 = target2;
    }
}
