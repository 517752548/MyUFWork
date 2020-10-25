package com.imop.lj.gameserver.common.msg;

import com.imop.lj.core.msg.MessageType;

/**
 * 服务器准备好之后,告知客户端可以进行登录操作2
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCHandshake extends GCMessage{
	
	/** content */
	private String value;

	public GCHandshake (){
	}
	
	public GCHandshake (
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
		return MessageType.GC_HANDSHAKE;
	}
	
	@Override
	public String getTypeName() {
		return "GC_HANDSHAKE";
	}

	public String getValue(){
		return value;
	}
		
	public void setValue(String value){
		this.value = value;
	}
}