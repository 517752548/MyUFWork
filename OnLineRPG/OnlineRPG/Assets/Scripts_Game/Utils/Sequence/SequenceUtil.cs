using UnityEngine;
using System.Collections;
using DG.Tweening;
using System;

public class SequenceUtil
{
    public static SequenceTask StartTask(float totalTime, ISequenceTaskCallback completeCallback)
    {
        SequenceTask seq = new SequenceTask();
        seq.SetTotalTask(totalTime, completeCallback);
        return seq;
    }
}

public class SequenceTask
{
    public Sequence sequence;
    private float insertPosition = 0;

    public SequenceTask()
    {
        this.sequence = DOTween.Sequence();
    }

    public void SetTotalTask(float totalTime, ISequenceTaskCallback completeCallback)
    {
        sequence.AppendInterval(totalTime);
        sequence.AppendCallback(completeCallback.Run);
    }

    public void InsertCallback(float interval, ISequenceTaskCallback callback)
    {
        insertPosition += interval;
        if (insertPosition <= 0)
        {
            insertPosition = 0;
            callback.Run();
            return;
        }
        sequence.InsertCallback(insertPosition, callback.Run);
    }
}

public interface ISequenceTaskCallback
{
    void Run();
}

public class SequenceTaskActionCallback : ISequenceTaskCallback
{
    private Action callback;

    public SequenceTaskActionCallback(Action callback)
    {
        this.callback = callback;
    }

    public void Run()
    {
        callback?.Invoke();
    }
}

public class SequenceTaskObjectCallback<T> : ISequenceTaskCallback
{
    private T param;
    private Action<T> callback;

    public SequenceTaskObjectCallback(T param, Action<T> callback)
    {
        this.param = param;
        this.callback = callback;
    }

    public void Run()
    {
        callback?.Invoke(param);
    }
}
