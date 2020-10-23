package com.imop.lj.gameserver.player.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.player.handler.PlayerHandlerFactory;

/**
 * 用户登录
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPlayerLogin extends CGMessage{
	
	/** 玩家的账户 */
	private String account;
	/** 玩家的密码  */
	private String password;
	/** 玩家的来源，web登陆，ipad，iphone */
	private String source;
	
	public CGPlayerLogin (){
	}
	
	public CGPlayerLogin (
			String account,
			String password,
			String source ){
			this.account = account;
			this.password = password;
			this.source = source;
	}
	
	@Override
	protected boolean readImpl() {

	// 玩家的账户
	String _account = readString();
	//end


	// 玩家的密码 
	String _password = readString();
	//end


	// 玩家的来源，web登陆，ipad，iphone
	String _source = readString();
	//end



			this.account = _account;
			this.password = _password;
			this.source = _source;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 玩家的账户
	writeString(account);


	// 玩家的密码 
	writeString(password);


	// 玩家的来源，web登陆，ipad，iphone
	writeString(source);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_PLAYER_LOGIN;
	}
	
	@Override
	public String getTypeName() {
		return "CG_PLAYER_LOGIN";
	}

	public String getAccount(){
		return account;
	}
		
	public void setAccount(String account){
		this.account = account;
	}

	public String getPassword(){
		return password;
	}
		
	public void setPassword(String password){
		this.password = password;
	}

	public String getSource(){
		return source;
	}
		
	public void setSource(String source){
		this.source = source;
	}


	@Override
	public void execute() {
		PlayerHandlerFactory.getHandler().handlePlayerLogin(this.getSession().getPlayer(), this);
	}
}