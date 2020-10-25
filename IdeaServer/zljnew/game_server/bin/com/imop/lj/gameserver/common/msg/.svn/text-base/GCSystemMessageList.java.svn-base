package com.imop.lj.gameserver.common.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 系统提示消息列表
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCSystemMessageList extends GCMessage{
	
	/** 系统提示消息列表 */
	private com.imop.lj.common.model.SysMsgInfo[] sysMsgInfoList;

	public GCSystemMessageList (){
	}
	
	public GCSystemMessageList (
			com.imop.lj.common.model.SysMsgInfo[] sysMsgInfoList ){
			this.sysMsgInfoList = sysMsgInfoList;
	}

	@Override
	protected boolean readImpl() {

	// 系统提示消息列表
	int sysMsgInfoListSize = readUnsignedShort();
	com.imop.lj.common.model.SysMsgInfo[] _sysMsgInfoList = new com.imop.lj.common.model.SysMsgInfo[sysMsgInfoListSize];
	int sysMsgInfoListIndex = 0;
	for(sysMsgInfoListIndex=0; sysMsgInfoListIndex<sysMsgInfoListSize; sysMsgInfoListIndex++){
		_sysMsgInfoList[sysMsgInfoListIndex] = new com.imop.lj.common.model.SysMsgInfo();
	// 消息内容
	String _sysMsgInfoList_content = readString();
	//end
	_sysMsgInfoList[sysMsgInfoListIndex].setContent (_sysMsgInfoList_content);

	// 消息显示类型
	short _sysMsgInfoList_showType = readShort();
	//end
	_sysMsgInfoList[sysMsgInfoListIndex].setShowType (_sysMsgInfoList_showType);
	}
	//end



		this.sysMsgInfoList = _sysMsgInfoList;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 系统提示消息列表
	writeShort(sysMsgInfoList.length);
	int sysMsgInfoListIndex = 0;
	int sysMsgInfoListSize = sysMsgInfoList.length;
	for(sysMsgInfoListIndex=0; sysMsgInfoListIndex<sysMsgInfoListSize; sysMsgInfoListIndex++){

	String sysMsgInfoList_content = sysMsgInfoList[sysMsgInfoListIndex].getContent();

	// 消息内容
	writeString(sysMsgInfoList_content);

	short sysMsgInfoList_showType = sysMsgInfoList[sysMsgInfoListIndex].getShowType();

	// 消息显示类型
	writeShort(sysMsgInfoList_showType);
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_SYSTEM_MESSAGE_LIST;
	}
	
	@Override
	public String getTypeName() {
		return "GC_SYSTEM_MESSAGE_LIST";
	}

	public com.imop.lj.common.model.SysMsgInfo[] getSysMsgInfoList(){
		return sysMsgInfoList;
	}

	public void setSysMsgInfoList(com.imop.lj.common.model.SysMsgInfo[] sysMsgInfoList){
		this.sysMsgInfoList = sysMsgInfoList;
	}	
	public boolean isCompress() {
		return true;
	}
}