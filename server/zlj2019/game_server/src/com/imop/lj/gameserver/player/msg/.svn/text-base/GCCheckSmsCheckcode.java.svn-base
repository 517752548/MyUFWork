package com.imop.lj.gameserver.player.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 验证验证码结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCCheckSmsCheckcode extends GCMessage{
	
	/** 验证结果，1成功，2失败 */
	private int result;
	/** QQ号 */
	private String qqNum;
	/** 手机号 */
	private String phoneNum;

	public GCCheckSmsCheckcode (){
	}
	
	public GCCheckSmsCheckcode (
			int result,
			String qqNum,
			String phoneNum ){
			this.result = result;
			this.qqNum = qqNum;
			this.phoneNum = phoneNum;
	}

	@Override
	protected boolean readImpl() {

	// 验证结果，1成功，2失败
	int _result = readInteger();
	//end


	// QQ号
	String _qqNum = readString();
	//end


	// 手机号
	String _phoneNum = readString();
	//end



		this.result = _result;
		this.qqNum = _qqNum;
		this.phoneNum = _phoneNum;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 验证结果，1成功，2失败
	writeInteger(result);


	// QQ号
	writeString(qqNum);


	// 手机号
	writeString(phoneNum);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_CHECK_SMS_CHECKCODE;
	}
	
	@Override
	public String getTypeName() {
		return "GC_CHECK_SMS_CHECKCODE";
	}

	public int getResult(){
		return result;
	}
		
	public void setResult(int result){
		this.result = result;
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
}