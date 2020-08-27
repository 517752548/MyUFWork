using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventConfigData
{
    public int ConfigVersion;
    public int ActivityType;
    public int ActivityGroup;
    public int ActivityId;
    public int TimeType;
    public long StartTime, EndTime, StopEnterTime;
    
    public int Priority;
    public int ShowHome;
    public int Settlement;
    public string EnterResName;
    public string HomeEnterResName;
    public JObject Config;

    public object ConfigObj { get; set; }
    public T GetConfig<T>()
    {
        return (T)ConfigObj;
    }
}


public class CommReward
{
    public int ItemId;
    public int ItemType;
    public int Number;
}

public class DailyChallengeTarget : CommReward
{
    public int Target;
    public int MasterId;
}

public class DailyChallenge
{
    public int StartLevel;
    public int StarCount;
    public List<int> StarCondation;
    public CommReward LevelReward;
    public string UnknownPetResName;
    public List<DailyChallengeTarget> TargetList;
}

public class TournameyConfig
{
    public int CurDanCups;//当前cup数量
    public TournameyDan CurDan;//当前段位
    public List<TournameySubEvent> ActivityList;//子活动列表
    public List<TournameyReward> RewardList;//奖励列表
}

public class TournameyDan
{
    public int ID;
    public int DanGrading;//段位等级
    public int Target;//升级需要cup数量
    public string Title;
    public List<CommReward> RewardList;
    public string LogoResName;
    public string BgResName;
    public string Color1;
    public string Color2;
}

public class TournameySubEvent
{
    public string ActivityId;
    public int Priority;
    public int PlayMode;　//玩法ID
    public List<int> PlayModeConfig;　//玩法中的数值配置
    public int TimeType; //时间类型 0未开始 1进行中 -1已结束
    public long StartTime;
    public long EndTime;
    public long StopEnterTime;//禁止加入时间
    public int Ticket; //门票消耗 -1 代表此活动不能用门票
    public int Coin; //金币消耗 -1 代表此活动不能用金币
    public int FreeCount; //免费次数
    public int LevelLibId;　//关卡库id
    public string EnterResName; //入口prefab资源名称
    public string LogoResName; //结算时玩法logo资源名称
}

public class TournameyReward
{
    public int Type;
    public long Id;
    public int RoomId;
    public List<CommReward> RewardList;
}

public class TournameySubRankData
{
    public int Rank;
    public int RankPercent;
    public EventPlayer PlayerInfo;
    public List<CommReward> RewardList;
}

public class EventPlayer
{
    public string DeviceId;
    public string UserHeadUrl;
    public int UserLevel;
    public string UserName;
    public int Score;
    public int UserHeadFrameId;
    public int BackgroundId;
    public int MasterId;
    public int WordDiskId;
}
