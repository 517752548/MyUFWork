using System;
using System.IO;
namespace app.net
{

/**
 * 举报
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGReportPlayer :BaseMessage
{
	
	/** 聊天范围 */
	private int scope;
	/** 被举报的角色ID */
	private long charId;
	/** 被举报的角色名称 */
	private string charName;
	/** 举报的聊天内容 */
	private string chatText;
	/** 消息令牌 */
	private string token;
	
	public CGReportPlayer ()
	{
	}
	
	public CGReportPlayer (
			int scope,
			long charId,
			string charName,
			string chatText,
			string token )
	{
			this.scope = scope;
			this.charId = charId;
			this.charName = charName;
			this.chatText = chatText;
			this.token = token;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 聊天范围
	WriteInt(scope);
	// 被举报的角色ID
	WriteLong(charId);
	// 被举报的角色名称
	WriteString(charName);
	// 举报的聊天内容
	WriteString(chatText);
	// 消息令牌
	WriteString(token);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_REPORT_PLAYER;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}