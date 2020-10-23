using System;
using System.IO;
namespace app.net
{

/**
 * 阅读邮件
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGReadMail :BaseMessage
{
	
	/** 要阅读的邮件uuid */
	private string uuid;
	
	public CGReadMail ()
	{
	}
	
	public CGReadMail (
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
	// 要阅读的邮件uuid
	WriteString(uuid);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_READ_MAIL;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}