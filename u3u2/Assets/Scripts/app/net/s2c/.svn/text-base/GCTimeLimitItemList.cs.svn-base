
using System;
namespace app.net
{
/**
 * 请求限时物品列表
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCTimeLimitItemList :BaseMessage
{
	/** 队列ID */
	private string queueUUID;
	/** 商城限时物品信息列表 */
	private MallTimeLimitItemInfoData[] timeLimitItemInfoList;

	public GCTimeLimitItemList ()
	{
	}

	protected override void ReadImpl()
	{
	// 队列ID
	string _queueUUID = ReadString();

	// 商城限时物品信息列表
	int timeLimitItemInfoListSize = ReadShort();
	MallTimeLimitItemInfoData[] _timeLimitItemInfoList = new MallTimeLimitItemInfoData[timeLimitItemInfoListSize];
	int timeLimitItemInfoListIndex = 0;
	MallTimeLimitItemInfoData _timeLimitItemInfoListTmp = null;
	for(timeLimitItemInfoListIndex=0; timeLimitItemInfoListIndex<timeLimitItemInfoListSize; timeLimitItemInfoListIndex++){
		_timeLimitItemInfoListTmp = new MallTimeLimitItemInfoData();
		_timeLimitItemInfoList[timeLimitItemInfoListIndex] = _timeLimitItemInfoListTmp;
	// 商城物品ID
	int _timeLimitItemInfoList_mallItemId = ReadInt();	_timeLimitItemInfoListTmp.mallItemId = _timeLimitItemInfoList_mallItemId;
		// 商城限时物品信息
	CommonItemData _timeLimitItemInfoList_commonItem = new CommonItemData();
	// 道具实例uuid
	string _timeLimitItemInfoList_commonItem_uuid = ReadString();	_timeLimitItemInfoList_commonItem.uuid = _timeLimitItemInfoList_commonItem_uuid;
	// 包id
	int _timeLimitItemInfoList_commonItem_bagId = ReadInt();	_timeLimitItemInfoList_commonItem.bagId = _timeLimitItemInfoList_commonItem_bagId;
	// 道具在背包内位置索引
	int _timeLimitItemInfoList_commonItem_index = ReadInt();	_timeLimitItemInfoList_commonItem.index = _timeLimitItemInfoList_commonItem_index;
	// 道具模板Id
	int _timeLimitItemInfoList_commonItem_tplId = ReadInt();	_timeLimitItemInfoList_commonItem.tplId = _timeLimitItemInfoList_commonItem_tplId;
	// 数量
	int _timeLimitItemInfoList_commonItem_count = ReadInt();	_timeLimitItemInfoList_commonItem.count = _timeLimitItemInfoList_commonItem_count;
	// 最后一次更新时间
	long _timeLimitItemInfoList_commonItem_lastUpdateTime = ReadLong();	_timeLimitItemInfoList_commonItem.lastUpdateTime = _timeLimitItemInfoList_commonItem_lastUpdateTime;
	// 剩余使用时限描述
	string _timeLimitItemInfoList_commonItem_expireDesc = ReadString();	_timeLimitItemInfoList_commonItem.expireDesc = _timeLimitItemInfoList_commonItem_expireDesc;
	// 持有者id，主背包为0
	long _timeLimitItemInfoList_commonItem_wearerId = ReadLong();	_timeLimitItemInfoList_commonItem.wearerId = _timeLimitItemInfoList_commonItem_wearerId;
	// 绑定状态，0绑定，1未绑定
	int _timeLimitItemInfoList_commonItem_bind = ReadInt();	_timeLimitItemInfoList_commonItem.bind = _timeLimitItemInfoList_commonItem_bind;
	// 道具props，json
	string _timeLimitItemInfoList_commonItem_props = ReadString();	_timeLimitItemInfoList_commonItem.props = _timeLimitItemInfoList_commonItem_props;
	_timeLimitItemInfoListTmp.commonItem = _timeLimitItemInfoList_commonItem;
		// 价格
	CurrencyInfoData _timeLimitItemInfoList_price = new CurrencyInfoData();
	// 货币类型
	int _timeLimitItemInfoList_price_currencyType = ReadInt();	_timeLimitItemInfoList_price.currencyType = _timeLimitItemInfoList_price_currencyType;
	// 货币数量
	long _timeLimitItemInfoList_price_num = ReadLong();	_timeLimitItemInfoList_price.num = _timeLimitItemInfoList_price_num;
	_timeLimitItemInfoListTmp.price = _timeLimitItemInfoList_price;
		// 有效期
	long _timeLimitItemInfoList_validPeriod = ReadLong();	_timeLimitItemInfoListTmp.validPeriod = _timeLimitItemInfoList_validPeriod;
		// 是否限制库存
	int _timeLimitItemInfoList_limitStock = ReadInt();	_timeLimitItemInfoListTmp.limitStock = _timeLimitItemInfoList_limitStock;
		// 是否限制库存
	int _timeLimitItemInfoList_stock = ReadInt();	_timeLimitItemInfoListTmp.stock = _timeLimitItemInfoList_stock;
		// 是否限购
	int _timeLimitItemInfoList_limitPurchase = ReadInt();	_timeLimitItemInfoListTmp.limitPurchase = _timeLimitItemInfoList_limitPurchase;
		// 限购数量
	int _timeLimitItemInfoList_limitPurchaseNum = ReadInt();	_timeLimitItemInfoListTmp.limitPurchaseNum = _timeLimitItemInfoList_limitPurchaseNum;
		// 各种标识
	string _timeLimitItemInfoList_marks = ReadString();	_timeLimitItemInfoListTmp.marks = _timeLimitItemInfoList_marks;
		}
	//end



		this.queueUUID = _queueUUID;
		this.timeLimitItemInfoList = _timeLimitItemInfoList;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_TIME_LIMIT_ITEM_LIST;
	}
	
	public override string getEventType()
	{
		return MallGCHandler.GCTimeLimitItemListEvent;
	}
	

	public string getQueueUUID(){
		return queueUUID;
	}
		

	public MallTimeLimitItemInfoData[] getTimeLimitItemInfoList(){
		return timeLimitItemInfoList;
	}


}
}