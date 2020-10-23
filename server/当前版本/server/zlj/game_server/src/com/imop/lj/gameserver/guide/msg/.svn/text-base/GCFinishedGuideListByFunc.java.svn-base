package com.imop.lj.gameserver.guide.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 已全部完成新手引导的功能模块列表
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCFinishedGuideListByFunc extends GCMessage{
	
	/** 功能类型id */
	private int[] funcTypeIdList;

	public GCFinishedGuideListByFunc (){
	}
	
	public GCFinishedGuideListByFunc (
			int[] funcTypeIdList ){
			this.funcTypeIdList = funcTypeIdList;
	}

	@Override
	protected boolean readImpl() {

	// 功能类型id
	int funcTypeIdListSize = readUnsignedShort();
	int[] _funcTypeIdList = new int[funcTypeIdListSize];
	int funcTypeIdListIndex = 0;
	for(funcTypeIdListIndex=0; funcTypeIdListIndex<funcTypeIdListSize; funcTypeIdListIndex++){
		_funcTypeIdList[funcTypeIdListIndex] = readInteger();
	}//end



		this.funcTypeIdList = _funcTypeIdList;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 功能类型id
	writeShort(funcTypeIdList.length);
	int funcTypeIdListSize = funcTypeIdList.length;
	int funcTypeIdListIndex = 0;
	for(funcTypeIdListIndex=0; funcTypeIdListIndex<funcTypeIdListSize; funcTypeIdListIndex++){
		writeInteger(funcTypeIdList [ funcTypeIdListIndex ]);
	}//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_FINISHED_GUIDE_LIST_BY_FUNC;
	}
	
	@Override
	public String getTypeName() {
		return "GC_FINISHED_GUIDE_LIST_BY_FUNC";
	}

	public int[] getFuncTypeIdList(){
		return funcTypeIdList;
	}

	public void setFuncTypeIdList(int[] funcTypeIdList){
		this.funcTypeIdList = funcTypeIdList;
	}	
}