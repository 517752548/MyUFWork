package com.imop.lj.gameserver.lifeskill.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.lifeskill.handler.LifeskillHandlerFactory;

/**
 * 申请采矿界面
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGLsMineGetPannel extends CGMessage{
	
	
	public CGLsMineGetPannel (){
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
		return MessageType.CG_LS_MINE_GET_PANNEL;
	}
	
	@Override
	public String getTypeName() {
		return "CG_LS_MINE_GET_PANNEL";
	}


	@Override
	public void execute() {
		LifeskillHandlerFactory.getHandler().handleLsMineGetPannel(this.getSession().getPlayer(), this);
	}
}