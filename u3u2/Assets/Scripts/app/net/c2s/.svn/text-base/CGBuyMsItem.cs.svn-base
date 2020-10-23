using System;
using System.IO;
namespace app.net
{

/**
 * 购买神秘商店物品
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGBuyMsItem :BaseMessage
{
	
	/** 神秘商店物品ID */
	private int msItemId;
	
	public CGBuyMsItem ()
	{
	}
	
	public CGBuyMsItem (
			int msItemId )
	{
			this.msItemId = msItemId;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 神秘商店物品ID
	WriteInt(msItemId);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_BUY_MS_ITEM;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}