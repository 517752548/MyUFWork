package com.imop.lj.gameserver.common.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 系统提示消息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCSystemMessage extends GCMessage{
	
	/** 消息内容 */
	private String content;
	/** 消息显示类型 */
	private short showType;

	public GCSystemMessage (){
	}
	
	public GCSystemMessage (
			String content,
			short showType ){
			this.content = content;
			this.showType = showType;
	}

	@Override
	protected boolean readImpl() {

	// 消息内容
	String _content = readString();
	//end


	// 消息显示类型
	short _showType = readShort();
	//end



		this.content = _content;
		this.showType = _showType;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 消息内容
	writeString(content);


	// 消息显示类型
	writeShort(showType);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_SYSTEM_MESSAGE;
	}
	
	@Override
	public String getTypeName() {
		return "GC_SYSTEM_MESSAGE";
	}

	public String getContent(){
		return content;
	}
		
	public void setContent(String content){
		this.content = content;
	}

	public short getShowType(){
		return showType;
	}
		
	public void setShowType(short showType){
		this.showType = showType;
	}
}