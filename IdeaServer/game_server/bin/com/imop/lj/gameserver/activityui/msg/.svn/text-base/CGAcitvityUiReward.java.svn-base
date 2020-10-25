package com.imop.lj.gameserver.activityui.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.activityui.handler.ActivityuiHandlerFactory;

/**
 * 获得活跃度奖励
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGAcitvityUiReward extends CGMessage{
	
	/** 活力值(20,40,60,80,100) */
	private int vitalityNum;
	
	public CGAcitvityUiReward (){
	}
	
	public CGAcitvityUiReward (
			int vitalityNum ){
			this.vitalityNum = vitalityNum;
	}
	
	@Override
	protected boolean readImpl() {

	// 活力值(20,40,60,80,100)
	int _vitalityNum = readInteger();
	//end



			this.vitalityNum = _vitalityNum;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 活力值(20,40,60,80,100)
	writeInteger(vitalityNum);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_ACITVITY_UI_REWARD;
	}
	
	@Override
	public String getTypeName() {
		return "CG_ACITVITY_UI_REWARD";
	}

	public int getVitalityNum(){
		return vitalityNum;
	}
		
	public void setVitalityNum(int vitalityNum){
		this.vitalityNum = vitalityNum;
	}


	@Override
	public void execute() {
		ActivityuiHandlerFactory.getHandler().handleAcitvityUiReward(this.getSession().getPlayer(), this);
	}
}