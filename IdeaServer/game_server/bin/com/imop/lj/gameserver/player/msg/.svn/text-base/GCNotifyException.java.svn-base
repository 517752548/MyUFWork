package com.imop.lj.gameserver.player.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 通知客户端
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCNotifyException extends GCMessage{
	
	/** 错误码 */
	private int code;
	/** 错误信息，如果为空就显示默认的 */
	private String errMsg;

	public GCNotifyException (){
	}
	
	public GCNotifyException (
			int code,
			String errMsg ){
			this.code = code;
			this.errMsg = errMsg;
	}

	@Override
	protected boolean readImpl() {

	// 错误码
	int _code = readInteger();
	//end


	// 错误信息，如果为空就显示默认的
	String _errMsg = readString();
	//end



		this.code = _code;
		this.errMsg = _errMsg;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 错误码
	writeInteger(code);


	// 错误信息，如果为空就显示默认的
	writeString(errMsg);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_NOTIFY_EXCEPTION;
	}
	
	@Override
	public String getTypeName() {
		return "GC_NOTIFY_EXCEPTION";
	}

	public int getCode(){
		return code;
	}
		
	public void setCode(int code){
		this.code = code;
	}

	public String getErrMsg(){
		return errMsg;
	}
		
	public void setErrMsg(String errMsg){
		this.errMsg = errMsg;
	}
}