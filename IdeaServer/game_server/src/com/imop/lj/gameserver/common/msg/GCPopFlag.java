package com.imop.lj.gameserver.common.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 冒泡开关
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPopFlag extends GCMessage{
	
	/** 是否冒泡，0不冒，1冒 */
	private int flag;

	public GCPopFlag (){
	}
	
	public GCPopFlag (
			int flag ){
			this.flag = flag;
	}

	@Override
	protected boolean readImpl() {

	// 是否冒泡，0不冒，1冒
	int _flag = readInteger();
	//end



		this.flag = _flag;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 是否冒泡，0不冒，1冒
	writeInteger(flag);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_POP_FLAG;
	}
	
	@Override
	public String getTypeName() {
		return "GC_POP_FLAG";
	}

	public int getFlag(){
		return flag;
	}
		
	public void setFlag(int flag){
		this.flag = flag;
	}
}