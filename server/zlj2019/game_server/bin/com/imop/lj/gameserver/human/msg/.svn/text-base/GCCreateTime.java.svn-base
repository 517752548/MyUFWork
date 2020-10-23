package com.imop.lj.gameserver.human.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 玩家创建角色时间
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCCreateTime extends GCMessage{
	
	/** 创建角色时间，毫秒 */
	private long createTime;

	public GCCreateTime (){
	}
	
	public GCCreateTime (
			long createTime ){
			this.createTime = createTime;
	}

	@Override
	protected boolean readImpl() {

	// 创建角色时间，毫秒
	long _createTime = readLong();
	//end



		this.createTime = _createTime;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 创建角色时间，毫秒
	writeLong(createTime);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_CREATE_TIME;
	}
	
	@Override
	public String getTypeName() {
		return "GC_CREATE_TIME";
	}

	public long getCreateTime(){
		return createTime;
	}
		
	public void setCreateTime(long createTime){
		this.createTime = createTime;
	}
}