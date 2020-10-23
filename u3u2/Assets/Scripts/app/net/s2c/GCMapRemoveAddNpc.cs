
using System;
namespace app.net
{
/**
 * 地图删除附加的npc
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCMapRemoveAddNpc :BaseMessage
{
	/** 移除的npcUUId列表 */
	private string[] removeUUIdList;

	public GCMapRemoveAddNpc ()
	{
	}

	protected override void ReadImpl()
	{
	// 移除的npcUUId列表
	int removeUUIdListSize = ReadShort();
	string[] _removeUUIdList = new string[removeUUIdListSize];
	int removeUUIdListIndex = 0;
	for(removeUUIdListIndex=0; removeUUIdListIndex<removeUUIdListSize; removeUUIdListIndex++){
		_removeUUIdList[removeUUIdListIndex] = ReadString();
	}//end
	


		this.removeUUIdList = _removeUUIdList;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_MAP_REMOVE_ADD_NPC;
	}
	
	public override string getEventType()
	{
		return MapGCHandler.GCMapRemoveAddNpcEvent;
	}
	

	public string[] getRemoveUUIdList(){
		return removeUUIdList;
	}


}
}