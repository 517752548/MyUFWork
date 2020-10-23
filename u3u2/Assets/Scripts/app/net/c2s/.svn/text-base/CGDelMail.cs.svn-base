using System;
using System.IO;
namespace app.net
{

/**
 * 删除邮件
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGDelMail :BaseMessage
{
	
	/** 要删除的邮件uuid */
	private string uuid;
	
	public CGDelMail ()
	{
	}
	
	public CGDelMail (
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
	// 要删除的邮件uuid
	WriteString(uuid);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_DEL_MAIL;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}