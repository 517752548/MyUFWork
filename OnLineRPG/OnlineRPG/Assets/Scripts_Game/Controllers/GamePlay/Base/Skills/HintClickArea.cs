using System;
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using BetaFramework;

/// <summary>
/// hint的点击处理
/// </summary>
public class HintClickArea : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    public BaseDragHint hint;

    private bool isDuringChooseTarget = false;//是否在选择道具使用目标过程

    private void Start()
    {
        AppEngine.SSystemManager.GetSystem<UiLayerSystem>().HighLightUI(transform, UILayer.Default, UiLayerOrder.High, true);
    }

    private void OnDestroy()
    {
        //AppEngine.SSystemManager.GetSystem<UiLayerSystem>().ResetUiLayer(transform);
    }

    public void OnPointerClick(PointerEventData eventData)
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        hint.OnChooseTargetClick(eventData);
    }

    public bool IsDuringChoose
    {
        get { return isDuringChooseTarget; }
        set
        {
            isDuringChooseTarget = value;
            gameObject.SetActive(isDuringChooseTarget);
        }
    }
}
