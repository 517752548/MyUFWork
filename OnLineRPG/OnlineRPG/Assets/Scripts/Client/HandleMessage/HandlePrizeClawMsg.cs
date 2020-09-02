using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using UnityEngine;
using EventUtil;

public class HandlePrizeClawMsg :  IPacketHandler
{
    public short OpCode { get; set; }
    public int ApiType;
    public Action<bool,string> callBack;
    public Action<bool, PrizeClawOnLineData> callBackData;
    public void Handle(IIncommingMessage message)
    {
        LoggerHelper.Log(message.ToString());
        BetaFramework.LoggerHelper.Log("娃娃机:" + message.ToString());
        if (ApiType == 1)
        {
            var data = message.Deserialize<ReqPrizeClawPacket>();
            if (data.code == (int) RepCodes.SUCCESSED)
            {
                if (callBack != null)
                {
                    callBack.Invoke(true,data.data.id.ToString());
                }
            }
            else
            {
                if (callBack != null)
                {
                    callBack.Invoke(false,"");
                }
                EventDispatcher.TriggerEvent(GlobalEvents.PrizeClawRoll, true);
            }
        }
        else
        {
            var data = message.Deserialize<PrizeClawOnLineData>();
            
            if (data.code == (int) RepCodes.SUCCESSED)
            {
                if (callBackData != null)
                {
                    callBackData.Invoke(true,data);
                }
            }
            else
            {
                if (callBackData != null)
                {
                    callBackData.Invoke(false,null);
                }
            }
        }
        
    }
}
