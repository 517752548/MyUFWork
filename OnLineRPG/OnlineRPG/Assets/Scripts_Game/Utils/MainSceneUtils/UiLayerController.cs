using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiLayerController:MonoBehaviour
{

   public Image mask;
   
   /// <summary>
   /// 展示遮罩
   /// </summary>
   public void ShowMask()
   {
      mask.enabled = true;
   }

   /// <summary>
   /// 隐藏遮罩
   /// </summary>
   public void CloseMask()
   {
      mask.enabled = false;
   }
   
   /// <summary>
   /// 高亮某个UI
   /// </summary>
   /// <param name="UIElement"></param>
   public void HighLightUI(Transform UIElement,int layer,bool raycaster)
   {
      if (!UIElement.GetComponent<Canvas>())
      {
         Canvas canvas = UIElement.gameObject.AddComponent<Canvas>();
         canvas.overrideSorting = true;
         canvas.sortingOrder = layer;
      }

      if (raycaster && !UIElement.GetComponent<GraphicRaycaster>())
      {
         UIElement.gameObject.AddComponent<GraphicRaycaster>();
      }
   }


   public void HighLightUIs(List<Transform> UIElements,int layer,bool raycaster)
   {
      for (int i = 0; i < UIElements.Count; i++)
      {
         HighLightUI(UIElements[i],layer,raycaster);
      }
   }

   /// <summary>
   /// 将某些UI从高亮状态恢复原来状态
   /// </summary>
   /// <param name="UIElement"></param>
   public void ResetUiLayer(Transform UIElement)
   {
      Canvas canvas = UIElement.gameObject.GetComponent<Canvas>();
      if (canvas)
      {
         Object.Destroy(canvas);
      }

      GraphicRaycaster graycaster = UIElement.GetComponent<GraphicRaycaster>();
      if (graycaster)
      {
        Object.Destroy(graycaster);
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
