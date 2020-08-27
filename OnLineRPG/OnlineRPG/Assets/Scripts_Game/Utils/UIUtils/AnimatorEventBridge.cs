using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimatorEventBridge : MonoBehaviour
{
    public UnityEvent triggerEvent1;
    public UnityEvent triggerEvent2;
    public UnityEvent triggerEvent3;
    public UnityEvent triggerEvent4;
    public UnityEvent triggerEvent5;
    public UnityEvent triggerEvent6;

    public void TriggerEvent1()
    {
        if (triggerEvent1 != null)
        {
            triggerEvent1.Invoke();
        }
    }

    public void TriggerEvent2()
    {
        if (triggerEvent2 != null)
        {
            triggerEvent2.Invoke();
        }
    }
    
    public void TriggerEvent3()
    {
        if (triggerEvent3 != null)
        {
            triggerEvent3.Invoke();
        }
    }
    
    public void TriggerEvent4()
    {
        if (triggerEvent4 != null)
        {
            triggerEvent4.Invoke();
        }
    }
    
    public void TriggerEvent5()
    {
        if (triggerEvent5 != null)
        {
            triggerEvent5.Invoke();
        }
    }
    
    public void TriggerEvent6()
    {
        if (triggerEvent6 != null)
        {
            triggerEvent6.Invoke();
        }
    }
}
