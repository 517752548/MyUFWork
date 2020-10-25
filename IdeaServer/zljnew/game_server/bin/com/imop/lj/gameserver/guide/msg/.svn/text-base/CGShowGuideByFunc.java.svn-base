package com.imop.lj.gameserver.guide.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.guide.handler.GuideHandlerFactory;

/**
 * 根据功能Id显示新手引导
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGShowGuideByFunc extends CGMessage{
	
	/** 功能类型id */
	private int funcTypeId;
	
	public CGShowGuideByFunc (){
	}
	
	public CGShowGuideByFunc (
			int funcTypeId ){
			this.funcTypeId = funcTypeId;
	}
	
	@Override
	protected boolean readImpl() {

	// 功能类型id
	int _funcTypeId = readInteger();
	//end



			this.funcTypeId = _funcTypeId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 功能类型id
	writeInteger(funcTypeId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_SHOW_GUIDE_BY_FUNC;
	}
	
	@Override
	public String getTypeName() {
		return "CG_SHOW_GUIDE_BY_FUNC";
	}

	public int getFuncTypeId(){
		return funcTypeId;
	}
		
	public void setFuncTypeId(int funcTypeId){
		this.funcTypeId = funcTypeId;
	}


	@Override
	public void execute() {
		GuideHandlerFactory.getHandler().handleShowGuideByFunc(this.getSession().getPlayer(), this);
	}
}