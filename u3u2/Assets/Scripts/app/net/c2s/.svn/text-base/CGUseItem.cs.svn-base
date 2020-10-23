using System;
using System.IO;
namespace app.net
{

/**
 * 玩家使用道具消息
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGUseItem :BaseMessage
{
	
	/** 背包ID */
	private int bagId;
	/** 道具索引 */
	private int index;
	/** 使用数量 */
	private int count;
	/** 佩戴者类型，如果佩戴者不为0，wearType与roleType对应1:human,2:pet,3:horse,默认对wearId只对2、3有效 */
	private int wearType;
	/** 物品佩戴者的UUID,即当前操作的武将或者宠物id，wearId为0表示没有佩戴者 */
	private long wearerId;
	
	public CGUseItem ()
	{
	}
	
	public CGUseItem (
			int bagId,
			int index,
			int count,
			int wearType,
			long wearerId )
	{
			this.bagId = bagId;
			this.index = index;
			this.count = count;
			this.wearType = wearType;
			this.wearerId = wearerId;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 背包ID
	WriteInt(bagId);
	// 道具索引
	WriteInt(index);
	// 使用数量
	WriteInt(count);
	// 佩戴者类型，如果佩戴者不为0，wearType与roleType对应1:human,2:pet,3:horse,默认对wearId只对2、3有效
	WriteInt(wearType);
	// 物品佩戴者的UUID,即当前操作的武将或者宠物id，wearId为0表示没有佩戴者
	WriteLong(wearerId);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_USE_ITEM;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}