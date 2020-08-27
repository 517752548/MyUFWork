using System;
using System.Diagnostics;

public class NETSubTimeUtils
{
    private static System.Diagnostics.Stopwatch timewatch;

    public static void StopWatchStart()
    {
        timewatch = new Stopwatch();
        timewatch.Start();
    }

    public static void StopWatchRecord(string recordStr)
    {
        timewatch.Stop(); //  停止监视
        TimeSpan timeSpan = timewatch.Elapsed; //  获取总时间
        timewatch.Start();
        double milliseconds = timeSpan.TotalMilliseconds;  //  毫秒数
        UnityEngine.Debug.Log("<color=#9400D3>---------------->StopWatch:" + recordStr + ":" + milliseconds + "</color>");
    }

    public static void StopWatchStop()
    {
        timewatch.Stop(); //  停止监视
        TimeSpan timeSpan = timewatch.Elapsed; //  获取总时间
        double milliseconds = timeSpan.TotalMilliseconds;  //  毫秒数
        UnityEngine.Debug.Log("StopWatch:STOP:" + milliseconds);
    }
}