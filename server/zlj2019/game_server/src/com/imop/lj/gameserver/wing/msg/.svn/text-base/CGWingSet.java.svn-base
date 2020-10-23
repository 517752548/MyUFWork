package com.imop.lj.gameserver.wing.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.wing.handler.WingHandlerFactory;

/**
 * 装备翅膀
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGWingSet extends CGMessage{
	
	/** 翅膀模板Id */
	private int templateId;
	
	public CGWingSet (){
	}
	
	public CGWingSet (
			int templateId ){
			this.templateId = templateId;
	}
	
	@Override
	protected boolean readImpl() {

	// 翅膀模板Id
	int _templateId = readInteger();
	//end



			this.templateId = _templateId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 翅膀模板Id
	writeInteger(templateId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_WING_SET;
	}
	
	@Override
	public String getTypeName() {
		return "CG_WING_SET";
	}

	public int getTemplateId(){
		return templateId;
	}
		
	public void setTemplateId(int templateId){
		this.templateId = templateId;
	}


	@Override
	public void execute() {
		WingHandlerFactory.getHandler().handleWingSet(this.getSession().getPlayer(), this);
	}
}