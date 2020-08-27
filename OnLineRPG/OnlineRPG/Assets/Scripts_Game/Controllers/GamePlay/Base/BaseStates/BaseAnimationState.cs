using UnityEngine;
using System.Collections;

public class BaseAnimationState : BaseCountState
{
    private const float maxTime = 5f;
    private float time = 0;
    private Coroutine coroutine = null;

    public override void AddCount()
    {
        base.AddCount();
        time = 0;
        if (coroutine == null)
            coroutine = StartCoroutine(CheckTime());
    }
    
    protected override void OnCompleted()
    {
        base.OnCompleted();
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
            coroutine = null;
            time = 0;
        }
    }

    private IEnumerator CheckTime()
    {
        while (time < maxTime)
        {
            yield return new WaitForSeconds(0.1f);
            time += 0.1f;
        }
        OnCompleted();
        yield break;
    }
}
