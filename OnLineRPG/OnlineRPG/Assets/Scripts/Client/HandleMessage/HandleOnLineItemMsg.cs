using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using UnityEngine;

public class HandleOnLineItemMsg : IPacketHandler
{
    public object Data { get; set; }
    public short OpCode { get; set; }

    public Action<IIncommingMessage> callBack;
    public void Handle(IIncommingMessage message)
    {
        if(callBack != null)
            callBack.Invoke(message);
    }
}
