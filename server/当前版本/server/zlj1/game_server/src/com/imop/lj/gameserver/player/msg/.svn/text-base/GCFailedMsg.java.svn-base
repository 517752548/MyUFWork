package com.imop.lj.gameserver.player.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * GS向CLIENT发送操作失败消息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCFailedMsg extends GCMessage{
	
	/** 错误号 */
	private short errorNo;
	/** 错误提示信息 */
	private String errMsg;

	public GCFailedMsg (){
	}
	
	public GCFailedMsg (
			short errorNo,
			String errMsg ){
			this.errorNo = errorNo;
			this.errMsg = errMsg;
	}

	@Override
	protected boolean readImpl() {

	// 错误号
	short _errorNo = readShort();
	//end


	// 错误提示信息
	String _errMsg = readString();
	//end



		this.errorNo = _errorNo;
		this.errMsg = _errMsg;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 错误号
	writeShort(errorNo);


	// 错误提示信息
	writeString(errMsg);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_FAILED_MSG;
	}
	
	@Override
	public String getTypeName() {
		return "GC_FAILED_MSG";
	}

	public short getErrorNo(){
		return errorNo;
	}
		
	public void setErrorNo(short errorNo){
		this.errorNo = errorNo;
	}

	public String getErrMsg(){
		return errMsg;
	}
		
	public void setErrMsg(String errMsg){
		this.errMsg = errMsg;
	}
}