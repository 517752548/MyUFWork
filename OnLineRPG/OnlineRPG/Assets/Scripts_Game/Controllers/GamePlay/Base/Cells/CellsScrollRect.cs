using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class CellsScrollRect : ScrollRect
{
    protected Action endDragCallback;

    public override void OnBeginDrag(PointerEventData eventData)
    {
        inertia = true;
        decelerationRate = 0.2f;
        base.OnBeginDrag(eventData);
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
        endDragCallback?.Invoke();
    }

    public void OnEndDrag(Action callback)
    {
        endDragCallback = callback;
    }
}
