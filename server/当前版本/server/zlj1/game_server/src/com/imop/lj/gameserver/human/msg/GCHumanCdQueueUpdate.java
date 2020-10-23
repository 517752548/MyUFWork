package com.imop.lj.gameserver.human.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 服务器下发新的冷却队列信息（部分改变）
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCHumanCdQueueUpdate extends GCMessage{
	
	/** 冷却队列 */
	private com.imop.lj.gameserver.cd.CdQueueInfo[] cdQueueInfo;

	public GCHumanCdQueueUpdate (){
	}
	
	public GCHumanCdQueueUpdate (
			com.imop.lj.gameserver.cd.CdQueueInfo[] cdQueueInfo ){
			this.cdQueueInfo = cdQueueInfo;
	}

	@Override
	protected boolean readImpl() {

	// 冷却队列
	int cdQueueInfoSize = readUnsignedShort();
	com.imop.lj.gameserver.cd.CdQueueInfo[] _cdQueueInfo = new com.imop.lj.gameserver.cd.CdQueueInfo[cdQueueInfoSize];
	int cdQueueInfoIndex = 0;
	for(cdQueueInfoIndex=0; cdQueueInfoIndex<cdQueueInfoSize; cdQueueInfoIndex++){
		_cdQueueInfo[cdQueueInfoIndex] = new com.imop.lj.gameserver.cd.CdQueueInfo();
	// cd队列的类型
	int _cdQueueInfo_cdTypeInt = readInteger();
	//end
	_cdQueueInfo[cdQueueInfoIndex].setCdTypeInt (_cdQueueInfo_cdTypeInt);

	// cd队列索引
	int _cdQueueInfo_index = readInteger();
	//end
	_cdQueueInfo[cdQueueInfoIndex].setIndex (_cdQueueInfo_index);

	// cd队列名称
	String _cdQueueInfo_name = readString();
	//end
	_cdQueueInfo[cdQueueInfoIndex].setName (_cdQueueInfo_name);

	// 图标
	String _cdQueueInfo_icon = readString();
	//end
	_cdQueueInfo[cdQueueInfoIndex].setIcon (_cdQueueInfo_icon);

	// 服务器当前时间到结束时间的时间差
	int _cdQueueInfo_currTimeDiff = readInteger();
	//end
	_cdQueueInfo[cdQueueInfoIndex].setCurrTimeDiff (_cdQueueInfo_currTimeDiff);

	// 是否已开启
	boolean _cdQueueInfo_opened = readBoolean();
	//end
	_cdQueueInfo[cdQueueInfoIndex].setOpened (_cdQueueInfo_opened);

	// 是否可以累计时间
	boolean _cdQueueInfo_canAddTime = readBoolean();
	//end
	_cdQueueInfo[cdQueueInfoIndex].setCanAddTime (_cdQueueInfo_canAddTime);
	}
	//end



		this.cdQueueInfo = _cdQueueInfo;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 冷却队列
	writeShort(cdQueueInfo.length);
	int cdQueueInfoIndex = 0;
	int cdQueueInfoSize = cdQueueInfo.length;
	for(cdQueueInfoIndex=0; cdQueueInfoIndex<cdQueueInfoSize; cdQueueInfoIndex++){

	int cdQueueInfo_cdTypeInt = cdQueueInfo[cdQueueInfoIndex].getCdTypeInt();

	// cd队列的类型
	writeInteger(cdQueueInfo_cdTypeInt);

	int cdQueueInfo_index = cdQueueInfo[cdQueueInfoIndex].getIndex();

	// cd队列索引
	writeInteger(cdQueueInfo_index);

	String cdQueueInfo_name = cdQueueInfo[cdQueueInfoIndex].getName();

	// cd队列名称
	writeString(cdQueueInfo_name);

	String cdQueueInfo_icon = cdQueueInfo[cdQueueInfoIndex].getIcon();

	// 图标
	writeString(cdQueueInfo_icon);

	int cdQueueInfo_currTimeDiff = cdQueueInfo[cdQueueInfoIndex].getCurrTimeDiff();

	// 服务器当前时间到结束时间的时间差
	writeInteger(cdQueueInfo_currTimeDiff);

	boolean cdQueueInfo_opened = cdQueueInfo[cdQueueInfoIndex].getOpened();

	// 是否已开启
	writeBoolean(cdQueueInfo_opened);

	boolean cdQueueInfo_canAddTime = cdQueueInfo[cdQueueInfoIndex].getCanAddTime();

	// 是否可以累计时间
	writeBoolean(cdQueueInfo_canAddTime);
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_HUMAN_CD_QUEUE_UPDATE;
	}
	
	@Override
	public String getTypeName() {
		return "GC_HUMAN_CD_QUEUE_UPDATE";
	}

	public com.imop.lj.gameserver.cd.CdQueueInfo[] getCdQueueInfo(){
		return cdQueueInfo;
	}

	public void setCdQueueInfo(com.imop.lj.gameserver.cd.CdQueueInfo[] cdQueueInfo){
		this.cdQueueInfo = cdQueueInfo;
	}	
}