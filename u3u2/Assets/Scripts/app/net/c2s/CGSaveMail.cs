using System;
using System.IO;
namespace app.net
{

/**
 * 保存邮件
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGSaveMail :BaseMessage
{
	
	/** 要保存的邮件uuid */
	private string uuid;
	
	public CGSaveMail ()
	{
	}
	
	public CGSaveMail (
			string uuid )
	{
			this.uuid = uuid;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 要保存的邮件uuid
	WriteString(uuid);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_SAVE_MAIL;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}