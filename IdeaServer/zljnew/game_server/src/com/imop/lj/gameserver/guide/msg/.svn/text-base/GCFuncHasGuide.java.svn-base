package com.imop.lj.gameserver.guide.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 通知前台某功能模块有新手引导了
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCFuncHasGuide extends GCMessage{
	
	/** 功能类型id */
	private int funcTypeId;

	public GCFuncHasGuide (){
	}
	
	public GCFuncHasGuide (
			int funcTypeId ){
			this.funcTypeId = funcTypeId;
	}

	@Override
	protected boolean readImpl() {

	// 功能类型id
	int _funcTypeId = readInteger();
	//end



		this.funcTypeId = _funcTypeId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 功能类型id
	writeInteger(funcTypeId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_FUNC_HAS_GUIDE;
	}
	
	@Override
	public String getTypeName() {
		return "GC_FUNC_HAS_GUIDE";
	}

	public int getFuncTypeId(){
		return funcTypeId;
	}
		
	public void setFuncTypeId(int funcTypeId){
		this.funcTypeId = funcTypeId;
	}
}