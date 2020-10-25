package com.imop.lj.gameserver.prize.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 领取奖励成功
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPrizeSuccess extends GCMessage{
	
	/** 平台奖励唯一编号 */
	private int uniqueId;
	/** 奖励类型  1 平台奖励还是 2 gm奖励  */
	private int prizeType;
	/** 奖励编号 */
	private String prizeId;

	public GCPrizeSuccess (){
	}
	
	public GCPrizeSuccess (
			int uniqueId,
			int prizeType,
			String prizeId ){
			this.uniqueId = uniqueId;
			this.prizeType = prizeType;
			this.prizeId = prizeId;
	}

	@Override
	protected boolean readImpl() {

	// 平台奖励唯一编号
	int _uniqueId = readInteger();
	//end


	// 奖励类型  1 平台奖励还是 2 gm奖励 
	int _prizeType = readInteger();
	//end


	// 奖励编号
	String _prizeId = readString();
	//end



		this.uniqueId = _uniqueId;
		this.prizeType = _prizeType;
		this.prizeId = _prizeId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 平台奖励唯一编号
	writeInteger(uniqueId);


	// 奖励类型  1 平台奖励还是 2 gm奖励 
	writeInteger(prizeType);


	// 奖励编号
	writeString(prizeId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_PRIZE_SUCCESS;
	}
	
	@Override
	public String getTypeName() {
		return "GC_PRIZE_SUCCESS";
	}

	public int getUniqueId(){
		return uniqueId;
	}
		
	public void setUniqueId(int uniqueId){
		this.uniqueId = uniqueId;
	}

	public int getPrizeType(){
		return prizeType;
	}
		
	public void setPrizeType(int prizeType){
		this.prizeType = prizeType;
	}

	public String getPrizeId(){
		return prizeId;
	}
		
	public void setPrizeId(String prizeId){
		this.prizeId = prizeId;
	}
}