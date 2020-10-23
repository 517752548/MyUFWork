using System;
using System.IO;
namespace app.net
{

/**
 * 服务器端向客户端发送的聊天消息
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGChatMsg :BaseMessage
{
	
	/** 聊天范围 */
	private int scope;
	/** 聊天消息接收的玩家 */
	private string destRoleName;
	/** 消息接收玩家的UUID */
	private string destRoleUUID;
	/** 聊天消息 */
	private string content;
	/** 类型，0默认，1语音 */
	private int chatType;
	
	public CGChatMsg ()
	{
	}
	
	public CGChatMsg (
			int scope,
			string destRoleName,
			string destRoleUUID,
			string content,
			int chatType )
	{
			this.scope = scope;
			this.destRoleName = destRoleName;
			this.destRoleUUID = destRoleUUID;
			this.content = content;
			this.chatType = chatType;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 聊天范围
	WriteInt(scope);
	// 聊天消息接收的玩家
	WriteString(destRoleName);
	// 消息接收玩家的UUID
	WriteString(destRoleUUID);
	// 聊天消息
	WriteString(content);
	// 类型，0默认，1语音
	WriteInt(chatType);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_CHAT_MSG;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}