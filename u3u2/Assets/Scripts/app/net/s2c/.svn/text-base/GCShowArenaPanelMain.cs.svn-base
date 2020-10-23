
using System;
namespace app.net
{
/**
 * 显示竞技场面板主要信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCShowArenaPanelMain :BaseMessage
{
	/** 当前排名 */
	private int rank;
	/** 最高排名 */
	private int rankMax;
	/** 连胜次数 */
	private int conWinTimes;
	/** 当前可以挑战次数 */
	private int challengeTimes;
	/** 可否购买挑战次数，0否，1是 */
	private int canBuyChallengeTimes;
	/** 挑战冷却时间，毫秒 */
	private int challengeCdTime;
	/** 当前能否挑战，0否，1是 */
	private int canChallenge;
	/** 购买竞技场次数消耗金票数 */
	private int buyChallengeTimesCost;
	/** 清除冷却时间消耗银票数 */
	private int killCdCost;
	/** 挑战人员列表 */
	private ArenaMemberData[] arenaChallengeList;

	public GCShowArenaPanelMain ()
	{
	}

	protected override void ReadImpl()
	{
	// 当前排名
	int _rank = ReadInt();
	// 最高排名
	int _rankMax = ReadInt();
	// 连胜次数
	int _conWinTimes = ReadInt();
	// 当前可以挑战次数
	int _challengeTimes = ReadInt();
	// 可否购买挑战次数，0否，1是
	int _canBuyChallengeTimes = ReadInt();
	// 挑战冷却时间，毫秒
	int _challengeCdTime = ReadInt();
	// 当前能否挑战，0否，1是
	int _canChallenge = ReadInt();
	// 购买竞技场次数消耗金票数
	int _buyChallengeTimesCost = ReadInt();
	// 清除冷却时间消耗银票数
	int _killCdCost = ReadInt();

	// 挑战人员列表
	int arenaChallengeListSize = ReadShort();
	ArenaMemberData[] _arenaChallengeList = new ArenaMemberData[arenaChallengeListSize];
	int arenaChallengeListIndex = 0;
	ArenaMemberData _arenaChallengeListTmp = null;
	for(arenaChallengeListIndex=0; arenaChallengeListIndex<arenaChallengeListSize; arenaChallengeListIndex++){
		_arenaChallengeListTmp = new ArenaMemberData();
		_arenaChallengeList[arenaChallengeListIndex] = _arenaChallengeListTmp;
	// 成员Id
	long _arenaChallengeList_memberId = ReadLong();	_arenaChallengeListTmp.memberId = _arenaChallengeList_memberId;
		// 排名
	int _arenaChallengeList_rank = ReadInt();	_arenaChallengeListTmp.rank = _arenaChallengeList_rank;
		// 名字
	string _arenaChallengeList_name = ReadString();	_arenaChallengeListTmp.name = _arenaChallengeList_name;
		// 等级
	int _arenaChallengeList_level = ReadInt();	_arenaChallengeListTmp.level = _arenaChallengeList_level;
		// 模板Id
	int _arenaChallengeList_tplId = ReadInt();	_arenaChallengeListTmp.tplId = _arenaChallengeList_tplId;
		// 战力
	int _arenaChallengeList_fightPower = ReadInt();	_arenaChallengeListTmp.fightPower = _arenaChallengeList_fightPower;
		// 是否自己，0否，1是
	int _arenaChallengeList_isSelf = ReadInt();	_arenaChallengeListTmp.isSelf = _arenaChallengeList_isSelf;
		// 是否机器人，0否，1是
	int _arenaChallengeList_isRobot = ReadInt();	_arenaChallengeListTmp.isRobot = _arenaChallengeList_isRobot;
		// 军团Id
	long _arenaChallengeList_corpsId = ReadLong();	_arenaChallengeListTmp.corpsId = _arenaChallengeList_corpsId;
		// 军团名字
	string _arenaChallengeList_corpsName = ReadString();	_arenaChallengeListTmp.corpsName = _arenaChallengeList_corpsName;
		}
	//end



		this.rank = _rank;
		this.rankMax = _rankMax;
		this.conWinTimes = _conWinTimes;
		this.challengeTimes = _challengeTimes;
		this.canBuyChallengeTimes = _canBuyChallengeTimes;
		this.challengeCdTime = _challengeCdTime;
		this.canChallenge = _canChallenge;
		this.buyChallengeTimesCost = _buyChallengeTimesCost;
		this.killCdCost = _killCdCost;
		this.arenaChallengeList = _arenaChallengeList;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_SHOW_ARENA_PANEL_MAIN;
	}
	
	public override string getEventType()
	{
		return ArenaGCHandler.GCShowArenaPanelMainEvent;
	}
	

	public int getRank(){
		return rank;
	}
		

	public int getRankMax(){
		return rankMax;
	}
		

	public int getConWinTimes(){
		return conWinTimes;
	}
		

	public int getChallengeTimes(){
		return challengeTimes;
	}
		

	public int getCanBuyChallengeTimes(){
		return canBuyChallengeTimes;
	}
		

	public int getChallengeCdTime(){
		return challengeCdTime;
	}
		

	public int getCanChallenge(){
		return canChallenge;
	}
		

	public int getBuyChallengeTimesCost(){
		return buyChallengeTimesCost;
	}
		

	public int getKillCdCost(){
		return killCdCost;
	}
		

	public ArenaMemberData[] getArenaChallengeList(){
		return arenaChallengeList;
	}


}
}