using System;
using System.IO;
namespace app.net
{

/**
 * 移动物品，用于拖拽动作
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGMoveItem :BaseMessage
{
	
	/** 来源包id */
	private int fromBagId;
	/** 道具在来源背包内位置索引 */
	private int fromIndex;
	/** 目的包id */
	private int toBagId;
	/** 道具在目的包内位置索引 */
	private int toIndex;
	/** 物品佩戴者的UUID,即当前操作的武将宠物id */
	private long wearerId;
	
	public CGMoveItem ()
	{
	}
	
	public CGMoveItem (
			int fromBagId,
			int fromIndex,
			int toBagId,
			int toIndex,
			long wearerId )
	{
			this.fromBagId = fromBagId;
			this.fromIndex = fromIndex;
			this.toBagId = toBagId;
			this.toIndex = toIndex;
			this.wearerId = wearerId;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 来源包id
	WriteInt(fromBagId);
	// 道具在来源背包内位置索引
	WriteInt(fromIndex);
	// 目的包id
	WriteInt(toBagId);
	// 道具在目的包内位置索引
	WriteInt(toIndex);
	// 物品佩戴者的UUID,即当前操作的武将宠物id
	WriteLong(wearerId);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_MOVE_ITEM;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}