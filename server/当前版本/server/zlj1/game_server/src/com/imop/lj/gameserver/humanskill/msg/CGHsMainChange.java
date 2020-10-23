package com.imop.lj.gameserver.humanskill.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.humanskill.handler.HumanskillHandlerFactory;

/**
 * 心法切换
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGHsMainChange extends CGMessage{
	
	/** 心法的类型 */
	private int mainSkillType;
	
	public CGHsMainChange (){
	}
	
	public CGHsMainChange (
			int mainSkillType ){
			this.mainSkillType = mainSkillType;
	}
	
	@Override
	protected boolean readImpl() {

	// 心法的类型
	int _mainSkillType = readInteger();
	//end



			this.mainSkillType = _mainSkillType;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 心法的类型
	writeInteger(mainSkillType);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_HS_MAIN_CHANGE;
	}
	
	@Override
	public String getTypeName() {
		return "CG_HS_MAIN_CHANGE";
	}

	public int getMainSkillType(){
		return mainSkillType;
	}
		
	public void setMainSkillType(int mainSkillType){
		this.mainSkillType = mainSkillType;
	}


	@Override
	public void execute() {
		HumanskillHandlerFactory.getHandler().handleHsMainChange(this.getSession().getPlayer(), this);
	}
}