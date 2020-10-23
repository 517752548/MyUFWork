package com.imop.lj.gameserver.lifeskill.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 返回采矿界面结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCLsMineGetPannel extends GCMessage{
	
	/** 矿点信息 */
	private com.imop.lj.gameserver.lifeskill.MinePitInfo[] pitList;
	/** 服务器时间 */
	private long serverTime;

	public GCLsMineGetPannel (){
	}
	
	public GCLsMineGetPannel (
			com.imop.lj.gameserver.lifeskill.MinePitInfo[] pitList,
			long serverTime ){
			this.pitList = pitList;
			this.serverTime = serverTime;
	}

	@Override
	protected boolean readImpl() {

	// 矿点信息
	int pitListSize = readUnsignedShort();
	com.imop.lj.gameserver.lifeskill.MinePitInfo[] _pitList = new com.imop.lj.gameserver.lifeskill.MinePitInfo[pitListSize];
	int pitListIndex = 0;
	for(pitListIndex=0; pitListIndex<pitListSize; pitListIndex++){
		_pitList[pitListIndex] = new com.imop.lj.gameserver.lifeskill.MinePitInfo();
	// 矿坑ID
	int _pitList_id = readInteger();
	//end
	_pitList[pitListIndex].setId (_pitList_id);

	// 矿石种类
	int _pitList_mineTypeId = readInteger();
	//end
	_pitList[pitListIndex].setMineTypeId (_pitList_mineTypeId);

	// 开采方式Id
	int _pitList_miningTypeId = readInteger();
	//end
	_pitList[pitListIndex].setMiningTypeId (_pitList_miningTypeId);

	// 矿工名字
	String _pitList_minerName = readString();
	//end
	_pitList[pitListIndex].setMinerName (_pitList_minerName);

	// 矿工Id
	long _pitList_minerId = readLong();
	//end
	_pitList[pitListIndex].setMinerId (_pitList_minerId);

	// 矿工模型Id
	int _pitList_minerTplId = readInteger();
	//end
	_pitList[pitListIndex].setMinerTplId (_pitList_minerTplId);

	// 结束时间 
	long _pitList_endTime = readLong();
	//end
	_pitList[pitListIndex].setEndTime (_pitList_endTime);
	}
	//end


	// 服务器时间
	long _serverTime = readLong();
	//end



		this.pitList = _pitList;
		this.serverTime = _serverTime;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 矿点信息
	writeShort(pitList.length);
	int pitListIndex = 0;
	int pitListSize = pitList.length;
	for(pitListIndex=0; pitListIndex<pitListSize; pitListIndex++){

	int pitList_id = pitList[pitListIndex].getId();

	// 矿坑ID
	writeInteger(pitList_id);

	int pitList_mineTypeId = pitList[pitListIndex].getMineTypeId();

	// 矿石种类
	writeInteger(pitList_mineTypeId);

	int pitList_miningTypeId = pitList[pitListIndex].getMiningTypeId();

	// 开采方式Id
	writeInteger(pitList_miningTypeId);

	String pitList_minerName = pitList[pitListIndex].getMinerName();

	// 矿工名字
	writeString(pitList_minerName);

	long pitList_minerId = pitList[pitListIndex].getMinerId();

	// 矿工Id
	writeLong(pitList_minerId);

	int pitList_minerTplId = pitList[pitListIndex].getMinerTplId();

	// 矿工模型Id
	writeInteger(pitList_minerTplId);

	long pitList_endTime = pitList[pitListIndex].getEndTime();

	// 结束时间 
	writeLong(pitList_endTime);
	}
	//end


	// 服务器时间
	writeLong(serverTime);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_LS_MINE_GET_PANNEL;
	}
	
	@Override
	public String getTypeName() {
		return "GC_LS_MINE_GET_PANNEL";
	}

	public com.imop.lj.gameserver.lifeskill.MinePitInfo[] getPitList(){
		return pitList;
	}

	public void setPitList(com.imop.lj.gameserver.lifeskill.MinePitInfo[] pitList){
		this.pitList = pitList;
	}	

	public long getServerTime(){
		return serverTime;
	}
		
	public void setServerTime(long serverTime){
		this.serverTime = serverTime;
	}
}