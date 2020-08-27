using BetaFramework;
using System.Collections.Generic;

public class RepSyncPacket : SerializablePacket
{
    public int code;

    //是否首次绑定,首次绑定fb=true，data=null
    public bool fb;
    //FB绑定设备是否达到上限
    public bool full;

    public RepSyncData data;
}

public class RepSyncData
{
    public int Coin;
    public int Hint1;
    public int Hint2;
    public int Hint3;
    public bool MultiHintUnlock;
    public Dictionary<string, int> PurchaseRecord;
    public string PlayerTag;
    public int RandomId;
    public long Register;
    public long SyncDateTime;
    public int UnLockedWorld;
    public int UnlockedSubWorld;
    public int UnlockedLevel;
    public int UserScore;
    public string DailyChallengeData;
    public string GuidData;
    public string DailySignCount;

    public int ClassicAnswerCount;
    public int BonusCount;
    public int DailyStarCount;
    public int TourneyCount;
    public int HeadIndex;
    public string UserName;
    public string CurrentUseId;
    public Dictionary<string, int> PetSystem;

    //当前绑定的deviceid
    public string DeviceId;
}