using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiLayerController
{
    private Transform parent;
    private Dictionary<int,BaseUI> currentUI = new Dictionary<int, BaseUI>();
    public UiLayerController(Transform parent)
    {
        this.parent = parent;
    }

    public void ShowWindow(BaseUI baseui)
    {
        baseui.SetController(this);
        baseui.UIID = Random.Range(0, 9999999);
        baseui.transform.SetParent(parent,false);
        currentUI.Add(baseui.UIID,baseui);
    }

    public void CloseWindow(BaseUI baseui)
    {
        if (currentUI.ContainsKey(baseui.UIID))
        {
            
        }
    }
}
