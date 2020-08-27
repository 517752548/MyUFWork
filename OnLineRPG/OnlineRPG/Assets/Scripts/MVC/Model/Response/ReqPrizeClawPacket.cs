using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using UnityEngine;

public class ReqPrizeClawPacket : SerializablePacket
{
    public int code;
    public RepPrizeClawData data;
}

public class RepPrizeClawData
{
    public int machineid;
    public int id;
}
public class PrizeClawOnLineData: SerializablePacket
{
    public int code;
    public List<PrizeClawOnData> data;
}

public class PrizeClawOnData
{
    public int id;
    public int jackpotId;
    public int dCoin;
    public int dNumber;
    public int timetype;
    public int endtime;
}