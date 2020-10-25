package com.imop.lj.gameserver.across.test.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.across.msg.GWMessage;
/**
 * 游戏服务器到跨服服务器测试消息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GWTest extends GWMessage{
	
	/** 测试内容 */
	private String content;

	public GWTest (){
	}
	
	public GWTest (
			String content ){
			this.content = content;
	}

	@Override
	protected boolean readImpl() {

	// 测试内容
	String _content = readString();
	//end



		this.content = _content;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {
		writeString(content);
		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GW_TEST;
	}
	
	@Override
	public String getTypeName() {
		return "GW_TEST";
	}

	public String getContent(){
		return content;
	}
		
	public void setContent(String content){
		this.content = content;
	}
}