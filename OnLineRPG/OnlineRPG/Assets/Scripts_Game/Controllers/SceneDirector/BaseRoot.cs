using System;
using System.Collections;
using System.Collections.Generic;
using Scripts_Game.Views;
using UnityEngine;
using UnityEngine.UI;

public class BaseRoot : MonoBehaviour
{
    public PartTransparentMask _imageMask;
    public GameUI _UiType;

    public virtual void Init()
    {
        
    }
    
    public virtual void Show(Action<bool> callback)
    {
        callback?.Invoke(true);
    }

    public virtual void Hidden()
    {
        
    }

    private void OnDestroy()
    {
        Hidden();
    }

    public virtual void OnUISwitched(GameUI currentType)
    {
        
    }

    public virtual bool IsVisible()
    {
        return true;
    }


}
