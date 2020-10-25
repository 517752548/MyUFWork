package com.imop.lj.gameserver.corps.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 返回请求发送帮派红包
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCCreateCorpsRedEnvelope extends GCMessage{
	
	/** 结果,1成功,2失败 */
	private int result;

	public GCCreateCorpsRedEnvelope (){
	}
	
	public GCCreateCorpsRedEnvelope (
			int result ){
			this.result = result;
	}

	@Override
	protected boolean readImpl() {

	// 结果,1成功,2失败
	int _result = readInteger();
	//end



		this.result = _result;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 结果,1成功,2失败
	writeInteger(result);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_CREATE_CORPS_RED_ENVELOPE;
	}
	
	@Override
	public String getTypeName() {
		return "GC_CREATE_CORPS_RED_ENVELOPE";
	}

	public int getResult(){
		return result;
	}
		
	public void setResult(int result){
		this.result = result;
	}
}