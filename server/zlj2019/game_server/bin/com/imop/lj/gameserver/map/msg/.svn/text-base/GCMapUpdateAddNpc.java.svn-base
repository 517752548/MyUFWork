package com.imop.lj.gameserver.map.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 地图增加的npc更新
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCMapUpdateAddNpc extends GCMessage{
	
	/** npc信息 */
	private com.imop.lj.common.model.NpcInfo NpcInfoData;

	public GCMapUpdateAddNpc (){
	}
	
	public GCMapUpdateAddNpc (
			com.imop.lj.common.model.NpcInfo NpcInfoData ){
			this.NpcInfoData = NpcInfoData;
	}

	@Override
	protected boolean readImpl() {
	// npc信息
	com.imop.lj.common.model.NpcInfo _NpcInfoData = new com.imop.lj.common.model.NpcInfo();

	// 唯一id
	String _NpcInfoData_uuid = readString();
	//end
	_NpcInfoData.setUuid (_NpcInfoData_uuid);

	// 地图Id
	int _NpcInfoData_mapId = readInteger();
	//end
	_NpcInfoData.setMapId (_NpcInfoData_mapId);

	// npcId
	int _NpcInfoData_npcId = readInteger();
	//end
	_NpcInfoData.setNpcId (_NpcInfoData_npcId);

	// npc位置坐标x
	int _NpcInfoData_x = readInteger();
	//end
	_NpcInfoData.setX (_NpcInfoData_x);

	// npc位置坐标y
	int _NpcInfoData_y = readInteger();
	//end
	_NpcInfoData.setY (_NpcInfoData_y);

	// 是否处于战斗中，0否，1是
	int _NpcInfoData_isInBattle = readInteger();
	//end
	_NpcInfoData.setIsInBattle (_NpcInfoData_isInBattle);

	// 活动战斗类型
	int _NpcInfoData_activityType = readInteger();
	//end
	_NpcInfoData.setActivityType (_NpcInfoData_activityType);

	// 动态生成npc的时间
	long _NpcInfoData_createTime = readLong();
	//end
	_NpcInfoData.setCreateTime (_NpcInfoData_createTime);



		this.NpcInfoData = _NpcInfoData;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	String NpcInfoData_uuid = NpcInfoData.getUuid ();

	// 唯一id
	writeString(NpcInfoData_uuid);

	int NpcInfoData_mapId = NpcInfoData.getMapId ();

	// 地图Id
	writeInteger(NpcInfoData_mapId);

	int NpcInfoData_npcId = NpcInfoData.getNpcId ();

	// npcId
	writeInteger(NpcInfoData_npcId);

	int NpcInfoData_x = NpcInfoData.getX ();

	// npc位置坐标x
	writeInteger(NpcInfoData_x);

	int NpcInfoData_y = NpcInfoData.getY ();

	// npc位置坐标y
	writeInteger(NpcInfoData_y);

	int NpcInfoData_isInBattle = NpcInfoData.getIsInBattle ();

	// 是否处于战斗中，0否，1是
	writeInteger(NpcInfoData_isInBattle);

	int NpcInfoData_activityType = NpcInfoData.getActivityType ();

	// 活动战斗类型
	writeInteger(NpcInfoData_activityType);

	long NpcInfoData_createTime = NpcInfoData.getCreateTime ();

	// 动态生成npc的时间
	writeLong(NpcInfoData_createTime);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_MAP_UPDATE_ADD_NPC;
	}
	
	@Override
	public String getTypeName() {
		return "GC_MAP_UPDATE_ADD_NPC";
	}

	public com.imop.lj.common.model.NpcInfo getNpcInfoData(){
		return NpcInfoData;
	}
		
	public void setNpcInfoData(com.imop.lj.common.model.NpcInfo NpcInfoData){
		this.NpcInfoData = NpcInfoData;
	}
}