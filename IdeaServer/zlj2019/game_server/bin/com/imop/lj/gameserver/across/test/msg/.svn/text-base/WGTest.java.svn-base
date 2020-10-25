package com.imop.lj.gameserver.across.test.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.across.msg.WGMessage;
import com.imop.lj.gameserver.across.test.handler.TestAcrossHandlerFactory;

/**
 * 跨服服务器到游戏服务器测试消息
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class WGTest extends WGMessage{
	
	/** 测试内容 */
	private String content;
	
	public WGTest (){
	}
	
	public WGTest (
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
		return MessageType.WG_TEST;
	}
	
	@Override
	public String getTypeName() {
		return "WG_TEST";
	}

	public String getContent(){
		return content;
	}
		
	public void setContent(String content){
		this.content = content;
	}

	@Override
	public void execute() {
		TestAcrossHandlerFactory.getHandler().handleTest(this);
	}
}