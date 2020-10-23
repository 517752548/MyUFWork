package com.imop.lj.gameserver.map.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 地图删除附加的npc
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCMapRemoveAddNpc extends GCMessage{
	
	/** 移除的npcUUId列表 */
	private String[] removeUUIdList;

	public GCMapRemoveAddNpc (){
	}
	
	public GCMapRemoveAddNpc (
			String[] removeUUIdList ){
			this.removeUUIdList = removeUUIdList;
	}

	@Override
	protected boolean readImpl() {

	// 移除的npcUUId列表
	int removeUUIdListSize = readUnsignedShort();
	String[] _removeUUIdList = new String[removeUUIdListSize];
	int removeUUIdListIndex = 0;
	for(removeUUIdListIndex=0; removeUUIdListIndex<removeUUIdListSize; removeUUIdListIndex++){
		_removeUUIdList[removeUUIdListIndex] = readString();
	}//end



		this.removeUUIdList = _removeUUIdList;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 移除的npcUUId列表
	writeShort(removeUUIdList.length);
	int removeUUIdListSize = removeUUIdList.length;
	int removeUUIdListIndex = 0;
	for(removeUUIdListIndex=0; removeUUIdListIndex<removeUUIdListSize; removeUUIdListIndex++){
		writeString(removeUUIdList [ removeUUIdListIndex ]);
	}//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_MAP_REMOVE_ADD_NPC;
	}
	
	@Override
	public String getTypeName() {
		return "GC_MAP_REMOVE_ADD_NPC";
	}

	public String[] getRemoveUUIdList(){
		return removeUUIdList;
	}

	public void setRemoveUUIdList(String[] removeUUIdList){
		this.removeUUIdList = removeUUIdList;
	}	
}