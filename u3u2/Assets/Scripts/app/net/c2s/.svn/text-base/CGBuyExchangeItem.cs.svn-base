using System;
using System.IO;
namespace app.net
{

/**
 * 兑换商城物品
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGBuyExchangeItem :BaseMessage
{
	
	/** 商城物品ID */
	private int mallItemId;
	/** 购买数量 */
	private int count;
	
	public CGBuyExchangeItem ()
	{
	}
	
	public CGBuyExchangeItem (
			int mallItemId,
			int count )
	{
			this.mallItemId = mallItemId;
			this.count = count;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 商城物品ID
	WriteInt(mallItemId);
	// 购买数量
	WriteInt(count);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_BUY_EXCHANGE_ITEM;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}