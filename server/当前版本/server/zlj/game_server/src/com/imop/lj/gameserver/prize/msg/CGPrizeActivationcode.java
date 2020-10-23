package com.imop.lj.gameserver.prize.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.prize.handler.PrizeHandlerFactory;

/**
 * 激活码激活
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPrizeActivationcode extends CGMessage{
	
	/** 激活码 */
	private String activationCode;
	
	public CGPrizeActivationcode (){
	}
	
	public CGPrizeActivationcode (
			String activationCode ){
			this.activationCode = activationCode;
	}
	
	@Override
	protected boolean readImpl() {

	// 激活码
	String _activationCode = readString();
	//end



			this.activationCode = _activationCode;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 激活码
	writeString(activationCode);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_PRIZE_ACTIVATIONCODE;
	}
	
	@Override
	public String getTypeName() {
		return "CG_PRIZE_ACTIVATIONCODE";
	}

	public String getActivationCode(){
		return activationCode;
	}
		
	public void setActivationCode(String activationCode){
		this.activationCode = activationCode;
	}


	@Override
	public void execute() {
		PrizeHandlerFactory.getHandler().handlePrizeActivationcode(this.getSession().getPlayer(), this);
	}
}