package com.imop.lj.gameserver.player.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.player.handler.PlayerHandlerFactory;

/**
 * 用户token登录
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPlayerTokenLogin extends CGMessage{
	
	/** passportId */
	private String pid;
	/** 角色id */
	private long rid;
	/** token */
	private String token;
	/** 玩家的终端信息，web登陆，ipad，iphone */
	private String source;
	
	public CGPlayerTokenLogin (){
	}
	
	public CGPlayerTokenLogin (
			String pid,
			long rid,
			String token,
			String source ){
			this.pid = pid;
			this.rid = rid;
			this.token = token;
			this.source = source;
	}
	
	@Override
	protected boolean readImpl() {

	// passportId
	String _pid = readString();
	//end


	// 角色id
	long _rid = readLong();
	//end


	// token
	String _token = readString();
	//end


	// 玩家的终端信息，web登陆，ipad，iphone
	String _source = readString();
	//end



			this.pid = _pid;
			this.rid = _rid;
			this.token = _token;
			this.source = _source;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// passportId
	writeString(pid);


	// 角色id
	writeLong(rid);


	// token
	writeString(token);


	// 玩家的终端信息，web登陆，ipad，iphone
	writeString(source);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_PLAYER_TOKEN_LOGIN;
	}
	
	@Override
	public String getTypeName() {
		return "CG_PLAYER_TOKEN_LOGIN";
	}

	public String getPid(){
		return pid;
	}
		
	public void setPid(String pid){
		this.pid = pid;
	}

	public long getRid(){
		return rid;
	}
		
	public void setRid(long rid){
		this.rid = rid;
	}

	public String getToken(){
		return token;
	}
		
	public void setToken(String token){
		this.token = token;
	}

	public String getSource(){
		return source;
	}
		
	public void setSource(String source){
		this.source = source;
	}


	@Override
	public void execute() {
		PlayerHandlerFactory.getHandler().handlePlayerTokenLogin(this.getSession().getPlayer(), this);
	}
}