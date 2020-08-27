using BetaFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OneKeyButton : Button
{
    public Action press;
    public Action idle;
    public Action<bool> longPress;

    private bool longPressStart = false;
    
    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        press?.Invoke();
        TimersManager.SetTimer(1f, OnLongPressed);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        idle?.Invoke();
        EndLongPress();
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        base.OnPointerExit(eventData);
        idle?.Invoke();
        EndLongPress();
    }

    private void OnLongPressed()
    {
        longPressStart = true;
        longPress?.Invoke(true);
    }

    private void EndLongPress()
    {
        TimersManager.ClearTimer(OnLongPressed);
        if (longPressStart)
        {
            longPressStart = false;
            longPress?.Invoke(false);
        }
    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus && longPressStart)
        {
            ExecuteEvents.Execute<IPointerUpHandler>(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerUpHandler);
        }
    }
}
