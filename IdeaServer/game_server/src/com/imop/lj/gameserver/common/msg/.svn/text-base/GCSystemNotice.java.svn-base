package com.imop.lj.gameserver.common.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 系统公告
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCSystemNotice extends GCMessage{
	
	/** 消息内容 */
	private String content;
	/** 速度 */
	private short speed;

	public GCSystemNotice (){
	}
	
	public GCSystemNotice (
			String content,
			short speed ){
			this.content = content;
			this.speed = speed;
	}

	@Override
	protected boolean readImpl() {

	// 消息内容
	String _content = readString();
	//end


	// 速度
	short _speed = readShort();
	//end



		this.content = _content;
		this.speed = _speed;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 消息内容
	writeString(content);


	// 速度
	writeShort(speed);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_SYSTEM_NOTICE;
	}
	
	@Override
	public String getTypeName() {
		return "GC_SYSTEM_NOTICE";
	}

	public String getContent(){
		return content;
	}
		
	public void setContent(String content){
		this.content = content;
	}

	public short getSpeed(){
		return speed;
	}
		
	public void setSpeed(short speed){
		this.speed = speed;
	}
}