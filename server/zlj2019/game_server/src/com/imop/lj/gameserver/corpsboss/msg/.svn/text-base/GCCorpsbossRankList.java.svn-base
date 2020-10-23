package com.imop.lj.gameserver.corpsboss.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 帮派boss排行榜
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCCorpsbossRankList extends GCMessage{
	
	/** 本帮派boss排行榜信息 */
	private com.imop.lj.common.model.corps.CorpsBossRankInfo cbRankInfo;
	/** 所有帮派boss排行榜信息 */
	private com.imop.lj.common.model.corps.CorpsBossRankInfo[] cbRankInfoList;

	public GCCorpsbossRankList (){
	}
	
	public GCCorpsbossRankList (
			com.imop.lj.common.model.corps.CorpsBossRankInfo cbRankInfo,
			com.imop.lj.common.model.corps.CorpsBossRankInfo[] cbRankInfoList ){
			this.cbRankInfo = cbRankInfo;
			this.cbRankInfoList = cbRankInfoList;
	}

	@Override
	protected boolean readImpl() {
	// 本帮派boss排行榜信息
	com.imop.lj.common.model.corps.CorpsBossRankInfo _cbRankInfo = new com.imop.lj.common.model.corps.CorpsBossRankInfo();

	// 军团id
	long _cbRankInfo_corpsId = readLong();
	//end
	_cbRankInfo.setCorpsId (_cbRankInfo_corpsId);

	// 军团名称
	String _cbRankInfo_name = readString();
	//end
	_cbRankInfo.setName (_cbRankInfo_name);

	// 排名
	int _cbRankInfo_rank = readInteger();
	//end
	_cbRankInfo.setRank (_cbRankInfo_rank);

	// 录像
	String _cbRankInfo_replay = readString();
	//end
	_cbRankInfo.setReplay (_cbRankInfo_replay);

	// 最高纪录
	int _cbRankInfo_bossLevel = readInteger();
	//end
	_cbRankInfo.setBossLevel (_cbRankInfo_bossLevel);

	// 回合数
	int _cbRankInfo_round = readInteger();
	//end
	_cbRankInfo.setRound (_cbRankInfo_round);


	// 所有帮派boss排行榜信息
	int cbRankInfoListSize = readUnsignedShort();
	com.imop.lj.common.model.corps.CorpsBossRankInfo[] _cbRankInfoList = new com.imop.lj.common.model.corps.CorpsBossRankInfo[cbRankInfoListSize];
	int cbRankInfoListIndex = 0;
	for(cbRankInfoListIndex=0; cbRankInfoListIndex<cbRankInfoListSize; cbRankInfoListIndex++){
		_cbRankInfoList[cbRankInfoListIndex] = new com.imop.lj.common.model.corps.CorpsBossRankInfo();
	// 军团id
	long _cbRankInfoList_corpsId = readLong();
	//end
	_cbRankInfoList[cbRankInfoListIndex].setCorpsId (_cbRankInfoList_corpsId);

	// 军团名称
	String _cbRankInfoList_name = readString();
	//end
	_cbRankInfoList[cbRankInfoListIndex].setName (_cbRankInfoList_name);

	// 排名
	int _cbRankInfoList_rank = readInteger();
	//end
	_cbRankInfoList[cbRankInfoListIndex].setRank (_cbRankInfoList_rank);

	// 录像
	String _cbRankInfoList_replay = readString();
	//end
	_cbRankInfoList[cbRankInfoListIndex].setReplay (_cbRankInfoList_replay);

	// 最高纪录
	int _cbRankInfoList_bossLevel = readInteger();
	//end
	_cbRankInfoList[cbRankInfoListIndex].setBossLevel (_cbRankInfoList_bossLevel);

	// 回合数
	int _cbRankInfoList_round = readInteger();
	//end
	_cbRankInfoList[cbRankInfoListIndex].setRound (_cbRankInfoList_round);
	}
	//end



		this.cbRankInfo = _cbRankInfo;
		this.cbRankInfoList = _cbRankInfoList;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	long cbRankInfo_corpsId = cbRankInfo.getCorpsId ();

	// 军团id
	writeLong(cbRankInfo_corpsId);

	String cbRankInfo_name = cbRankInfo.getName ();

	// 军团名称
	writeString(cbRankInfo_name);

	int cbRankInfo_rank = cbRankInfo.getRank ();

	// 排名
	writeInteger(cbRankInfo_rank);

	String cbRankInfo_replay = cbRankInfo.getReplay ();

	// 录像
	writeString(cbRankInfo_replay);

	int cbRankInfo_bossLevel = cbRankInfo.getBossLevel ();

	// 最高纪录
	writeInteger(cbRankInfo_bossLevel);

	int cbRankInfo_round = cbRankInfo.getRound ();

	// 回合数
	writeInteger(cbRankInfo_round);


	// 所有帮派boss排行榜信息
	writeShort(cbRankInfoList.length);
	int cbRankInfoListIndex = 0;
	int cbRankInfoListSize = cbRankInfoList.length;
	for(cbRankInfoListIndex=0; cbRankInfoListIndex<cbRankInfoListSize; cbRankInfoListIndex++){

	long cbRankInfoList_corpsId = cbRankInfoList[cbRankInfoListIndex].getCorpsId();

	// 军团id
	writeLong(cbRankInfoList_corpsId);

	String cbRankInfoList_name = cbRankInfoList[cbRankInfoListIndex].getName();

	// 军团名称
	writeString(cbRankInfoList_name);

	int cbRankInfoList_rank = cbRankInfoList[cbRankInfoListIndex].getRank();

	// 排名
	writeInteger(cbRankInfoList_rank);

	String cbRankInfoList_replay = cbRankInfoList[cbRankInfoListIndex].getReplay();

	// 录像
	writeString(cbRankInfoList_replay);

	int cbRankInfoList_bossLevel = cbRankInfoList[cbRankInfoListIndex].getBossLevel();

	// 最高纪录
	writeInteger(cbRankInfoList_bossLevel);

	int cbRankInfoList_round = cbRankInfoList[cbRankInfoListIndex].getRound();

	// 回合数
	writeInteger(cbRankInfoList_round);
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_CORPSBOSS_RANK_LIST;
	}
	
	@Override
	public String getTypeName() {
		return "GC_CORPSBOSS_RANK_LIST";
	}

	public com.imop.lj.common.model.corps.CorpsBossRankInfo getCbRankInfo(){
		return cbRankInfo;
	}
		
	public void setCbRankInfo(com.imop.lj.common.model.corps.CorpsBossRankInfo cbRankInfo){
		this.cbRankInfo = cbRankInfo;
	}

	public com.imop.lj.common.model.corps.CorpsBossRankInfo[] getCbRankInfoList(){
		return cbRankInfoList;
	}

	public void setCbRankInfoList(com.imop.lj.common.model.corps.CorpsBossRankInfo[] cbRankInfoList){
		this.cbRankInfoList = cbRankInfoList;
	}	
}