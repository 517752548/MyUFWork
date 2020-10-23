package com.imop.lj.gameserver.trade;

import java.sql.Timestamp;

import com.imop.lj.core.object.LifeCycle;
import com.imop.lj.core.object.LifeCycleImpl;
import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.core.uuid.UUIDType;
import com.imop.lj.db.model.TradeEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.scene.CommonScene;
import com.imop.lj.gameserver.trade.TradeDef.CommodityType;
import com.imop.lj.gameserver.trade.TradeDef.TradeStatue;
import com.imop.lj.gameserver.trade.bean.ICommodity;
import com.imop.lj.gameserver.trade.bean.TradeItem;
import com.imop.lj.gameserver.trade.bean.TradePet;

public class Trade implements PersistanceObject<Long, TradeEntity>,Comparable<Trade> {
	
	/** 此实例是否在db中 */
	private boolean isInDb;
	/** 生命期 */ 
	private final LifeCycle lifeCycle; 
	/** 场景 */
	private CommonScene commonScene;
	
	
	/** 主键 */
	private long id;
	/** 卖家角色 */
	private long sellerId;
	/** 买家角色 */
	private long buyerId = 0;
	/** 商品类型 */
	private CommodityType commodityType;
	/** 交易状态 */
	private TradeStatue tradeStatus;
	/** 商品详细信息 */
	private ICommodity<?> commodityPojo ;
	/** 交易创建时间 */
	private Timestamp startTime;
	/** 交易最后更新时间*/
	private Timestamp lastUpdateTime;
	/** 商品在卖家的摊位位置*/
	private int boothIndex;
	/** 出售货币类型 */
	private Currency currencyType;
	/** 售价 */
	private int currencyNum;
	/** 商品数量 */
	private int commodityNum;
	/** 商品下架时间*/
	private Timestamp overDueTime;
	/**交易信息类，用于消息*/
	private TradeInfo tradeInfo ;
	
	private Timestamp deleteDate;
	private int deleted;
	
	
	/**这个方法只在加载交易行时使用*/
	public Trade() {
		super();
		this.commonScene = Globals.getSceneService().getCommonScene();
		lifeCycle = new LifeCycleImpl(this);
	}

	public Trade(Human Seller) {
		super();
		this.commonScene = Globals.getSceneService().getCommonScene();
		lifeCycle = new LifeCycleImpl(this);
		this.sellerId = Seller.getCharId();
		init();
	}
	
	protected void init() {
		// 设置交易为初始状态
		setTradeStatus(TradeStatue.NULL);
		this.id = Globals.getUUIDService().getNextUUID(UUIDType.TRADE);
		this.startTime = new Timestamp(0L);
		this.startTime.setTime(Globals.getTimeService().now());
		this.overDueTime = new Timestamp(0L);
		this.overDueTime.setTime(Globals.getTimeService().now() + TimeUtils.DAY * Globals.getGameConstants().getShelfLife());
	}
	
	/**
	 * 生成交易信息消息类,在set方法的最后执行
	 */
	public void buildTradeInfo(){
		this.tradeInfo = new TradeInfo(sellerId,buyerId,commodityType.index,tradeStatus.index,commodityPojo.toCommodityJsonForTradeInfo(),boothIndex,currencyType.index,currencyNum,commodityNum,startTime.getTime(),overDueTime.getTime());
	}
	
	
	public CommonScene getCommonScene() {
		return commonScene;
	}

	public void setCommonScene(CommonScene commonScene) {
		this.commonScene = commonScene;
	}

	public long getId() {
		return id;
	}

