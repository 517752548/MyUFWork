package com.imop.lj.gameserver.guide.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 已全部完成新手引导的功能模块Id，当某完成某新手引导后给前台发送更新
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCFinishedGuideByFunc extends GCMessage{
	
	/** 功能类型id */
	private int funcTypeId;

	public GCFinishedGuideByFunc (){
	}
	
	public GCFinishedGuideByFunc (
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
		return MessageType.GC_FINISHED_GUIDE_BY_FUNC;
	}
	
	@Override
	public String getTypeName() {
		return "GC_FINISHED_GUIDE_BY_FUNC";
	}

	public int getFuncTypeId(){
		return funcTypeId;
	}
		
	public void setFuncTypeId(int funcTypeId){
		this.funcTypeId = funcTypeId;
	}
}