using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiLayerSystem : ISystem
{
 /// <summary>
    /// 高亮某个UI
    /// </summary>
    /// <param name="UIElement"></param>
    public void HighLightUI(Transform UIElement, UILayer layer, UiLayerOrder layerSortOrder, bool raycaster)
    {
        UiLayerInfo  uiLayerInfo = UIElement.GetComponent<UiLayerInfo>();
        if (!uiLayerInfo)
        {
            uiLayerInfo = UIElement.gameObject.AddComponent<UiLayerInfo>();
        }

        Canvas uiCanvas = UIElement.GetComponent<Canvas>();
        if (!uiCanvas)
        {
            uiCanvas = UIElement.gameObject.AddComponent<Canvas>();
            uiLayerInfo.hasCanvas = false;
        }
        else
        {
            uiLayerInfo.hasCanvas = true;
            uiLayerInfo.sortingOrder = uiCanvas.sortingOrder;
            uiLayerInfo.layerId = uiCanvas.sortingLayerID;
        }
        uiCanvas.overrideSorting = true;
        uiCanvas.sortingLayerID = SortingLayer.NameToID(layer.ToString());
        uiCanvas.sortingOrder = (int)layerSortOrder;

        GraphicRaycaster graphicRaycaster = UIElement.GetComponent<GraphicRaycaster>();
        if (graphicRaycaster)
        {
            uiLayerInfo.hasGraphicRaycaster = true;
        }
        else
        {
            uiLayerInfo.hasGraphicRaycaster = false;
        }
        
        if (raycaster && !graphicRaycaster)
        {
            UIElement.gameObject.AddComponent<GraphicRaycaster>();
        }
    }


    public void HighLightUIs(List<Transform> UIElements, UILayer layer, UiLayerOrder layerSortOrder, bool raycaster)
    {
        for (int i = 0; i < UIElements.Count; i++)
        {
            HighLightUI(UIElements[i], layer, layerSortOrder, raycaster);
        }
    }

    /// <summary>
    /// 将某些UI从高亮状态恢复原来状态
    /// </summary>
    /// <param name="UIElement"></param>
    public void ResetUiLayer(Transform UIElement)
    {
        UiLayerInfo  uiLayerInfo = UIElement.GetComponent<UiLayerInfo>();

        if (uiLayerInfo != null)
        {
            GraphicRaycaster graycaster = UIElement.GetComponent<GraphicRaycaster>();
            if (uiLayerInfo.hasGraphicRaycaster)
            {
                if (!graycaster)
                {
                    UIElement.gameObject.AddComponent<GraphicRaycaster>();
                }
            }
            else
            {
                if (graycaster)
                {
                    Object.Destroy(graycaster);
                }
            }

            Canvas canvas = UIElement.gameObject.GetComponent<Canvas>();
            if (uiLayerInfo.hasCanvas)
            {
                if (canvas)
                {
                    canvas.sortingLayerID = uiLayerInfo.layerId;
                    canvas.sortingOrder = uiLayerInfo.sortingOrder;
                }
                else
                {
                    canvas = UIElement.gameObject.AddComponent<Canvas>();
                    canvas.sortingLayerID = uiLayerInfo.layerId;
                    canvas.sortingOrder = uiLayerInfo.sortingOrder;
                }
            }
            else
            {
                if (canvas)
                {
                   Object.Destroy(canvas);
                }
            }
        }
    }

    public void ResetUiLayers(List<Transform> UIElements)
    {
        for (int i = 0; i < UIElements.Count; i++)
        {
            ResetUiLayer(UIElements[i]);
        }
    }
}
public class UiLayerInfo : MonoBehaviour
{
    public bool hasCanvas = false;
    public bool hasGraphicRaycaster = false;
    public int layerId = 0;
    public int sortingOrder = 0;
}

public class UILayerTarget
{
    public RectTransform target;
    public UILayer layer;
    public UiLayerOrder order;
    public bool hasRaycaster = false;
}