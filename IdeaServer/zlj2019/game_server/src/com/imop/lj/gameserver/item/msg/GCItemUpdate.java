package com.imop.lj.gameserver.item.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 更新单个道具信息，客户端受到此消息就替换原来此位置的道具
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCItemUpdate extends GCMessage{
	
	/** 单个道具信息 */
	private com.imop.lj.common.model.item.CommonItem item;

	public GCItemUpdate (){
	}
	
	public GCItemUpdate (
			com.imop.lj.common.model.item.CommonItem item ){
			this.item = item;
	}

	@Override
	protected boolean readImpl() {
	// 单个道具信息
	com.imop.lj.common.model.item.CommonItem _item = new com.imop.lj.common.model.item.CommonItem();

	// 道具实例uuid
	String _item_uuid = readString();
	//end
	_item.setUuid (_item_uuid);

	// 包id
	int _item_bagId = readInteger();
	//end
	_item.setBagId (_item_bagId);

	// 道具在背包内位置索引
	int _item_index = readInteger();
	//end
	_item.setIndex (_item_index);

	// 道具模板Id
	int _item_tplId = readInteger();
	//end
	_item.setTplId (_item_tplId);

	// 数量
	int _item_count = readInteger();
	//end
	_item.setCount (_item_count);

	// 最后一次更新时间
	long _item_lastUpdateTime = readLong();
	//end
	_item.setLastUpdateTime (_item_lastUpdateTime);

	// 剩余使用时限描述
	String _item_expireDesc = readString();
	//end
	_item.setExpireDesc (_item_expireDesc);

	// 持有者id，主背包为0
	long _item_wearerId = readLong();
	//end
	_item.setWearerId (_item_wearerId);

	// 绑定状态，0绑定，1未绑定
	int _item_bind = readInteger();
	//end
	_item.setBind (_item_bind);

	// 道具props，json
	String _item_props = readString();
	//end
	_item.setProps (_item_props);



		this.item = _item;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	String item_uuid = item.getUuid ();

	// 道具实例uuid
	writeString(item_uuid);

	int item_bagId = item.getBagId ();

	// 包id
	writeInteger(item_bagId);

	int item_index = item.getIndex ();

	// 道具在背包内位置索引
	writeInteger(item_index);

	int item_tplId = item.getTplId ();

	// 道具模板Id
	writeInteger(item_tplId);

	int item_count = item.getCount ();

	// 数量
	writeInteger(item_count);

	long item_lastUpdateTime = item.getLastUpdateTime ();

	// 最后一次更新时间
	writeLong(item_lastUpdateTime);

	String item_expireDesc = item.getExpireDesc ();

	// 剩余使用时限描述
	writeString(item_expireDesc);

	long item_wearerId = item.getWearerId ();

	// 持有者id，主背包为0
	writeLong(item_wearerId);

	int item_bind = item.getBind ();

	// 绑定状态，0绑定，1未绑定
	writeInteger(item_bind);

	String item_props = item.getProps ();

	// 道具props，json
	writeString(item_props);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_ITEM_UPDATE;
	}
	
	@Override
	public String getTypeName() {
		return "GC_ITEM_UPDATE";
	}

	public com.imop.lj.common.model.item.CommonItem getItem(){
		return item;
	}
		
	public void setItem(com.imop.lj.common.model.item.CommonItem item){
		this.item = item;
	}
}