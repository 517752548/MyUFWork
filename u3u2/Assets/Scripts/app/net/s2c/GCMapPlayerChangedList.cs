
using System;
namespace app.net
{
/**
 * 地图中的玩家更新
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCMapPlayerChangedList :BaseMessage
{
	/** 地图id */
	private int mapId;
	/** 地图玩家信息 */
	private MapPlayerInfoData[] MapPlayerInfoDataList;

	public GCMapPlayerChangedList ()
	{
	}

	protected override void ReadImpl()
	{
	// 地图id
	int _mapId = ReadInt();

	// 地图玩家信息
	int MapPlayerInfoDataListSize = ReadShort();
	MapPlayerInfoData[] _MapPlayerInfoDataList = new MapPlayerInfoData[MapPlayerInfoDataListSize];
	int MapPlayerInfoDataListIndex = 0;
	MapPlayerInfoData _MapPlayerInfoDataListTmp = null;
	for(MapPlayerInfoDataListIndex=0; MapPlayerInfoDataListIndex<MapPlayerInfoDataListSize; MapPlayerInfoDataListIndex++){
		_MapPlayerInfoDataListTmp = new MapPlayerInfoData();
		_MapPlayerInfoDataList[MapPlayerInfoDataListIndex] = _MapPlayerInfoDataListTmp;
	// 角色id
	long _MapPlayerInfoDataList_uuid = ReadLong();	_MapPlayerInfoDataListTmp.uuid = _MapPlayerInfoDataList_uuid;
		// 1删除，2移动，3添加，4更新
	int _MapPlayerInfoDataList_msgType = ReadInt();	_MapPlayerInfoDataListTmp.msgType = _MapPlayerInfoDataList_msgType;
		// 玩家名称
	string _MapPlayerInfoDataList_name = ReadString();	_MapPlayerInfoDataListTmp.name = _MapPlayerInfoDataList_name;
		// 玩家等级
	int _MapPlayerInfoDataList_level = ReadInt();	_MapPlayerInfoDataListTmp.level = _MapPlayerInfoDataList_level;
		// 玩家模型
	string _MapPlayerInfoDataList_model = ReadString();	_MapPlayerInfoDataListTmp.model = _MapPlayerInfoDataList_model;
		// 地图Id
	int _MapPlayerInfoDataList_mapId = ReadInt();	_MapPlayerInfoDataListTmp.mapId = _MapPlayerInfoDataList_mapId;
		// 玩家X坐标(像素)
	int _MapPlayerInfoDataList_x = ReadInt();	_MapPlayerInfoDataListTmp.x = _MapPlayerInfoDataList_x;
		// 玩家Y坐标(像素)
	int _MapPlayerInfoDataList_y = ReadInt();	_MapPlayerInfoDataListTmp.y = _MapPlayerInfoDataList_y;
		// 0否，1是
	int _MapPlayerInfoDataList_isLeader = ReadInt();	_MapPlayerInfoDataListTmp.isLeader = _MapPlayerInfoDataList_isLeader;
		// 0否，1是
	int _MapPlayerInfoDataList_isFighting = ReadInt();	_MapPlayerInfoDataListTmp.isFighting = _MapPlayerInfoDataList_isFighting;
		// 是否运粮中，0否，1是
	int _MapPlayerInfoDataList_isForaging = ReadInt();	_MapPlayerInfoDataListTmp.isForaging = _MapPlayerInfoDataList_isForaging;
		// 骑宠模板Id，0表示没骑
	int _MapPlayerInfoDataList_rideHorseTplId = ReadInt();	_MapPlayerInfoDataListTmp.rideHorseTplId = _MapPlayerInfoDataList_rideHorseTplId;
		// 称号名称
	string _MapPlayerInfoDataList_titleName = ReadString();	_MapPlayerInfoDataListTmp.titleName = _MapPlayerInfoDataList_titleName;
		// 帮派 id
	long _MapPlayerInfoDataList_corpsId = ReadLong();	_MapPlayerInfoDataListTmp.corpsId = _MapPlayerInfoDataList_corpsId;
		// 翅膀模板Id，0表示没装备
	int _MapPlayerInfoDataList_wingTplId = ReadInt();	_MapPlayerInfoDataListTmp.wingTplId = _MapPlayerInfoDataList_wingTplId;
		// 时装模板Id，-1表示没装备
	int _MapPlayerInfoDataList_fashionTplId = ReadInt();	_MapPlayerInfoDataListTmp.fashionTplId = _MapPlayerInfoDataList_fashionTplId;
		// 主将武器模板Id
	int _MapPlayerInfoDataList_equipWeaponId = ReadInt();	_MapPlayerInfoDataListTmp.equipWeaponId = _MapPlayerInfoDataList_equipWeaponId;
		// vip等级
	int _MapPlayerInfoDataList_vipLevel = ReadInt();	_MapPlayerInfoDataListTmp.vipLevel = _MapPlayerInfoDataList_vipLevel;
		// 采集状态,0未在采集,1-伐木,2-采药,3-采矿,4-狩猎
	int _MapPlayerInfoDataList_lifeSkillFlag = ReadInt();	_MapPlayerInfoDataListTmp.lifeSkillFlag = _MapPlayerInfoDataList_lifeSkillFlag;
		// 玩家扩展信息json串，备用
	string _MapPlayerInfoDataList_extStr = ReadString();	_MapPlayerInfoDataListTmp.extStr = _MapPlayerInfoDataList_extStr;
		}
	//end



		this.mapId = _mapId;
		this.MapPlayerInfoDataList = _MapPlayerInfoDataList;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_MAP_PLAYER_CHANGED_LIST;
	}
	
	public override string getEventType()
	{
		return MapGCHandler.GCMapPlayerChangedListEvent;
	}
	

	public int getMapId(){
		return mapId;
	}
		

	public MapPlayerInfoData[] getMapPlayerInfoDataList(){
		return MapPlayerInfoDataList;
	}


	public override bool isCompress() {
		return true;
	}
}
}