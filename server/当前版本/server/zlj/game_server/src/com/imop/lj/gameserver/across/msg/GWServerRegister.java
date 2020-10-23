package com.imop.lj.gameserver.across.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.across.msg.GWMessage;
/**
 * gs注册
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GWServerRegister extends GWMessage{
	
	/** 服务器id */
	private int serverId;

	public GWServerRegister (){
	}
	
	public GWServerRegister (
			int serverId ){
			this.serverId = serverId;
	}

	@Override
	protected boolean readImpl() {
		serverId = readInteger();
		return true;
	}
	
	@Override
	protected boolean writeImpl() {
		writeInteger(serverId);
		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GW_SERVER_REGISTER;
	}
	
	@Override
	public String getTypeName() {
		return "GW_SERVER_REGISTER";
	}

	public int getServerId(){
		return serverId;
	}
		
	public void setServerId(int serverId){
		this.serverId = serverId;
	}
}