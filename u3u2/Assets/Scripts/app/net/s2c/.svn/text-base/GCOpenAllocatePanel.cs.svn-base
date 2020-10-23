
using System;
namespace app.net
{
/**
 * 返回请求打开活动奖励分配面板
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCOpenAllocatePanel :BaseMessage
{
	/** 待被分配到的奖励内容 */
	private AllocateItemInfo[] beforeAllocateItemInfos;
	/** 被分配奖励的玩家信息 */
	private AllocateMemberInfo[] allocateMemberInfoList;

	public GCOpenAllocatePanel ()
	{
	}

	protected override void ReadImpl()
	{

	// 待被分配到的奖励内容
	int beforeAllocateItemInfosSize = ReadShort();
	AllocateItemInfo[] _beforeAllocateItemInfos = new AllocateItemInfo[beforeAllocateItemInfosSize];
	int beforeAllocateItemInfosIndex = 0;
	AllocateItemInfo _beforeAllocateItemInfosTmp = null;
	for(beforeAllocateItemInfosIndex=0; beforeAllocateItemInfosIndex<beforeAllocateItemInfosSize; beforeAllocateItemInfosIndex++){
		_beforeAllocateItemInfosTmp = new AllocateItemInfo();
		_beforeAllocateItemInfos[beforeAllocateItemInfosIndex] = _beforeAllocateItemInfosTmp;
	// 已被分配到的奖励道具Id
	int _beforeAllocateItemInfos_itemId = ReadInt();	_beforeAllocateItemInfosTmp.itemId = _beforeAllocateItemInfos_itemId;
		// 已被分配到的奖励道具数量
	int _beforeAllocateItemInfos_num = ReadInt();	_beforeAllocateItemInfosTmp.num = _beforeAllocateItemInfos_num;
		}
	//end


	// 被分配奖励的玩家信息
	int allocateMemberInfoListSize = ReadShort();
	AllocateMemberInfo[] _allocateMemberInfoList = new AllocateMemberInfo[allocateMemberInfoListSize];
	int allocateMemberInfoListIndex = 0;
	AllocateMemberInfo _allocateMemberInfoListTmp = null;
	for(allocateMemberInfoListIndex=0; allocateMemberInfoListIndex<allocateMemberInfoListSize; allocateMemberInfoListIndex++){
		_allocateMemberInfoListTmp = new AllocateMemberInfo();
		_allocateMemberInfoList[allocateMemberInfoListIndex] = _allocateMemberInfoListTmp;
	// 玩家id
	long _allocateMemberInfoList_roleId = ReadLong();	_allocateMemberInfoListTmp.roleId = _allocateMemberInfoList_roleId;
		// 玩家姓名
	string _allocateMemberInfoList_playerName = ReadString();	_allocateMemberInfoListTmp.playerName = _allocateMemberInfoList_playerName;
		// 玩家军团id
	long _allocateMemberInfoList_corpsId = ReadLong();	_allocateMemberInfoListTmp.corpsId = _allocateMemberInfoList_corpsId;
		// 玩家积分
	int _allocateMemberInfoList_score = ReadInt();	_allocateMemberInfoListTmp.score = _allocateMemberInfoList_score;
		// 玩家等级
	int _allocateMemberInfoList_playerLevel = ReadInt();	_allocateMemberInfoListTmp.playerLevel = _allocateMemberInfoList_playerLevel;
		// 玩家战力
	int _allocateMemberInfoList_playerPower = ReadInt();	_allocateMemberInfoListTmp.playerPower = _allocateMemberInfoList_playerPower;
		// 玩家帮派职务
	int _allocateMemberInfoList_corpsJob = ReadInt();	_allocateMemberInfoListTmp.corpsJob = _allocateMemberInfoList_corpsJob;
	
	// 已被分配到的奖励内容
	int allocateMemberInfoList_afterAllocateItemInfosSize = ReadShort();
	AllocateItemInfo[] _allocateMemberInfoList_afterAllocateItemInfos = new AllocateItemInfo[allocateMemberInfoList_afterAllocateItemInfosSize];
	int allocateMemberInfoList_afterAllocateItemInfosIndex = 0;
	AllocateItemInfo _allocateMemberInfoList_afterAllocateItemInfosTmp = null;
	for(allocateMemberInfoList_afterAllocateItemInfosIndex=0; allocateMemberInfoList_afterAllocateItemInfosIndex<allocateMemberInfoList_afterAllocateItemInfosSize; allocateMemberInfoList_afterAllocateItemInfosIndex++){
		_allocateMemberInfoList_afterAllocateItemInfosTmp = new AllocateItemInfo();
		_allocateMemberInfoList_afterAllocateItemInfos[allocateMemberInfoList_afterAllocateItemInfosIndex] = _allocateMemberInfoList_afterAllocateItemInfosTmp;
	// 已被分配到的奖励道具Id
	int _allocateMemberInfoList_afterAllocateItemInfos_itemId = ReadInt();	_allocateMemberInfoList_afterAllocateItemInfosTmp.itemId = _allocateMemberInfoList_afterAllocateItemInfos_itemId;
		// 已被分配到的奖励道具数量
	int _allocateMemberInfoList_afterAllocateItemInfos_num = ReadInt();	_allocateMemberInfoList_afterAllocateItemInfosTmp.num = _allocateMemberInfoList_afterAllocateItemInfos_num;
		}
	//end
	_allocateMemberInfoListTmp.afterAllocateItemInfos = _allocateMemberInfoList_afterAllocateItemInfos;
		}
	//end



		this.beforeAllocateItemInfos = _beforeAllocateItemInfos;
		this.allocateMemberInfoList = _allocateMemberInfoList;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_OPEN_ALLOCATE_PANEL;
	}
	
	public override string getEventType()
	{
		return CorpsGCHandler.GCOpenAllocatePanelEvent;
	}
	

	public AllocateItemInfo[] getBeforeAllocateItemInfos(){
		return beforeAllocateItemInfos;
	}


	public AllocateMemberInfo[] getAllocateMemberInfoList(){
		return allocateMemberInfoList;
	}


}
}