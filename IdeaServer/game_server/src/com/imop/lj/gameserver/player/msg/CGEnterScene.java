package com.imop.lj.gameserver.player.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.player.handler.PlayerHandlerFactory;

/**
 * 玩家可以进入场景
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGEnterScene extends CGMessage{
	
	
	public CGEnterScene (){
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
		return MessageType.CG_ENTER_SCENE;
	}
	
	@Override
	public String getTypeName() {
		return "CG_ENTER_SCENE";
	}


	@Override
	public void execute() {
		PlayerHandlerFactory.getHandler().handleEnterScene(this.getSession().getPlayer(), this);
	}
}