package com.imop.lj.gameserver.guaji.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 返回挂机结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCStartGuaJi extends GCMessage{
	
	/** 1成功，2失败 */
	private int result;

	public GCStartGuaJi (){
	}
	
	public GCStartGuaJi (
			int result ){
			this.result = result;
	}

	@Override
	protected boolean readImpl() {

	// 1成功，2失败
	int _result = readInteger();
	//end



		this.result = _result;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 1成功，2失败
	writeInteger(result);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_START_GUA_JI;
	}
	
	@Override
	public String getTypeName() {
		return "GC_START_GUA_JI";
	}

	public int getResult(){
		return result;
	}
		
	public void setResult(int result){
		this.result = result;
	}
}