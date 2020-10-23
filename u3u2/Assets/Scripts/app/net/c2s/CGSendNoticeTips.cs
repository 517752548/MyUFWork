using System;
using System.IO;
namespace app.net
{

/**
 * 发送小信封
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGSendNoticeTips :BaseMessage
{
	
	/** 内容 */
	private string content;
	/** 发送目标 */
	private long roleId;
	
	public CGSendNoticeTips ()
	{
	}
	
	public CGSendNoticeTips (
			string content,
			long roleId )
	{
			this.content = content;
			this.roleId = roleId;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 内容
	WriteString(content);
	// 发送目标
	WriteLong(roleId);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_SEND_NOTICE_TIPS;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}