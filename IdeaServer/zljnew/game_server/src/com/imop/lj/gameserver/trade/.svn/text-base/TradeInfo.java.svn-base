package com.imop.lj.gameserver.trade;

import net.sf.json.JSONObject;

public class TradeInfo {
	/** 卖家角色 */
	private long sellerId;
	/** 买家角色 */
	private long buyerId;
	/** 商品类型 */
	private int commodityType;
	/** 交易状态 */
	private int tradeStatus;
	/** 商品详细信息 */
	private String commodityJson ;
	/** 商品在卖家的摊位位置*/
	private int boothIndex;
	/** 出售货币类型 */
	private int currencyType;
	/** 售价 */
	private int currencyNum;
	/** 商品数量 */
	private int commodityNum;
	/** 交易创建时间 */
	private long startTime;
	/** 商品下架时间*/
	private long overDueTime;
	/** */
	
	public TradeInfo(long sellerId, long buyerId, int commodityType,
			int tradeStatus, String commodityJson, int boothIndex,
			int currencyType, int currencyNum, int commodityNum,
			long startTime, long overDueTime) {
		super();
		this.sellerId = sellerId;
		this.buyerId = buyerId;
		this.commodityType = commodityType;
		this.tradeStatus = tradeStatus;
		this.commodityJson = commodityJson;
		this.boothIndex = boothIndex;
		this.currencyType = currencyType;
		this.currencyNum = currencyNum;
		this.commodityNum = commodityNum;
		this.startTime = startTime;
		this.overDueTime = overDueTime;
	}
	
    public JSONObject toJson() {
        JSONObject jsonObject = new JSONObject();
        jsonObject.put("commodityType", commodityType);
        jsonObject.put("tradeStatus", tradeStatus);
        jsonObject.put("commodityJson",commodityJson);
        jsonObject.put("boothIndex",boothIndex);
        jsonObject.put("currencyType",currencyType);
        jsonObject.put("currencyNum",currencyNum);
        jsonObject.put("commodityNum",commodityNum);
        jsonObject.put("startTime",startTime);
        jsonObject.put("overDueTime",overDueTime);
        return jsonObject;
    }
	
	public TradeInfo() {
		super();
	}
	
	public long getSellerId() {
		return sellerId;
	}
	public void setSellerId(long sellerId) {
		this.sellerId = sellerId;
	}
	public long getBuyerId() {
		return buyerId;
	}
	public void setBuyerId(long buyerId) {
		this.buyerId = buyerId;
	}
	public int getCommodityType() {
		return commodityType;
	}
	public void setCommodityType(int commodityType) {
		this.commodityType = commodityType;
	}
	public int getTradeStatus() {
		return tradeStatus;
	}
	public void setTradeStatus(int tradeStatus) {
		this.tradeStatus = tradeStatus;
	}
	public String getCommodityJson() {
		return commodityJson;
	}
	public void setCommodityJson(String commodityJson) {
		this.commodityJson = commodityJson;
	}
	public int getBoothIndex() {
		return boothIndex;
	}
	public void setBoothIndex(int boothIndex) {
		this.boothIndex = boothIndex;
	}
	public int getCurrencyType() {
		return currencyType;
	}
	public void setCurrencyType(int currencyType) {
		this.currencyType = currencyType;
	}
	public int getCurrencyNum() {
		return currencyNum;
	}
	public void setCurrencyNum(int currencyNum) {
		this.currencyNum = currencyNum;
	}
	public int getCommodityNum() {
		return commodityNum;
	}
	public void setCommodityNum(int commodityNum) {
		this.commodityNum = commodityNum;
	}
	public long getStartTime() {
		return startTime;
	}
	public void setStartTime(long startTime) {
		this.startTime = startTime;
	}
	public long getOverDueTime() {
		return overDueTime;
	}
	public void setOverDueTime(long overDueTime) {
		this.overDueTime = overDueTime;
	}

	@Override
	public String toString() {
		return "TradeInfo [sellerId=" + sellerId + ", buyerId=" + buyerId + ", commodityType=" + commodityType
				+ ", tradeStatus=" + tradeStatus + ", commodityJson=" + commodityJson + ", boothIndex=" + boothIndex
				+ ", currencyType=" + currencyType + ", currencyNum=" + currencyNum + ", commodityNum=" + commodityNum
				+ ", startTime=" + startTime + ", overDueTime=" + overDueTime + "]";
	}
	
}
