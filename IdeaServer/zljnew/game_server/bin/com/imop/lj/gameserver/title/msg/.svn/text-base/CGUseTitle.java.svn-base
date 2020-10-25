package com.imop.lj.gameserver.title.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.title.handler.TitleHandlerFactory;

/**
 * 使用称号
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGUseTitle extends CGMessage{
	
	/** 称号的模版ID */
	private int titleTemplateId;
	
	public CGUseTitle (){
	}
	
	public CGUseTitle (
			int titleTemplateId ){
			this.titleTemplateId = titleTemplateId;
	}
	
	@Override
	protected boolean readImpl() {

	// 称号的模版ID
	int _titleTemplateId = readInteger();
	//end



			this.titleTemplateId = _titleTemplateId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 称号的模版ID
	writeInteger(titleTemplateId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_USE_TITLE;
	}
	
	@Override
	public String getTypeName() {
		return "CG_USE_TITLE";
	}

	public int getTitleTemplateId(){
		return titleTemplateId;
	}
		
	public void setTitleTemplateId(int titleTemplateId){
		this.titleTemplateId = titleTemplateId;
	}


	@Override
	public void execute() {
		TitleHandlerFactory.getHandler().handleUseTitle(this.getSession().getPlayer(), this);
	}
}