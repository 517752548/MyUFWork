using System;
using UnityEngine;
using System.Collections.Generic;


/// <summary>
    /// 定时管理器
    /// </summary>
    public class TimerManager : MonoBehaviour
    {
        public static readonly int FIXED_DELTA_TIME = (int)Math.Round(Time.fixedDeltaTime * 1000);

        private static TimerManager _ins;

        public static TimerManager Ins
        {
            get
            {
                if (_ins == null)
                {
                    _ins = GameObject.Find("ScriptsRoot").GetComponent<TimerManager>();
                    if (_ins == null)
                    {
                        _ins = GameObject.Find("ScriptsRoot").AddComponent<TimerManager>();
                    }
                    
                }
                return _ins;
            }
        }

        private TimerManager()
        {
            timerList = new List<RTimer>();
            ClientLog.Log("FIXED_DELTA_TIME=" + FIXED_DELTA_TIME);
        }

        //所有的timer列表
        private List<RTimer> timerList;
        
        public void FixedUpdate()
        {
            for (int i = 0; i < timerList.Count; i++)
            {
                RTimer timer = timerList[i];
                if (timer != null)
                {
                    //更新已开始未结束的计时器
                    if (timer.IsRunning)
                    {
                        timer.update(DateTime.Now);
                    }

                    //删除结束的计时器
                    if (!timer.IsRunning)
                    {
                        timerList.RemoveAt(i);
                        i--;
                        continue;
                    }
                }
            }            
        }

        /// <summary>
        /// 创建一个计时器，时间单位均为毫秒
        /// </summary>
        /// <param name="interval">间隔时间</param>
        /// <param name="totalTime">总计时时间，-1表示无限循环</param>
        /// <param name="onTimer">到达间隔时间的事件</param>
        /// <param name="onEnd">结束事件</param>
        /// <returns></returns>
        public RTimer createTimer(int interval, int totalTime, RTimerHandler onTimer, RTimerHandler onEnd)
        {
            ////时间间隔最小为一次心跳的时间
            //if (interval < TimerManager.FIXED_DELTA_TIME)
            //{
            //    interval = TimerManager.FIXED_DELTA_TIME;
            //}
            ////总时间不能小于间隔时间
            //if (totalTime > 0 && totalTime < interval)
            //{
            //    totalTime = interval;
            //}

            RTimer timer = new RTimer(interval, totalTime, onTimer, onEnd);
            timerList.Add(timer);
            return timer;
        }

        public RTimer createTimer(RTimerHandler onTimer, RTimerHandler onEnd)
        {
            RTimer timer = new RTimer(onTimer, onEnd);
            timerList.Add(timer);
            return timer;
        }

        public void AddTimer(RTimer timer)
        {
            if (!timerList.Contains(timer))
            {
                timerList.Add(timer);
            }
        }
}

