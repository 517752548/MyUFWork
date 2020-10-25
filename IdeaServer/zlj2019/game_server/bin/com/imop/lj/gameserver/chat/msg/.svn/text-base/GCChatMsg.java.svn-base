package com.imop.lj.gameserver.chat.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 服务器向客户端发送过滤后的聊天信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCChatMsg extends GCMessage{
	
	/** 聊天数据 */
	private com.imop.lj.common.model.human.ChatInfo chatInfo;

	public GCChatMsg (){
	}
	
	public GCChatMsg (
			com.imop.lj.common.model.human.ChatInfo chatInfo ){
			this.chatInfo = chatInfo;
	}

	@Override
	protected boolean readImpl() {
	// 聊天数据
	com.imop.lj.common.model.human.ChatInfo _chatInfo = new com.imop.lj.common.model.human.ChatInfo();

	// 聊天范围
	int _chatInfo_scope = readInteger();
	//end
	_chatInfo.setScope (_chatInfo_scope);

	// 类型，0默认，1语音
	int _chatInfo_chatType = readInteger();
	//end
	_chatInfo.setChatType (_chatInfo_chatType);

	// 聊天消息发送者角色UUID
	String _chatInfo_fromRoleUUID = readString();
	//end
	_chatInfo.setFromRoleUUID (_chatInfo_fromRoleUUID);

	// 聊天消息发送者角色名称
	String _chatInfo_fromRoleName = readString();
	//end
	_chatInfo.setFromRoleName (_chatInfo_fromRoleName);

	// 聊天消息发送者等级
	int _chatInfo_fromRoleLevel = readInteger();
	//end
	_chatInfo.setFromRoleLevel (_chatInfo_fromRoleLevel);

	// 聊天消息发送者国家
	int _chatInfo_fromRoleCountry = readInteger();
	//end
	_chatInfo.setFromRoleCountry (_chatInfo_fromRoleCountry);

	// 聊天消息发送者模板Id
	int _chatInfo_fromRoleTplId = readInteger();
	//end
	_chatInfo.setFromRoleTplId (_chatInfo_fromRoleTplId);

	// 经过过滤后的聊天消息
	String _chatInfo_content = readString();
	//end
	_chatInfo.setContent (_chatInfo_content);

	// 聊天时间
	long _chatInfo_chatTime = readLong();
	//end
	_chatInfo.setChatTime (_chatInfo_chatTime);

	// 聊天消息接收者角色UUID
	String _chatInfo_toRoleUUID = readString();
	//end
	_chatInfo.setToRoleUUID (_chatInfo_toRoleUUID);

	// 聊天消息接收者角色名
	String _chatInfo_toRoleName = readString();
	//end
	_chatInfo.setToRoleName (_chatInfo_toRoleName);

	// 聊天消息接收者模板Id
	int _chatInfo_toRoleTplId = readInteger();
	//end
	_chatInfo.setToRoleTplId (_chatInfo_toRoleTplId);

	// 发送者的vip等级
	int _chatInfo_fromRoleVipLevel = readInteger();
	//end
	_chatInfo.setFromRoleVipLevel (_chatInfo_fromRoleVipLevel);

	// 接受者的vip等级
	int _chatInfo_toRoleVipLevel = readInteger();
	//end
	_chatInfo.setToRoleVipLevel (_chatInfo_toRoleVipLevel);

	// 发送者是否接受者的好友
	int _chatInfo_IsFriendOfToRole = readInteger();
	//end
	_chatInfo.setIsFriendOfToRole (_chatInfo_IsFriendOfToRole);
	// 发送者qq信息vip等数据
	com.imop.lj.common.model.human.QQInfo _chatInfo_fromQQInfo = new com.imop.lj.common.model.human.QQInfo();

	// 是否黄钻用户，0否，1是
	int _chatInfo_fromQQInfo_isYellowVip = readInteger();
	//end
	_chatInfo_fromQQInfo.setIsYellowVip (_chatInfo_fromQQInfo_isYellowVip);

	// 黄钻等级
	int _chatInfo_fromQQInfo_yellowVipLevel = readInteger();
	//end
	_chatInfo_fromQQInfo.setYellowVipLevel (_chatInfo_fromQQInfo_yellowVipLevel);

	// 是否黄钻年费用户，0否，1是
	int _chatInfo_fromQQInfo_isYellowYearVip = readInteger();
	//end
	_chatInfo_fromQQInfo.setIsYellowYearVip (_chatInfo_fromQQInfo_isYellowYearVip);

	// 是否豪华版黄钻用户，0否，1是
	int _chatInfo_fromQQInfo_isYellowHighVip = readInteger();
	//end
	_chatInfo_fromQQInfo.setIsYellowHighVip (_chatInfo_fromQQInfo_isYellowHighVip);
	_chatInfo.setFromQQInfo (_chatInfo_fromQQInfo);
	// 接受者qq信息vip等数据
	com.imop.lj.common.model.human.QQInfo _chatInfo_toQQInfo = new com.imop.lj.common.model.human.QQInfo();

	// 是否黄钻用户，0否，1是
	int _chatInfo_toQQInfo_isYellowVip = readInteger();
	//end
	_chatInfo_toQQInfo.setIsYellowVip (_chatInfo_toQQInfo_isYellowVip);

	// 黄钻等级
	int _chatInfo_toQQInfo_yellowVipLevel = readInteger();
	//end
	_chatInfo_toQQInfo.setYellowVipLevel (_chatInfo_toQQInfo_yellowVipLevel);

	// 是否黄钻年费用户，0否，1是
	int _chatInfo_toQQInfo_isYellowYearVip = readInteger();
	//end
	_chatInfo_toQQInfo.setIsYellowYearVip (_chatInfo_toQQInfo_isYellowYearVip);

	// 是否豪华版黄钻用户，0否，1是
	int _chatInfo_toQQInfo_isYellowHighVip = readInteger();
	//end
	_chatInfo_toQQInfo.setIsYellowHighVip (_chatInfo_toQQInfo_isYellowHighVip);
	_chatInfo.setToQQInfo (_chatInfo_toQQInfo);

	// 额外扩展字段
	String _chatInfo_ext = readString();
	//end
	_chatInfo.setExt (_chatInfo_ext);



		this.chatInfo = _chatInfo;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	int chatInfo_scope = chatInfo.getScope ();

	// 聊天范围
	writeInteger(chatInfo_scope);

	int chatInfo_chatType = chatInfo.getChatType ();

	// 类型，0默认，1语音
	writeInteger(chatInfo_chatType);

	String chatInfo_fromRoleUUID = chatInfo.getFromRoleUUID ();

	// 聊天消息发送者角色UUID
	writeString(chatInfo_fromRoleUUID);

	String chatInfo_fromRoleName = chatInfo.getFromRoleName ();

	// 聊天消息发送者角色名称
	writeString(chatInfo_fromRoleName);

	int chatInfo_fromRoleLevel = chatInfo.getFromRoleLevel ();

	// 聊天消息发送者等级
	writeInteger(chatInfo_fromRoleLevel);

	int chatInfo_fromRoleCountry = chatInfo.getFromRoleCountry ();

	// 聊天消息发送者国家
	writeInteger(chatInfo_fromRoleCountry);

	int chatInfo_fromRoleTplId = chatInfo.getFromRoleTplId ();

	// 聊天消息发送者模板Id
	writeInteger(chatInfo_fromRoleTplId);

	String chatInfo_content = chatInfo.getContent ();

	// 经过过滤后的聊天消息
	writeString(chatInfo_content);

	long chatInfo_chatTime = chatInfo.getChatTime ();

	// 聊天时间
	writeLong(chatInfo_chatTime);

	String chatInfo_toRoleUUID = chatInfo.getToRoleUUID ();

	// 聊天消息接收者角色UUID
	writeString(chatInfo_toRoleUUID);

	String chatInfo_toRoleName = chatInfo.getToRoleName ();

	// 聊天消息接收者角色名
	writeString(chatInfo_toRoleName);

	int chatInfo_toRoleTplId = chatInfo.getToRoleTplId ();

	// 聊天消息接收者模板Id
	writeInteger(chatInfo_toRoleTplId);

	int chatInfo_fromRoleVipLevel = chatInfo.getFromRoleVipLevel ();

	// 发送者的vip等级
	writeInteger(chatInfo_fromRoleVipLevel);

	int chatInfo_toRoleVipLevel = chatInfo.getToRoleVipLevel ();

	// 接受者的vip等级
	writeInteger(chatInfo_toRoleVipLevel);

	int chatInfo_IsFriendOfToRole = chatInfo.getIsFriendOfToRole ();

	// 发送者是否接受者的好友
	writeInteger(chatInfo_IsFriendOfToRole);

	com.imop.lj.common.model.human.QQInfo chatInfo_fromQQInfo = chatInfo.getFromQQInfo ();

	int chatInfo_fromQQInfo_isYellowVip = chatInfo_fromQQInfo.getIsYellowVip ();

	// 是否黄钻用户，0否，1是
	writeInteger(chatInfo_fromQQInfo_isYellowVip);

	int chatInfo_fromQQInfo_yellowVipLevel = chatInfo_fromQQInfo.getYellowVipLevel ();

	// 黄钻等级
	writeInteger(chatInfo_fromQQInfo_yellowVipLevel);

	int chatInfo_fromQQInfo_isYellowYearVip = chatInfo_fromQQInfo.getIsYellowYearVip ();

	// 是否黄钻年费用户，0否，1是
	writeInteger(chatInfo_fromQQInfo_isYellowYearVip);

	int chatInfo_fromQQInfo_isYellowHighVip = chatInfo_fromQQInfo.getIsYellowHighVip ();

	// 是否豪华版黄钻用户，0否，1是
	writeInteger(chatInfo_fromQQInfo_isYellowHighVip);

	com.imop.lj.common.model.human.QQInfo chatInfo_toQQInfo = chatInfo.getToQQInfo ();

	int chatInfo_toQQInfo_isYellowVip = chatInfo_toQQInfo.getIsYellowVip ();

	// 是否黄钻用户，0否，1是
	writeInteger(chatInfo_toQQInfo_isYellowVip);

	int chatInfo_toQQInfo_yellowVipLevel = chatInfo_toQQInfo.getYellowVipLevel ();

	// 黄钻等级
	writeInteger(chatInfo_toQQInfo_yellowVipLevel);

	int chatInfo_toQQInfo_isYellowYearVip = chatInfo_toQQInfo.getIsYellowYearVip ();

	// 是否黄钻年费用户，0否，1是
	writeInteger(chatInfo_toQQInfo_isYellowYearVip);

	int chatInfo_toQQInfo_isYellowHighVip = chatInfo_toQQInfo.getIsYellowHighVip ();

	// 是否豪华版黄钻用户，0否，1是
	writeInteger(chatInfo_toQQInfo_isYellowHighVip);

	String chatInfo_ext = chatInfo.getExt ();

	// 额外扩展字段
	writeString(chatInfo_ext);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_CHAT_MSG;
	}
	
	@Override
	public String getTypeName() {
		return "GC_CHAT_MSG";
	}

	public com.imop.lj.common.model.human.ChatInfo getChatInfo(){
		return chatInfo;
	}
		
	public void setChatInfo(com.imop.lj.common.model.human.ChatInfo chatInfo){
		this.chatInfo = chatInfo;
	}
}