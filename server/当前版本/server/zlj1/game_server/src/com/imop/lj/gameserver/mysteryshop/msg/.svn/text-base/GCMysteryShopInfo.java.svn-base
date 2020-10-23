package com.imop.lj.gameserver.mysteryshop.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 返回神秘商店信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCMysteryShopInfo extends GCMessage{
	
	/** 神秘商店物品列表 */
	private com.imop.lj.common.model.mysteryshop.MSItemInfo[] msItemInfoList;
	/** CD */
	private long cd;
	/** 刷新价格 */
	private com.imop.lj.common.model.CurrencyInfo bondFlushPrice;
	/** 免费刷新次数 */
	private int freeFlushNum;

	public GCMysteryShopInfo (){
	}
	
	public GCMysteryShopInfo (
			com.imop.lj.common.model.mysteryshop.MSItemInfo[] msItemInfoList,
			long cd,
			com.imop.lj.common.model.CurrencyInfo bondFlushPrice,
			int freeFlushNum ){
			this.msItemInfoList = msItemInfoList;
			this.cd = cd;
			this.bondFlushPrice = bondFlushPrice;
			this.freeFlushNum = freeFlushNum;
	}

	@Override
	protected boolean readImpl() {

	// 神秘商店物品列表
	int msItemInfoListSize = readUnsignedShort();
	com.imop.lj.common.model.mysteryshop.MSItemInfo[] _msItemInfoList = new com.imop.lj.common.model.mysteryshop.MSItemInfo[msItemInfoListSize];
	int msItemInfoListIndex = 0;
	for(msItemInfoListIndex=0; msItemInfoListIndex<msItemInfoListSize; msItemInfoListIndex++){
		_msItemInfoList[msItemInfoListIndex] = new com.imop.lj.common.model.mysteryshop.MSItemInfo();
	// 神秘商店物品ID
	int _msItemInfoList_id = readInteger();
	//end
	_msItemInfoList[msItemInfoListIndex].setId (_msItemInfoList_id);

	// 1-等待购买,2-已购买
	int _msItemInfoList_buyState = readInteger();
	//end
	_msItemInfoList[msItemInfoListIndex].setBuyState (_msItemInfoList_buyState);
	}
	//end


	// CD
	long _cd = readLong();
	//end

	// 刷新价格
	com.imop.lj.common.model.CurrencyInfo _bondFlushPrice = new com.imop.lj.common.model.CurrencyInfo();

	// 货币类型
	int _bondFlushPrice_currencyType = readInteger();
	//end
	_bondFlushPrice.setCurrencyType (_bondFlushPrice_currencyType);

	// 货币数量
	long _bondFlushPrice_num = readLong();
	//end
	_bondFlushPrice.setNum (_bondFlushPrice_num);


	// 免费刷新次数
	int _freeFlushNum = readInteger();
	//end



		this.msItemInfoList = _msItemInfoList;
		this.cd = _cd;
		this.bondFlushPrice = _bondFlushPrice;
		this.freeFlushNum = _freeFlushNum;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 神秘商店物品列表
	writeShort(msItemInfoList.length);
	int msItemInfoListIndex = 0;
	int msItemInfoListSize = msItemInfoList.length;
	for(msItemInfoListIndex=0; msItemInfoListIndex<msItemInfoListSize; msItemInfoListIndex++){

	int msItemInfoList_id = msItemInfoList[msItemInfoListIndex].getId();

	// 神秘商店物品ID
	writeInteger(msItemInfoList_id);

	int msItemInfoList_buyState = msItemInfoList[msItemInfoListIndex].getBuyState();

	// 1-等待购买,2-已购买
	writeInteger(msItemInfoList_buyState);
	}
	//end


	// CD
	writeLong(cd);


	int bondFlushPrice_currencyType = bondFlushPrice.getCurrencyType ();

	// 货币类型
	writeInteger(bondFlushPrice_currencyType);

	long bondFlushPrice_num = bondFlushPrice.getNum ();

	// 货币数量
	writeLong(bondFlushPrice_num);


	// 免费刷新次数
	writeInteger(freeFlushNum);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_MYSTERY_SHOP_INFO;
	}
	
	@Override
	public String getTypeName() {
		return "GC_MYSTERY_SHOP_INFO";
	}

	public com.imop.lj.common.model.mysteryshop.MSItemInfo[] getMsItemInfoList(){
		return msItemInfoList;
	}

	public void setMsItemInfoList(com.imop.lj.common.model.mysteryshop.MSItemInfo[] msItemInfoList){
		this.msItemInfoList = msItemInfoList;
	}	

	public long getCd(){
		return cd;
	}
		
	public void setCd(long cd){
		this.cd = cd;
	}

	public com.imop.lj.common.model.CurrencyInfo getBondFlushPrice(){
		return bondFlushPrice;
	}
		
	public void setBondFlushPrice(com.imop.lj.common.model.CurrencyInfo bondFlushPrice){
		this.bondFlushPrice = bondFlushPrice;
	}

	public int getFreeFlushNum(){
		return freeFlushNum;
	}
		
	public void setFreeFlushNum(int freeFlushNum){
		this.freeFlushNum = freeFlushNum;
	}
}