package com.imop.lj.gameserver.foragetask.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 已完成所有任务
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCForagetaskDone extends GCMessage{
	

	public GCForagetaskDone (){
	}
	

	@Override
	protected boolean readImpl() {


		return true;
	}
	
	@Override
	protected boolean writeImpl() {

		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_FORAGETASK_DONE;
	}
	
	@Override
	public String getTypeName() {
		return "GC_FORAGETASK_DONE";
	}
}