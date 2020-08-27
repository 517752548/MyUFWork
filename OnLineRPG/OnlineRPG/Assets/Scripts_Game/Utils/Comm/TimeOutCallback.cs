using System;
using DG.Tweening;

namespace Scripts_Game.Utils.Comm
{
    /// <summary>
    /// 可以设置超时的回调
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TimeOutCallback<T> where T : class
    {
        private readonly T callback;
        private readonly Action<T> onTimeOut;
        private bool isFinished = false;

        public TimeOutCallback(float time, T callback, Action<T> onTimeOut)
        {
            this.callback = callback;
            this.onTimeOut = onTimeOut;
            isFinished = false;
            DOTween.Sequence().InsertCallback(time, OnTimeOut);
        }

        private void OnTimeOut()
        {
            if (isFinished)
                return;
            isFinished = true;
            onTimeOut.Invoke(callback);
        }

        public T Callback
        {
            get
            {
                if (isFinished)
                    return null;
                isFinished = true;
                return callback;
            }
        }
    }
}