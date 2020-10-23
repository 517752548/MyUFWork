package com.imop.lj.gameserver.tower.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.tower.handler.TowerHandlerFactory;

/**
 * 请求查看通天塔每层的奖励
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGTowerReward extends CGMessage{
	
	
	public CGTowerReward (){
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
		return MessageType.CG_TOWER_REWARD;
	}
	
	@Override
	public String getTypeName() {
		return "CG_TOWER_REWARD";
	}


	@Override
	public void execute() {
		TowerHandlerFactory.getHandler().handleTowerReward(this.getSession().getPlayer(), this);
	}
}