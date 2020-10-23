package com.imop.lj.gameserver.player.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.player.handler.PlayerHandlerFactory;

/**
 * 激活帐号
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGAccountActivationcode extends CGMessage{
	
	/** 激活码 */
	private String activationCode;
	
	public CGAccountActivationcode (){
	}
	
	public CGAccountActivationcode (
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
		return MessageType.CG_ACCOUNT_ACTIVATIONCODE;
	}
	
	@Override
	public String getTypeName() {
		return "CG_ACCOUNT_ACTIVATIONCODE";
	}

	public String getActivationCode(){
		return activationCode;
	}
		
	public void setActivationCode(String activationCode){
		this.activationCode = activationCode;
	}


	@Override
	public void execute() {
		PlayerHandlerFactory.getHandler().handleAccountActivationcode(this.getSession().getPlayer(), this);
	}
}