package com.imop.lj.gameserver.item.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 交换道具
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCSwapItem extends GCMessage{
	
	/** 来源持有者id，主背包为0 */
	private long fromWearerId;
	/** 来源包id */
	private int fromBagId;
	/** 道具在来源背包内位置索引 */
	private int fromIndex;
	/** 目的持有者id，主背包为0 */
	private long toWearerId;
	/** 目的包id */
	private int toBagId;
	/** 道具在目的包内位置索引 */
	private int toIndex;

	public GCSwapItem (){
	}
	
	public GCSwapItem (
			long fromWearerId,
			int fromBagId,
			int fromIndex,
			long toWearerId,
			int toBagId,
			int toIndex ){
			this.fromWearerId = fromWearerId;
			this.fromBagId = fromBagId;
			this.fromIndex = fromIndex;
			this.toWearerId = toWearerId;
			this.toBagId = toBagId;
			this.toIndex = toIndex;
	}

	@Override
	protected boolean readImpl() {

	// 来源持有者id，主背包为0
	long _fromWearerId = readLong();
	//end


	// 来源包id
	int _fromBagId = readInteger();
	//end


	// 道具在来源背包内位置索引
	int _fromIndex = readInteger();
	//end


	// 目的持有者id，主背包为0
	long _toWearerId = readLong();
	//end


	// 目的包id
	int _toBagId = readInteger();
	//end


	// 道具在目的包内位置索引
	int _toIndex = readInteger();
	//end



		this.fromWearerId = _fromWearerId;
		this.fromBagId = _fromBagId;
		this.fromIndex = _fromIndex;
		this.toWearerId = _toWearerId;
		this.toBagId = _toBagId;
		this.toIndex = _toIndex;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 来源持有者id，主背包为0
	writeLong(fromWearerId);


	// 来源包id
	writeInteger(fromBagId);


	// 道具在来源背包内位置索引
	writeInteger(fromIndex);


	// 目的持有者id，主背包为0
	writeLong(toWearerId);


	// 目的包id
	writeInteger(toBagId);


	// 道具在目的包内位置索引
	writeInteger(toIndex);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_SWAP_ITEM;
	}
	
	@Override
	public String getTypeName() {
		return "GC_SWAP_ITEM";
	}

	public long getFromWearerId(){
		return fromWearerId;
	}
		
	public void setFromWearerId(long fromWearerId){
		this.fromWearerId = fromWearerId;
	}

	public int getFromBagId(){
		return fromBagId;
	}
		
	public void setFromBagId(int fromBagId){
		this.fromBagId = fromBagId;
	}

	public int getFromIndex(){
		return fromIndex;
	}
		
	public void setFromIndex(int fromIndex){
		this.fromIndex = fromIndex;
	}

	public long getToWearerId(){
		return toWearerId;
	}
		
	public void setToWearerId(long toWearerId){
		this.toWearerId = toWearerId;
	}

	public int getToBagId(){
		return toBagId;
	}
		
	public void setToBagId(int toBagId){
		this.toBagId = toBagId;
	}

	public int getToIndex(){
		return toIndex;
	}
		
	public void setToIndex(int toIndex){
		this.toIndex = toIndex;
	}
}