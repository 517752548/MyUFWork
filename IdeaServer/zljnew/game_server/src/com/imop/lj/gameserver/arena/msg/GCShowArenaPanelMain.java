package com.imop.lj.gameserver.arena.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 显示竞技场面板主要信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCShowArenaPanelMain extends GCMessage{
	
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
	private com.imop.lj.common.model.arena.ArenaMemberInfo[] arenaChallengeList;

	public GCShowArenaPanelMain (){
	}
	
	public GCShowArenaPanelMain (
			int rank,
			int rankMax,
			int conWinTimes,
			int challengeTimes,
			int canBuyChallengeTimes,
			int challengeCdTime,
			int canChallenge,
			int buyChallengeTimesCost,
			int killCdCost,
			com.imop.lj.common.model.arena.ArenaMemberInfo[] arenaChallengeList ){
			this.rank = rank;
			this.rankMax = rankMax;
			this.conWinTimes = conWinTimes;
			this.challengeTimes = challengeTimes;
			this.canBuyChallengeTimes = canBuyChallengeTimes;
			this.challengeCdTime = challengeCdTime;
			this.canChallenge = canChallenge;
			this.buyChallengeTimesCost = buyChallengeTimesCost;
			this.killCdCost = killCdCost;
			this.arenaChallengeList = arenaChallengeList;
	}

	@Override
	protected boolean readImpl() {

	// 当前排名
	int _rank = readInteger();
	//end


	// 最高排名
	int _rankMax = readInteger();
	//end


	// 连胜次数
	int _conWinTimes = readInteger();
	//end


	// 当前可以挑战次数
	int _challengeTimes = readInteger();
	//end


	// 可否购买挑战次数，0否，1是
	int _canBuyChallengeTimes = readInteger();
	//end


	// 挑战冷却时间，毫秒
	int _challengeCdTime = readInteger();
	//end


	// 当前能否挑战，0否，1是
	int _canChallenge = readInteger();
	//end


	// 购买竞技场次数消耗金票数
	int _buyChallengeTimesCost = readInteger();
	//end


	// 清除冷却时间消耗银票数
	int _killCdCost = readInteger();
	//end


	// 挑战人员列表
	int arenaChallengeListSize = readUnsignedShort();
	com.imop.lj.common.model.arena.ArenaMemberInfo[] _arenaChallengeList = new com.imop.lj.common.model.arena.ArenaMemberInfo[arenaChallengeListSize];
	int arenaChallengeListIndex = 0;
	for(arenaChallengeListIndex=0; arenaChallengeListIndex<arenaChallengeListSize; arenaChallengeListIndex++){
		_arenaChallengeList[arenaChallengeListIndex] = new com.imop.lj.common.model.arena.ArenaMemberInfo();
	// 成员Id
	long _arenaChallengeList_memberId = readLong();
	//end
	_arenaChallengeList[arenaChallengeListIndex].setMemberId (_arenaChallengeList_memberId);

	// 排名
	int _arenaChallengeList_rank = readInteger();
	//end
	_arenaChallengeList[arenaChallengeListIndex].setRank (_arenaChallengeList_rank);

	// 名字
	String _arenaChallengeList_name = readString();
	//end
	_arenaChallengeList[arenaChallengeListIndex].setName (_arenaChallengeList_name);

	// 等级
	int _arenaChallengeList_level = readInteger();
	//end
	_arenaChallengeList[arenaChallengeListIndex].setLevel (_arenaChallengeList_level);

	// 模板Id
	int _arenaChallengeList_tplId = readInteger();
	//end
	_arenaChallengeList[arenaChallengeListIndex].setTplId (_arenaChallengeList_tplId);

	// 战力
	int _arenaChallengeList_fightPower = readInteger();
	//end
	_arenaChallengeList[arenaChallengeListIndex].setFightPower (_arenaChallengeList_fightPower);

	// 是否自己，0否，1是
	int _arenaChallengeList_isSelf = readInteger();
	//end
	_arenaChallengeList[arenaChallengeListIndex].setIsSelf (_arenaChallengeList_isSelf);

	// 是否机器人，0否，1是
	int _arenaChallengeList_isRobot = readInteger();
	//end
	_arenaChallengeList[arenaChallengeListIndex].setIsRobot (_arenaChallengeList_isRobot);

	// 军团Id
	long _arenaChallengeList_corpsId = readLong();
	//end
	_arenaChallengeList[arenaChallengeListIndex].setCorpsId (_arenaChallengeList_corpsId);

	// 军团名字
	String _arenaChallengeList_corpsName = readString();
	//end
	_arenaChallengeList[arenaChallengeListIndex].setCorpsName (_arenaChallengeList_corpsName);
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
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 当前排名
	writeInteger(rank);


	// 最高排名
	writeInteger(rankMax);


	// 连胜次数
	writeInteger(conWinTimes);


	// 当前可以挑战次数
	writeInteger(challengeTimes);


	// 可否购买挑战次数，0否，1是
	writeInteger(canBuyChallengeTimes);


	// 挑战冷却时间，毫秒
	writeInteger(challengeCdTime);


	// 当前能否挑战，0否，1是
	writeInteger(canChallenge);


	// 购买竞技场次数消耗金票数
	writeInteger(buyChallengeTimesCost);


	// 清除冷却时间消耗银票数
	writeInteger(killCdCost);


	// 挑战人员列表
	writeShort(arenaChallengeList.length);
	int arenaChallengeListIndex = 0;
	int arenaChallengeListSize = arenaChallengeList.length;
	for(arenaChallengeListIndex=0; arenaChallengeListIndex<arenaChallengeListSize; arenaChallengeListIndex++){

	long arenaChallengeList_memberId = arenaChallengeList[arenaChallengeListIndex].getMemberId();

	// 成员Id
	writeLong(arenaChallengeList_memberId);

	int arenaChallengeList_rank = arenaChallengeList[arenaChallengeListIndex].getRank();

	// 排名
	writeInteger(arenaChallengeList_rank);

	String arenaChallengeList_name = arenaChallengeList[arenaChallengeListIndex].getName();

	// 名字
	writeString(arenaChallengeList_name);

	int arenaChallengeList_level = arenaChallengeList[arenaChallengeListIndex].getLevel();

	// 等级
	writeInteger(arenaChallengeList_level);

	int arenaChallengeList_tplId = arenaChallengeList[arenaChallengeListIndex].getTplId();

	// 模板Id
	writeInteger(arenaChallengeList_tplId);

	int arenaChallengeList_fightPower = arenaChallengeList[arenaChallengeListIndex].getFightPower();

	// 战力
	writeInteger(arenaChallengeList_fightPower);

	int arenaChallengeList_isSelf = arenaChallengeList[arenaChallengeListIndex].getIsSelf();

	// 是否自己，0否，1是
	writeInteger(arenaChallengeList_isSelf);

	int arenaChallengeList_isRobot = arenaChallengeList[arenaChallengeListIndex].getIsRobot();

	// 是否机器人，0否，1是
	writeInteger(arenaChallengeList_isRobot);

	long arenaChallengeList_corpsId = arenaChallengeList[arenaChallengeListIndex].getCorpsId();

	// 军团Id
	writeLong(arenaChallengeList_corpsId);

	String arenaChallengeList_corpsName = arenaChallengeList[arenaChallengeListIndex].getCorpsName();

	// 军团名字
	writeString(arenaChallengeList_corpsName);
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_SHOW_ARENA_PANEL_MAIN;
	}
	
	@Override
	public String getTypeName() {
		return "GC_SHOW_ARENA_PANEL_MAIN";
	}

	public int getRank(){
		return rank;
	}
		
	public void setRank(int rank){
		this.rank = rank;
	}

	public int getRankMax(){
		return rankMax;
	}
		
	public void setRankMax(int rankMax){
		this.rankMax = rankMax;
	}

	public int getConWinTimes(){
		return conWinTimes;
	}
		
	public void setConWinTimes(int conWinTimes){
		this.conWinTimes = conWinTimes;
	}

	public int getChallengeTimes(){
		return challengeTimes;
	}
		
	public void setChallengeTimes(int challengeTimes){
		this.challengeTimes = challengeTimes;
	}

	public int getCanBuyChallengeTimes(){
		return canBuyChallengeTimes;
	}
		
	public void setCanBuyChallengeTimes(int canBuyChallengeTimes){
		this.canBuyChallengeTimes = canBuyChallengeTimes;
	}

	public int getChallengeCdTime(){
		return challengeCdTime;
	}
		
	public void setChallengeCdTime(int challengeCdTime){
		this.challengeCdTime = challengeCdTime;
	}

	public int getCanChallenge(){
		return canChallenge;
	}
		
	public void setCanChallenge(int canChallenge){
		this.canChallenge = canChallenge;
	}

	public int getBuyChallengeTimesCost(){
		return buyChallengeTimesCost;
	}
		
	public void setBuyChallengeTimesCost(int buyChallengeTimesCost){
		this.buyChallengeTimesCost = buyChallengeTimesCost;
	}

	public int getKillCdCost(){
		return killCdCost;
	}
		
	public void setKillCdCost(int killCdCost){
		this.killCdCost = killCdCost;
	}

	public com.imop.lj.common.model.arena.ArenaMemberInfo[] getArenaChallengeList(){
		return arenaChallengeList;
	}

	public void setArenaChallengeList(com.imop.lj.common.model.arena.ArenaMemberInfo[] arenaChallengeList){
		this.arenaChallengeList = arenaChallengeList;
	}	
}