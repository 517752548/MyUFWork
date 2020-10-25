package com.imop.lj.gameserver.onlinegift.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 申请补签结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCDaliyGiftRetroactive extends GCMessage{
	
	/** 申请补签结果 1成功,2失败 */
	private int result;

	public GCDaliyGiftRetroactive (){
	}
	
	public GCDaliyGiftRetroactive (
			int result ){
			this.result = result;
	}

	@Override
	protected boolean readImpl() {

	// 申请补签结果 1成功,2失败
	int _result = readInteger();
	//end



		this.result = _result;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 申请补签结果 1成功,2失败
	writeInteger(result);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_DALIY_GIFT_RETROACTIVE;
	}
	
	@Override
	public String getTypeName() {
		return "GC_DALIY_GIFT_RETROACTIVE";
	}

	public int getResult(){
		return result;
	}
		
	public void setResult(int result){
		this.result = result;
	}
}