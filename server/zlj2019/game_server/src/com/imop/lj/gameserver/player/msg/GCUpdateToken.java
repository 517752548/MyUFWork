package com.imop.lj.gameserver.player.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 更新token
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCUpdateToken extends GCMessage{
	
	/** passportId */
	private String pid;
	/** 角色id */
	private long rid;
	/** token */
	private String token;

	public GCUpdateToken (){
	}
	
	public GCUpdateToken (
			String pid,
			long rid,
			String token ){
			this.pid = pid;
			this.rid = rid;
			this.token = token;
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



		this.pid = _pid;
		this.rid = _rid;
		this.token = _token;
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


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_UPDATE_TOKEN;
	}
	
	@Override
	public String getTypeName() {
		return "GC_UPDATE_TOKEN";
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
}