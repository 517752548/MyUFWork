package com.imop.lj.gameserver.player.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.player.handler.PlayerHandlerFactory;

/**
 * 验证验证码
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGCheckSmsCheckcode extends CGMessage{
	
	/** QQ号 */
	private String qqNum;
	/** 手机号 */
	private String phoneNum;
	/** 验证码 */
	private String checkCode;
	
	public CGCheckSmsCheckcode (){
	}
	
	public CGCheckSmsCheckcode (
			String qqNum,
			String phoneNum,
			String checkCode ){
			this.qqNum = qqNum;
			this.phoneNum = phoneNum;
			this.checkCode = checkCode;
	}
	
	@Override
	protected boolean readImpl() {

	// QQ号
	String _qqNum = readString();
	//end


	// 手机号
	String _phoneNum = readString();
	//end


	// 验证码
	String _checkCode = readString();
	//end



			this.qqNum = _qqNum;
			this.phoneNum = _phoneNum;
			this.checkCode = _checkCode;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// QQ号
	writeString(qqNum);


	// 手机号
	writeString(phoneNum);


	// 验证码
	writeString(checkCode);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_CHECK_SMS_CHECKCODE;
	}
	
	@Override
	public String getTypeName() {
		return "CG_CHECK_SMS_CHECKCODE";
	}

	public String getQqNum(){
		return qqNum;
	}
		
	public void setQqNum(String qqNum){
		this.qqNum = qqNum;
	}

	public String getPhoneNum(){
		return phoneNum;
	}
		
	public void setPhoneNum(String phoneNum){
		this.phoneNum = phoneNum;
	}

	public String getCheckCode(){
		return checkCode;
	}
		
	public void setCheckCode(String checkCode){
		this.checkCode = checkCode;
	}


	@Override
	public void execute() {
		PlayerHandlerFactory.getHandler().handleCheckSmsCheckcode(this.getSession().getPlayer(), this);
	}
}