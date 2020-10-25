package com.imop.lj.gameserver.item.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 刷新整个背包
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCBagUpdate extends GCMessage{
	
	/** 背包ID */
	private int bagId;
	/** 佩戴者uuid */
	private long wearerId;
	/** 单个道具信息 */
	private com.imop.lj.common.model.item.CommonItem[] item;

	public GCBagUpdate (){
	}
	
	public GCBagUpdate (
			int bagId,
			long wearerId,
			com.imop.lj.common.model.item.CommonItem[] item ){
			this.bagId = bagId;
			this.wearerId = wearerId;
			this.item = item;
	}

	@Override
	protected boolean readImpl() {

	// 背包ID
	int _bagId = readInteger();
	//end


	// 佩戴者uuid
	long _wearerId = readLong();
	//end


	// 单个道具信息
	int itemSize = readUnsignedShort();
	com.imop.lj.common.model.item.CommonItem[] _item = new com.imop.lj.common.model.item.CommonItem[itemSize];
	int itemIndex = 0;
	for(itemIndex=0; itemIndex<itemSize; itemIndex++){
		_item[itemIndex] = new com.imop.lj.common.model.item.CommonItem();
	// 道具实例uuid
	String _item_uuid = readString();
	//end
	_item[itemIndex].setUuid (_item_uuid);

	// 包id
	int _item_bagId = readInteger();
	//end
	_item[itemIndex].setBagId (_item_bagId);

	// 道具在背包内位置索引
	int _item_index = readInteger();
	//end
	_item[itemIndex].setIndex (_item_index);

	// 道具模板Id
	int _item_tplId = readInteger();
	//end
	_item[itemIndex].setTplId (_item_tplId);

	// 数量
	int _item_count = readInteger();
	//end
	_item[itemIndex].setCount (_item_count);

	// 最后一次更新时间
	long _item_lastUpdateTime = readLong();
	//end
	_item[itemIndex].setLastUpdateTime (_item_lastUpdateTime);

	// 剩余使用时限描述
	String _item_expireDesc = readString();
	//end
	_item[itemIndex].setExpireDesc (_item_expireDesc);

	// 持有者id，主背包为0
	long _item_wearerId = readLong();
	//end
	_item[itemIndex].setWearerId (_item_wearerId);

	// 绑定状态，0绑定，1未绑定
	int _item_bind = readInteger();
	//end
	_item[itemIndex].setBind (_item_bind);

	// 道具props，json
	String _item_props = readString();
	//end
	_item[itemIndex].setProps (_item_props);
	}
	//end



		this.bagId = _bagId;
		this.wearerId = _wearerId;
		this.item = _item;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 背包ID
	writeInteger(bagId);


	// 佩戴者uuid
	writeLong(wearerId);


	// 单个道具信息
	writeShort(item.length);
	int itemIndex = 0;
	int itemSize = item.length;
	for(itemIndex=0; itemIndex<itemSize; itemIndex++){

	String item_uuid = item[itemIndex].getUuid();

	// 道具实例uuid
	writeString(item_uuid);

	int item_bagId = item[itemIndex].getBagId();

	// 包id
	writeInteger(item_bagId);

	int item_index = item[itemIndex].getIndex();

	// 道具在背包内位置索引
	writeInteger(item_index);

	int item_tplId = item[itemIndex].getTplId();

	// 道具模板Id
	writeInteger(item_tplId);

	int item_count = item[itemIndex].getCount();

	// 数量
	writeInteger(item_count);

	long item_lastUpdateTime = item[itemIndex].getLastUpdateTime();

	// 最后一次更新时间
	writeLong(item_lastUpdateTime);

	String item_expireDesc = item[itemIndex].getExpireDesc();

	// 剩余使用时限描述
	writeString(item_expireDesc);

	long item_wearerId = item[itemIndex].getWearerId();

	// 持有者id，主背包为0
	writeLong(item_wearerId);

	int item_bind = item[itemIndex].getBind();

	// 绑定状态，0绑定，1未绑定
	writeInteger(item_bind);

	String item_props = item[itemIndex].getProps();

	// 道具props，json
	writeString(item_props);
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_BAG_UPDATE;
	}
	
	@Override
	public String getTypeName() {
		return "GC_BAG_UPDATE";
	}

	public int getBagId(){
		return bagId;
	}
		
	public void setBagId(int bagId){
		this.bagId = bagId;
	}

	public long getWearerId(){
		return wearerId;
	}
		
	public void setWearerId(long wearerId){
		this.wearerId = wearerId;
	}

	public com.imop.lj.common.model.item.CommonItem[] getItem(){
		return item;
	}

	public void setItem(com.imop.lj.common.model.item.CommonItem[] item){
		this.item = item;
	}	
	public boolean isCompress() {
		return true;
	}
}