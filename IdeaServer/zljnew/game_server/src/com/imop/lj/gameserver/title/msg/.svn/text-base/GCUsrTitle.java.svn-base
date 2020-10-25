package com.imop.lj.gameserver.title.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 正在使用称号
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCUsrTitle extends GCMessage{
	
	/** 称号的模版id */
	private int titleTemplateId;

	public GCUsrTitle (){
	}
	
	public GCUsrTitle (
			int titleTemplateId ){
			this.titleTemplateId = titleTemplateId;
	}

	@Override
	protected boolean readImpl() {

	// 称号的模版id
	int _titleTemplateId = readInteger();
	//end



		this.titleTemplateId = _titleTemplateId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 称号的模版id
	writeInteger(titleTemplateId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_USR_TITLE;
	}
	
	@Override
	public String getTypeName() {
		return "GC_USR_TITLE";
	}

	public int getTitleTemplateId(){
		return titleTemplateId;
	}
		
	public void setTitleTemplateId(int titleTemplateId){
		this.titleTemplateId = titleTemplateId;
	}
}