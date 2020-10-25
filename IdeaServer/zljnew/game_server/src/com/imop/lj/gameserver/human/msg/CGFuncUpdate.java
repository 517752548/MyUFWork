package com.imop.lj.gameserver.human.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.human.handler.HumanHandlerFactory;

/**
 * 功能按钮更新
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGFuncUpdate extends CGMessage{
	
	/** 功能按钮类型 */
	private int funcType;
	
	public CGFuncUpdate (){
	}
	
	public CGFuncUpdate (
			int funcType ){
			this.funcType = funcType;
	}
	
	@Override
	protected boolean readImpl() {

	// 功能按钮类型
	int _funcType = readInteger();
	//end



			this.funcType = _funcType;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 功能按钮类型
	writeInteger(funcType);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_FUNC_UPDATE;
	}
	
	@Override
	public String getTypeName() {
		return "CG_FUNC_UPDATE";
	}

	public int getFuncType(){
		return funcType;
	}
		
	public void setFuncType(int funcType){
		this.funcType = funcType;
	}


	@Override
	public void execute() {
		HumanHandlerFactory.getHandler().handleFuncUpdate(this.getSession().getPlayer(), this);
	}
}