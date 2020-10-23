package com.imop.lj.gameserver.player.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.player.handler.PlayerHandlerFactory;

/**
 * 用户cookie登录
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPlayerCookieLogin extends CGMessage{
	
	/** cookie值 */
	private String cookieValue;
	/** 玩家的终端信息，web登陆，ipad，iphone */
	private String source;
	
	public CGPlayerCookieLogin (){
	}
	
	public CGPlayerCookieLogin (
			String cookieValue,
			String source ){
			this.cookieValue = cookieValue;
			this.source = source;
	}
	
	@Override
	protected boolean readImpl() {

	// cookie值
	String _cookieValue = readString();
	//end


	// 玩家的终端信息，web登陆，ipad，iphone
	String _source = readString();
	//end



			this.cookieValue = _cookieValue;
			this.source = _source;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// cookie值
	writeString(cookieValue);


	// 玩家的终端信息，web登陆，ipad，iphone
	writeString(source);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_PLAYER_COOKIE_LOGIN;
	}
	
	@Override
	public String getTypeName() {
		return "CG_PLAYER_COOKIE_LOGIN";
	}

	public String getCookieValue(){
		return cookieValue;
	}
		
	public void setCookieValue(String cookieValue){
		this.cookieValue = cookieValue;
	}

	public String getSource(){
		return source;
	}
		
	public void setSource(String source){
		this.source = source;
	}


	@Override
	public void execute() {
		PlayerHandlerFactory.getHandler().handlePlayerCookieLogin(this.getSession().getPlayer(), this);
	}
}