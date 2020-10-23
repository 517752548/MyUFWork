
using System;
namespace app.net
{
/**
 * 地图附加的npc列表
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCMapAddNpcList :BaseMessage
{
	/** npc列表 */
	private NpcInfoData[] NpcInfoDataList;

	public GCMapAddNpcList ()
	{
	}

	protected override void ReadImpl()
	{

	// npc列表
	int NpcInfoDataListSize = ReadShort();
	NpcInfoData[] _NpcInfoDataList = new NpcInfoData[NpcInfoDataListSize];
	int NpcInfoDataListIndex = 0;
	NpcInfoData _NpcInfoDataListTmp = null;
	for(NpcInfoDataListIndex=0; NpcInfoDataListIndex<NpcInfoDataListSize; NpcInfoDataListIndex++){
		_NpcInfoDataListTmp = new NpcInfoData();
		_NpcInfoDataList[NpcInfoDataListIndex] = _NpcInfoDataListTmp;
	// 唯一id
	string _NpcInfoDataList_uuid = ReadString();	_NpcInfoDataListTmp.uuid = _NpcInfoDataList_uuid;
		// 地图Id
	int _NpcInfoDataList_mapId = ReadInt();	_NpcInfoDataListTmp.mapId = _NpcInfoDataList_mapId;
		// npcId
	int _NpcInfoDataList_npcId = ReadInt();	_NpcInfoDataListTmp.npcId = _NpcInfoDataList_npcId;
		// npc位置坐标x
	int _NpcInfoDataList_x = ReadInt();	_NpcInfoDataListTmp.x = _NpcInfoDataList_x;
		// npc位置坐标y
	int _NpcInfoDataList_y = ReadInt();	_NpcInfoDataListTmp.y = _NpcInfoDataList_y;
		// 是否处于战斗中，0否，1是
	int _NpcInfoDataList_isInBattle = ReadInt();	_NpcInfoDataListTmp.isInBattle = _NpcInfoDataList_isInBattle;
		// 活动战斗类型
	int _NpcInfoDataList_activityType = ReadInt();	_NpcInfoDataListTmp.activityType = _NpcInfoDataList_activityType;
		// 动态生成npc的时间
	long _NpcInfoDataList_createTime = ReadLong();	_NpcInfoDataListTmp.createTime = _NpcInfoDataList_createTime;
		}
	//end



		this.NpcInfoDataList = _NpcInfoDataList;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_MAP_ADD_NPC_LIST;
	}
	
	public override string getEventType()
	{
		return MapGCHandler.GCMapAddNpcListEvent;
	}
	

	public NpcInfoData[] getNpcInfoDataList(){
		return NpcInfoDataList;
	}


}
}