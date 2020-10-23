package com.imop.lj.gameserver.mall.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 请求限时物品列表
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCTimeLimitItemList extends GCMessage{
	
	/** 队列ID */
	private String queueUUID;
	/** 商城限时物品信息列表 */
	private com.imop.lj.common.model.mall.MallTimeLimitItemInfo[] timeLimitItemInfoList;

	public GCTimeLimitItemList (){
	}
	
	public GCTimeLimitItemList (
			String queueUUID,
			com.imop.lj.common.model.mall.MallTimeLimitItemInfo[] timeLimitItemInfoList ){
			this.queueUUID = queueUUID;
			this.timeLimitItemInfoList = timeLimitItemInfoList;
	}

	@Override
	protected boolean readImpl() {

	// 队列ID
	String _queueUUID = readString();
	//end


	// 商城限时物品信息列表
	int timeLimitItemInfoListSize = readUnsignedShort();
	com.imop.lj.common.model.mall.MallTimeLimitItemInfo[] _timeLimitItemInfoList = new com.imop.lj.common.model.mall.MallTimeLimitItemInfo[timeLimitItemInfoListSize];
	int timeLimitItemInfoListIndex = 0;
	for(timeLimitItemInfoListIndex=0; timeLimitItemInfoListIndex<timeLimitItemInfoListSize; timeLimitItemInfoListIndex++){
		_timeLimitItemInfoList[timeLimitItemInfoListIndex] = new com.imop.lj.common.model.mall.MallTimeLimitItemInfo();
	// 商城物品ID
	int _timeLimitItemInfoList_mallItemId = readInteger();
	//end
	_timeLimitItemInfoList[timeLimitItemInfoListIndex].setMallItemId (_timeLimitItemInfoList_mallItemId);
	// 商城限时物品信息
	com.imop.lj.common.model.item.CommonItem _timeLimitItemInfoList_commonItem = new com.imop.lj.common.model.item.CommonItem();

	// 道具实例uuid
	String _timeLimitItemInfoList_commonItem_uuid = readString();
	//end
	_timeLimitItemInfoList_commonItem.setUuid (_timeLimitItemInfoList_commonItem_uuid);

	// 包id
	int _timeLimitItemInfoList_commonItem_bagId = readInteger();
	//end
	_timeLimitItemInfoList_commonItem.setBagId (_timeLimitItemInfoList_commonItem_bagId);

	// 道具在背包内位置索引
	int _timeLimitItemInfoList_commonItem_index = readInteger();
	//end
	_timeLimitItemInfoList_commonItem.setIndex (_timeLimitItemInfoList_commonItem_index);

	// 道具模板Id
	int _timeLimitItemInfoList_commonItem_tplId = readInteger();
	//end
	_timeLimitItemInfoList_commonItem.setTplId (_timeLimitItemInfoList_commonItem_tplId);

	// 数量
	int _timeLimitItemInfoList_commonItem_count = readInteger();
	//end
	_timeLimitItemInfoList_commonItem.setCount (_timeLimitItemInfoList_commonItem_count);

	// 最后一次更新时间
	long _timeLimitItemInfoList_commonItem_lastUpdateTime = readLong();
	//end
	_timeLimitItemInfoList_commonItem.setLastUpdateTime (_timeLimitItemInfoList_commonItem_lastUpdateTime);

	// 剩余使用时限描述
	String _timeLimitItemInfoList_commonItem_expireDesc = readString();
	//end
	_timeLimitItemInfoList_commonItem.setExpireDesc (_timeLimitItemInfoList_commonItem_expireDesc);

	// 持有者id，主背包为0
	long _timeLimitItemInfoList_commonItem_wearerId = readLong();
	//end
	_timeLimitItemInfoList_commonItem.setWearerId (_timeLimitItemInfoList_commonItem_wearerId);

	// 绑定状态，0绑定，1未绑定
	int _timeLimitItemInfoList_commonItem_bind = readInteger();
	//end
	_timeLimitItemInfoList_commonItem.setBind (_timeLimitItemInfoList_commonItem_bind);

	// 道具props，json
	String _timeLimitItemInfoList_commonItem_props = readString();
	//end
	_timeLimitItemInfoList_commonItem.setProps (_timeLimitItemInfoList_commonItem_props);
	_timeLimitItemInfoList[timeLimitItemInfoListIndex].setCommonItem (_timeLimitItemInfoList_commonItem);
	// 价格
	com.imop.lj.common.model.CurrencyInfo _timeLimitItemInfoList_price = new com.imop.lj.common.model.CurrencyInfo();

	// 货币类型
	int _timeLimitItemInfoList_price_currencyType = readInteger();
	//end
	_timeLimitItemInfoList_price.setCurrencyType (_timeLimitItemInfoList_price_currencyType);

	// 货币数量
	long _timeLimitItemInfoList_price_num = readLong();
	//end
	_timeLimitItemInfoList_price.setNum (_timeLimitItemInfoList_price_num);
	_timeLimitItemInfoList[timeLimitItemInfoListIndex].setPrice (_timeLimitItemInfoList_price);

	// 有效期
	long _timeLimitItemInfoList_validPeriod = readLong();
	//end
	_timeLimitItemInfoList[timeLimitItemInfoListIndex].setValidPeriod (_timeLimitItemInfoList_validPeriod);

	// 是否限制库存
	int _timeLimitItemInfoList_limitStock = readInteger();
	//end
	_timeLimitItemInfoList[timeLimitItemInfoListIndex].setLimitStock (_timeLimitItemInfoList_limitStock);

	// 是否限制库存
	int _timeLimitItemInfoList_stock = readInteger();
	//end
	_timeLimitItemInfoList[timeLimitItemInfoListIndex].setStock (_timeLimitItemInfoList_stock);

	// 是否限购
	int _timeLimitItemInfoList_limitPurchase = readInteger();
	//end
	_timeLimitItemInfoList[timeLimitItemInfoListIndex].setLimitPurchase (_timeLimitItemInfoList_limitPurchase);

	// 限购数量
	int _timeLimitItemInfoList_limitPurchaseNum = readInteger();
	//end
	_timeLimitItemInfoList[timeLimitItemInfoListIndex].setLimitPurchaseNum (_timeLimitItemInfoList_limitPurchaseNum);

	// 各种标识
	String _timeLimitItemInfoList_marks = readString();
	//end
	_timeLimitItemInfoList[timeLimitItemInfoListIndex].setMarks (_timeLimitItemInfoList_marks);
	}
	//end



		this.queueUUID = _queueUUID;
		this.timeLimitItemInfoList = _timeLimitItemInfoList;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 队列ID
	writeString(queueUUID);


	// 商城限时物品信息列表
	writeShort(timeLimitItemInfoList.length);
	int timeLimitItemInfoListIndex = 0;
	int timeLimitItemInfoListSize = timeLimitItemInfoList.length;
	for(timeLimitItemInfoListIndex=0; timeLimitItemInfoListIndex<timeLimitItemInfoListSize; timeLimitItemInfoListIndex++){

	int timeLimitItemInfoList_mallItemId = timeLimitItemInfoList[timeLimitItemInfoListIndex].getMallItemId();

	// 商城物品ID
	writeInteger(timeLimitItemInfoList_mallItemId);

	com.imop.lj.common.model.item.CommonItem timeLimitItemInfoList_commonItem = timeLimitItemInfoList[timeLimitItemInfoListIndex].getCommonItem();

	String timeLimitItemInfoList_commonItem_uuid = timeLimitItemInfoList_commonItem.getUuid ();

	// 道具实例uuid
	writeString(timeLimitItemInfoList_commonItem_uuid);

	int timeLimitItemInfoList_commonItem_bagId = timeLimitItemInfoList_commonItem.getBagId ();

	// 包id
	writeInteger(timeLimitItemInfoList_commonItem_bagId);

	int timeLimitItemInfoList_commonItem_index = timeLimitItemInfoList_commonItem.getIndex ();

	// 道具在背包内位置索引
	writeInteger(timeLimitItemInfoList_commonItem_index);

	int timeLimitItemInfoList_commonItem_tplId = timeLimitItemInfoList_commonItem.getTplId ();

	// 道具模板Id
	writeInteger(timeLimitItemInfoList_commonItem_tplId);

	int timeLimitItemInfoList_commonItem_count = timeLimitItemInfoList_commonItem.getCount ();

	// 数量
	writeInteger(timeLimitItemInfoList_commonItem_count);

	long timeLimitItemInfoList_commonItem_lastUpdateTime = timeLimitItemInfoList_commonItem.getLastUpdateTime ();

	// 最后一次更新时间
	writeLong(timeLimitItemInfoList_commonItem_lastUpdateTime);

	String timeLimitItemInfoList_commonItem_expireDesc = timeLimitItemInfoList_commonItem.getExpireDesc ();

	// 剩余使用时限描述
	writeString(timeLimitItemInfoList_commonItem_expireDesc);

	long timeLimitItemInfoList_commonItem_wearerId = timeLimitItemInfoList_commonItem.getWearerId ();

	// 持有者id，主背包为0
	writeLong(timeLimitItemInfoList_commonItem_wearerId);

	int timeLimitItemInfoList_commonItem_bind = timeLimitItemInfoList_commonItem.getBind ();

	// 绑定状态，0绑定，1未绑定
	writeInteger(timeLimitItemInfoList_commonItem_bind);

	String timeLimitItemInfoList_commonItem_props = timeLimitItemInfoList_commonItem.getProps ();

	// 道具props，json
	writeString(timeLimitItemInfoList_commonItem_props);

	com.imop.lj.common.model.CurrencyInfo timeLimitItemInfoList_price = timeLimitItemInfoList[timeLimitItemInfoListIndex].getPrice();

	int timeLimitItemInfoList_price_currencyType = timeLimitItemInfoList_price.getCurrencyType ();

	// 货币类型
	writeInteger(timeLimitItemInfoList_price_currencyType);

	long timeLimitItemInfoList_price_num = timeLimitItemInfoList_price.getNum ();

	// 货币数量
	writeLong(timeLimitItemInfoList_price_num);

	long timeLimitItemInfoList_validPeriod = timeLimitItemInfoList[timeLimitItemInfoListIndex].getValidPeriod();

	// 有效期
	writeLong(timeLimitItemInfoList_validPeriod);

	int timeLimitItemInfoList_limitStock = timeLimitItemInfoList[timeLimitItemInfoListIndex].getLimitStock();

	// 是否限制库存
	writeInteger(timeLimitItemInfoList_limitStock);

	int timeLimitItemInfoList_stock = timeLimitItemInfoList[timeLimitItemInfoListIndex].getStock();

	// 是否限制库存
	writeInteger(timeLimitItemInfoList_stock);

	int timeLimitItemInfoList_limitPurchase = timeLimitItemInfoList[timeLimitItemInfoListIndex].getLimitPurchase();

	// 是否限购
	writeInteger(timeLimitItemInfoList_limitPurchase);

	int timeLimitItemInfoList_limitPurchaseNum = timeLimitItemInfoList[timeLimitItemInfoListIndex].getLimitPurchaseNum();

	// 限购数量
	writeInteger(timeLimitItemInfoList_limitPurchaseNum);

	String timeLimitItemInfoList_marks = timeLimitItemInfoList[timeLimitItemInfoListIndex].getMarks();

	// 各种标识
	writeString(timeLimitItemInfoList_marks);
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_TIME_LIMIT_ITEM_LIST;
	}
	
	@Override
	public String getTypeName() {
		return "GC_TIME_LIMIT_ITEM_LIST";
	}

	public String getQueueUUID(){
		return queueUUID;
	}
		
	public void setQueueUUID(String queueUUID){
		this.queueUUID = queueUUID;
	}

	public com.imop.lj.common.model.mall.MallTimeLimitItemInfo[] getTimeLimitItemInfoList(){
		return timeLimitItemInfoList;
	}

	public void setTimeLimitItemInfoList(com.imop.lj.common.model.mall.MallTimeLimitItemInfo[] timeLimitItemInfoList){
		this.timeLimitItemInfoList = timeLimitItemInfoList;
	}	
}