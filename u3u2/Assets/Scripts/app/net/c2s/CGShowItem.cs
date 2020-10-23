using System;
using System.IO;
namespace app.net
{

/**
 * 按uuid查看道具，聊天中使用
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGShowItem :BaseMessage
{
	
	/** 道具唯一Id */
	private string itemUUID;
	
	public CGShowItem ()
	{
	}
	
	public CGShowItem (
			string itemUUID )
	{
			this.itemUUID = itemUUID;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 道具唯一Id
	WriteString(itemUUID);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_SHOW_ITEM;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}