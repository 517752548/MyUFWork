using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using DG.Tweening;
using UnityEngine;

public static class DotweenExtention
{
    public static DOTweenAwaiter ToAwaiter(this Tween tween,
        CancellationToken cancellationToken = default,
        TweenCancelBehaviour behaviour = TweenCancelBehaviour.Kill)
    {
        return new DOTweenAwaiter(tween, cancellationToken, behaviour);
    }
}

public struct DOTweenAwaiter : ICriticalNotifyCompletion
{
    private Tween _tween;
    private CancellationToken _cancellationToken;
    private TweenCancelBehaviour _behaviour;

    public DOTweenAwaiter(Tween tween, CancellationToken cancellationToken, TweenCancelBehaviour behaviour)
    {
        _tween = tween;
        _cancellationToken = cancellationToken;
        _behaviour = behaviour;
    }

    public bool IsCompleted => _tween.IsPlaying() == false;

    public void GetResult() => _cancellationToken.ThrowIfCancellationRequested();

    public void OnCompleted(Action continuation) => UnsafeOnCompleted(continuation);

    public void UnsafeOnCompleted(Action continuation)
    {
        DOTweenAwaiter tmpThis = this;
        var tween = _tween;
        var regist = tmpThis._cancellationToken.Register(
            () =>
            {
                switch (tmpThis._behaviour)
                {
                    case TweenCancelBehaviour.Kill:
                        tween.Kill();
                        break;
                    case TweenCancelBehaviour.KillWithCompleteCallback:
                        tween.Kill(true);
                        break;
                    case TweenCancelBehaviour.Complete:
                        tween.Complete();
                        break;
                    default: throw new ArgumentOutOfRangeException();
                }
            }
        );

        _tween.OnKill(
            () =>
            {
                regist.Dispose();
                continuation();
            }
        );
    }

    public DOTweenAwaiter GetAwaiter() => this;
}

public enum TweenCancelBehaviour
{
    Kill,
    KillWithCompleteCallback,
    Complete
}