using System;
using System.IO;
namespace app.net
{

/**
 * 发送军团邮件
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGSendGuildMail :BaseMessage
{
	
	/** 邮件标题 */
	private string title;
	/** 邮件内容 */
	private string content;
	
	public CGSendGuildMail ()
	{
	}
	
	public CGSendGuildMail (
			string title,
			string content )
	{
			this.title = title;
			this.content = content;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 邮件标题
	WriteString(title);
	// 邮件内容
	WriteString(content);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_SEND_GUILD_MAIL;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}