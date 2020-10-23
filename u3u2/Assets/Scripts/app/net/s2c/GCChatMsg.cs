
using System;
namespace app.net
{
/**
 * 服务器向客户端发送过滤后的聊天信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCChatMsg :BaseMessage
{
	/** 聊天数据 */
	private ChatInfoData chatInfo;

	public GCChatMsg ()
	{
	}

	protected override void ReadImpl()
	{
	// 聊天数据
	ChatInfoData _chatInfo = new ChatInfoData();
	// 聊天范围
	int _chatInfo_scope = ReadInt();	_chatInfo.scope = _chatInfo_scope;
	// 类型，0默认，1语音
	int _chatInfo_chatType = ReadInt();	_chatInfo.chatType = _chatInfo_chatType;
	// 聊天消息发送者角色UUID
	string _chatInfo_fromRoleUUID = ReadString();	_chatInfo.fromRoleUUID = _chatInfo_fromRoleUUID;
	// 聊天消息发送者角色名称
	string _chatInfo_fromRoleName = ReadString();	_chatInfo.fromRoleName = _chatInfo_fromRoleName;
	// 聊天消息发送者等级
	int _chatInfo_fromRoleLevel = ReadInt();	_chatInfo.fromRoleLevel = _chatInfo_fromRoleLevel;
	// 聊天消息发送者国家
	int _chatInfo_fromRoleCountry = ReadInt();	_chatInfo.fromRoleCountry = _chatInfo_fromRoleCountry;
	// 聊天消息发送者模板Id
	int _chatInfo_fromRoleTplId = ReadInt();	_chatInfo.fromRoleTplId = _chatInfo_fromRoleTplId;
	// 经过过滤后的聊天消息
	string _chatInfo_content = ReadString();	_chatInfo.content = _chatInfo_content;
	// 聊天时间
	long _chatInfo_chatTime = ReadLong();	_chatInfo.chatTime = _chatInfo_chatTime;
	// 聊天消息接收者角色UUID
	string _chatInfo_toRoleUUID = ReadString();	_chatInfo.toRoleUUID = _chatInfo_toRoleUUID;
	// 聊天消息接收者角色名
	string _chatInfo_toRoleName = ReadString();	_chatInfo.toRoleName = _chatInfo_toRoleName;
	// 聊天消息接收者模板Id
	int _chatInfo_toRoleTplId = ReadInt();	_chatInfo.toRoleTplId = _chatInfo_toRoleTplId;
	// 发送者的vip等级
	int _chatInfo_fromRoleVipLevel = ReadInt();	_chatInfo.fromRoleVipLevel = _chatInfo_fromRoleVipLevel;
	// 接受者的vip等级
	int _chatInfo_toRoleVipLevel = ReadInt();	_chatInfo.toRoleVipLevel = _chatInfo_toRoleVipLevel;
	// 发送者是否接受者的好友
	int _chatInfo_IsFriendOfToRole = ReadInt();	_chatInfo.IsFriendOfToRole = _chatInfo_IsFriendOfToRole;
	// 发送者qq信息vip等数据
	QQInfoData _chatInfo_fromQQInfo = new QQInfoData();
	// 是否黄钻用户，0否，1是
	int _chatInfo_fromQQInfo_isYellowVip = ReadInt();	_chatInfo_fromQQInfo.isYellowVip = _chatInfo_fromQQInfo_isYellowVip;
	// 黄钻等级
	int _chatInfo_fromQQInfo_yellowVipLevel = ReadInt();	_chatInfo_fromQQInfo.yellowVipLevel = _chatInfo_fromQQInfo_yellowVipLevel;
	// 是否黄钻年费用户，0否，1是
	int _chatInfo_fromQQInfo_isYellowYearVip = ReadInt();	_chatInfo_fromQQInfo.isYellowYearVip = _chatInfo_fromQQInfo_isYellowYearVip;
	// 是否豪华版黄钻用户，0否，1是
	int _chatInfo_fromQQInfo_isYellowHighVip = ReadInt();	_chatInfo_fromQQInfo.isYellowHighVip = _chatInfo_fromQQInfo_isYellowHighVip;
	_chatInfo.fromQQInfo = _chatInfo_fromQQInfo;
	// 接受者qq信息vip等数据
	QQInfoData _chatInfo_toQQInfo = new QQInfoData();
	// 是否黄钻用户，0否，1是
	int _chatInfo_toQQInfo_isYellowVip = ReadInt();	_chatInfo_toQQInfo.isYellowVip = _chatInfo_toQQInfo_isYellowVip;
	// 黄钻等级
	int _chatInfo_toQQInfo_yellowVipLevel = ReadInt();	_chatInfo_toQQInfo.yellowVipLevel = _chatInfo_toQQInfo_yellowVipLevel;
	// 是否黄钻年费用户，0否，1是
	int _chatInfo_toQQInfo_isYellowYearVip = ReadInt();	_chatInfo_toQQInfo.isYellowYearVip = _chatInfo_toQQInfo_isYellowYearVip;
	// 是否豪华版黄钻用户，0否，1是
	int _chatInfo_toQQInfo_isYellowHighVip = ReadInt();	_chatInfo_toQQInfo.isYellowHighVip = _chatInfo_toQQInfo_isYellowHighVip;
	_chatInfo.toQQInfo = _chatInfo_toQQInfo;
	// 额外扩展字段
	string _chatInfo_ext = ReadString();	_chatInfo.ext = _chatInfo_ext;



		this.chatInfo = _chatInfo;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_CHAT_MSG;
	}
	
	public override string getEventType()
	{
		return ChatGCHandler.GCChatMsgEvent;
	}
	

	public ChatInfoData getChatInfo(){
		return chatInfo;
	}
		

}
}