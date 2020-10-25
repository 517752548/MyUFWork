package com.imop.lj.gameserver.equip.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 分解装备结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCEqpDecompose extends GCMessage{
	
	/** 1成功2失败 */
	private int result;

	public GCEqpDecompose (){
	}
	
	public GCEqpDecompose (
			int result ){
			this.result = result;
	}

	@Override
	protected boolean readImpl() {

	// 1成功2失败
	int _result = readInteger();
	//end



		this.result = _result;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 1成功2失败
	writeInteger(result);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_EQP_DECOMPOSE;
	}
	
	@Override
	public String getTypeName() {
		return "GC_EQP_DECOMPOSE";
	}

	public int getResult(){
		return result;
	}
		
	public void setResult(int result){
		this.result = result;
	}
}