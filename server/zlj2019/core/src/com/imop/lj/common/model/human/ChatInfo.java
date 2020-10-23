package com.imop.lj.common.model.human;

public class ChatInfo {
	//聊天范围
	private int scope;
	//类型，0默认，1语音
	private int chatType;
	//聊天消息发送者角色UUID
	private String fromRoleUUID;
	//聊天消息发送者角色名称
	private String fromRoleName;
	//聊天消息发送者等级
	private int fromRoleLevel;
	//聊天消息发送者国家
	private int fromRoleCountry;
	//聊天消息发送者模板Id
	private int fromRoleTplId;
	//经过过滤后的聊天消息
	private String content;
	//聊天时间
	private long chatTime;
	//聊天消息接收者角色UUID
	private String toRoleUUID;
	//聊天消息接收者角色名
	private String toRoleName;
	//" comment="聊天消息接收者模板Id" />
	private int  toRoleTplId;
	//" comment="发送者的vip等级" />
	private int fromRoleVipLevel;
	//" comment="接受者的vip等级" />
	private int toRoleVipLevel;
	//" comment="发送者是否接受者的好友" />
	private int IsFriendOfToRole;
	//发送者qq信息vip等数据
	private QQInfo fromQQInfo;
	//接受者qq信息vip等数据
	private QQInfo toQQInfo;
	//额外扩展字段
	private String ext = "";
	
	
	public int getScope() {
		return scope;
	}
	public void setScope(int scope) {
		this.scope = scope;
	}
	public int getChatType() {
		return chatType;
	}
	public void setChatType(int chatType) {
		this.chatType = chatType;
	}
	public String getFromRoleUUID() {
		return fromRoleUUID;
	}
	public void setFromRoleUUID(String fromRoleUUID) {
		this.fromRoleUUID = fromRoleUUID;
	}
	public String getFromRoleName() {
		return fromRoleName;
	}
	public void setFromRoleName(String fromRoleName) {
		this.fromRoleName = fromRoleName;
	}
	public int getFromRoleLevel() {
		return fromRoleLevel;
	}
	public void setFromRoleLevel(int fromRoleLevel) {
		this.fromRoleLevel = fromRoleLevel;
	}
	public int getFromRoleCountry() {
		return fromRoleCountry;
	}
	public void setFromRoleCountry(int fromRoleCountry) {
		this.fromRoleCountry = fromRoleCountry;
	}
	public int getFromRoleTplId() {
		return fromRoleTplId;
	}
	public void setFromRoleTplId(int fromRoleTplId) {
		this.fromRoleTplId = fromRoleTplId;
	}
	public String getContent() {
		return content;
	}
	public void setContent(String content) {
		this.content = content;
	}
	public long getChatTime() {
		return chatTime;
	}
	public void setChatTime(long chatTime) {
		this.chatTime = chatTime;
	}
	public String getToRoleUUID() {
		return toRoleUUID;
	}
	public void setToRoleUUID(String toRoleUUID) {
		this.toRoleUUID = toRoleUUID;
	}
	public String getToRoleName() {
		return toRoleName;
	}
	public void setToRoleName(String toRoleName) {
		this.toRoleName = toRoleName;
	}
	public int getToRoleTplId() {
		return toRoleTplId;
	}
	public void setToRoleTplId(int toRoleTplId) {
		this.toRoleTplId = toRoleTplId;
	}
	public int getFromRoleVipLevel() {
		return fromRoleVipLevel;
	}
	public void setFromRoleVipLevel(int fromRoleVipLevel) {
		this.fromRoleVipLevel = fromRoleVipLevel;
	}
	public int getToRoleVipLevel() {
		return toRoleVipLevel;
	}
	public void setToRoleVipLevel(int toRoleVipLevel) {
		this.toRoleVipLevel = toRoleVipLevel;
	}
	public int getIsFriendOfToRole() {
		return IsFriendOfToRole;
	}
	public void setIsFriendOfToRole(int isFriendOfToRole) {
		IsFriendOfToRole = isFriendOfToRole;
	}
	public QQInfo getFromQQInfo() {
		return fromQQInfo;
	}
	public void setFromQQInfo(QQInfo fromQQInfo) {
		this.fromQQInfo = fromQQInfo;
	}
	public QQInfo getToQQInfo() {
		return toQQInfo;
	}
	public void setToQQInfo(QQInfo toQQInfo) {
		this.toQQInfo = toQQInfo;
	}
	public String getExt() {
		return ext;
	}
	public void setExt(String ext) {
		this.ext = ext;
	}
	
}
