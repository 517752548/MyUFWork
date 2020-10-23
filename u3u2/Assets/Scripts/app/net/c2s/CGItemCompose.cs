using System;
using System.IO;
namespace app.net
{

/**
 * 道具合成
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGItemCompose :BaseMessage
{
	
	/** 背包ID */
	private int bagId;
	/** 道具索引 */
	private int index;
	/** 0合成一个，1批量合成 */
	private int batchFlag;
	
	public CGItemCompose ()
	{
	}
	
	public CGItemCompose (
			int bagId,
			int index,
			int batchFlag )
	{
			this.bagId = bagId;
			this.index = index;
			this.batchFlag = batchFlag;
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
	// 0合成一个，1批量合成
	WriteInt(batchFlag);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_ITEM_COMPOSE;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}