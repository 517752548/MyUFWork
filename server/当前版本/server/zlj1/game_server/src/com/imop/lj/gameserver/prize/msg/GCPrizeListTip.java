package com.imop.lj.gameserver.prize.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 查询平台玩家奖励列表和gm补偿列表时，礼包内的具体物品信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPrizeListTip extends GCMessage{
	
	/** 奖励列表内的具体物品信息 */
	private com.imop.lj.gameserver.prize.UserPrizeTipInfo[] userPrizeTips;

	public GCPrizeListTip (){
	}
	
	public GCPrizeListTip (
			com.imop.lj.gameserver.prize.UserPrizeTipInfo[] userPrizeTips ){
			this.userPrizeTips = userPrizeTips;
	}

	@Override
	protected boolean readImpl() {

	// 奖励列表内的具体物品信息
	int userPrizeTipsSize = readUnsignedShort();
	com.imop.lj.gameserver.prize.UserPrizeTipInfo[] _userPrizeTips = new com.imop.lj.gameserver.prize.UserPrizeTipInfo[userPrizeTipsSize];
	int userPrizeTipsIndex = 0;
	for(userPrizeTipsIndex=0; userPrizeTipsIndex<userPrizeTipsSize; userPrizeTipsIndex++){
		_userPrizeTips[userPrizeTipsIndex] = new com.imop.lj.gameserver.prize.UserPrizeTipInfo();
	// 奖品id 
	String _userPrizeTips_prizeId = readString();
	//end
	_userPrizeTips[userPrizeTipsIndex].setPrizeId (_userPrizeTips_prizeId);

	// 礼包内金钱信息
	int userPrizeTips_moneysSize = readUnsignedShort();
	com.imop.lj.gameserver.prize.UserPrizeItemTipInfo[] _userPrizeTips_moneys = new com.imop.lj.gameserver.prize.UserPrizeItemTipInfo[userPrizeTips_moneysSize];
	int userPrizeTips_moneysIndex = 0;
	for(userPrizeTips_moneysIndex=0; userPrizeTips_moneysIndex<userPrizeTips_moneysSize; userPrizeTips_moneysIndex++){
		_userPrizeTips_moneys[userPrizeTips_moneysIndex] = new com.imop.lj.gameserver.prize.UserPrizeItemTipInfo();
	// 金钱数量
	int _userPrizeTips_moneys_num = readInteger();
	//end
	_userPrizeTips_moneys[userPrizeTips_moneysIndex].setNum (_userPrizeTips_moneys_num);

	// 金钱名称
	String _userPrizeTips_moneys_name = readString();
	//end
	_userPrizeTips_moneys[userPrizeTips_moneysIndex].setName (_userPrizeTips_moneys_name);

	// 金钱颜色
	String _userPrizeTips_moneys_color = readString();
	//end
	_userPrizeTips_moneys[userPrizeTips_moneysIndex].setColor (_userPrizeTips_moneys_color);

	// 货币类型
	int _userPrizeTips_moneys_moneyType = readInteger();
	//end
	_userPrizeTips_moneys[userPrizeTips_moneysIndex].setMoneyType (_userPrizeTips_moneys_moneyType);
	}
	//end
	_userPrizeTips[userPrizeTipsIndex].setMoneys (_userPrizeTips_moneys);

	// 礼包内物品信息
	int userPrizeTips_itemsSize = readUnsignedShort();
	com.imop.lj.gameserver.prize.UserPrizeItemTipInfo[] _userPrizeTips_items = new com.imop.lj.gameserver.prize.UserPrizeItemTipInfo[userPrizeTips_itemsSize];
	int userPrizeTips_itemsIndex = 0;
	for(userPrizeTips_itemsIndex=0; userPrizeTips_itemsIndex<userPrizeTips_itemsSize; userPrizeTips_itemsIndex++){
		_userPrizeTips_items[userPrizeTips_itemsIndex] = new com.imop.lj.gameserver.prize.UserPrizeItemTipInfo();
	// 物品数量
	int _userPrizeTips_items_num = readInteger();
	//end
	_userPrizeTips_items[userPrizeTips_itemsIndex].setNum (_userPrizeTips_items_num);

	// 物品名称
	String _userPrizeTips_items_name = readString();
	//end
	_userPrizeTips_items[userPrizeTips_itemsIndex].setName (_userPrizeTips_items_name);

	// 物品颜色
	String _userPrizeTips_items_color = readString();
	//end
	_userPrizeTips_items[userPrizeTips_itemsIndex].setColor (_userPrizeTips_items_color);
	}
	//end
	_userPrizeTips[userPrizeTipsIndex].setItems (_userPrizeTips_items);
	}
	//end



		this.userPrizeTips = _userPrizeTips;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 奖励列表内的具体物品信息
	writeShort(userPrizeTips.length);
	int userPrizeTipsIndex = 0;
	int userPrizeTipsSize = userPrizeTips.length;
	for(userPrizeTipsIndex=0; userPrizeTipsIndex<userPrizeTipsSize; userPrizeTipsIndex++){

	String userPrizeTips_prizeId = userPrizeTips[userPrizeTipsIndex].getPrizeId();

	// 奖品id 
	writeString(userPrizeTips_prizeId);

	com.imop.lj.gameserver.prize.UserPrizeItemTipInfo[] userPrizeTips_moneys = userPrizeTips[userPrizeTipsIndex].getMoneys();

	// 礼包内金钱信息
	writeShort(userPrizeTips_moneys.length);
	int userPrizeTips_moneysIndex = 0;
	int userPrizeTips_moneysSize = userPrizeTips_moneys.length;
	for(userPrizeTips_moneysIndex=0; userPrizeTips_moneysIndex<userPrizeTips_moneysSize; userPrizeTips_moneysIndex++){

	int userPrizeTips_moneys_num = userPrizeTips_moneys[userPrizeTips_moneysIndex].getNum();

	// 金钱数量
	writeInteger(userPrizeTips_moneys_num);

	String userPrizeTips_moneys_name = userPrizeTips_moneys[userPrizeTips_moneysIndex].getName();

	// 金钱名称
	writeString(userPrizeTips_moneys_name);

	String userPrizeTips_moneys_color = userPrizeTips_moneys[userPrizeTips_moneysIndex].getColor();

	// 金钱颜色
	writeString(userPrizeTips_moneys_color);

	int userPrizeTips_moneys_moneyType = userPrizeTips_moneys[userPrizeTips_moneysIndex].getMoneyType();

	// 货币类型
	writeInteger(userPrizeTips_moneys_moneyType);
	}
	//end

	com.imop.lj.gameserver.prize.UserPrizeItemTipInfo[] userPrizeTips_items = userPrizeTips[userPrizeTipsIndex].getItems();

	// 礼包内物品信息
	writeShort(userPrizeTips_items.length);
	int userPrizeTips_itemsIndex = 0;
	int userPrizeTips_itemsSize = userPrizeTips_items.length;
	for(userPrizeTips_itemsIndex=0; userPrizeTips_itemsIndex<userPrizeTips_itemsSize; userPrizeTips_itemsIndex++){

	int userPrizeTips_items_num = userPrizeTips_items[userPrizeTips_itemsIndex].getNum();

	// 物品数量
	writeInteger(userPrizeTips_items_num);

	String userPrizeTips_items_name = userPrizeTips_items[userPrizeTips_itemsIndex].getName();

	// 物品名称
	writeString(userPrizeTips_items_name);

	String userPrizeTips_items_color = userPrizeTips_items[userPrizeTips_itemsIndex].getColor();

	// 物品颜色
	writeString(userPrizeTips_items_color);
	}
	//end
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_PRIZE_LIST_TIP;
	}
	
	@Override
	public String getTypeName() {
		return "GC_PRIZE_LIST_TIP";
	}

	public com.imop.lj.gameserver.prize.UserPrizeTipInfo[] getUserPrizeTips(){
		return userPrizeTips;
	}

	public void setUserPrizeTips(com.imop.lj.gameserver.prize.UserPrizeTipInfo[] userPrizeTips){
		this.userPrizeTips = userPrizeTips;
	}	
}