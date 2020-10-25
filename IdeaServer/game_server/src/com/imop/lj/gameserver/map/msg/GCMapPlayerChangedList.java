package com.imop.lj.gameserver.map.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 地图中的玩家更新
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCMapPlayerChangedList extends GCMessage{
	
	/** 地图id */
	private int mapId;
	/** 地图玩家信息 */
	private com.imop.lj.common.model.map.MapPlayerInfo[] MapPlayerInfoDataList;

	public GCMapPlayerChangedList (){
	}
	
	public GCMapPlayerChangedList (
			int mapId,
			com.imop.lj.common.model.map.MapPlayerInfo[] MapPlayerInfoDataList ){
			this.mapId = mapId;
			this.MapPlayerInfoDataList = MapPlayerInfoDataList;
	}

	@Override
	protected boolean readImpl() {

	// 地图id
	int _mapId = readInteger();
	//end


	// 地图玩家信息
	int MapPlayerInfoDataListSize = readUnsignedShort();
	com.imop.lj.common.model.map.MapPlayerInfo[] _MapPlayerInfoDataList = new com.imop.lj.common.model.map.MapPlayerInfo[MapPlayerInfoDataListSize];
	int MapPlayerInfoDataListIndex = 0;
	for(MapPlayerInfoDataListIndex=0; MapPlayerInfoDataListIndex<MapPlayerInfoDataListSize; MapPlayerInfoDataListIndex++){
		_MapPlayerInfoDataList[MapPlayerInfoDataListIndex] = new com.imop.lj.common.model.map.MapPlayerInfo();
	// 角色id
	long _MapPlayerInfoDataList_uuid = readLong();
	//end
	_MapPlayerInfoDataList[MapPlayerInfoDataListIndex].setUuid (_MapPlayerInfoDataList_uuid);

	// 1删除，2移动，3添加，4更新
	int _MapPlayerInfoDataList_msgType = readInteger();
	//end
	_MapPlayerInfoDataList[MapPlayerInfoDataListIndex].setMsgType (_MapPlayerInfoDataList_msgType);

	// 玩家名称
	String _MapPlayerInfoDataList_name = readString();
	//end
	_MapPlayerInfoDataList[MapPlayerInfoDataListIndex].setName (_MapPlayerInfoDataList_name);

	// 玩家等级
	int _MapPlayerInfoDataList_level = readInteger();
	//end
	_MapPlayerInfoDataList[MapPlayerInfoDataListIndex].setLevel (_MapPlayerInfoDataList_level);

	// 玩家模型
	String _MapPlayerInfoDataList_model = readString();
	//end
	_MapPlayerInfoDataList[MapPlayerInfoDataListIndex].setModel (_MapPlayerInfoDataList_model);

	// 地图Id
	int _MapPlayerInfoDataList_mapId = readInteger();
	//end
	_MapPlayerInfoDataList[MapPlayerInfoDataListIndex].setMapId (_MapPlayerInfoDataList_mapId);

	// 玩家X坐标(像素)
	int _MapPlayerInfoDataList_x = readInteger();
	//end
	_MapPlayerInfoDataList[MapPlayerInfoDataListIndex].setX (_MapPlayerInfoDataList_x);

	// 玩家Y坐标(像素)
	int _MapPlayerInfoDataList_y = readInteger();
	//end
	_MapPlayerInfoDataList[MapPlayerInfoDataListIndex].setY (_MapPlayerInfoDataList_y);

	// 0否，1是
	int _MapPlayerInfoDataList_isLeader = readInteger();
	//end
	_MapPlayerInfoDataList[MapPlayerInfoDataListIndex].setIsLeader (_MapPlayerInfoDataList_isLeader);

	// 0否，1是
	int _MapPlayerInfoDataList_isFighting = readInteger();
	//end
	_MapPlayerInfoDataList[MapPlayerInfoDataListIndex].setIsFighting (_MapPlayerInfoDataList_isFighting);

	// 是否运粮中，0否，1是
	int _MapPlayerInfoDataList_isForaging = readInteger();
	//end
	_MapPlayerInfoDataList[MapPlayerInfoDataListIndex].setIsForaging (_MapPlayerInfoDataList_isForaging);

	// 骑宠模板Id，0表示没骑
	int _MapPlayerInfoDataList_rideHorseTplId = readInteger();
	//end
	_MapPlayerInfoDataList[MapPlayerInfoDataListIndex].setRideHorseTplId (_MapPlayerInfoDataList_rideHorseTplId);

	// 称号名称
	String _MapPlayerInfoDataList_titleName = readString();
	//end
	_MapPlayerInfoDataList[MapPlayerInfoDataListIndex].setTitleName (_MapPlayerInfoDataList_titleName);

	// 帮派 id
	long _MapPlayerInfoDataList_corpsId = readLong();
	//end
	_MapPlayerInfoDataList[MapPlayerInfoDataListIndex].setCorpsId (_MapPlayerInfoDataList_corpsId);

	// 翅膀模板Id，0表示没装备
	int _MapPlayerInfoDataList_wingTplId = readInteger();
	//end
	_MapPlayerInfoDataList[MapPlayerInfoDataListIndex].setWingTplId (_MapPlayerInfoDataList_wingTplId);

	// 时装模板Id，-1表示没装备
	int _MapPlayerInfoDataList_fashionTplId = readInteger();
	//end
	_MapPlayerInfoDataList[MapPlayerInfoDataListIndex].setFashionTplId (_MapPlayerInfoDataList_fashionTplId);

	// 主将武器模板Id
	int _MapPlayerInfoDataList_equipWeaponId = readInteger();
	//end
	_MapPlayerInfoDataList[MapPlayerInfoDataListIndex].setEquipWeaponId (_MapPlayerInfoDataList_equipWeaponId);

	// vip等级
	int _MapPlayerInfoDataList_vipLevel = readInteger();
	//end
	_MapPlayerInfoDataList[MapPlayerInfoDataListIndex].setVipLevel (_MapPlayerInfoDataList_vipLevel);

	// 采集状态,0未在采集,1-伐木,2-采药,3-采矿,4-狩猎
	int _MapPlayerInfoDataList_lifeSkillFlag = readInteger();
	//end
	_MapPlayerInfoDataList[MapPlayerInfoDataListIndex].setLifeSkillFlag (_MapPlayerInfoDataList_lifeSkillFlag);

	// 玩家扩展信息json串，备用
	String _MapPlayerInfoDataList_extStr = readString();
	//end
	_MapPlayerInfoDataList[MapPlayerInfoDataListIndex].setExtStr (_MapPlayerInfoDataList_extStr);
	}
	//end



		this.mapId = _mapId;
		this.MapPlayerInfoDataList = _MapPlayerInfoDataList;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 地图id
	writeInteger(mapId);


	// 地图玩家信息
	writeShort(MapPlayerInfoDataList.length);
	int MapPlayerInfoDataListIndex = 0;
	int MapPlayerInfoDataListSize = MapPlayerInfoDataList.length;
	for(MapPlayerInfoDataListIndex=0; MapPlayerInfoDataListIndex<MapPlayerInfoDataListSize; MapPlayerInfoDataListIndex++){

	long MapPlayerInfoDataList_uuid = MapPlayerInfoDataList[MapPlayerInfoDataListIndex].getUuid();

	// 角色id
	writeLong(MapPlayerInfoDataList_uuid);

	int MapPlayerInfoDataList_msgType = MapPlayerInfoDataList[MapPlayerInfoDataListIndex].getMsgType();

	// 1删除，2移动，3添加，4更新
	writeInteger(MapPlayerInfoDataList_msgType);

	String MapPlayerInfoDataList_name = MapPlayerInfoDataList[MapPlayerInfoDataListIndex].getName();

	// 玩家名称
	writeString(MapPlayerInfoDataList_name);

	int MapPlayerInfoDataList_level = MapPlayerInfoDataList[MapPlayerInfoDataListIndex].getLevel();

	// 玩家等级
	writeInteger(MapPlayerInfoDataList_level);

	String MapPlayerInfoDataList_model = MapPlayerInfoDataList[MapPlayerInfoDataListIndex].getModel();

	// 玩家模型
	writeString(MapPlayerInfoDataList_model);

	int MapPlayerInfoDataList_mapId = MapPlayerInfoDataList[MapPlayerInfoDataListIndex].getMapId();

	// 地图Id
	writeInteger(MapPlayerInfoDataList_mapId);

	int MapPlayerInfoDataList_x = MapPlayerInfoDataList[MapPlayerInfoDataListIndex].getX();

	// 玩家X坐标(像素)
	writeInteger(MapPlayerInfoDataList_x);

	int MapPlayerInfoDataList_y = MapPlayerInfoDataList[MapPlayerInfoDataListIndex].getY();

	// 玩家Y坐标(像素)
	writeInteger(MapPlayerInfoDataList_y);

	int MapPlayerInfoDataList_isLeader = MapPlayerInfoDataList[MapPlayerInfoDataListIndex].getIsLeader();

	// 0否，1是
	writeInteger(MapPlayerInfoDataList_isLeader);

	int MapPlayerInfoDataList_isFighting = MapPlayerInfoDataList[MapPlayerInfoDataListIndex].getIsFighting();

	// 0否，1是
	writeInteger(MapPlayerInfoDataList_isFighting);

	int MapPlayerInfoDataList_isForaging = MapPlayerInfoDataList[MapPlayerInfoDataListIndex].getIsForaging();

	// 是否运粮中，0否，1是
	writeInteger(MapPlayerInfoDataList_isForaging);

	int MapPlayerInfoDataList_rideHorseTplId = MapPlayerInfoDataList[MapPlayerInfoDataListIndex].getRideHorseTplId();

	// 骑宠模板Id，0表示没骑
	writeInteger(MapPlayerInfoDataList_rideHorseTplId);

	String MapPlayerInfoDataList_titleName = MapPlayerInfoDataList[MapPlayerInfoDataListIndex].getTitleName();

	// 称号名称
	writeString(MapPlayerInfoDataList_titleName);

	long MapPlayerInfoDataList_corpsId = MapPlayerInfoDataList[MapPlayerInfoDataListIndex].getCorpsId();

	// 帮派 id
	writeLong(MapPlayerInfoDataList_corpsId);

	int MapPlayerInfoDataList_wingTplId = MapPlayerInfoDataList[MapPlayerInfoDataListIndex].getWingTplId();

	// 翅膀模板Id，0表示没装备
	writeInteger(MapPlayerInfoDataList_wingTplId);

	int MapPlayerInfoDataList_fashionTplId = MapPlayerInfoDataList[MapPlayerInfoDataListIndex].getFashionTplId();

	// 时装模板Id，-1表示没装备
	writeInteger(MapPlayerInfoDataList_fashionTplId);

	int MapPlayerInfoDataList_equipWeaponId = MapPlayerInfoDataList[MapPlayerInfoDataListIndex].getEquipWeaponId();

	// 主将武器模板Id
	writeInteger(MapPlayerInfoDataList_equipWeaponId);

	int MapPlayerInfoDataList_vipLevel = MapPlayerInfoDataList[MapPlayerInfoDataListIndex].getVipLevel();

	// vip等级
	writeInteger(MapPlayerInfoDataList_vipLevel);

	int MapPlayerInfoDataList_lifeSkillFlag = MapPlayerInfoDataList[MapPlayerInfoDataListIndex].getLifeSkillFlag();

	// 采集状态,0未在采集,1-伐木,2-采药,3-采矿,4-狩猎
	writeInteger(MapPlayerInfoDataList_lifeSkillFlag);

	String MapPlayerInfoDataList_extStr = MapPlayerInfoDataList[MapPlayerInfoDataListIndex].getExtStr();

	// 玩家扩展信息json串，备用
	writeString(MapPlayerInfoDataList_extStr);
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_MAP_PLAYER_CHANGED_LIST;
	}
	
	@Override
	public String getTypeName() {
		return "GC_MAP_PLAYER_CHANGED_LIST";
	}

	public int getMapId(){
		return mapId;
	}
		
	public void setMapId(int mapId){
		this.mapId = mapId;
	}

	public com.imop.lj.common.model.map.MapPlayerInfo[] getMapPlayerInfoDataList(){
		return MapPlayerInfoDataList;
	}

	public void setMapPlayerInfoDataList(com.imop.lj.common.model.map.MapPlayerInfo[] MapPlayerInfoDataList){
		this.MapPlayerInfoDataList = MapPlayerInfoDataList;
	}	
	public boolean isCompress() {
		return true;
	}
}