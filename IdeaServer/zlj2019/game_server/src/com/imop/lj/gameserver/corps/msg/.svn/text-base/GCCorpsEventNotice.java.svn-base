package com.imop.lj.gameserver.corps.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 军团事件通知
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCCorpsEventNotice extends GCMessage{
	
	/** 事件类型 */
	private int corpsEventType;
	/** 事件参数 */
	private long param;

	public GCCorpsEventNotice (){
	}
	
	public GCCorpsEventNotice (
			int corpsEventType,
			long param ){
			this.corpsEventType = corpsEventType;
			this.param = param;
	}

	@Override
	protected boolean readImpl() {

	// 事件类型
	int _corpsEventType = readInteger();
	//end


	// 事件参数
	long _param = readLong();
	//end



		this.corpsEventType = _corpsEventType;
		this.param = _param;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 事件类型
	writeInteger(corpsEventType);


	// 事件参数
	writeLong(param);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_CORPS_EVENT_NOTICE;
	}
	
	@Override
	public String getTypeName() {
		return "GC_CORPS_EVENT_NOTICE";
	}

	public int getCorpsEventType(){
		return corpsEventType;
	}
		
	public void setCorpsEventType(int corpsEventType){
		this.corpsEventType = corpsEventType;
	}

	public long getParam(){
		return param;
	}
		
	public void setParam(long param){
		this.param = param;
	}
}