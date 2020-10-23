package com.imop.lj.gameserver.chat.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.chat.handler.ChatHandlerFactory;

/**
 * 服务器端向客户端发送的聊天消息
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGChatMsg extends CGMessage{
	
	/** 聊天范围 */
	private int scope;
	/** 聊天消息接收的玩家 */
	private String destRoleName;
	/** 消息接收玩家的UUID */
	private String destRoleUUID;
	/** 聊天消息 */
	private String content;
	/** 类型，0默认，1语音 */
	private int chatType;
	
	public CGChatMsg (){
	}
	
	public CGChatMsg (
			int scope,
			String destRoleName,
			String destRoleUUID,
			String content,
			int chatType ){
			this.scope = scope;
			this.destRoleName = destRoleName;
			this.destRoleUUID = destRoleUUID;
			this.content = content;
			this.chatType = chatType;
	}
	
	@Override
	protected boolean readImpl() {

	// 聊天范围
	int _scope = readInteger();
	//end


	// 聊天消息接收的玩家
	String _destRoleName = readString();
	//end


	// 消息接收玩家的UUID
	String _destRoleUUID = readString();
	//end


	// 聊天消息
	String _content = readString();
	//end


	// 类型，0默认，1语音
	int _chatType = readInteger();
	//end



			this.scope = _scope;
			this.destRoleName = _destRoleName;
			this.destRoleUUID = _destRoleUUID;
			this.content = _content;
			this.chatType = _chatType;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 聊天范围
	writeInteger(scope);


	// 聊天消息接收的玩家
	writeString(destRoleName);


	// 消息接收玩家的UUID
	writeString(destRoleUUID);


	// 聊天消息
	writeString(content);


	// 类型，0默认，1语音
	writeInteger(chatType);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_CHAT_MSG;
	}
	
	@Override
	public String getTypeName() {
		return "CG_CHAT_MSG";
	}

	public int getScope(){
		return scope;
	}
		
	public void setScope(int scope){
		this.scope = scope;
	}

	public String getDestRoleName(){
		return destRoleName;
	}
		
	public void setDestRoleName(String destRoleName){
		this.destRoleName = destRoleName;
	}

	public String getDestRoleUUID(){
		return destRoleUUID;
	}
		
	public void setDestRoleUUID(String destRoleUUID){
		this.destRoleUUID = destRoleUUID;
	}

	public String getContent(){
		return content;
	}
		
	public void setContent(String content){
		this.content = content;
	}

	public int getChatType(){
		return chatType;
	}
		
	public void setChatType(int chatType){
		this.chatType = chatType;
	}


	@Override
	public void execute() {
		ChatHandlerFactory.getHandler().handleChatMsg(this.getSession().getPlayer(), this);
	}
}