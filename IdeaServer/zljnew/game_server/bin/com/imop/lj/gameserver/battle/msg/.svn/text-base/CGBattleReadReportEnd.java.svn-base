package com.imop.lj.gameserver.battle.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.battle.handler.BattleHandlerFactory;

/**
 * 播放最后一轮战报结束
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGBattleReadReportEnd extends CGMessage{
	
	
	public CGBattleReadReportEnd (){
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
		return MessageType.CG_BATTLE_READ_REPORT_END;
	}
	
	@Override
	public String getTypeName() {
		return "CG_BATTLE_READ_REPORT_END";
	}


	@Override
	public void execute() {
		BattleHandlerFactory.getHandler().handleBattleReadReportEnd(this.getSession().getPlayer(), this);
	}
}