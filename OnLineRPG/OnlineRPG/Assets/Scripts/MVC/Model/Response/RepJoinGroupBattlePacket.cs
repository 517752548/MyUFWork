using BetaFramework;

public class RepJoinGroupBattlePacket : SerializablePacket
{
    public int code;
    public GroupBattleData data;
}

public class GroupBattleData
{
    public int memberId;
    public string icon;
    public int likeCount;
    public int insight;
    public bool isEnemy;
}
