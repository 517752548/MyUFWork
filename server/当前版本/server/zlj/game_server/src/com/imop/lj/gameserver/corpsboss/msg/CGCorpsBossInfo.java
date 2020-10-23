package com.imop.lj.gameserver.corpsboss.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.corpsboss.handler.CorpsbossHandlerFactory;

/**
 * 查看当前队长或个人的boss情况
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGCorpsBossInfo extends CGMessage{
	
	
	public CGCorpsBossInfo (){
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
		return MessageType.CG_CORPS_BOSS_INFO;
	}
	
	@Override
	public String getTypeName() {
		return "CG_CORPS_BOSS_INFO";
	}


	@Override
	public void execute() {
		CorpsbossHandlerFactory.getHandler().handleCorpsBossInfo(this.getSession().getPlayer(), this);
	}
}