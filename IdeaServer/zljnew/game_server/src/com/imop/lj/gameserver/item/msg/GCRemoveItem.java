package com.imop.lj.gameserver.item.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 移除一个道具
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCRemoveItem extends GCMessage{
	
	/** 佩戴者uuid，主背包为0 */
	private long wearerId;
	/** 物品UUID */
	private String uuid;
	/** 包id */
	private int bagId;
	/** 道具在包内位置索引 */
	private int index;

	public GCRemoveItem (){
	}
	
	public GCRemoveItem (
			long wearerId,
			String uuid,
			int bagId,
			int index ){
			this.wearerId = wearerId;
			this.uuid = uuid;
			this.bagId = bagId;
			this.index = index;
	}

	@Override
	protected boolean readImpl() {

	// 佩戴者uuid，主背包为0
	long _wearerId = readLong();
	//end


	// 物品UUID
	String _uuid = readString();
	//end


	// 包id
	int _bagId = readInteger();
	//end


	// 道具在包内位置索引
	int _index = readInteger();
	//end



		this.wearerId = _wearerId;
		this.uuid = _uuid;
		this.bagId = _bagId;
		this.index = _index;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 佩戴者uuid，主背包为0
	writeLong(wearerId);


	// 物品UUID
	writeString(uuid);


	// 包id
	writeInteger(bagId);


	// 道具在包内位置索引
	writeInteger(index);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_REMOVE_ITEM;
	}
	
	@Override
	public String getTypeName() {
		return "GC_REMOVE_ITEM";
	}

	public long getWearerId(){
		return wearerId;
	}
		
	public void setWearerId(long wearerId){
		this.wearerId = wearerId;
	}

	public String getUuid(){
		return uuid;
	}
		
	public void setUuid(String uuid){
		this.uuid = uuid;
	}

	public int getBagId(){
		return bagId;
	}
		
	public void setBagId(int bagId){
		this.bagId = bagId;
	}

	public int getIndex(){
		return index;
	}
		
	public void setIndex(int index){
		this.index = index;
	}
}