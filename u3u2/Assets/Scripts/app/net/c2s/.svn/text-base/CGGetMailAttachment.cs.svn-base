using System;
using System.IO;
namespace app.net
{

/**
 * 领取邮件附件
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGGetMailAttachment :BaseMessage
{
	
	/** 要阅读的邮件uuid */
	private string uuid;
	
	public CGGetMailAttachment ()
	{
	}
	
	public CGGetMailAttachment (
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
		return (short)MessageType.CG_GET_MAIL_ATTACHMENT;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}