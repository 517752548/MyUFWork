package com.imop.lj.gameserver.mail.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.mail.handler.MailHandlerFactory;

/**
 * 查询邮件列表
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGMailList extends CGMessage{
	
	/** 查询的页面索引 */
	private int queryIndex;
	/** 邮箱类型1-inbox,2-sended,3-savebox */
	private int boxType;
	
	public CGMailList (){
	}
	
	public CGMailList (
			int queryIndex,
			int boxType ){
			this.queryIndex = queryIndex;
			this.boxType = boxType;
	}
	
	@Override
	protected boolean readImpl() {

	// 查询的页面索引
	int _queryIndex = readInteger();
	//end


	// 邮箱类型1-inbox,2-sended,3-savebox
	int _boxType = readInteger();
	//end



			this.queryIndex = _queryIndex;
			this.boxType = _boxType;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 查询的页面索引
	writeInteger(queryIndex);


	// 邮箱类型1-inbox,2-sended,3-savebox
	writeInteger(boxType);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_MAIL_LIST;
	}
	
	@Override
	public String getTypeName() {
		return "CG_MAIL_LIST";
	}

	public int getQueryIndex(){
		return queryIndex;
	}
		
	public void setQueryIndex(int queryIndex){
		this.queryIndex = queryIndex;
	}

	public int getBoxType(){
		return boxType;
	}
		
	public void setBoxType(int boxType){
		this.boxType = boxType;
	}


	@Override
	public void execute() {
		MailHandlerFactory.getHandler().handleMailList(this.getSession().getPlayer(), this);
	}
}