	public void setId(long id) {
		this.id = id;
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

	public ICommodity<?> getCommodityPojo() {
		return commodityPojo;
	}


	public void setCommodityPojo(ICommodity<?> commodityPojo) {
		this.commodityPojo = commodityPojo;
	}

	public CommodityType getCommodityType() {
		return commodityType;
	}

	public void setCommodityType(CommodityType CommodityType) {
		this.commodityType = CommodityType;
	}

	public TradeStatue getTradeStatus() {
		return tradeStatus;
	}

	public void setTradeStatus(TradeStatue tradeStatus) {
		this.tradeStatus = tradeStatus;
		if (this.tradeInfo != null) {
			this.tradeInfo.setTradeStatus(tradeStatus.getIndex());
		}
	}


	public Timestamp getDeleteDate() {
		return deleteDate;
	}

	public void setDeleteDate(Timestamp deleteDate) {
		this.deleteDate = deleteDate;
	}

	public int getDeleted() {
		return deleted;
	}

	public void setDeleted(int deleted) {
		this.deleted = deleted;
	}

	@Override
	public void setDbId(Long id) {
		this.id = id ;
	}


	@Override
	public Long getDbId() {
		return this.id;
	}


	@Override
	public String getGUID() {
		return "Trade#" + this.id;
	}

	@Override
	public boolean isInDb() {
		return this.isInDb;
	}

	@Override
	public void setInDb(boolean inDb) {
		this.isInDb = inDb;
	}

	@Override
	public long getCharId() {
		return this.id;
	}

	@Override
	public TradeEntity toEntity() {
		TradeEntity te = new TradeEntity();
		te.setSellerCharId(this.sellerId);
		te.setStartTime(this.getStartTime());
		te.setLastUpdateTime(this.getLastUpdateTime());
		te.setType(this.getCommodityType().index);
		te.setTradeStatus(this.getTradeStatus().index);
		te.setBuyerCharId(this.buyerId);
		te.setDeleted(this.getDeleted());
		te.setDeleteDate(this.getDeleted() == 1 ? this.getDeleteDate(): null);
		te.setId(this.getId());
		te.setCommodityInfo(this.getCommodityPojo()==null ? null : this.getCommodityPojo().toCommodityJson());
		te.setBoothIndex(this.getBoothIndex());
		te.setCurrencyType(this.getCurrencyType().index);
		te.setCurrencyNum(this.getCurrencyNum());
		te.setCommodityNum(this.getCommodityNum());
		te.setOverDueTime(this.getOverDueTime());
		return te;
	}

	@Override
	public void fromEntity(TradeEntity entity) {
		this.id = entity.getId();
		this.sellerId = entity.getSellerCharId();
		this.buyerId = entity.getBuyerCharId();
		this.commodityType = CommodityType.valueOf(entity.getType());
		this.isInDb = true ;
		this.deleted = entity.getDeleted();
		this.tradeStatus = TradeStatue.valueOf(entity.getTradeStatus());
		this.deleteDate = entity.getDeleteDate();
		this.startTime = entity.getStartTime();
		this.lastUpdateTime = entity.getLastUpdateTime();
		this.boothIndex = entity.getBoothIndex();
		this.currencyType = Currency.valueOf(entity.getCurrencyType());
		this.currencyNum = entity.getCurrencyNum();
		this.overDueTime = entity.getOverDueTime();
		this.commodityNum = entity.getCommodityNum();
		this.loadCommodity(entity);
		this.buildTradeInfo();
	}
	
	private void loadCommodity(TradeEntity entity){
		this.commodityPojo = getPojo(this.getCommodityType());
		if(this.getCommodityPojo()!=null){
			this.getCommodityPojo().loadFromCommodityJson(entity.getCommodityInfo());
		}
	}
	//TODO
	private ICommodity<?> getPojo(CommodityType type){
		switch(type){
			case PET : return new TradePet();
			case ITEM : return new TradeItem();
			default : return null;
		}
	}
	@Override
	public LifeCycle getLifeCycle() {
		return this.lifeCycle;
	}

	@Override
	public void setModified() {
		if (this.lifeCycle.isActive()) {
			commonScene.getCommonDataUpdater().addUpdate(lifeCycle);
		}		
	}

	/**
	 * 删除信息
	 */
	public void delete() {
		onDelete();
	}
	
	/**
	 * 实例被删除,触发删除机制
	 */
	protected void onDelete() {
		this.lifeCycle.destroy();
		this.commonScene.getCommonDataUpdater().addDelete(lifeCycle);
	}
	
	/**
	 * 激活此对象，并初始化属性
	 */
	public void active() {
		getLifeCycle().activate();
	}

	public int getBoothIndex() {
		return boothIndex;
	}

	public void setBoothIndex(int boothIndex) {
		this.boothIndex = boothIndex;
	}

	public Currency getCurrencyType() {
		return currencyType;
	}

	public void setCurrencyType(Currency currencyType) {
		this.currencyType = currencyType;
	}

	public int getCurrencyNum() {
		return currencyNum;
	}

	public void setCurrencyNum(int currencyNum) {
		this.currencyNum = currencyNum;
	}

	public Timestamp getStartTime() {
		return startTime;
	}

	public void setStartTime(Timestamp startTime) {
		this.startTime = startTime;
	}

	public Timestamp getLastUpdateTime() {
		return lastUpdateTime;
	}

	public void setLastUpdateTime(Timestamp lastUpdateTime) {
		this.lastUpdateTime = lastUpdateTime;
	}

	public Timestamp getOverDueTime() {
		return overDueTime;
	}

	public void setOverDueTime(Timestamp overDueTime) {
		this.overDueTime = overDueTime;
	}

	public int getCommodityNum() {
		return commodityNum;
	}

	public void setCommodityNum(int commodityNum) {
		this.commodityNum = commodityNum;
	}

	public TradeInfo getTradeInfo() {
		return tradeInfo;
	}

	public void setTradeInfo(TradeInfo tradeInfo) {
		this.tradeInfo = tradeInfo;
	}

	@Override
	public int compareTo(Trade trade) {
        if(this.id>trade.id){  
            return 1;  
        }  
        else{  
            return 0;  
        }  
	}

	@Override
	public String toString() {
		return "Trade [isInDb=" + isInDb + ", lifeCycle=" + lifeCycle + ", commonScene=" + commonScene + ", id=" + id
				+ ", sellerId=" + sellerId + ", buyerId=" + buyerId + ", commodityType=" + commodityType
				+ ", tradeStatus=" + tradeStatus + ", commodityPojo=" + commodityPojo + ", startTime=" + startTime
				+ ", lastUpdateTime=" + lastUpdateTime + ", boothIndex=" + boothIndex + ", currencyType=" + currencyType
				+ ", currencyNum=" + currencyNum + ", commodityNum=" + commodityNum + ", overDueTime=" + overDueTime
				+ ", tradeInfo=" + tradeInfo + ", deleteDate=" + deleteDate + ", deleted=" + deleted + "]";
	}
}
