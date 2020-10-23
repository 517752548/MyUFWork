package com.imop.lj.gameserver.mall.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 返回下个限时列表上架CD
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCNextQueueCd extends GCMessage{
	
	/** cd */
	private long cd;

	public GCNextQueueCd (){
	}
	
	public GCNextQueueCd (
			long cd ){
			this.cd = cd;
	}

	@Override
	protected boolean readImpl() {

	// cd
	long _cd = readLong();
	//end



		this.cd = _cd;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// cd
	writeLong(cd);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_NEXT_QUEUE_CD;
	}
	
	@Override
	public String getTypeName() {
		return "GC_NEXT_QUEUE_CD";
	}

	public long getCd(){
		return cd;
	}
		
	public void setCd(long cd){
		this.cd = cd;
	}
}