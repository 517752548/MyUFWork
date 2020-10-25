package com.imop.lj.gameserver.corpsboss.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 帮派boss挑战次数排行榜
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCCorpsbossCountRankList extends GCMessage{
	
	/** 本帮派boss挑战次数排行榜信息 */
	private com.imop.lj.common.model.corps.CorpsBossCountRankInfo cbCountRankInfo;
	/** 所有帮派boss挑战次数排行榜信息 */
	private com.imop.lj.common.model.corps.CorpsBossCountRankInfo[] cbCountRankInfoList;

	public GCCorpsbossCountRankList (){
	}
	
	public GCCorpsbossCountRankList (
			com.imop.lj.common.model.corps.CorpsBossCountRankInfo cbCountRankInfo,
			com.imop.lj.common.model.corps.CorpsBossCountRankInfo[] cbCountRankInfoList ){
			this.cbCountRankInfo = cbCountRankInfo;
			this.cbCountRankInfoList = cbCountRankInfoList;
	}

	@Override
	protected boolean readImpl() {
	// 本帮派boss挑战次数排行榜信息
	com.imop.lj.common.model.corps.CorpsBossCountRankInfo _cbCountRankInfo = new com.imop.lj.common.model.corps.CorpsBossCountRankInfo();

	// 军团id
	long _cbCountRankInfo_corpsId = readLong();
	//end
	_cbCountRankInfo.setCorpsId (_cbCountRankInfo_corpsId);

	// 军团名称
	String _cbCountRankInfo_name = readString();
	//end
	_cbCountRankInfo.setName (_cbCountRankInfo_name);

	// 排名
	int _cbCountRankInfo_rank = readInteger();
	//end
	_cbCountRankInfo.setRank (_cbCountRankInfo_rank);

	// 排名
	int _cbCountRankInfo_count = readInteger();
	//end
	_cbCountRankInfo.setCount (_cbCountRankInfo_count);

	// 帮主名字
	String _cbCountRankInfo_presidentName = readString();
	//end
	_cbCountRankInfo.setPresidentName (_cbCountRankInfo_presidentName);

	// 当前成员数量
	int _cbCountRankInfo_curMemberCount = readInteger();
	//end
	_cbCountRankInfo.setCurMemberCount (_cbCountRankInfo_curMemberCount);

	// 最大成员数量
	int _cbCountRankInfo_maxMemberCount = readInteger();
	//end
	_cbCountRankInfo.setMaxMemberCount (_cbCountRankInfo_maxMemberCount);


	// 所有帮派boss挑战次数排行榜信息
	int cbCountRankInfoListSize = readUnsignedShort();
	com.imop.lj.common.model.corps.CorpsBossCountRankInfo[] _cbCountRankInfoList = new com.imop.lj.common.model.corps.CorpsBossCountRankInfo[cbCountRankInfoListSize];
	int cbCountRankInfoListIndex = 0;
	for(cbCountRankInfoListIndex=0; cbCountRankInfoListIndex<cbCountRankInfoListSize; cbCountRankInfoListIndex++){
		_cbCountRankInfoList[cbCountRankInfoListIndex] = new com.imop.lj.common.model.corps.CorpsBossCountRankInfo();
	// 军团id
	long _cbCountRankInfoList_corpsId = readLong();
	//end
	_cbCountRankInfoList[cbCountRankInfoListIndex].setCorpsId (_cbCountRankInfoList_corpsId);

	// 军团名称
	String _cbCountRankInfoList_name = readString();
	//end
	_cbCountRankInfoList[cbCountRankInfoListIndex].setName (_cbCountRankInfoList_name);

	// 排名
	int _cbCountRankInfoList_rank = readInteger();
	//end
	_cbCountRankInfoList[cbCountRankInfoListIndex].setRank (_cbCountRankInfoList_rank);

	// 排名
	int _cbCountRankInfoList_count = readInteger();
	//end
	_cbCountRankInfoList[cbCountRankInfoListIndex].setCount (_cbCountRankInfoList_count);

	// 帮主名字
	String _cbCountRankInfoList_presidentName = readString();
	//end
	_cbCountRankInfoList[cbCountRankInfoListIndex].setPresidentName (_cbCountRankInfoList_presidentName);

	// 当前成员数量
	int _cbCountRankInfoList_curMemberCount = readInteger();
	//end
	_cbCountRankInfoList[cbCountRankInfoListIndex].setCurMemberCount (_cbCountRankInfoList_curMemberCount);

	// 最大成员数量
	int _cbCountRankInfoList_maxMemberCount = readInteger();
	//end
	_cbCountRankInfoList[cbCountRankInfoListIndex].setMaxMemberCount (_cbCountRankInfoList_maxMemberCount);
	}
	//end



		this.cbCountRankInfo = _cbCountRankInfo;
		this.cbCountRankInfoList = _cbCountRankInfoList;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	long cbCountRankInfo_corpsId = cbCountRankInfo.getCorpsId ();

	// 军团id
	writeLong(cbCountRankInfo_corpsId);

	String cbCountRankInfo_name = cbCountRankInfo.getName ();

	// 军团名称
	writeString(cbCountRankInfo_name);

	int cbCountRankInfo_rank = cbCountRankInfo.getRank ();

	// 排名
	writeInteger(cbCountRankInfo_rank);

	int cbCountRankInfo_count = cbCountRankInfo.getCount ();

	// 排名
	writeInteger(cbCountRankInfo_count);

	String cbCountRankInfo_presidentName = cbCountRankInfo.getPresidentName ();

	// 帮主名字
	writeString(cbCountRankInfo_presidentName);

	int cbCountRankInfo_curMemberCount = cbCountRankInfo.getCurMemberCount ();

	// 当前成员数量
	writeInteger(cbCountRankInfo_curMemberCount);

	int cbCountRankInfo_maxMemberCount = cbCountRankInfo.getMaxMemberCount ();

	// 最大成员数量
	writeInteger(cbCountRankInfo_maxMemberCount);


	// 所有帮派boss挑战次数排行榜信息
	writeShort(cbCountRankInfoList.length);
	int cbCountRankInfoListIndex = 0;
	int cbCountRankInfoListSize = cbCountRankInfoList.length;
	for(cbCountRankInfoListIndex=0; cbCountRankInfoListIndex<cbCountRankInfoListSize; cbCountRankInfoListIndex++){

	long cbCountRankInfoList_corpsId = cbCountRankInfoList[cbCountRankInfoListIndex].getCorpsId();

	// 军团id
	writeLong(cbCountRankInfoList_corpsId);

	String cbCountRankInfoList_name = cbCountRankInfoList[cbCountRankInfoListIndex].getName();

	// 军团名称
	writeString(cbCountRankInfoList_name);

	int cbCountRankInfoList_rank = cbCountRankInfoList[cbCountRankInfoListIndex].getRank();

	// 排名
	writeInteger(cbCountRankInfoList_rank);

	int cbCountRankInfoList_count = cbCountRankInfoList[cbCountRankInfoListIndex].getCount();

	// 排名
	writeInteger(cbCountRankInfoList_count);

	String cbCountRankInfoList_presidentName = cbCountRankInfoList[cbCountRankInfoListIndex].getPresidentName();

	// 帮主名字
	writeString(cbCountRankInfoList_presidentName);

	int cbCountRankInfoList_curMemberCount = cbCountRankInfoList[cbCountRankInfoListIndex].getCurMemberCount();

	// 当前成员数量
	writeInteger(cbCountRankInfoList_curMemberCount);

	int cbCountRankInfoList_maxMemberCount = cbCountRankInfoList[cbCountRankInfoListIndex].getMaxMemberCount();

	// 最大成员数量
	writeInteger(cbCountRankInfoList_maxMemberCount);
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_CORPSBOSS_COUNT_RANK_LIST;
	}
	
	@Override
	public String getTypeName() {
		return "GC_CORPSBOSS_COUNT_RANK_LIST";
	}

	public com.imop.lj.common.model.corps.CorpsBossCountRankInfo getCbCountRankInfo(){
		return cbCountRankInfo;
	}
		
	public void setCbCountRankInfo(com.imop.lj.common.model.corps.CorpsBossCountRankInfo cbCountRankInfo){
		this.cbCountRankInfo = cbCountRankInfo;
	}

	public com.imop.lj.common.model.corps.CorpsBossCountRankInfo[] getCbCountRankInfoList(){
		return cbCountRankInfoList;
	}

	public void setCbCountRankInfoList(com.imop.lj.common.model.corps.CorpsBossCountRankInfo[] cbCountRankInfoList){
		this.cbCountRankInfoList = cbCountRankInfoList;
	}	
}