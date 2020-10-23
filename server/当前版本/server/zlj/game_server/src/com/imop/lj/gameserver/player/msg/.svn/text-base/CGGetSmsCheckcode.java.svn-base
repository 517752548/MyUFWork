package com.imop.lj.gameserver.player.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.player.handler.PlayerHandlerFactory;

/**
 * 获取验证码
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGGetSmsCheckcode extends CGMessage{
	
	/** 手机号 */
	private String phoneNum;
	
	public CGGetSmsCheckcode (){
	}
	
	public CGGetSmsCheckcode (
			String phoneNum ){
			this.phoneNum = phoneNum;
	}
	
	@Override
	protected boolean readImpl() {

	// 手机号
	String _phoneNum = readString();
	//end



			this.phoneNum = _phoneNum;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 手机号
	writeString(phoneNum);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_GET_SMS_CHECKCODE;
	}
	
	@Override
	public String getTypeName() {
		return "CG_GET_SMS_CHECKCODE";
	}

	public String getPhoneNum(){
		return phoneNum;
	}
		
	public void setPhoneNum(String phoneNum){
		this.phoneNum = phoneNum;
	}


	@Override
	public void execute() {
		PlayerHandlerFactory.getHandler().handleGetSmsCheckcode(this.getSession().getPlayer(), this);
	}
}