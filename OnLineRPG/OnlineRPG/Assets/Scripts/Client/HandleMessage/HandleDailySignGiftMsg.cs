using BetaFramework;
using System;
using UnityEngine;

public class HandleDailySignGiftMsg : IPacketHandler {
public short OpCode { get; set; }
public void Handle(IIncommingMessage message)
    {
       var data = message.Deserialize<RepDailySignGiftPacket>();
       Debug.LogError("每日三选一：" + message.ToString());
    }
}

public class HandleClamDailySignMsg : IPacketHandler {
public short OpCode { get; set; }
public void Handle(IIncommingMessage message)
    {
        var data = message.Deserialize<RepClamDailySignGiftPacket>();
        Debug.LogError("每日三选一1：" + message.ToString());
        if (data.code == (int)RepCodes.SUCCESSED)
        {
            DataManager.DailySignGiftData = null;
        }
       
    }
}
