package com.imop.lj.gameserver.mail.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.mail.handler.MailHandlerFactory;

/**
 * 删除邮件
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGDelMail extends CGMessage{
	
	/** 要删除的邮件uuid */
	private String uuid;
	
	public CGDelMail (){
	}
	
	public CGDelMail (
			String uuid ){
			this.uuid = uuid;
	}
	
	@Override
	protected boolean readImpl() {

	// 要删除的邮件uuid
	String _uuid = readString();
	//end



			this.uuid = _uuid;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 要删除的邮件uuid
	writeString(uuid);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_DEL_MAIL;
	}
	
	@Override
	public String getTypeName() {
		return "CG_DEL_MAIL";
	}

	public String getUuid(){
		return uuid;
	}
		
	public void setUuid(String uuid){
		this.uuid = uuid;
	}


	@Override
	public void execute() {
		MailHandlerFactory.getHandler().handleDelMail(this.getSession().getPlayer(), this);
	}
}