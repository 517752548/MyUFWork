package com.imop.lj.gameserver.mail.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.mail.handler.MailHandlerFactory;

/**
 * 删除所有邮件
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGDelAllMail extends CGMessage{
	
	/** 要删除的所有邮件uuid */
	private String[] uuidlist;
	
	public CGDelAllMail (){
	}
	
	public CGDelAllMail (
			String[] uuidlist ){
			this.uuidlist = uuidlist;
	}
	
	@Override
	protected boolean readImpl() {

	// 要删除的所有邮件uuid
	int uuidlistSize = readUnsignedShort();
	String[] _uuidlist = new String[uuidlistSize];
	int uuidlistIndex = 0;
	for(uuidlistIndex=0; uuidlistIndex<uuidlistSize; uuidlistIndex++){
		_uuidlist[uuidlistIndex] = readString();
	}//end



			this.uuidlist = _uuidlist;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 要删除的所有邮件uuid
	writeShort(uuidlist.length);
	int uuidlistSize = uuidlist.length;
	int uuidlistIndex = 0;
	for(uuidlistIndex=0; uuidlistIndex<uuidlistSize; uuidlistIndex++){
		writeString(uuidlist [ uuidlistIndex ]);
	}//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_DEL_ALL_MAIL;
	}
	
	@Override
	public String getTypeName() {
		return "CG_DEL_ALL_MAIL";
	}

	public String[] getUuidlist(){
		return uuidlist;
	}

	public void setUuidlist(String[] uuidlist){
		this.uuidlist = uuidlist;
	}	


	@Override
	public void execute() {
		MailHandlerFactory.getHandler().handleDelAllMail(this.getSession().getPlayer(), this);
	}
}