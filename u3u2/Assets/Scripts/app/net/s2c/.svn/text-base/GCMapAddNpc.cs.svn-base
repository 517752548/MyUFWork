
using System;
namespace app.net
{
/**
 * 地图增加一个npc
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCMapAddNpc :BaseMessage
{
	/** npc信息 */
	private NpcInfoData NpcInfoData;

	public GCMapAddNpc ()
	{
	}

	protected override void ReadImpl()
	{
	// npc信息
	NpcInfoData _NpcInfoData = new NpcInfoData();
	// 唯一id
	string _NpcInfoData_uuid = ReadString();	_NpcInfoData.uuid = _NpcInfoData_uuid;
	// 地图Id
	int _NpcInfoData_mapId = ReadInt();	_NpcInfoData.mapId = _NpcInfoData_mapId;
	// npcId
	int _NpcInfoData_npcId = ReadInt();	_NpcInfoData.npcId = _NpcInfoData_npcId;
	// npc位置坐标x
	int _NpcInfoData_x = ReadInt();	_NpcInfoData.x = _NpcInfoData_x;
	// npc位置坐标y
	int _NpcInfoData_y = ReadInt();	_NpcInfoData.y = _NpcInfoData_y;
	// 是否处于战斗中，0否，1是
	int _NpcInfoData_isInBattle = ReadInt();	_NpcInfoData.isInBattle = _NpcInfoData_isInBattle;
	// 活动战斗类型
	int _NpcInfoData_activityType = ReadInt();	_NpcInfoData.activityType = _NpcInfoData_activityType;
	// 动态生成npc的时间
	long _NpcInfoData_createTime = ReadLong();	_NpcInfoData.createTime = _NpcInfoData_createTime;



		this.NpcInfoData = _NpcInfoData;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_MAP_ADD_NPC;
	}
	
	public override string getEventType()
	{
		return MapGCHandler.GCMapAddNpcEvent;
	}
	

	public NpcInfoData getNpcInfoData(){
		return NpcInfoData;
	}
		

}
}