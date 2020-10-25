package com.imop.lj.gameserver.player.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.player.handler.PlayerHandlerFactory;

/**
 * ios充值check
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGIoschargeCheck extends CGMessage{
	
	/** 充值token */
	private String token;
	
	public CGIoschargeCheck (){
	}
	
	public CGIoschargeCheck (
			String token ){
			this.token = token;
	}
	
	@Override
	protected boolean readImpl() {

	// 充值token
	String _token = readString();
	//end



			this.token = _token;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 充值token
	writeString(token);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_IOSCHARGE_CHECK;
	}
	
	@Override
	public String getTypeName() {
		return "CG_IOSCHARGE_CHECK";
	}

	public String getToken(){
		return token;
	}
		
	public void setToken(String token){
		this.token = token;
	}


	@Override
	public void execute() {
		PlayerHandlerFactory.getHandler().handleIoschargeCheck(this.getSession().getPlayer(), this);
	}
}