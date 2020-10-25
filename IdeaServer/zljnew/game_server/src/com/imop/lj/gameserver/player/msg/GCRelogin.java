package com.imop.lj.gameserver.player.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 通知客户端需要重新登录（一般有openkey过期造成）
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCRelogin extends GCMessage{
	

	public GCRelogin (){
	}
	

	@Override
	protected boolean readImpl() {


		return true;
	}
	
	@Override
	protected boolean writeImpl() {

		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_RELOGIN;
	}
	
	@Override
	public String getTypeName() {
		return "GC_RELOGIN";
	}
}