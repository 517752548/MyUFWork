
using System;
namespace app.net
{
/**
 * 聊天信息列表
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCChatMsgList :BaseMessage
{
	/** 聊天数据列表 */
	private ChatInfoData[] chatInfos;

	public GCChatMsgList ()
	{
	}

	protected override void ReadImpl()
	{

	// 聊天数据列表
	int chatInfosSize = ReadShort();
	ChatInfoData[] _chatInfos = new ChatInfoData[chatInfosSize];
	int chatInfosIndex = 0;
	ChatInfoData _chatInfosTmp = null;
	for(chatInfosIndex=0; chatInfosIndex<chatInfosSize; chatInfosIndex++){
		_chatInfosTmp = new ChatInfoData();
		_chatInfos[chatInfosIndex] = _chatInfosTmp;
	// 聊天范围
	int _chatInfos_scope = ReadInt();	_chatInfosTmp.scope = _chatInfos_scope;
		// 类型，0默认，1语音
	int _chatInfos_chatType = ReadInt();	_chatInfosTmp.chatType = _chatInfos_chatType;
		// 聊天消息发送者角色UUID
	string _chatInfos_fromRoleUUID = ReadString();	_chatInfosTmp.fromRoleUUID = _chatInfos_fromRoleUUID;
		// 聊天消息发送者角色名称
	string _chatInfos_fromRoleName = ReadString();	_chatInfosTmp.fromRoleName = _chatInfos_fromRoleName;
		// 聊天消息发送者等级
	int _chatInfos_fromRoleLevel = ReadInt();	_chatInfosTmp.fromRoleLevel = _chatInfos_fromRoleLevel;
		// 聊天消息发送者国家
	int _chatInfos_fromRoleCountry = ReadInt();	_chatInfosTmp.fromRoleCountry = _chatInfos_fromRoleCountry;
		// 聊天消息发送者模板Id
	int _chatInfos_fromRoleTplId = ReadInt();	_chatInfosTmp.fromRoleTplId = _chatInfos_fromRoleTplId;
		// 经过过滤后的聊天消息
	string _chatInfos_content = ReadString();	_chatInfosTmp.content = _chatInfos_content;
		// 聊天时间
	long _chatInfos_chatTime = ReadLong();	_chatInfosTmp.chatTime = _chatInfos_chatTime;
		// 聊天消息接收者角色UUID
	string _chatInfos_toRoleUUID = ReadString();	_chatInfosTmp.toRoleUUID = _chatInfos_toRoleUUID;
		// 聊天消息接收者角色名
	string _chatInfos_toRoleName = ReadString();	_chatInfosTmp.toRoleName = _chatInfos_toRoleName;
		// 聊天消息接收者模板Id
	int _chatInfos_toRoleTplId = ReadInt();	_chatInfosTmp.toRoleTplId = _chatInfos_toRoleTplId;
		// 发送者的vip等级
	int _chatInfos_fromRoleVipLevel = ReadInt();	_chatInfosTmp.fromRoleVipLevel = _chatInfos_fromRoleVipLevel;
		// 接受者的vip等级
	int _chatInfos_toRoleVipLevel = ReadInt();	_chatInfosTmp.toRoleVipLevel = _chatInfos_toRoleVipLevel;
		// 发送者是否接受者的好友
	int _chatInfos_IsFriendOfToRole = ReadInt();	_chatInfosTmp.IsFriendOfToRole = _chatInfos_IsFriendOfToRole;
		// 发送者qq信息vip等数据
	QQInfoData _chatInfos_fromQQInfo = new QQInfoData();
	// 是否黄钻用户，0否，1是
	int _chatInfos_fromQQInfo_isYellowVip = ReadInt();	_chatInfos_fromQQInfo.isYellowVip = _chatInfos_fromQQInfo_isYellowVip;
	// 黄钻等级
	int _chatInfos_fromQQInfo_yellowVipLevel = ReadInt();	_chatInfos_fromQQInfo.yellowVipLevel = _chatInfos_fromQQInfo_yellowVipLevel;
	// 是否黄钻年费用户，0否，1是
	int _chatInfos_fromQQInfo_isYellowYearVip = ReadInt();	_chatInfos_fromQQInfo.isYellowYearVip = _chatInfos_fromQQInfo_isYellowYearVip;
	// 是否豪华版黄钻用户，0否，1是
	int _chatInfos_fromQQInfo_isYellowHighVip = ReadInt();	_chatInfos_fromQQInfo.isYellowHighVip = _chatInfos_fromQQInfo_isYellowHighVip;
	_chatInfosTmp.fromQQInfo = _chatInfos_fromQQInfo;
		// 接受者qq信息vip等数据
	QQInfoData _chatInfos_toQQInfo = new QQInfoData();
	// 是否黄钻用户，0否，1是
	int _chatInfos_toQQInfo_isYellowVip = ReadInt();	_chatInfos_toQQInfo.isYellowVip = _chatInfos_toQQInfo_isYellowVip;
	// 黄钻等级
	int _chatInfos_toQQInfo_yellowVipLevel = ReadInt();	_chatInfos_toQQInfo.yellowVipLevel = _chatInfos_toQQInfo_yellowVipLevel;
	// 是否黄钻年费用户，0否，1是
	int _chatInfos_toQQInfo_isYellowYearVip = ReadInt();	_chatInfos_toQQInfo.isYellowYearVip = _chatInfos_toQQInfo_isYellowYearVip;
	// 是否豪华版黄钻用户，0否，1是
	int _chatInfos_toQQInfo_isYellowHighVip = ReadInt();	_chatInfos_toQQInfo.isYellowHighVip = _chatInfos_toQQInfo_isYellowHighVip;
	_chatInfosTmp.toQQInfo = _chatInfos_toQQInfo;
		// 额外扩展字段
	string _chatInfos_ext = ReadString();	_chatInfosTmp.ext = _chatInfos_ext;
		}
	//end



		this.chatInfos = _chatInfos;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_CHAT_MSG_LIST;
	}
	
	public override string getEventType()
	{
		return ChatGCHandler.GCChatMsgListEvent;
	}
	

	public ChatInfoData[] getChatInfos(){
		return chatInfos;
	}


}
}