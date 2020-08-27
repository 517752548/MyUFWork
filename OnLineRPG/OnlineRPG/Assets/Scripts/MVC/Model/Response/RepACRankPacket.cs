using System;
using System.Collections.Generic;
using BetaFramework;
using UnityEngine;

public class RepACRankPacket : SerializablePacket
{
    public int code;
    public int activityId;
    public int roomId;
    public bool isEnd;
    public int countdown;
    public int endTime;
    public List<RepACRankData> rankingList;

}

public class RepACRankData

{
    public string DeviceId;
    public int HeadIndex;
    public string HeadUrl;
    public int Number;
    public string UserName;
    public string RewardId;
    public int RewardNum;
    public RepACRankData()
    {

    }


}