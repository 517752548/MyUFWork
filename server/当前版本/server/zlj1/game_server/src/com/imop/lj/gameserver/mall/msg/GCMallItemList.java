package com.imop.lj.gameserver.mall.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 返回商城物品列表
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCMallItemList extends GCMessage{
	
	/** 标签ID */
	private int catalogId;
	/** 商城物品信息列表 */
	private com.imop.lj.common.model.mall.MallNormalItemInfo[] normalItemInfoList;

	public GCMallItemList (){
	}
	
	public GCMallItemList (
			int catalogId,
			com.imop.lj.common.model.mall.MallNormalItemInfo[] normalItemInfoList ){
			this.catalogId = catalogId;
			this.normalItemInfoList = normalItemInfoList;
	}

	@Override
	protected boolean readImpl() {

	// 标签ID
	int _catalogId = readInteger();
	//end


	// 商城物品信息列表
	int normalItemInfoListSize = readUnsignedShort();
	com.imop.lj.common.model.mall.MallNormalItemInfo[] _normalItemInfoList = new com.imop.lj.common.model.mall.MallNormalItemInfo[normalItemInfoListSize];
	int normalItemInfoListIndex = 0;
	for(normalItemInfoListIndex=0; normalItemInfoListIndex<normalItemInfoListSize; normalItemInfoListIndex++){
		_normalItemInfoList[normalItemInfoListIndex] = new com.imop.lj.common.model.mall.MallNormalItemInfo();
	// 商城物品ID
	int _normalItemInfoList_mallItemId = readInteger();
	//end
	_normalItemInfoList[normalItemInfoListIndex].setMallItemId (_normalItemInfoList_mallItemId);
	// 商城物品信息
	com.imop.lj.common.model.item.CommonItem _normalItemInfoList_commonItem = new com.imop.lj.common.model.item.CommonItem();

	// 道具实例uuid
	String _normalItemInfoList_commonItem_uuid = readString();
	//end
	_normalItemInfoList_commonItem.setUuid (_normalItemInfoList_commonItem_uuid);

	// 包id
	int _normalItemInfoList_commonItem_bagId = readInteger();
	//end
	_normalItemInfoList_commonItem.setBagId (_normalItemInfoList_commonItem_bagId);

	// 道具在背包内位置索引
	int _normalItemInfoList_commonItem_index = readInteger();
	//end
	_normalItemInfoList_commonItem.setIndex (_normalItemInfoList_commonItem_index);

	// 道具模板Id
	int _normalItemInfoList_commonItem_tplId = readInteger();
	//end
	_normalItemInfoList_commonItem.setTplId (_normalItemInfoList_commonItem_tplId);

	// 数量
	int _normalItemInfoList_commonItem_count = readInteger();
	//end
	_normalItemInfoList_commonItem.setCount (_normalItemInfoList_commonItem_count);

	// 最后一次更新时间
	long _normalItemInfoList_commonItem_lastUpdateTime = readLong();
	//end
	_normalItemInfoList_commonItem.setLastUpdateTime (_normalItemInfoList_commonItem_lastUpdateTime);

	// 剩余使用时限描述
	String _normalItemInfoList_commonItem_expireDesc = readString();
	//end
	_normalItemInfoList_commonItem.setExpireDesc (_normalItemInfoList_commonItem_expireDesc);

	// 持有者id，主背包为0
	long _normalItemInfoList_commonItem_wearerId = readLong();
	//end
	_normalItemInfoList_commonItem.setWearerId (_normalItemInfoList_commonItem_wearerId);

	// 道具props，json
	String _normalItemInfoList_commonItem_props = readString();
	//end
	_normalItemInfoList_commonItem.setProps (_normalItemInfoList_commonItem_props);
	_normalItemInfoList[normalItemInfoListIndex].setCommonItem (_normalItemInfoList_commonItem);
	// 原始价格
	com.imop.lj.common.model.CurrencyInfo _normalItemInfoList_originalPrice = new com.imop.lj.common.model.CurrencyInfo();

	// 货币类型
	int _normalItemInfoList_originalPrice_currencyType = readInteger();
	//end
	_normalItemInfoList_originalPrice.setCurrencyType (_normalItemInfoList_originalPrice_currencyType);

	// 货币数量
	long _normalItemInfoList_originalPrice_num = readLong();
	//end
	_normalItemInfoList_originalPrice.setNum (_normalItemInfoList_originalPrice_num);
	_normalItemInfoList[normalItemInfoListIndex].setOriginalPrice (_normalItemInfoList_originalPrice);
	// 折后价格
	com.imop.lj.common.model.CurrencyInfo _normalItemInfoList_discountPrice = new com.imop.lj.common.model.CurrencyInfo();

	// 货币类型
	int _normalItemInfoList_discountPrice_currencyType = readInteger();
	//end
	_normalItemInfoList_discountPrice.setCurrencyType (_normalItemInfoList_discountPrice_currencyType);

	// 货币数量
	long _normalItemInfoList_discountPrice_num = readLong();
	//end
	_normalItemInfoList_discountPrice.setNum (_normalItemInfoList_discountPrice_num);
	_normalItemInfoList[normalItemInfoListIndex].setDiscountPrice (_normalItemInfoList_discountPrice);

	// VIP价格
	int normalItemInfoList_vipPricesSize = readUnsignedShort();
	com.imop.lj.common.model.CurrencyInfo[] _normalItemInfoList_vipPrices = new com.imop.lj.common.model.CurrencyInfo[normalItemInfoList_vipPricesSize];
	int normalItemInfoList_vipPricesIndex = 0;
	for(normalItemInfoList_vipPricesIndex=0; normalItemInfoList_vipPricesIndex<normalItemInfoList_vipPricesSize; normalItemInfoList_vipPricesIndex++){
		_normalItemInfoList_vipPrices[normalItemInfoList_vipPricesIndex] = new com.imop.lj.common.model.CurrencyInfo();
	// 货币类型
	int _normalItemInfoList_vipPrices_currencyType = readInteger();
	//end
	_normalItemInfoList_vipPrices[normalItemInfoList_vipPricesIndex].setCurrencyType (_normalItemInfoList_vipPrices_currencyType);

	// 货币数量
	long _normalItemInfoList_vipPrices_num = readLong();
	//end
	_normalItemInfoList_vipPrices[normalItemInfoList_vipPricesIndex].setNum (_normalItemInfoList_vipPrices_num);
	}
	//end
	_normalItemInfoList[normalItemInfoListIndex].setVipPrices (_normalItemInfoList_vipPrices);

	// 是否热卖
	int _normalItemInfoList_hot = readInteger();
	//end
	_normalItemInfoList[normalItemInfoListIndex].setHot (_normalItemInfoList_hot);

	// 各种标识
	String _normalItemInfoList_marks = readString();
	//end
	_normalItemInfoList[normalItemInfoListIndex].setMarks (_normalItemInfoList_marks);
	}
	//end



		this.catalogId = _catalogId;
		this.normalItemInfoList = _normalItemInfoList;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 标签ID
	writeInteger(catalogId);


	// 商城物品信息列表
	writeShort(normalItemInfoList.length);
	int normalItemInfoListIndex = 0;
	int normalItemInfoListSize = normalItemInfoList.length;
	for(normalItemInfoListIndex=0; normalItemInfoListIndex<normalItemInfoListSize; normalItemInfoListIndex++){

	int normalItemInfoList_mallItemId = normalItemInfoList[normalItemInfoListIndex].getMallItemId();

	// 商城物品ID
	writeInteger(normalItemInfoList_mallItemId);

	com.imop.lj.common.model.item.CommonItem normalItemInfoList_commonItem = normalItemInfoList[normalItemInfoListIndex].getCommonItem();

	String normalItemInfoList_commonItem_uuid = normalItemInfoList_commonItem.getUuid ();

	// 道具实例uuid
	writeString(normalItemInfoList_commonItem_uuid);

	int normalItemInfoList_commonItem_bagId = normalItemInfoList_commonItem.getBagId ();

	// 包id
	writeInteger(normalItemInfoList_commonItem_bagId);

	int normalItemInfoList_commonItem_index = normalItemInfoList_commonItem.getIndex ();

	// 道具在背包内位置索引
	writeInteger(normalItemInfoList_commonItem_index);

	int normalItemInfoList_commonItem_tplId = normalItemInfoList_commonItem.getTplId ();

	// 道具模板Id
	writeInteger(normalItemInfoList_commonItem_tplId);

	int normalItemInfoList_commonItem_count = normalItemInfoList_commonItem.getCount ();

	// 数量
	writeInteger(normalItemInfoList_commonItem_count);

	long normalItemInfoList_commonItem_lastUpdateTime = normalItemInfoList_commonItem.getLastUpdateTime ();

	// 最后一次更新时间
	writeLong(normalItemInfoList_commonItem_lastUpdateTime);

	String normalItemInfoList_commonItem_expireDesc = normalItemInfoList_commonItem.getExpireDesc ();

	// 剩余使用时限描述
	writeString(normalItemInfoList_commonItem_expireDesc);

	long normalItemInfoList_commonItem_wearerId = normalItemInfoList_commonItem.getWearerId ();

	// 持有者id，主背包为0
	writeLong(normalItemInfoList_commonItem_wearerId);

	String normalItemInfoList_commonItem_props = normalItemInfoList_commonItem.getProps ();

	// 道具props，json
	writeString(normalItemInfoList_commonItem_props);

	com.imop.lj.common.model.CurrencyInfo normalItemInfoList_originalPrice = normalItemInfoList[normalItemInfoListIndex].getOriginalPrice();

	int normalItemInfoList_originalPrice_currencyType = normalItemInfoList_originalPrice.getCurrencyType ();

	// 货币类型
	writeInteger(normalItemInfoList_originalPrice_currencyType);

	long normalItemInfoList_originalPrice_num = normalItemInfoList_originalPrice.getNum ();

	// 货币数量
	writeLong(normalItemInfoList_originalPrice_num);

	com.imop.lj.common.model.CurrencyInfo normalItemInfoList_discountPrice = normalItemInfoList[normalItemInfoListIndex].getDiscountPrice();

	int normalItemInfoList_discountPrice_currencyType = normalItemInfoList_discountPrice.getCurrencyType ();

	// 货币类型
	writeInteger(normalItemInfoList_discountPrice_currencyType);

	long normalItemInfoList_discountPrice_num = normalItemInfoList_discountPrice.getNum ();

	// 货币数量
	writeLong(normalItemInfoList_discountPrice_num);

	com.imop.lj.common.model.CurrencyInfo[] normalItemInfoList_vipPrices = normalItemInfoList[normalItemInfoListIndex].getVipPrices();

	// VIP价格
	writeShort(normalItemInfoList_vipPrices.length);
	int normalItemInfoList_vipPricesIndex = 0;
	int normalItemInfoList_vipPricesSize = normalItemInfoList_vipPrices.length;
	for(normalItemInfoList_vipPricesIndex=0; normalItemInfoList_vipPricesIndex<normalItemInfoList_vipPricesSize; normalItemInfoList_vipPricesIndex++){

	int normalItemInfoList_vipPrices_currencyType = normalItemInfoList_vipPrices[normalItemInfoList_vipPricesIndex].getCurrencyType();

	// 货币类型
	writeInteger(normalItemInfoList_vipPrices_currencyType);

	long normalItemInfoList_vipPrices_num = normalItemInfoList_vipPrices[normalItemInfoList_vipPricesIndex].getNum();

	// 货币数量
	writeLong(normalItemInfoList_vipPrices_num);
	}
	//end

	int normalItemInfoList_hot = normalItemInfoList[normalItemInfoListIndex].getHot();

	// 是否热卖
	writeInteger(normalItemInfoList_hot);

	String normalItemInfoList_marks = normalItemInfoList[normalItemInfoListIndex].getMarks();

	// 各种标识
	writeString(normalItemInfoList_marks);
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_MALL_ITEM_LIST;
	}
	
	@Override
	public String getTypeName() {
		return "GC_MALL_ITEM_LIST";
	}

	public int getCatalogId(){
		return catalogId;
	}
		
	public void setCatalogId(int catalogId){
		this.catalogId = catalogId;
	}

	public com.imop.lj.common.model.mall.MallNormalItemInfo[] getNormalItemInfoList(){
		return normalItemInfoList;
	}

	public void setNormalItemInfoList(com.imop.lj.common.model.mall.MallNormalItemInfo[] normalItemInfoList){
		this.normalItemInfoList = normalItemInfoList;
	}	
}