package com.imop.lj.gameserver.promote.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 返回提升列表
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPromotePanel extends GCMessage{
	
	/** 提升列表 */
	private com.imop.lj.gameserver.promote.PromoteInfo[] promoteInfo;

	public GCPromotePanel (){
	}
	
	public GCPromotePanel (
			com.imop.lj.gameserver.promote.PromoteInfo[] promoteInfo ){
			this.promoteInfo = promoteInfo;
	}

	@Override
	protected boolean readImpl() {

	// 提升列表
	int promoteInfoSize = readUnsignedShort();
	com.imop.lj.gameserver.promote.PromoteInfo[] _promoteInfo = new com.imop.lj.gameserver.promote.PromoteInfo[promoteInfoSize];
	int promoteInfoIndex = 0;
	for(promoteInfoIndex=0; promoteInfoIndex<promoteInfoSize; promoteInfoIndex++){
		_promoteInfo[promoteInfoIndex] = new com.imop.lj.gameserver.promote.PromoteInfo();
	// 提升Id
	int _promoteInfo_protmoteId = readInteger();
	//end
	_promoteInfo[promoteInfoIndex].setProtmoteId (_promoteInfo_protmoteId);

	// 是否可以提升
	boolean _promoteInfo_canPromote = readBoolean();
	//end
	_promoteInfo[promoteInfoIndex].setCanPromote (_promoteInfo_canPromote);
	}
	//end



		this.promoteInfo = _promoteInfo;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 提升列表
	writeShort(promoteInfo.length);
	int promoteInfoIndex = 0;
	int promoteInfoSize = promoteInfo.length;
	for(promoteInfoIndex=0; promoteInfoIndex<promoteInfoSize; promoteInfoIndex++){

	int promoteInfo_protmoteId = promoteInfo[promoteInfoIndex].getProtmoteId();

	// 提升Id
	writeInteger(promoteInfo_protmoteId);

	boolean promoteInfo_canPromote = promoteInfo[promoteInfoIndex].getCanPromote();

	// 是否可以提升
	writeBoolean(promoteInfo_canPromote);
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_PROMOTE_PANEL;
	}
	
	@Override
	public String getTypeName() {
		return "GC_PROMOTE_PANEL";
	}

	public com.imop.lj.gameserver.promote.PromoteInfo[] getPromoteInfo(){
		return promoteInfo;
	}

	public void setPromoteInfo(com.imop.lj.gameserver.promote.PromoteInfo[] promoteInfo){
		this.promoteInfo = promoteInfo;
	}	
}