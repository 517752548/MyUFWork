using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using BetaFramework;
using System;
using System.Collections.Generic;

public class BaseBoardGuide : UIWindowBase
{
    [SerializeField]
    protected RectTransform board;
    [SerializeField]
    protected Text desText = null;
    [SerializeField]
    protected Button gotBtn;

    protected GuideParam guideParam;
    protected BaseRoot curRoot;

    public override void OnOpen()
    {
        curRoot = MainSceneDirector.Instance.GetVisibleRoot();

        base.OnOpen();
        guideParam = (GuideParam)objs[0];

        if (!string.IsNullOrEmpty(guideParam.desStr) && desText != null)
            desText.text = guideParam.desStr;
        if (gotBtn != null)
        {
            gotBtn.onClick.RemoveAllListeners();
            gotBtn.onClick.AddListener(OnGotClick);
        }
		
        ShowMask();
        HighLightUIs();
    }

    protected virtual void ShowMask()
    {
        if (curRoot != null)
            curRoot._imageMask.Show();
    }

    protected virtual void HighLightUIs()
    {
        if (guideParam.targetInfo != null)
        {
            AppEngine.SSystemManager.GetSystem<UiLayerSystem>().HighLightUI(guideParam.targetInfo.target,
                UILayer.UI, UiLayerOrder.Guide, guideParam.targetInfo.hasRaycaster); 
        }
        if (guideParam.highLightUIs != null)
            guideParam.highLightUIs.ForEach(ui => {
                AppEngine.SSystemManager.GetSystem<UiLayerSystem>().HighLightUI(ui.target,
                    UILayer.UI, UiLayerOrder.Guide, ui.hasRaycaster);
            });
    }

    public override void OnClose()
    {
        base.OnClose();
        if (curRoot != null)
        {
            curRoot._imageMask.Hide();
            curRoot = null;
        }
        if (guideParam.targetInfo != null)
            AppEngine.SSystemManager.GetSystem<UiLayerSystem>().ResetUiLayer(guideParam.targetInfo.target);
        if (guideParam.highLightUIs != null)
            guideParam.highLightUIs.ForEach(ui => {
                AppEngine.SSystemManager.GetSystem<UiLayerSystem>().ResetUiLayer(ui.target);
            });
        guideParam.onClose?.Invoke();
    }

    protected virtual void OnGotClick()
    {
        guideParam.clickGotIt?.Invoke();
        Close();
    }
}

public class GuideParam
{
    public UILayerTarget targetInfo;
    public Action clickGotIt;
    public Action onClose;
    public List<UILayerTarget> highLightUIs = null;
    public string desStr;

    public GuideParam(UILayerTarget target, Action clickGotIt, Action onClose, List<UILayerTarget> highLightUIs, string des = null)
    {
        this.targetInfo = target;
        this.clickGotIt = clickGotIt;
        this.onClose = onClose;
        this.highLightUIs = highLightUIs;
        this.desStr = des;
    }
}
