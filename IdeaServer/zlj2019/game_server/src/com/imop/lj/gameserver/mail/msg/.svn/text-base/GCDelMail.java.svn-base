package com.imop.lj.gameserver.mail.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 删除结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCDelMail extends GCMessage{
	
	/** 删除结果，1成功，2失败 */
	private int result;

	public GCDelMail (){
	}
	
	public GCDelMail (
			int result ){
			this.result = result;
	}

	@Override
	protected boolean readImpl() {

	// 删除结果，1成功，2失败
	int _result = readInteger();
	//end



		this.result = _result;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 删除结果，1成功，2失败
	writeInteger(result);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_DEL_MAIL;
	}
	
	@Override
	public String getTypeName() {
		return "GC_DEL_MAIL";
	}

	public int getResult(){
		return result;
	}
		
	public void setResult(int result){
		this.result = result;
	}
}