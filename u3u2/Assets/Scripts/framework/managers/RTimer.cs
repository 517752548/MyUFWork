using System;

public delegate void RTimerHandler(RTimer timer);

public class RTimer
{
    private bool isRunning;
    /// <summary>
    /// 是否正在运行
    /// </summary>
    public bool IsRunning
    {
        get { return isRunning; }
    }

    private int interval;
    /// <summary>
    /// 间隔时间,单位毫秒
    /// </summary>
    public int Interval
    {
        get { return interval; }
    }

    private int totalTime = 0;
    /// <summary>
    /// 总时间，单位毫秒
    /// </summary>
    public int TotalTime
    {
        get { return totalTime; }
    }

    private RTimerHandler onTimer;

    private RTimerHandler onEnd;

    //从计时开始已过去的时间
    private long totalPassTime;
    //最后一次达到间隔时间的时间
    private long lastOnTimerPassTime;
    //开始计时的时间
    private DateTime startTime;

    /// <summary>
    /// 构建定时器，时间单位均为毫秒
    /// </summary>
    /// <param name="interval">间隔时间</param>
    /// <param name="totalTime">总计时时间，-1表示无限循环</param>
    /// <param name="onTimer">到达间隔时间的事件</param>
    /// <param name="onEnd">结束事件</param>
    public RTimer(int interval, int totalTime, RTimerHandler onTimer, RTimerHandler onEnd)
    {
        this.interval = interval;
        this.totalTime = totalTime;
        this.onTimer = onTimer;
        this.onEnd = onEnd;
    }

    public RTimer()
    {
    }

    public RTimer(RTimerHandler onTimer, RTimerHandler onEnd)
    {
        this.onTimer = onTimer;
        this.onEnd = onEnd;
    }

    public void Reset(int interval,int totalTime)
    {
        isRunning = false;

        this.interval = interval;
        this.totalTime = totalTime;
    }

    public void Restart()
    {
        if (start())
        {
            TimerManager.Ins.AddTimer(this);
        }
    }

    /// <summary>
    /// 开始计时
    /// </summary>
    /// <returns></returns>
    public bool start()
    {
        if (!IsRunning)
        {
            isRunning = true;
            totalPassTime = 0;
            lastOnTimerPassTime = 0;
            startTime = DateTime.Now;
            return true;
        }
        return false;
    }

    /// <summary>
    /// 结束计时
    /// </summary>
    /// <returns></returns>
    public bool stop()
    {
        if (IsRunning)
        {
            isRunning = false;
            return true;
        }
        return false;
    }

    /// <summary>
    /// 定时更新
    /// 如果到了间隔时间，则调用onTimer，如果到了结束时间，则调用stop和onEnd
    /// </summary>
    /// <param name="passTime"></param>
    public void update(DateTime currentTime)
    {
        TimeSpan ts = currentTime-startTime;
        int passTime = (int)Math.Floor(ts.TotalMilliseconds);
        if (IsRunning)
        {
            //累计已经过去的时间
            totalPassTime = passTime;

            //到了间隔时间，触发onTimer
            if (onTimer != null)
            {
                if (isOnTimer())
                {
                    lastOnTimerPassTime += interval;
                    onTimer(this);
                }
            }

            //到了结束时间，触发onEnd
            if (isOnEnd())
            {
                stop();

                if (onEnd != null)
                {
                    onEnd(this);
                }
            }
        }
    }

    /// <summary>
    /// 是否到了间隔时间
    /// </summary>
    /// <returns></returns>
    private bool isOnTimer()
    {
        long deltaTime = totalPassTime - lastOnTimerPassTime;
        if (deltaTime >= Interval)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// 是否到了结束时间（总时间）
    /// </summary>
    /// <returns></returns>
    private bool isOnEnd()
    {
        if (totalTime > 0)
        {
            if (totalPassTime >= totalTime)
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// 获取剩余时间
    /// 未停止则返回当前的剩余时间；已经停止，则固定返回0
    /// </summary>
    /// <returns></returns>
    public int getLeftTime()
    {
        long leftTime = 0;
        if (totalTime > 0)
        {
            if (isRunning)
            {
                leftTime = totalTime - totalPassTime;
            }
        }
        else 
        {
            //无限循环的，剩余时间为int最大值
            leftTime = int.MaxValue;
        }
        //leftTime修正
        leftTime = leftTime < 0 ? 0 : (leftTime > int.MaxValue ? int.MaxValue : leftTime);
        return (int)leftTime;
    }

    public int getTotalPassTime()
    {
        return (int) totalPassTime;
    }

    public override string ToString()
    {
        return string.Format("RTimer[isRunning={0}, interval={1}], totalTime={2}, totalPassTime={3}, lastOnTimerPassTime={4}, leftTime={5}",
            IsRunning, Interval, TotalTime, totalPassTime, lastOnTimerPassTime, getLeftTime());
    }
}
