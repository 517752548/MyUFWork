package com.imop.lj.gameserver.map.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 地图附加的npc列表
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCMapAddNpcList extends GCMessage{
	
	/** npc列表 */
	private com.imop.lj.common.model.NpcInfo[] NpcInfoDataList;

	public GCMapAddNpcList (){
	}
	
	public GCMapAddNpcList (
			com.imop.lj.common.model.NpcInfo[] NpcInfoDataList ){
			this.NpcInfoDataList = NpcInfoDataList;
	}

	@Override
	protected boolean readImpl() {

	// npc列表
	int NpcInfoDataListSize = readUnsignedShort();
	com.imop.lj.common.model.NpcInfo[] _NpcInfoDataList = new com.imop.lj.common.model.NpcInfo[NpcInfoDataListSize];
	int NpcInfoDataListIndex = 0;
	for(NpcInfoDataListIndex=0; NpcInfoDataListIndex<NpcInfoDataListSize; NpcInfoDataListIndex++){
		_NpcInfoDataList[NpcInfoDataListIndex] = new com.imop.lj.common.model.NpcInfo();
	// 唯一id
	String _NpcInfoDataList_uuid = readString();
	//end
	_NpcInfoDataList[NpcInfoDataListIndex].setUuid (_NpcInfoDataList_uuid);

	// 地图Id
	int _NpcInfoDataList_mapId = readInteger();
	//end
	_NpcInfoDataList[NpcInfoDataListIndex].setMapId (_NpcInfoDataList_mapId);

	// npcId
	int _NpcInfoDataList_npcId = readInteger();
	//end
	_NpcInfoDataList[NpcInfoDataListIndex].setNpcId (_NpcInfoDataList_npcId);

	// npc位置坐标x
	int _NpcInfoDataList_x = readInteger();
	//end
	_NpcInfoDataList[NpcInfoDataListIndex].setX (_NpcInfoDataList_x);

	// npc位置坐标y
	int _NpcInfoDataList_y = readInteger();
	//end
	_NpcInfoDataList[NpcInfoDataListIndex].setY (_NpcInfoDataList_y);

	// 是否处于战斗中，0否，1是
	int _NpcInfoDataList_isInBattle = readInteger();
	//end
	_NpcInfoDataList[NpcInfoDataListIndex].setIsInBattle (_NpcInfoDataList_isInBattle);

	// 活动战斗类型
	int _NpcInfoDataList_activityType = readInteger();
	//end
	_NpcInfoDataList[NpcInfoDataListIndex].setActivityType (_NpcInfoDataList_activityType);

	// 动态生成npc的时间
	long _NpcInfoDataList_createTime = readLong();
	//end
	_NpcInfoDataList[NpcInfoDataListIndex].setCreateTime (_NpcInfoDataList_createTime);
	}
	//end



		this.NpcInfoDataList = _NpcInfoDataList;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// npc列表
	writeShort(NpcInfoDataList.length);
	int NpcInfoDataListIndex = 0;
	int NpcInfoDataListSize = NpcInfoDataList.length;
	for(NpcInfoDataListIndex=0; NpcInfoDataListIndex<NpcInfoDataListSize; NpcInfoDataListIndex++){

	String NpcInfoDataList_uuid = NpcInfoDataList[NpcInfoDataListIndex].getUuid();

	// 唯一id
	writeString(NpcInfoDataList_uuid);

	int NpcInfoDataList_mapId = NpcInfoDataList[NpcInfoDataListIndex].getMapId();

	// 地图Id
	writeInteger(NpcInfoDataList_mapId);

	int NpcInfoDataList_npcId = NpcInfoDataList[NpcInfoDataListIndex].getNpcId();

	// npcId
	writeInteger(NpcInfoDataList_npcId);

	int NpcInfoDataList_x = NpcInfoDataList[NpcInfoDataListIndex].getX();

	// npc位置坐标x
	writeInteger(NpcInfoDataList_x);

	int NpcInfoDataList_y = NpcInfoDataList[NpcInfoDataListIndex].getY();

	// npc位置坐标y
	writeInteger(NpcInfoDataList_y);

	int NpcInfoDataList_isInBattle = NpcInfoDataList[NpcInfoDataListIndex].getIsInBattle();

	// 是否处于战斗中，0否，1是
	writeInteger(NpcInfoDataList_isInBattle);

	int NpcInfoDataList_activityType = NpcInfoDataList[NpcInfoDataListIndex].getActivityType();

	// 活动战斗类型
	writeInteger(NpcInfoDataList_activityType);

	long NpcInfoDataList_createTime = NpcInfoDataList[NpcInfoDataListIndex].getCreateTime();

	// 动态生成npc的时间
	writeLong(NpcInfoDataList_createTime);
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_MAP_ADD_NPC_LIST;
	}
	
	@Override
	public String getTypeName() {
		return "GC_MAP_ADD_NPC_LIST";
	}

	public com.imop.lj.common.model.NpcInfo[] getNpcInfoDataList(){
		return NpcInfoDataList;
	}

	public void setNpcInfoDataList(com.imop.lj.common.model.NpcInfo[] NpcInfoDataList){
		this.NpcInfoDataList = NpcInfoDataList;
	}	
}