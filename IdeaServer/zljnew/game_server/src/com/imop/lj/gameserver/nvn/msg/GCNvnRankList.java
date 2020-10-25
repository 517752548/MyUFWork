package com.imop.lj.gameserver.nvn.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * nvn联赛排行榜
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCNvnRankList extends GCMessage{
	
	/** 我的排名 */
	private int myRank;
	/** 我的积分 */
	private int myScore;
	/** 我的连胜数 */
	private int myConWinNum;
	/** nvn联赛排行榜信息 */
	private com.imop.lj.common.model.nvn.NvnRankInfo[] nvnRankInfoList;

	public GCNvnRankList (){
	}
	
	public GCNvnRankList (
			int myRank,
			int myScore,
			int myConWinNum,
			com.imop.lj.common.model.nvn.NvnRankInfo[] nvnRankInfoList ){
			this.myRank = myRank;
			this.myScore = myScore;
			this.myConWinNum = myConWinNum;
			this.nvnRankInfoList = nvnRankInfoList;
	}

	@Override
	protected boolean readImpl() {

	// 我的排名
	int _myRank = readInteger();
	//end


	// 我的积分
	int _myScore = readInteger();
	//end


	// 我的连胜数
	int _myConWinNum = readInteger();
	//end


	// nvn联赛排行榜信息
	int nvnRankInfoListSize = readUnsignedShort();
	com.imop.lj.common.model.nvn.NvnRankInfo[] _nvnRankInfoList = new com.imop.lj.common.model.nvn.NvnRankInfo[nvnRankInfoListSize];
	int nvnRankInfoListIndex = 0;
	for(nvnRankInfoListIndex=0; nvnRankInfoListIndex<nvnRankInfoListSize; nvnRankInfoListIndex++){
		_nvnRankInfoList[nvnRankInfoListIndex] = new com.imop.lj.common.model.nvn.NvnRankInfo();
	// 玩家id
	long _nvnRankInfoList_roleId = readLong();
	//end
	_nvnRankInfoList[nvnRankInfoListIndex].setRoleId (_nvnRankInfoList_roleId);

	// 玩家模板id
	int _nvnRankInfoList_tplId = readInteger();
	//end
	_nvnRankInfoList[nvnRankInfoListIndex].setTplId (_nvnRankInfoList_tplId);

	// 玩家名称
	String _nvnRankInfoList_name = readString();
	//end
	_nvnRankInfoList[nvnRankInfoListIndex].setName (_nvnRankInfoList_name);

	// 排名
	int _nvnRankInfoList_rank = readInteger();
	//end
	_nvnRankInfoList[nvnRankInfoListIndex].setRank (_nvnRankInfoList_rank);

	// 积分
	int _nvnRankInfoList_score = readInteger();
	//end
	_nvnRankInfoList[nvnRankInfoListIndex].setScore (_nvnRankInfoList_score);

	// 连胜数
	int _nvnRankInfoList_conWinNum = readInteger();
	//end
	_nvnRankInfoList[nvnRankInfoListIndex].setConWinNum (_nvnRankInfoList_conWinNum);
	}
	//end



		this.myRank = _myRank;
		this.myScore = _myScore;
		this.myConWinNum = _myConWinNum;
		this.nvnRankInfoList = _nvnRankInfoList;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 我的排名
	writeInteger(myRank);


	// 我的积分
	writeInteger(myScore);


	// 我的连胜数
	writeInteger(myConWinNum);


	// nvn联赛排行榜信息
	writeShort(nvnRankInfoList.length);
	int nvnRankInfoListIndex = 0;
	int nvnRankInfoListSize = nvnRankInfoList.length;
	for(nvnRankInfoListIndex=0; nvnRankInfoListIndex<nvnRankInfoListSize; nvnRankInfoListIndex++){

	long nvnRankInfoList_roleId = nvnRankInfoList[nvnRankInfoListIndex].getRoleId();

	// 玩家id
	writeLong(nvnRankInfoList_roleId);

	int nvnRankInfoList_tplId = nvnRankInfoList[nvnRankInfoListIndex].getTplId();

	// 玩家模板id
	writeInteger(nvnRankInfoList_tplId);

	String nvnRankInfoList_name = nvnRankInfoList[nvnRankInfoListIndex].getName();

	// 玩家名称
	writeString(nvnRankInfoList_name);

	int nvnRankInfoList_rank = nvnRankInfoList[nvnRankInfoListIndex].getRank();

	// 排名
	writeInteger(nvnRankInfoList_rank);

	int nvnRankInfoList_score = nvnRankInfoList[nvnRankInfoListIndex].getScore();

	// 积分
	writeInteger(nvnRankInfoList_score);

	int nvnRankInfoList_conWinNum = nvnRankInfoList[nvnRankInfoListIndex].getConWinNum();

	// 连胜数
	writeInteger(nvnRankInfoList_conWinNum);
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_NVN_RANK_LIST;
	}
	
	@Override
	public String getTypeName() {
		return "GC_NVN_RANK_LIST";
	}

	public int getMyRank(){
		return myRank;
	}
		
	public void setMyRank(int myRank){
		this.myRank = myRank;
	}

	public int getMyScore(){
		return myScore;
	}
		
	public void setMyScore(int myScore){
		this.myScore = myScore;
	}

	public int getMyConWinNum(){
		return myConWinNum;
	}
		
	public void setMyConWinNum(int myConWinNum){
		this.myConWinNum = myConWinNum;
	}

	public com.imop.lj.common.model.nvn.NvnRankInfo[] getNvnRankInfoList(){
		return nvnRankInfoList;
	}

	public void setNvnRankInfoList(com.imop.lj.common.model.nvn.NvnRankInfo[] nvnRankInfoList){
		this.nvnRankInfoList = nvnRankInfoList;
	}	
}