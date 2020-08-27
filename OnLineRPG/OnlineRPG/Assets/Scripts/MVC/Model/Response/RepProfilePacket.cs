using UnityEngine;
using System.Collections;
using BetaFramework;

public class RepProfilePacket : SerializablePacket
{
    public int code;
    public PlayerProfileData data;
}

public class PlayerProfileData
{
    public int HeadIndex;
    public string FbHeadUrl;
    public string Name;
    public bool IsMale;//性别 待定
    //TODO 收集的小人
    public int OwnPetCount;
    public int TotalPetCount;
    public string[] OwnedPet;

    public int changeNameTimes = 1;
    public string frameId;
    public int userLevel;
    public int curExp;
    public int targetExp;
    public int petCount, bgCount, diskCount, frameCount;
    public int petTotalCount, bgTotalCount, diskTotalCount, frameTotalCount;
    
    public int Score;
    public int ClassicLevel;
    public int AnswerWordCount;
    public int BonusWordCount;
    public int DailyChallengeStar;
    public int TourneyCount;
}
