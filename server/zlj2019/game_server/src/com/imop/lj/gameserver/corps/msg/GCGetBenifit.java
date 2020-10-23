package com.imop.lj.gameserver.corps.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 返回领取帮派福利结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCGetBenifit extends GCMessage{
	
	/** 1成功,2失败 */
	private int result;

	public GCGetBenifit (){
	}
	
	public GCGetBenifit (
			int result ){
			this.result = result;
	}

	@Override
	protected boolean readImpl() {

	// 1成功,2失败
	int _result = readInteger();
	//end



		this.result = _result;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 1成功,2失败
	writeInteger(result);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_GET_BENIFIT;
	}
	
	@Override
	public String getTypeName() {
		return "GC_GET_BENIFIT";
	}

	public int getResult(){
		return result;
	}
		
	public void setResult(int result){
		this.result = result;
	}
}