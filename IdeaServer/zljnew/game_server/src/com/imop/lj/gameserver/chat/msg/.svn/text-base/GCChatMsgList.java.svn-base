package com.imop.lj.gameserver.chat.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 聊天信息列表
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCChatMsgList extends GCMessage{
	
	/** 聊天数据列表 */
	private com.imop.lj.common.model.human.ChatInfo[] chatInfos;

	public GCChatMsgList (){
	}
	
	public GCChatMsgList (
			com.imop.lj.common.model.human.ChatInfo[] chatInfos ){
			this.chatInfos = chatInfos;
	}

	@Override
	protected boolean readImpl() {

	// 聊天数据列表
	int chatInfosSize = readUnsignedShort();
	com.imop.lj.common.model.human.ChatInfo[] _chatInfos = new com.imop.lj.common.model.human.ChatInfo[chatInfosSize];
	int chatInfosIndex = 0;
	for(chatInfosIndex=0; chatInfosIndex<chatInfosSize; chatInfosIndex++){
		_chatInfos[chatInfosIndex] = new com.imop.lj.common.model.human.ChatInfo();
	// 聊天范围
	int _chatInfos_scope = readInteger();
	//end
	_chatInfos[chatInfosIndex].setScope (_chatInfos_scope);

	// 类型，0默认，1语音
	int _chatInfos_chatType = readInteger();
	//end
	_chatInfos[chatInfosIndex].setChatType (_chatInfos_chatType);

	// 聊天消息发送者角色UUID
	String _chatInfos_fromRoleUUID = readString();
	//end
	_chatInfos[chatInfosIndex].setFromRoleUUID (_chatInfos_fromRoleUUID);

	// 聊天消息发送者角色名称
	String _chatInfos_fromRoleName = readString();
	//end
	_chatInfos[chatInfosIndex].setFromRoleName (_chatInfos_fromRoleName);

	// 聊天消息发送者等级
	int _chatInfos_fromRoleLevel = readInteger();
	//end
	_chatInfos[chatInfosIndex].setFromRoleLevel (_chatInfos_fromRoleLevel);

	// 聊天消息发送者国家
	int _chatInfos_fromRoleCountry = readInteger();
	//end
	_chatInfos[chatInfosIndex].setFromRoleCountry (_chatInfos_fromRoleCountry);

	// 聊天消息发送者模板Id
	int _chatInfos_fromRoleTplId = readInteger();
	//end
	_chatInfos[chatInfosIndex].setFromRoleTplId (_chatInfos_fromRoleTplId);

	// 经过过滤后的聊天消息
	String _chatInfos_content = readString();
	//end
	_chatInfos[chatInfosIndex].setContent (_chatInfos_content);

	// 聊天时间
	long _chatInfos_chatTime = readLong();
	//end
	_chatInfos[chatInfosIndex].setChatTime (_chatInfos_chatTime);

	// 聊天消息接收者角色UUID
	String _chatInfos_toRoleUUID = readString();
	//end
	_chatInfos[chatInfosIndex].setToRoleUUID (_chatInfos_toRoleUUID);

	// 聊天消息接收者角色名
	String _chatInfos_toRoleName = readString();
	//end
	_chatInfos[chatInfosIndex].setToRoleName (_chatInfos_toRoleName);

	// 聊天消息接收者模板Id
	int _chatInfos_toRoleTplId = readInteger();
	//end
	_chatInfos[chatInfosIndex].setToRoleTplId (_chatInfos_toRoleTplId);

	// 发送者的vip等级
	int _chatInfos_fromRoleVipLevel = readInteger();
	//end
	_chatInfos[chatInfosIndex].setFromRoleVipLevel (_chatInfos_fromRoleVipLevel);

	// 接受者的vip等级
	int _chatInfos_toRoleVipLevel = readInteger();
	//end
	_chatInfos[chatInfosIndex].setToRoleVipLevel (_chatInfos_toRoleVipLevel);

	// 发送者是否接受者的好友
	int _chatInfos_IsFriendOfToRole = readInteger();
	//end
	_chatInfos[chatInfosIndex].setIsFriendOfToRole (_chatInfos_IsFriendOfToRole);
	// 发送者qq信息vip等数据
	com.imop.lj.common.model.human.QQInfo _chatInfos_fromQQInfo = new com.imop.lj.common.model.human.QQInfo();

	// 是否黄钻用户，0否，1是
	int _chatInfos_fromQQInfo_isYellowVip = readInteger();
	//end
	_chatInfos_fromQQInfo.setIsYellowVip (_chatInfos_fromQQInfo_isYellowVip);

	// 黄钻等级
	int _chatInfos_fromQQInfo_yellowVipLevel = readInteger();
	//end
	_chatInfos_fromQQInfo.setYellowVipLevel (_chatInfos_fromQQInfo_yellowVipLevel);

	// 是否黄钻年费用户，0否，1是
	int _chatInfos_fromQQInfo_isYellowYearVip = readInteger();
	//end
	_chatInfos_fromQQInfo.setIsYellowYearVip (_chatInfos_fromQQInfo_isYellowYearVip);

	// 是否豪华版黄钻用户，0否，1是
	int _chatInfos_fromQQInfo_isYellowHighVip = readInteger();
	//end
	_chatInfos_fromQQInfo.setIsYellowHighVip (_chatInfos_fromQQInfo_isYellowHighVip);
	_chatInfos[chatInfosIndex].setFromQQInfo (_chatInfos_fromQQInfo);
	// 接受者qq信息vip等数据
	com.imop.lj.common.model.human.QQInfo _chatInfos_toQQInfo = new com.imop.lj.common.model.human.QQInfo();

	// 是否黄钻用户，0否，1是
	int _chatInfos_toQQInfo_isYellowVip = readInteger();
	//end
	_chatInfos_toQQInfo.setIsYellowVip (_chatInfos_toQQInfo_isYellowVip);

	// 黄钻等级
	int _chatInfos_toQQInfo_yellowVipLevel = readInteger();
	//end
	_chatInfos_toQQInfo.setYellowVipLevel (_chatInfos_toQQInfo_yellowVipLevel);

	// 是否黄钻年费用户，0否，1是
	int _chatInfos_toQQInfo_isYellowYearVip = readInteger();
	//end
	_chatInfos_toQQInfo.setIsYellowYearVip (_chatInfos_toQQInfo_isYellowYearVip);

	// 是否豪华版黄钻用户，0否，1是
	int _chatInfos_toQQInfo_isYellowHighVip = readInteger();
	//end
	_chatInfos_toQQInfo.setIsYellowHighVip (_chatInfos_toQQInfo_isYellowHighVip);
	_chatInfos[chatInfosIndex].setToQQInfo (_chatInfos_toQQInfo);

	// 额外扩展字段
	String _chatInfos_ext = readString();
	//end
	_chatInfos[chatInfosIndex].setExt (_chatInfos_ext);
	}
	//end



		this.chatInfos = _chatInfos;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 聊天数据列表
	writeShort(chatInfos.length);
	int chatInfosIndex = 0;
	int chatInfosSize = chatInfos.length;
	for(chatInfosIndex=0; chatInfosIndex<chatInfosSize; chatInfosIndex++){

	int chatInfos_scope = chatInfos[chatInfosIndex].getScope();

	// 聊天范围
	writeInteger(chatInfos_scope);

	int chatInfos_chatType = chatInfos[chatInfosIndex].getChatType();

	// 类型，0默认，1语音
	writeInteger(chatInfos_chatType);

	String chatInfos_fromRoleUUID = chatInfos[chatInfosIndex].getFromRoleUUID();

	// 聊天消息发送者角色UUID
	writeString(chatInfos_fromRoleUUID);

	String chatInfos_fromRoleName = chatInfos[chatInfosIndex].getFromRoleName();

	// 聊天消息发送者角色名称
	writeString(chatInfos_fromRoleName);

	int chatInfos_fromRoleLevel = chatInfos[chatInfosIndex].getFromRoleLevel();

	// 聊天消息发送者等级
	writeInteger(chatInfos_fromRoleLevel);

	int chatInfos_fromRoleCountry = chatInfos[chatInfosIndex].getFromRoleCountry();

	// 聊天消息发送者国家
	writeInteger(chatInfos_fromRoleCountry);

	int chatInfos_fromRoleTplId = chatInfos[chatInfosIndex].getFromRoleTplId();

	// 聊天消息发送者模板Id
	writeInteger(chatInfos_fromRoleTplId);

	String chatInfos_content = chatInfos[chatInfosIndex].getContent();

	// 经过过滤后的聊天消息
	writeString(chatInfos_content);

	long chatInfos_chatTime = chatInfos[chatInfosIndex].getChatTime();

	// 聊天时间
	writeLong(chatInfos_chatTime);

	String chatInfos_toRoleUUID = chatInfos[chatInfosIndex].getToRoleUUID();

	// 聊天消息接收者角色UUID
	writeString(chatInfos_toRoleUUID);

	String chatInfos_toRoleName = chatInfos[chatInfosIndex].getToRoleName();

	// 聊天消息接收者角色名
	writeString(chatInfos_toRoleName);

	int chatInfos_toRoleTplId = chatInfos[chatInfosIndex].getToRoleTplId();

	// 聊天消息接收者模板Id
	writeInteger(chatInfos_toRoleTplId);

	int chatInfos_fromRoleVipLevel = chatInfos[chatInfosIndex].getFromRoleVipLevel();

	// 发送者的vip等级
	writeInteger(chatInfos_fromRoleVipLevel);

	int chatInfos_toRoleVipLevel = chatInfos[chatInfosIndex].getToRoleVipLevel();

	// 接受者的vip等级
	writeInteger(chatInfos_toRoleVipLevel);

	int chatInfos_IsFriendOfToRole = chatInfos[chatInfosIndex].getIsFriendOfToRole();

	// 发送者是否接受者的好友
	writeInteger(chatInfos_IsFriendOfToRole);

	com.imop.lj.common.model.human.QQInfo chatInfos_fromQQInfo = chatInfos[chatInfosIndex].getFromQQInfo();

	int chatInfos_fromQQInfo_isYellowVip = chatInfos_fromQQInfo.getIsYellowVip ();

	// 是否黄钻用户，0否，1是
	writeInteger(chatInfos_fromQQInfo_isYellowVip);

	int chatInfos_fromQQInfo_yellowVipLevel = chatInfos_fromQQInfo.getYellowVipLevel ();

	// 黄钻等级
	writeInteger(chatInfos_fromQQInfo_yellowVipLevel);

	int chatInfos_fromQQInfo_isYellowYearVip = chatInfos_fromQQInfo.getIsYellowYearVip ();

	// 是否黄钻年费用户，0否，1是
	writeInteger(chatInfos_fromQQInfo_isYellowYearVip);

	int chatInfos_fromQQInfo_isYellowHighVip = chatInfos_fromQQInfo.getIsYellowHighVip ();

	// 是否豪华版黄钻用户，0否，1是
	writeInteger(chatInfos_fromQQInfo_isYellowHighVip);

	com.imop.lj.common.model.human.QQInfo chatInfos_toQQInfo = chatInfos[chatInfosIndex].getToQQInfo();

	int chatInfos_toQQInfo_isYellowVip = chatInfos_toQQInfo.getIsYellowVip ();

	// 是否黄钻用户，0否，1是
	writeInteger(chatInfos_toQQInfo_isYellowVip);

	int chatInfos_toQQInfo_yellowVipLevel = chatInfos_toQQInfo.getYellowVipLevel ();

	// 黄钻等级
	writeInteger(chatInfos_toQQInfo_yellowVipLevel);

	int chatInfos_toQQInfo_isYellowYearVip = chatInfos_toQQInfo.getIsYellowYearVip ();

	// 是否黄钻年费用户，0否，1是
	writeInteger(chatInfos_toQQInfo_isYellowYearVip);

	int chatInfos_toQQInfo_isYellowHighVip = chatInfos_toQQInfo.getIsYellowHighVip ();

	// 是否豪华版黄钻用户，0否，1是
	writeInteger(chatInfos_toQQInfo_isYellowHighVip);

	String chatInfos_ext = chatInfos[chatInfosIndex].getExt();

	// 额外扩展字段
	writeString(chatInfos_ext);
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_CHAT_MSG_LIST;
	}
	
	@Override
	public String getTypeName() {
		return "GC_CHAT_MSG_LIST";
	}

	public com.imop.lj.common.model.human.ChatInfo[] getChatInfos(){
		return chatInfos;
	}

	public void setChatInfos(com.imop.lj.common.model.human.ChatInfo[] chatInfos){
		this.chatInfos = chatInfos;
	}	
}