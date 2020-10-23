package com.imop.lj.gameserver.equip.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 镶嵌宝石结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCEqpGemSet extends GCMessage{
	
	/** 镶嵌宝石结果 1成功 2失败 */
	private int result;

	public GCEqpGemSet (){
	}
	
	public GCEqpGemSet (
			int result ){
			this.result = result;
	}

	@Override
	protected boolean readImpl() {

	// 镶嵌宝石结果 1成功 2失败
	int _result = readInteger();
	//end



		this.result = _result;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 镶嵌宝石结果 1成功 2失败
	writeInteger(result);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_EQP_GEM_SET;
	}
	
	@Override
	public String getTypeName() {
		return "GC_EQP_GEM_SET";
	}

	public int getResult(){
		return result;
	}
		
	public void setResult(int result){
		this.result = result;
	}
}