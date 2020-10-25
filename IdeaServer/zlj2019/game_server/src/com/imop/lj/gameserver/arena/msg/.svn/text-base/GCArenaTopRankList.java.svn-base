package com.imop.lj.gameserver.arena.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 显示竞技场榜首信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCArenaTopRankList extends GCMessage{
	
	/** 我的排名 */
	private int myRank;
	/** 我的军团Id */
	private long myCorpsId;
	/** 我的军团名字 */
	private String myCorpsName;
	/** 排行榜人员列表 */
	private com.imop.lj.common.model.arena.ArenaMemberInfo[] arenaTopMemberList;

	public GCArenaTopRankList (){
	}
	
	public GCArenaTopRankList (
			int myRank,
			long myCorpsId,
			String myCorpsName,
			com.imop.lj.common.model.arena.ArenaMemberInfo[] arenaTopMemberList ){
			this.myRank = myRank;
			this.myCorpsId = myCorpsId;
			this.myCorpsName = myCorpsName;
			this.arenaTopMemberList = arenaTopMemberList;
	}

	@Override
	protected boolean readImpl() {

	// 我的排名
	int _myRank = readInteger();
	//end


	// 我的军团Id
	long _myCorpsId = readLong();
	//end


	// 我的军团名字
	String _myCorpsName = readString();
	//end


	// 排行榜人员列表
	int arenaTopMemberListSize = readUnsignedShort();
	com.imop.lj.common.model.arena.ArenaMemberInfo[] _arenaTopMemberList = new com.imop.lj.common.model.arena.ArenaMemberInfo[arenaTopMemberListSize];
	int arenaTopMemberListIndex = 0;
	for(arenaTopMemberListIndex=0; arenaTopMemberListIndex<arenaTopMemberListSize; arenaTopMemberListIndex++){
		_arenaTopMemberList[arenaTopMemberListIndex] = new com.imop.lj.common.model.arena.ArenaMemberInfo();
	// 成员Id
	long _arenaTopMemberList_memberId = readLong();
	//end
	_arenaTopMemberList[arenaTopMemberListIndex].setMemberId (_arenaTopMemberList_memberId);

	// 排名
	int _arenaTopMemberList_rank = readInteger();
	//end
	_arenaTopMemberList[arenaTopMemberListIndex].setRank (_arenaTopMemberList_rank);

	// 名字
	String _arenaTopMemberList_name = readString();
	//end
	_arenaTopMemberList[arenaTopMemberListIndex].setName (_arenaTopMemberList_name);

	// 等级
	int _arenaTopMemberList_level = readInteger();
	//end
	_arenaTopMemberList[arenaTopMemberListIndex].setLevel (_arenaTopMemberList_level);

	// 模板Id
	int _arenaTopMemberList_tplId = readInteger();
	//end
	_arenaTopMemberList[arenaTopMemberListIndex].setTplId (_arenaTopMemberList_tplId);

	// 战力
	int _arenaTopMemberList_fightPower = readInteger();
	//end
	_arenaTopMemberList[arenaTopMemberListIndex].setFightPower (_arenaTopMemberList_fightPower);

	// 是否自己，0否，1是
	int _arenaTopMemberList_isSelf = readInteger();
	//end
	_arenaTopMemberList[arenaTopMemberListIndex].setIsSelf (_arenaTopMemberList_isSelf);

	// 是否机器人，0否，1是
	int _arenaTopMemberList_isRobot = readInteger();
	//end
	_arenaTopMemberList[arenaTopMemberListIndex].setIsRobot (_arenaTopMemberList_isRobot);

	// 军团Id
	long _arenaTopMemberList_corpsId = readLong();
	//end
	_arenaTopMemberList[arenaTopMemberListIndex].setCorpsId (_arenaTopMemberList_corpsId);

	// 军团名字
	String _arenaTopMemberList_corpsName = readString();
	//end
	_arenaTopMemberList[arenaTopMemberListIndex].setCorpsName (_arenaTopMemberList_corpsName);
	}
	//end



		this.myRank = _myRank;
		this.myCorpsId = _myCorpsId;
		this.myCorpsName = _myCorpsName;
		this.arenaTopMemberList = _arenaTopMemberList;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 我的排名
	writeInteger(myRank);


	// 我的军团Id
	writeLong(myCorpsId);


	// 我的军团名字
	writeString(myCorpsName);


	// 排行榜人员列表
	writeShort(arenaTopMemberList.length);
	int arenaTopMemberListIndex = 0;
	int arenaTopMemberListSize = arenaTopMemberList.length;
	for(arenaTopMemberListIndex=0; arenaTopMemberListIndex<arenaTopMemberListSize; arenaTopMemberListIndex++){

	long arenaTopMemberList_memberId = arenaTopMemberList[arenaTopMemberListIndex].getMemberId();

	// 成员Id
	writeLong(arenaTopMemberList_memberId);

	int arenaTopMemberList_rank = arenaTopMemberList[arenaTopMemberListIndex].getRank();

	// 排名
	writeInteger(arenaTopMemberList_rank);

	String arenaTopMemberList_name = arenaTopMemberList[arenaTopMemberListIndex].getName();

	// 名字
	writeString(arenaTopMemberList_name);

	int arenaTopMemberList_level = arenaTopMemberList[arenaTopMemberListIndex].getLevel();

	// 等级
	writeInteger(arenaTopMemberList_level);

	int arenaTopMemberList_tplId = arenaTopMemberList[arenaTopMemberListIndex].getTplId();

	// 模板Id
	writeInteger(arenaTopMemberList_tplId);

	int arenaTopMemberList_fightPower = arenaTopMemberList[arenaTopMemberListIndex].getFightPower();

	// 战力
	writeInteger(arenaTopMemberList_fightPower);

	int arenaTopMemberList_isSelf = arenaTopMemberList[arenaTopMemberListIndex].getIsSelf();

	// 是否自己，0否，1是
	writeInteger(arenaTopMemberList_isSelf);

	int arenaTopMemberList_isRobot = arenaTopMemberList[arenaTopMemberListIndex].getIsRobot();

	// 是否机器人，0否，1是
	writeInteger(arenaTopMemberList_isRobot);

	long arenaTopMemberList_corpsId = arenaTopMemberList[arenaTopMemberListIndex].getCorpsId();

	// 军团Id
	writeLong(arenaTopMemberList_corpsId);

	String arenaTopMemberList_corpsName = arenaTopMemberList[arenaTopMemberListIndex].getCorpsName();

	// 军团名字
	writeString(arenaTopMemberList_corpsName);
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_ARENA_TOP_RANK_LIST;
	}
	
	@Override
	public String getTypeName() {
		return "GC_ARENA_TOP_RANK_LIST";
	}

	public int getMyRank(){
		return myRank;
	}
		
	public void setMyRank(int myRank){
		this.myRank = myRank;
	}

	public long getMyCorpsId(){
		return myCorpsId;
	}
		
	public void setMyCorpsId(long myCorpsId){
		this.myCorpsId = myCorpsId;
	}

	public String getMyCorpsName(){
		return myCorpsName;
	}
		
	public void setMyCorpsName(String myCorpsName){
		this.myCorpsName = myCorpsName;
	}

	public com.imop.lj.common.model.arena.ArenaMemberInfo[] getArenaTopMemberList(){
		return arenaTopMemberList;
	}

	public void setArenaTopMemberList(com.imop.lj.common.model.arena.ArenaMemberInfo[] arenaTopMemberList){
		this.arenaTopMemberList = arenaTopMemberList;
	}	
}