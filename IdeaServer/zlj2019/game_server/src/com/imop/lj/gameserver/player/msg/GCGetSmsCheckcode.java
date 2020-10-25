package com.imop.lj.gameserver.player.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 获取验证码结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCGetSmsCheckcode extends GCMessage{
	
	/** 获取验证码结果，1成功，2失败 */
	private int result;

	public GCGetSmsCheckcode (){
	}
	
	public GCGetSmsCheckcode (
			int result ){
			this.result = result;
	}

	@Override
	protected boolean readImpl() {

	// 获取验证码结果，1成功，2失败
	int _result = readInteger();
	//end



		this.result = _result;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 获取验证码结果，1成功，2失败
	writeInteger(result);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_GET_SMS_CHECKCODE;
	}
	
	@Override
	public String getTypeName() {
		return "GC_GET_SMS_CHECKCODE";
	}

	public int getResult(){
		return result;
	}
		
	public void setResult(int result){
		this.result = result;
	}
}