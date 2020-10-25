package com.imop.lj.gameserver.siegedemon.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.siegedemon.handler.SiegedemonHandlerFactory;

/**
 * 放弃已接任务
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGGiveUpSiegedemontask extends CGMessage{
	
	/** 任务类型 */
	private int questType;
	
	public CGGiveUpSiegedemontask (){
	}
	
	public CGGiveUpSiegedemontask (
			int questType ){
			this.questType = questType;
	}
	
	@Override
	protected boolean readImpl() {

	// 任务类型
	int _questType = readInteger();
	//end



			this.questType = _questType;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 任务类型
	writeInteger(questType);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_GIVE_UP_SIEGEDEMONTASK;
	}
	
	@Override
	public String getTypeName() {
		return "CG_GIVE_UP_SIEGEDEMONTASK";
	}

	public int getQuestType(){
		return questType;
	}
		
	public void setQuestType(int questType){
		this.questType = questType;
	}


	@Override
	public void execute() {
		SiegedemonHandlerFactory.getHandler().handleGiveUpSiegedemontask(this.getSession().getPlayer(), this);
	}
}