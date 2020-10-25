package com.imop.lj.gameserver.rank.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 申请排行榜信息结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCRankApply extends GCMessage{
	
	/** 申请的排行榜信息类型(1等级排行,2战力排行,3宠物评分排行,4职业战力排行) */
	private int rankType;
	/** 申请对应排行榜信息的时间戳 */
	private long timeId;
	/** 排行榜信息 */
	private com.imop.lj.gameserver.rank.RankInfo[] rankInfoList;

	public GCRankApply (){
	}
	
	public GCRankApply (
			int rankType,
			long timeId,
			com.imop.lj.gameserver.rank.RankInfo[] rankInfoList ){
			this.rankType = rankType;
			this.timeId = timeId;
			this.rankInfoList = rankInfoList;
	}

	@Override
	protected boolean readImpl() {

	// 申请的排行榜信息类型(1等级排行,2战力排行,3宠物评分排行,4职业战力排行)
	int _rankType = readInteger();
	//end


	// 申请对应排行榜信息的时间戳
	long _timeId = readLong();
	//end


	// 排行榜信息
	int rankInfoListSize = readUnsignedShort();
	com.imop.lj.gameserver.rank.RankInfo[] _rankInfoList = new com.imop.lj.gameserver.rank.RankInfo[rankInfoListSize];
	int rankInfoListIndex = 0;
	for(rankInfoListIndex=0; rankInfoListIndex<rankInfoListSize; rankInfoListIndex++){
		_rankInfoList[rankInfoListIndex] = new com.imop.lj.gameserver.rank.RankInfo();
	// 排名
	int _rankInfoList_rank = readInteger();
	//end
	_rankInfoList[rankInfoListIndex].setRank (_rankInfoList_rank);

	// 玩家姓名
	String _rankInfoList_humanName = readString();
	//end
	_rankInfoList[rankInfoListIndex].setHumanName (_rankInfoList_humanName);

	// 宠物姓名
	String _rankInfoList_petName = readString();
	//end
	_rankInfoList[rankInfoListIndex].setPetName (_rankInfoList_petName);

	// 所属帮派
	String _rankInfoList_corpsName = readString();
	//end
	_rankInfoList[rankInfoListIndex].setCorpsName (_rankInfoList_corpsName);

	// 级别
	int _rankInfoList_level = readInteger();
	//end
	_rankInfoList[rankInfoListIndex].setLevel (_rankInfoList_level);

	// 玩家职业
	int _rankInfoList_humanJob = readInteger();
	//end
	_rankInfoList[rankInfoListIndex].setHumanJob (_rankInfoList_humanJob);

	// 战力
	int _rankInfoList_fightPower = readInteger();
	//end
	_rankInfoList[rankInfoListIndex].setFightPower (_rankInfoList_fightPower);

	// 评分
	int _rankInfoList_score = readInteger();
	//end
	_rankInfoList[rankInfoListIndex].setScore (_rankInfoList_score);

	// 玩家ID
	long _rankInfoList_humanId = readLong();
	//end
	_rankInfoList[rankInfoListIndex].setHumanId (_rankInfoList_humanId);

	// 宠物ID
	long _rankInfoList_petId = readLong();
	//end
	_rankInfoList[rankInfoListIndex].setPetId (_rankInfoList_petId);
	}
	//end



		this.rankType = _rankType;
		this.timeId = _timeId;
		this.rankInfoList = _rankInfoList;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 申请的排行榜信息类型(1等级排行,2战力排行,3宠物评分排行,4职业战力排行)
	writeInteger(rankType);


	// 申请对应排行榜信息的时间戳
	writeLong(timeId);


	// 排行榜信息
	writeShort(rankInfoList.length);
	int rankInfoListIndex = 0;
	int rankInfoListSize = rankInfoList.length;
	for(rankInfoListIndex=0; rankInfoListIndex<rankInfoListSize; rankInfoListIndex++){

	int rankInfoList_rank = rankInfoList[rankInfoListIndex].getRank();

	// 排名
	writeInteger(rankInfoList_rank);

	String rankInfoList_humanName = rankInfoList[rankInfoListIndex].getHumanName();

	// 玩家姓名
	writeString(rankInfoList_humanName);

	String rankInfoList_petName = rankInfoList[rankInfoListIndex].getPetName();

	// 宠物姓名
	writeString(rankInfoList_petName);

	String rankInfoList_corpsName = rankInfoList[rankInfoListIndex].getCorpsName();

	// 所属帮派
	writeString(rankInfoList_corpsName);

	int rankInfoList_level = rankInfoList[rankInfoListIndex].getLevel();

	// 级别
	writeInteger(rankInfoList_level);

	int rankInfoList_humanJob = rankInfoList[rankInfoListIndex].getHumanJob();

	// 玩家职业
	writeInteger(rankInfoList_humanJob);

	int rankInfoList_fightPower = rankInfoList[rankInfoListIndex].getFightPower();

	// 战力
	writeInteger(rankInfoList_fightPower);

	int rankInfoList_score = rankInfoList[rankInfoListIndex].getScore();

	// 评分
	writeInteger(rankInfoList_score);

	long rankInfoList_humanId = rankInfoList[rankInfoListIndex].getHumanId();

	// 玩家ID
	writeLong(rankInfoList_humanId);

	long rankInfoList_petId = rankInfoList[rankInfoListIndex].getPetId();

	// 宠物ID
	writeLong(rankInfoList_petId);
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_RANK_APPLY;
	}
	
	@Override
	public String getTypeName() {
		return "GC_RANK_APPLY";
	}

	public int getRankType(){
		return rankType;
	}
		
	public void setRankType(int rankType){
		this.rankType = rankType;
	}

	public long getTimeId(){
		return timeId;
	}
		
	public void setTimeId(long timeId){
		this.timeId = timeId;
	}

	public com.imop.lj.gameserver.rank.RankInfo[] getRankInfoList(){
		return rankInfoList;
	}

	public void setRankInfoList(com.imop.lj.gameserver.rank.RankInfo[] rankInfoList){
		this.rankInfoList = rankInfoList;
	}	
}