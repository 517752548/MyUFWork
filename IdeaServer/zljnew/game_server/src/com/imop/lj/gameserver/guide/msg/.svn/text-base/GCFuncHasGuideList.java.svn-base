package com.imop.lj.gameserver.guide.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 通知前台一些功能模块有新手引导了，功能id列表，登录时发
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCFuncHasGuideList extends GCMessage{
	
	/** 功能类型id */
	private int[] funcTypeId;

	public GCFuncHasGuideList (){
	}
	
	public GCFuncHasGuideList (
			int[] funcTypeId ){
			this.funcTypeId = funcTypeId;
	}

	@Override
	protected boolean readImpl() {

	// 功能类型id
	int funcTypeIdSize = readUnsignedShort();
	int[] _funcTypeId = new int[funcTypeIdSize];
	int funcTypeIdIndex = 0;
	for(funcTypeIdIndex=0; funcTypeIdIndex<funcTypeIdSize; funcTypeIdIndex++){
		_funcTypeId[funcTypeIdIndex] = readInteger();
	}//end



		this.funcTypeId = _funcTypeId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 功能类型id
	writeShort(funcTypeId.length);
	int funcTypeIdSize = funcTypeId.length;
	int funcTypeIdIndex = 0;
	for(funcTypeIdIndex=0; funcTypeIdIndex<funcTypeIdSize; funcTypeIdIndex++){
		writeInteger(funcTypeId [ funcTypeIdIndex ]);
	}//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_FUNC_HAS_GUIDE_LIST;
	}
	
	@Override
	public String getTypeName() {
		return "GC_FUNC_HAS_GUIDE_LIST";
	}

	public int[] getFuncTypeId(){
		return funcTypeId;
	}

	public void setFuncTypeId(int[] funcTypeId){
		this.funcTypeId = funcTypeId;
	}	
}