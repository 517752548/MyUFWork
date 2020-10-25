package com.imop.lj.gameserver.human.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.human.handler.HumanHandlerFactory;

/**
 * 通过码兑换奖励
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGChannelExchange extends CGMessage{
	
	/** 兑换码 */
	private String code;
	
	public CGChannelExchange (){
	}
	
	public CGChannelExchange (
			String code ){
			this.code = code;
	}
	
	@Override
	protected boolean readImpl() {

	// 兑换码
	String _code = readString();
	//end



			this.code = _code;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 兑换码
	writeString(code);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_CHANNEL_EXCHANGE;
	}
	
	@Override
	public String getTypeName() {
		return "CG_CHANNEL_EXCHANGE";
	}

	public String getCode(){
		return code;
	}
		
	public void setCode(String code){
		this.code = code;
	}


	@Override
	public void execute() {
		HumanHandlerFactory.getHandler().handleChannelExchange(this.getSession().getPlayer(), this);
	}
}