using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiLayerController
{
    private Transform parent;
    public UiLayerController(Transform parent)
    {
        this.parent = parent;
    }

    public void ShowWindow(BaseUI baseui)
    {
        baseui.SetController(this);
        baseui.transform.SetParent(parent,false);
    }

    public void CloseWindow()
    {
        
    }
}
