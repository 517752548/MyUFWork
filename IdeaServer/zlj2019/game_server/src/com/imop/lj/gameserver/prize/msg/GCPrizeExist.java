package com.imop.lj.gameserver.prize.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 返回当前玩家是否有奖励
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPrizeExist extends GCMessage{
	
	/** 判断玩家是否有礼包 */
	private boolean exist;

	public GCPrizeExist (){
	}
	
	public GCPrizeExist (
			boolean exist ){
			this.exist = exist;
	}

	@Override
	protected boolean readImpl() {

	// 判断玩家是否有礼包
	boolean _exist = readBoolean();
	//end



		this.exist = _exist;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 判断玩家是否有礼包
	writeBoolean(exist);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_PRIZE_EXIST;
	}
	
	@Override
	public String getTypeName() {
		return "GC_PRIZE_EXIST";
	}

	public boolean getExist(){
		return exist;
	}
		
	public void setExist(boolean exist){
		this.exist = exist;
	}
}