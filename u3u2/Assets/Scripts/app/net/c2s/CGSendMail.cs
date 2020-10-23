using System;
using System.IO;
namespace app.net
{

/**
 * 发送邮件
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGSendMail :BaseMessage
{
	
	/** 收件人名称 */
	private string recName;
	/** 邮件标题 */
	private string title;
	/** 邮件内容 */
	private string content;
	
	public CGSendMail ()
	{
	}
	
	public CGSendMail (
			string recName,
			string title,
			string content )
	{
			this.recName = recName;
			this.title = title;
			this.content = content;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 收件人名称
	WriteString(recName);
	// 邮件标题
	WriteString(title);
	// 邮件内容
	WriteString(content);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_SEND_MAIL;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}