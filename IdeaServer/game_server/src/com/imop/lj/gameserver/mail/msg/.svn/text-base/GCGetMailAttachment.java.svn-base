package com.imop.lj.gameserver.mail.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 领取邮件附件结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCGetMailAttachment extends GCMessage{
	
	/** 结果 */
	private int result;

	public GCGetMailAttachment (){
	}
	
	public GCGetMailAttachment (
			int result ){
			this.result = result;
	}

	@Override
	protected boolean readImpl() {

	// 结果
	int _result = readInteger();
	//end



		this.result = _result;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 结果
	writeInteger(result);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_GET_MAIL_ATTACHMENT;
	}
	
	@Override
	public String getTypeName() {
		return "GC_GET_MAIL_ATTACHMENT";
	}

	public int getResult(){
		return result;
	}
		
	public void setResult(int result){
		this.result = result;
	}
}