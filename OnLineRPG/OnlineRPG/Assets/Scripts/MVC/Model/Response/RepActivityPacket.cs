using System;
using System.Collections.Generic;
using BetaFramework;
using UnityEngine;

public class RepActivityPacket : SerializablePacket
{
    public int code;
    public RepActivityData config;
}

public class RepActivityData
{

    public int ActivityId;
    public bool IsStart;
    public int EndTime;
    public Dictionary<string,RepActivityReward> Info = new Dictionary<string, RepActivityReward>();
    public RepActivityData()
    {
        ActivityId = 0;
        IsStart = false;
        EndTime = -1;
//        info.Add("step1",new RepActivityReward(){Reward_Goal = 20,RewardId = 10002,Reward_Num = 1,xPoint = 10});
//        info.Add("step2",new RepActivityReward(){Reward_Goal = 80,RewardId = 10002,Reward_Num = 1,xPoint = 60});
//        info.Add("step3",new RepActivityReward(){Reward_Goal = 200,RewardId = 10002,Reward_Num = 1,xPoint = 90});
    }


}

public class RepActivityReward
{
    public int Reward_Goal;
    public int RewardId;
    public int xPoint;

    public RepActivityReward()
    {
        
    }
}