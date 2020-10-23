package com.imop.lj.gameserver.test.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.test.handler.TestHandlerFactory;

/**
 * 测试
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGTestLong extends CGMessage{
	
	/** 测试Long型 */
	private long testLong;
	/** 测试String型 */
	private String testString;
	
	public CGTestLong (){
	}
	
	public CGTestLong (
			long testLong,
			String testString ){
			this.testLong = testLong;
			this.testString = testString;
	}
	
	@Override
	protected boolean readImpl() {

	// 测试Long型
	long _testLong = readLong();
	//end


	// 测试String型
	String _testString = readString();
	//end



			this.testLong = _testLong;
			this.testString = _testString;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 测试Long型
	writeLong(testLong);


	// 测试String型
	writeString(testString);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_TEST_LONG;
	}
	
	@Override
	public String getTypeName() {
		return "CG_TEST_LONG";
	}

	public long getTestLong(){
		return testLong;
	}
		
	public void setTestLong(long testLong){
		this.testLong = testLong;
	}

	public String getTestString(){
		return testString;
	}
		
	public void setTestString(String testString){
		this.testString = testString;
	}


	@Override
	public void execute() {
		TestHandlerFactory.getHandler().handleTestLong(this.getSession().getPlayer(), this);
	}
}