using System;
using System.IO;
namespace app.net
{

/**
 * 请求分配活动得到的物品
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGAllocateActivityItem :BaseMessage
{
	
	/** 活动类型,1-帮派竞赛 */
	private int activityType;
	/** 接受者 */
	private long targetId;
	/** 分配中的奖励内容 */
	private AllocateItemInfo[] allocatingItemInfos;
	
	public CGAllocateActivityItem ()
	{
	}
	
	public CGAllocateActivityItem (
			int activityType,
			long targetId,
			AllocateItemInfo[] allocatingItemInfos )
	{
			this.activityType = activityType;
			this.targetId = targetId;
			this.allocatingItemInfos = allocatingItemInfos;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 活动类型,1-帮派竞赛
	WriteInt(activityType);
	// 接受者
	WriteLong(targetId);

	// 分配中的奖励内容
	WriteShort((short)allocatingItemInfos.Length);
	int allocatingItemInfosIndex = 0;
	int allocatingItemInfosSize = allocatingItemInfos.Length;
	for(allocatingItemInfosIndex=0; allocatingItemInfosIndex<allocatingItemInfosSize; allocatingItemInfosIndex++){

	int allocatingItemInfos_itemId = allocatingItemInfos[allocatingItemInfosIndex].itemId;
	// 已被分配到的奖励道具Id
	WriteInt(allocatingItemInfos_itemId);
	int allocatingItemInfos_num = allocatingItemInfos[allocatingItemInfosIndex].num;
	// 已被分配到的奖励道具数量
	WriteInt(allocatingItemInfos_num);	}
	//end


	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_ALLOCATE_ACTIVITY_ITEM;
	}
	
	public override string getEventType()
	{
		return "";
	}
	

	public AllocateItemInfo[] getAllocatingItemInfos()
	{
		return allocatingItemInfos;
	}

	public void setAllocatingItemInfos(AllocateItemInfo[] allocatingItemInfos)
	{
		this.allocatingItemInfos = allocatingItemInfos;
	}
	}
}