using System;
using System.IO;
namespace app.net
{

/**
 * 购买限时物品
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGBuyTimeLimitItem :BaseMessage
{
	
	/** 限时列表ID */
	private string queueUUID;
	/** 商城物品ID */
	private int mallItemId;
	/** 购买数量 */
	private int count;
	
	public CGBuyTimeLimitItem ()
	{
	}
	
	public CGBuyTimeLimitItem (
			string queueUUID,
			int mallItemId,
			int count )
	{
			this.queueUUID = queueUUID;
			this.mallItemId = mallItemId;
			this.count = count;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 限时列表ID
	WriteString(queueUUID);
	// 商城物品ID
	WriteInt(mallItemId);
	// 购买数量
	WriteInt(count);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_BUY_TIME_LIMIT_ITEM;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}