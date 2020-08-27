using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using Data.Request;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Scripting;

[Preserve]
public class TimeHeart : IModule
{
    private const float HeartCd = 20f;
    private float _heartCd = 0f;
    private int ErrorTimes = 1;
    private TimeSpan fixUTCTime = TimeSpan.Zero;
    private DateTime serverTime = DateTime.UtcNow;

    public Action OnTimeUpdate;


    /// <summary>
    /// 当前时间
    /// </summary>
    public DateTime RealTime
    {
        get { return DateTime.UtcNow + fixUTCTime; }
    }

    public DateTime ServerTime
    {
        get { return serverTime; }
    }
    public long CurTimeStamp
    {
        get { return XUtils.UTCDateTimeToTimeStamp(RealTime); }
    }

    public TimeSpan SubtractTimeStamp(long timeStamp)
    {
        DateTime dt = XUtils.TimeStampToUTCDateTime(timeStamp);
        return dt.Subtract(RealTime);
    }

    public override void Init()
    {
        base.Init();
        _heartCd = 0;
        AyncTime();
    }

    public void Refresh(Action onRefresh)
    {
        if (_heartCd > 1)
        {
            _heartCd = 0;
            AyncTime(onRefresh);
        }
        else
        {
            onRefresh?.Invoke();
        }
    }

    public override void Execute(float deltaTime)
    {
        base.Execute(deltaTime);
        _heartCd += deltaTime;
        if (_heartCd >= HeartCd)
        {
            _heartCd = 0;
            AyncTime();
        }
    }

    private void AyncTime(Action callback = null)
    {
        //Debug.Log("刷新服务器时间");
        string json = JsonConvert.SerializeObject(new BaseRequestParam(ServerCode.ServerTime));
        WebRequestPostUtility.Instance.PostJson(Const.ServerUrl, (back) =>
        {
            if (back.isNetworkError || back.isHttpError)
            {
                TimeGetError(back.error);
            }
            else
            {
                ServerTime response = JsonConvert.DeserializeObject<ServerTime>(back.downloadHandler.text);
                if (response == null)
                {
                    TimeGetError("response error " + back.downloadHandler.text);
                }
                else if (response.code != 200)
                {
                    TimeGetError("error code=" + response.code);
                }
                else
                {
                    if (response.data == null)
                    {
                        TimeGetError("response data null");
                    }
                    else
                    {
                        OnSuccess(response.data);
                    }
                }
            }
            callback?.Invoke();
        }, json);
    }

    private void OnSuccess(ServerTimeInt serverTimeInt)
    {
        DateTime webTime = XUtils.TimeStampToUTCDateTime(serverTimeInt.time);
        serverTime = webTime;
        fixUTCTime = webTime - DateTime.UtcNow;
        //LoggerHelper.Log("时间获取成功:" + serverTimeInt.time + " delta=" + fixUTCTime.ToString());
        ErrorTimes = 0;
        OnTimeUpdate?.Invoke();
    }

    private void TimeGetError(string error)
    {
        ErrorTimes++;
        LoggerHelper.Error("时间获取失败:" + error);
    }

    public bool IsTimeReal => ErrorTimes == 0;
}

public class ServerTime : BaseResponseData<ServerTimeInt>
{
}

public class ServerTimeInt
{
    public long time;
}