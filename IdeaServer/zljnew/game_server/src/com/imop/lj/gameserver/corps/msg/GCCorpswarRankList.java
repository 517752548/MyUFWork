package com.imop.lj.gameserver.corps.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 帮派竞赛排行榜
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCCorpswarRankList extends GCMessage{
	
	/** 帮派竞赛排行榜信息 */
	private com.imop.lj.common.model.corps.CorpsWarRankInfo[] cwRankInfoList;

	public GCCorpswarRankList (){
	}
	
	public GCCorpswarRankList (
			com.imop.lj.common.model.corps.CorpsWarRankInfo[] cwRankInfoList ){
			this.cwRankInfoList = cwRankInfoList;
	}

	@Override
	protected boolean readImpl() {

	// 帮派竞赛排行榜信息
	int cwRankInfoListSize = readUnsignedShort();
	com.imop.lj.common.model.corps.CorpsWarRankInfo[] _cwRankInfoList = new com.imop.lj.common.model.corps.CorpsWarRankInfo[cwRankInfoListSize];
	int cwRankInfoListIndex = 0;
	for(cwRankInfoListIndex=0; cwRankInfoListIndex<cwRankInfoListSize; cwRankInfoListIndex++){
		_cwRankInfoList[cwRankInfoListIndex] = new com.imop.lj.common.model.corps.CorpsWarRankInfo();
	// 军团id
	long _cwRankInfoList_corpsId = readLong();
	//end
	_cwRankInfoList[cwRankInfoListIndex].setCorpsId (_cwRankInfoList_corpsId);

	// 军团名称
	String _cwRankInfoList_name = readString();
	//end
	_cwRankInfoList[cwRankInfoListIndex].setName (_cwRankInfoList_name);

	// 排名
	int _cwRankInfoList_rank = readInteger();
	//end
	_cwRankInfoList[cwRankInfoListIndex].setRank (_cwRankInfoList_rank);

	// 积分
	int _cwRankInfoList_score = readInteger();
	//end
	_cwRankInfoList[cwRankInfoListIndex].setScore (_cwRankInfoList_score);
	}
	//end



		this.cwRankInfoList = _cwRankInfoList;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 帮派竞赛排行榜信息
	writeShort(cwRankInfoList.length);
	int cwRankInfoListIndex = 0;
	int cwRankInfoListSize = cwRankInfoList.length;
	for(cwRankInfoListIndex=0; cwRankInfoListIndex<cwRankInfoListSize; cwRankInfoListIndex++){

	long cwRankInfoList_corpsId = cwRankInfoList[cwRankInfoListIndex].getCorpsId();

	// 军团id
	writeLong(cwRankInfoList_corpsId);

	String cwRankInfoList_name = cwRankInfoList[cwRankInfoListIndex].getName();

	// 军团名称
	writeString(cwRankInfoList_name);

	int cwRankInfoList_rank = cwRankInfoList[cwRankInfoListIndex].getRank();

	// 排名
	writeInteger(cwRankInfoList_rank);

	int cwRankInfoList_score = cwRankInfoList[cwRankInfoListIndex].getScore();

	// 积分
	writeInteger(cwRankInfoList_score);
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_CORPSWAR_RANK_LIST;
	}
	
	@Override
	public String getTypeName() {
		return "GC_CORPSWAR_RANK_LIST";
	}

	public com.imop.lj.common.model.corps.CorpsWarRankInfo[] getCwRankInfoList(){
		return cwRankInfoList;
	}

	public void setCwRankInfoList(com.imop.lj.common.model.corps.CorpsWarRankInfo[] cwRankInfoList){
		this.cwRankInfoList = cwRankInfoList;
	}	
}