package com.imop.lj.gameserver.lifeskill.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.lifeskill.handler.LifeskillHandlerFactory;

/**
 * 取消采集
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGCancelLifeSkill extends CGMessage{
	
	
	public CGCancelLifeSkill (){
	}
	
	
	@Override
	protected boolean readImpl() {


		return true;
	}
	
	@Override
	protected boolean writeImpl() {

		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_CANCEL_LIFE_SKILL;
	}
	
	@Override
	public String getTypeName() {
		return "CG_CANCEL_LIFE_SKILL";
	}


	@Override
	public void execute() {
		LifeskillHandlerFactory.getHandler().handleCancelLifeSkill(this.getSession().getPlayer(), this);
	}
}