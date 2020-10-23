package com.imop.lj.gameserver.mail.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.mail.handler.MailHandlerFactory;

/**
 * 阅读邮件
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGReadMail extends CGMessage{
	
	/** 要阅读的邮件uuid */
	private String uuid;
	
	public CGReadMail (){
	}
	
	public CGReadMail (
			String uuid ){
			this.uuid = uuid;
	}
	
	@Override
	protected boolean readImpl() {

	// 要阅读的邮件uuid
	String _uuid = readString();
	//end



			this.uuid = _uuid;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 要阅读的邮件uuid
	writeString(uuid);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_READ_MAIL;
	}
	
	@Override
	public String getTypeName() {
		return "CG_READ_MAIL";
	}

	public String getUuid(){
		return uuid;
	}
		
	public void setUuid(String uuid){
		this.uuid = uuid;
	}


	@Override
	public void execute() {
		MailHandlerFactory.getHandler().handleReadMail(this.getSession().getPlayer(), this);
	}
}