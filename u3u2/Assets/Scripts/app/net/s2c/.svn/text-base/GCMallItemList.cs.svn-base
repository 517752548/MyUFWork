
using System;
namespace app.net
{
/**
 * 返回商城物品列表
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCMallItemList :BaseMessage
{
	/** 标签ID */
	private int catalogId;
	/** 商城物品信息列表 */
	private MallNormalItemInfoData[] normalItemInfoList;

	public GCMallItemList ()
	{
	}

	protected override void ReadImpl()
	{
	// 标签ID
	int _catalogId = ReadInt();

	// 商城物品信息列表
	int normalItemInfoListSize = ReadShort();
	MallNormalItemInfoData[] _normalItemInfoList = new MallNormalItemInfoData[normalItemInfoListSize];
	int normalItemInfoListIndex = 0;
	MallNormalItemInfoData _normalItemInfoListTmp = null;
	for(normalItemInfoListIndex=0; normalItemInfoListIndex<normalItemInfoListSize; normalItemInfoListIndex++){
		_normalItemInfoListTmp = new MallNormalItemInfoData();
		_normalItemInfoList[normalItemInfoListIndex] = _normalItemInfoListTmp;
	// 商城物品ID
	int _normalItemInfoList_mallItemId = ReadInt();	_normalItemInfoListTmp.mallItemId = _normalItemInfoList_mallItemId;
		// 商城物品信息
	CommonItemData _normalItemInfoList_commonItem = new CommonItemData();
	// 道具实例uuid
	string _normalItemInfoList_commonItem_uuid = ReadString();	_normalItemInfoList_commonItem.uuid = _normalItemInfoList_commonItem_uuid;
	// 包id
	int _normalItemInfoList_commonItem_bagId = ReadInt();	_normalItemInfoList_commonItem.bagId = _normalItemInfoList_commonItem_bagId;
	// 道具在背包内位置索引
	int _normalItemInfoList_commonItem_index = ReadInt();	_normalItemInfoList_commonItem.index = _normalItemInfoList_commonItem_index;
	// 道具模板Id
	int _normalItemInfoList_commonItem_tplId = ReadInt();	_normalItemInfoList_commonItem.tplId = _normalItemInfoList_commonItem_tplId;
	// 数量
	int _normalItemInfoList_commonItem_count = ReadInt();	_normalItemInfoList_commonItem.count = _normalItemInfoList_commonItem_count;
	// 最后一次更新时间
	long _normalItemInfoList_commonItem_lastUpdateTime = ReadLong();	_normalItemInfoList_commonItem.lastUpdateTime = _normalItemInfoList_commonItem_lastUpdateTime;
	// 剩余使用时限描述
	string _normalItemInfoList_commonItem_expireDesc = ReadString();	_normalItemInfoList_commonItem.expireDesc = _normalItemInfoList_commonItem_expireDesc;
	// 持有者id，主背包为0
	long _normalItemInfoList_commonItem_wearerId = ReadLong();	_normalItemInfoList_commonItem.wearerId = _normalItemInfoList_commonItem_wearerId;
	// 绑定状态，0绑定，1未绑定
	int _normalItemInfoList_commonItem_bind = ReadInt();	_normalItemInfoList_commonItem.bind = _normalItemInfoList_commonItem_bind;
	// 道具props，json
	string _normalItemInfoList_commonItem_props = ReadString();	_normalItemInfoList_commonItem.props = _normalItemInfoList_commonItem_props;
	_normalItemInfoListTmp.commonItem = _normalItemInfoList_commonItem;
		// 原始价格
	CurrencyInfoData _normalItemInfoList_originalPrice = new CurrencyInfoData();
	// 货币类型
	int _normalItemInfoList_originalPrice_currencyType = ReadInt();	_normalItemInfoList_originalPrice.currencyType = _normalItemInfoList_originalPrice_currencyType;
	// 货币数量
	long _normalItemInfoList_originalPrice_num = ReadLong();	_normalItemInfoList_originalPrice.num = _normalItemInfoList_originalPrice_num;
	_normalItemInfoListTmp.originalPrice = _normalItemInfoList_originalPrice;
		// 折后价格
	CurrencyInfoData _normalItemInfoList_discountPrice = new CurrencyInfoData();
	// 货币类型
	int _normalItemInfoList_discountPrice_currencyType = ReadInt();	_normalItemInfoList_discountPrice.currencyType = _normalItemInfoList_discountPrice_currencyType;
	// 货币数量
	long _normalItemInfoList_discountPrice_num = ReadLong();	_normalItemInfoList_discountPrice.num = _normalItemInfoList_discountPrice_num;
	_normalItemInfoListTmp.discountPrice = _normalItemInfoList_discountPrice;
	
	// VIP价格
	int normalItemInfoList_vipPricesSize = ReadShort();
	CurrencyInfoData[] _normalItemInfoList_vipPrices = new CurrencyInfoData[normalItemInfoList_vipPricesSize];
	int normalItemInfoList_vipPricesIndex = 0;
	CurrencyInfoData _normalItemInfoList_vipPricesTmp = null;
	for(normalItemInfoList_vipPricesIndex=0; normalItemInfoList_vipPricesIndex<normalItemInfoList_vipPricesSize; normalItemInfoList_vipPricesIndex++){
		_normalItemInfoList_vipPricesTmp = new CurrencyInfoData();
		_normalItemInfoList_vipPrices[normalItemInfoList_vipPricesIndex] = _normalItemInfoList_vipPricesTmp;
	// 货币类型
	int _normalItemInfoList_vipPrices_currencyType = ReadInt();	_normalItemInfoList_vipPricesTmp.currencyType = _normalItemInfoList_vipPrices_currencyType;
		// 货币数量
	long _normalItemInfoList_vipPrices_num = ReadLong();	_normalItemInfoList_vipPricesTmp.num = _normalItemInfoList_vipPrices_num;
		}
	//end
	_normalItemInfoListTmp.vipPrices = _normalItemInfoList_vipPrices;
		// 是否热卖
	int _normalItemInfoList_hot = ReadInt();	_normalItemInfoListTmp.hot = _normalItemInfoList_hot;
		// 各种标识
	string _normalItemInfoList_marks = ReadString();	_normalItemInfoListTmp.marks = _normalItemInfoList_marks;
		}
	//end



		this.catalogId = _catalogId;
		this.normalItemInfoList = _normalItemInfoList;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_MALL_ITEM_LIST;
	}
	
	public override string getEventType()
	{
		return MallGCHandler.GCMallItemListEvent;
	}
	

	public int getCatalogId(){
		return catalogId;
	}
		

	public MallNormalItemInfoData[] getNormalItemInfoList(){
		return normalItemInfoList;
	}


}
}