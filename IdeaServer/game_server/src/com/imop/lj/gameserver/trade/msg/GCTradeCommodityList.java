package com.imop.lj.gameserver.trade.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 商品信息表
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCTradeCommodityList extends GCMessage{
	
	/** 商品信息 */
	private com.imop.lj.gameserver.trade.TradeInfo[] tradeList;
	/** 当前页数 */
	private int pageNum;
	/** 总页数 */
	private int totalPageNum;

	public GCTradeCommodityList (){
	}
	
	public GCTradeCommodityList (
			com.imop.lj.gameserver.trade.TradeInfo[] tradeList,
			int pageNum,
			int totalPageNum ){
			this.tradeList = tradeList;
			this.pageNum = pageNum;
			this.totalPageNum = totalPageNum;
	}

	@Override
	protected boolean readImpl() {

	// 商品信息
	int tradeListSize = readUnsignedShort();
	com.imop.lj.gameserver.trade.TradeInfo[] _tradeList = new com.imop.lj.gameserver.trade.TradeInfo[tradeListSize];
	int tradeListIndex = 0;
	for(tradeListIndex=0; tradeListIndex<tradeListSize; tradeListIndex++){
		_tradeList[tradeListIndex] = new com.imop.lj.gameserver.trade.TradeInfo();
	// 卖家ID
	long _tradeList_sellerId = readLong();
	//end
	_tradeList[tradeListIndex].setSellerId (_tradeList_sellerId);

	// 买家ID
	long _tradeList_buyerId = readLong();
	//end
	_tradeList[tradeListIndex].setBuyerId (_tradeList_buyerId);

	// 商品类型
	int _tradeList_commodityType = readInteger();
	//end
	_tradeList[tradeListIndex].setCommodityType (_tradeList_commodityType);

	// 交易状态
	int _tradeList_tradeStatus = readInteger();
	//end
	_tradeList[tradeListIndex].setTradeStatus (_tradeList_tradeStatus);

	// 商品详细信息
	String _tradeList_commodityJson = readString();
	//end
	_tradeList[tradeListIndex].setCommodityJson (_tradeList_commodityJson);

	// 摊位坐标
	int _tradeList_boothIndex = readInteger();
	//end
	_tradeList[tradeListIndex].setBoothIndex (_tradeList_boothIndex);

	// 货币类型
	int _tradeList_currencyType = readInteger();
	//end
	_tradeList[tradeListIndex].setCurrencyType (_tradeList_currencyType);

	// 货币数量
	int _tradeList_currencyNum = readInteger();
	//end
	_tradeList[tradeListIndex].setCurrencyNum (_tradeList_currencyNum);

	// 商品数量
	int _tradeList_commodityNum = readInteger();
	//end
	_tradeList[tradeListIndex].setCommodityNum (_tradeList_commodityNum);

	// 交易创建时间
	long _tradeList_startTime = readLong();
	//end
	_tradeList[tradeListIndex].setStartTime (_tradeList_startTime);

	// 交易过期时间
	long _tradeList_overDueTime = readLong();
	//end
	_tradeList[tradeListIndex].setOverDueTime (_tradeList_overDueTime);
	}
	//end


	// 当前页数
	int _pageNum = readInteger();
	//end


	// 总页数
	int _totalPageNum = readInteger();
	//end



		this.tradeList = _tradeList;
		this.pageNum = _pageNum;
		this.totalPageNum = _totalPageNum;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 商品信息
	writeShort(tradeList.length);
	int tradeListIndex = 0;
	int tradeListSize = tradeList.length;
	for(tradeListIndex=0; tradeListIndex<tradeListSize; tradeListIndex++){

	long tradeList_sellerId = tradeList[tradeListIndex].getSellerId();

	// 卖家ID
	writeLong(tradeList_sellerId);

	long tradeList_buyerId = tradeList[tradeListIndex].getBuyerId();

	// 买家ID
	writeLong(tradeList_buyerId);

	int tradeList_commodityType = tradeList[tradeListIndex].getCommodityType();

	// 商品类型
	writeInteger(tradeList_commodityType);

	int tradeList_tradeStatus = tradeList[tradeListIndex].getTradeStatus();

	// 交易状态
	writeInteger(tradeList_tradeStatus);

	String tradeList_commodityJson = tradeList[tradeListIndex].getCommodityJson();

	// 商品详细信息
	writeString(tradeList_commodityJson);

	int tradeList_boothIndex = tradeList[tradeListIndex].getBoothIndex();

	// 摊位坐标
	writeInteger(tradeList_boothIndex);

	int tradeList_currencyType = tradeList[tradeListIndex].getCurrencyType();

	// 货币类型
	writeInteger(tradeList_currencyType);

	int tradeList_currencyNum = tradeList[tradeListIndex].getCurrencyNum();

	// 货币数量
	writeInteger(tradeList_currencyNum);

	int tradeList_commodityNum = tradeList[tradeListIndex].getCommodityNum();

	// 商品数量
	writeInteger(tradeList_commodityNum);

	long tradeList_startTime = tradeList[tradeListIndex].getStartTime();

	// 交易创建时间
	writeLong(tradeList_startTime);

	long tradeList_overDueTime = tradeList[tradeListIndex].getOverDueTime();

	// 交易过期时间
	writeLong(tradeList_overDueTime);
	}
	//end


	// 当前页数
	writeInteger(pageNum);


	// 总页数
	writeInteger(totalPageNum);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_TRADE_COMMODITY_LIST;
	}
	
	@Override
	public String getTypeName() {
		return "GC_TRADE_COMMODITY_LIST";
	}

	public com.imop.lj.gameserver.trade.TradeInfo[] getTradeList(){
		return tradeList;
	}

	public void setTradeList(com.imop.lj.gameserver.trade.TradeInfo[] tradeList){
		this.tradeList = tradeList;
	}	

	public int getPageNum(){
		return pageNum;
	}
		
	public void setPageNum(int pageNum){
		this.pageNum = pageNum;
	}

	public int getTotalPageNum(){
		return totalPageNum;
	}
		
	public void setTotalPageNum(int totalPageNum){
		this.totalPageNum = totalPageNum;
	}
}