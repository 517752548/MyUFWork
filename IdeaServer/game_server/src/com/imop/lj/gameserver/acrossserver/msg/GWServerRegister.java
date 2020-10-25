package com.imop.lj.gameserver.acrossserver.msg;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.msg.BaseMinaMessage;
import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.acrossserver.MinaServerClientSession;
import com.imop.lj.gameserver.acrossserver.ServerClient;
import com.imop.lj.gameserver.acrossserver.WGlobals;

/**
 * gs注册
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class GWServerRegister extends
BaseMinaMessage<MinaServerClientSession> {
	
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

	@Override
	public void execute() {
		ServerClient connectClient = this.getSession().getServerClient();
		if(connectClient == null){
			connectClient = new ServerClient(this.getSession());
			connectClient.setClientIp(this.getSession().getIp());
//			WGlobals.getRemoveGameServerService().putServerClient(this.getSession(), connectClient);
//			Loggers.statusLogger.info("Session open " + this.getSession());
		}
//		ServerClient connectClient = new ServerClient(this.getSession());
//		connectClient.setClientIp(this.getSession().getIp());
		WGlobals.getRemoveGameServerService().putServerClient(this.getSession(), connectClient);
		Loggers.statusLogger.info("Session open " + this.getSession());
//		CeowarworldAcrossServerHandlerFactory.getHandler().handleCeowarServerRegister(this.getSession().getServerClient(), this);
		WGlobals.getRemoveGameServerService().registerServer(connectClient, getServerId());
	}
}