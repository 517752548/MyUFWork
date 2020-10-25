package com.imop.lj.gameserver.common.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 服务器端响应的时间同步的消息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPing extends GCMessage{
	
	/** 服务器当前时间戳 */
	private long timestamp;

	public GCPing (){
	}
	
	public GCPing (
			long timestamp ){
			this.timestamp = timestamp;
	}

	@Override
	protected boolean readImpl() {

	// 服务器当前时间戳
	long _timestamp = readLong();
	//end



		this.timestamp = _timestamp;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 服务器当前时间戳
	writeLong(timestamp);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_PING;
	}
	
	@Override
	public String getTypeName() {
		return "GC_PING";
	}

	public long getTimestamp(){
		return timestamp;
	}
		
	public void setTimestamp(long timestamp){
		this.timestamp = timestamp;
	}
}