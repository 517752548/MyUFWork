package com.imop.lj.gameserver.onlinegift.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 申请签到结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCDaliyGiftSign extends GCMessage{
	
	/** 申请签到结果 1成功,2失败 */
	private int result;

	public GCDaliyGiftSign (){
	}
	
	public GCDaliyGiftSign (
			int result ){
			this.result = result;
	}

	@Override
	protected boolean readImpl() {

	// 申请签到结果 1成功,2失败
	int _result = readInteger();
	//end



		this.result = _result;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 申请签到结果 1成功,2失败
	writeInteger(result);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_DALIY_GIFT_SIGN;
	}
	
	@Override
	public String getTypeName() {
		return "GC_DALIY_GIFT_SIGN";
	}

	public int getResult(){
		return result;
	}
		
	public void setResult(int result){
		this.result = result;
	}
}