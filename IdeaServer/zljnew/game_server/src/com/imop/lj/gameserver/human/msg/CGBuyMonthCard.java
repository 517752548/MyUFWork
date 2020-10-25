package com.imop.lj.gameserver.human.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.human.handler.HumanHandlerFactory;

/**
 * 购买月卡
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGBuyMonthCard extends CGMessage{
	
	/** 月卡模板Id */
	private int tplId;
	
	public CGBuyMonthCard (){
	}
	
	public CGBuyMonthCard (
			int tplId ){
			this.tplId = tplId;
	}
	
	@Override
	protected boolean readImpl() {

	// 月卡模板Id
	int _tplId = readInteger();
	//end



			this.tplId = _tplId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 月卡模板Id
	writeInteger(tplId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_BUY_MONTH_CARD;
	}
	
	@Override
	public String getTypeName() {
		return "CG_BUY_MONTH_CARD";
	}

	public int getTplId(){
		return tplId;
	}
		
	public void setTplId(int tplId){
		this.tplId = tplId;
	}


	@Override
	public void execute() {
		HumanHandlerFactory.getHandler().handleBuyMonthCard(this.getSession().getPlayer(), this);
	}
}