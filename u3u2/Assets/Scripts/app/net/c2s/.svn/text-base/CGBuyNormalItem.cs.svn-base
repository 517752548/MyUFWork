using System;
using System.IO;
namespace app.net
{

/**
 * 购买普通物品
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGBuyNormalItem :BaseMessage
{
	
	/** 商城物品ID */
	private int mallItemId;
	/** 购买数量 */
	private int count;
	
	public CGBuyNormalItem ()
	{
	}
	
	public CGBuyNormalItem (
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
		return (short)MessageType.CG_BUY_NORMAL_ITEM;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}