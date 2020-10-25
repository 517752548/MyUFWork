package com.imop.lj.gameserver.common.msg;

import com.imop.lj.core.msg.BaseMinaMessage;
import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.startup.MinaGameClientSession;

/**
 * 服务器准备好之后,告知客户端可以进行登录操作2
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGHandshake extends BaseMinaMessage<MinaGameClientSession>{
	
	/** content */
	private String value;
	
	public CGHandshake (){
	}
	
	public CGHandshake (
			String value ){
			this.value = value;
	}
	
	@Override
	protected boolean readImpl() {
		value = readString();
		return true;
	}
	
	@Override
	protected boolean writeImpl() {
		writeString(value);
		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_HANDSHAKE;
	}
	
	@Override
	public String getTypeName() {
		return "CG_HANDSHAKE";
	}

	public String getValue(){
		return value;
	}
		
	public void setValue(String value){
		this.value = value;
	}

	@Override
	public void execute() {
//		Player connectClient = new Player(this.getSession());
//		connectClient.setClientIp(this.getSession().getIp());
//		Globals.getOnlinePlayerService().putPlayer(this.getSession(), connectClient);
//		connectClient.sendMessage(new GCHandshake(this.value));	
	}
}