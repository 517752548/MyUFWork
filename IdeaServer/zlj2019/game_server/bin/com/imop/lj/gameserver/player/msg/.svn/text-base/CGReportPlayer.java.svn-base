package com.imop.lj.gameserver.player.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.player.handler.PlayerHandlerFactory;

/**
 * 举报
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGReportPlayer extends CGMessage{
	
	/** 聊天范围 */
	private int scope;
	/** 被举报的角色ID */
	private long charId;
	/** 被举报的角色名称 */
	private String charName;
	/** 举报的聊天内容 */
	private String chatText;
	/** 消息令牌 */
	private String token;
	
	public CGReportPlayer (){
	}
	
	public CGReportPlayer (
			int scope,
			long charId,
			String charName,
			String chatText,
			String token ){
			this.scope = scope;
			this.charId = charId;
			this.charName = charName;
			this.chatText = chatText;
			this.token = token;
	}
	
	@Override
	protected boolean readImpl() {

	// 聊天范围
	int _scope = readInteger();
	//end


	// 被举报的角色ID
	long _charId = readLong();
	//end


	// 被举报的角色名称
	String _charName = readString();
	//end


	// 举报的聊天内容
	String _chatText = readString();
	//end


	// 消息令牌
	String _token = readString();
	//end



			this.scope = _scope;
			this.charId = _charId;
			this.charName = _charName;
			this.chatText = _chatText;
			this.token = _token;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 聊天范围
	writeInteger(scope);


	// 被举报的角色ID
	writeLong(charId);


	// 被举报的角色名称
	writeString(charName);


	// 举报的聊天内容
	writeString(chatText);


	// 消息令牌
	writeString(token);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_REPORT_PLAYER;
	}
	
	@Override
	public String getTypeName() {
		return "CG_REPORT_PLAYER";
	}

	public int getScope(){
		return scope;
	}
		
	public void setScope(int scope){
		this.scope = scope;
	}

	public long getCharId(){
		return charId;
	}
		
	public void setCharId(long charId){
		this.charId = charId;
	}

	public String getCharName(){
		return charName;
	}
		
	public void setCharName(String charName){
		this.charName = charName;
	}

	public String getChatText(){
		return chatText;
	}
		
	public void setChatText(String chatText){
		this.chatText = chatText;
	}

	public String getToken(){
		return token;
	}
		
	public void setToken(String token){
		this.token = token;
	}


	@Override
	public void execute() {
		PlayerHandlerFactory.getHandler().handleReportPlayer(this.getSession().getPlayer(), this);
	}
}