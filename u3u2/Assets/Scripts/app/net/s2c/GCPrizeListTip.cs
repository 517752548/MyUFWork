
using System;
namespace app.net
{
/**
 * 查询平台玩家奖励列表和gm补偿列表时，礼包内的具体物品信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPrizeListTip :BaseMessage
{
	/** 奖励列表内的具体物品信息 */
	private UserPrizeTipInfoData[] userPrizeTips;

	public GCPrizeListTip ()
	{
	}

	protected override void ReadImpl()
	{

	// 奖励列表内的具体物品信息
	int userPrizeTipsSize = ReadShort();
	UserPrizeTipInfoData[] _userPrizeTips = new UserPrizeTipInfoData[userPrizeTipsSize];
	int userPrizeTipsIndex = 0;
	UserPrizeTipInfoData _userPrizeTipsTmp = null;
	for(userPrizeTipsIndex=0; userPrizeTipsIndex<userPrizeTipsSize; userPrizeTipsIndex++){
		_userPrizeTipsTmp = new UserPrizeTipInfoData();
		_userPrizeTips[userPrizeTipsIndex] = _userPrizeTipsTmp;
	// 奖品id 
	string _userPrizeTips_prizeId = ReadString();	_userPrizeTipsTmp.prizeId = _userPrizeTips_prizeId;
	
	// 礼包内金钱信息
	int userPrizeTips_moneysSize = ReadShort();
	UserPrizeMoneyTipInfoData[] _userPrizeTips_moneys = new UserPrizeMoneyTipInfoData[userPrizeTips_moneysSize];
	int userPrizeTips_moneysIndex = 0;
	UserPrizeMoneyTipInfoData _userPrizeTips_moneysTmp = null;
	for(userPrizeTips_moneysIndex=0; userPrizeTips_moneysIndex<userPrizeTips_moneysSize; userPrizeTips_moneysIndex++){
		_userPrizeTips_moneysTmp = new UserPrizeMoneyTipInfoData();
		_userPrizeTips_moneys[userPrizeTips_moneysIndex] = _userPrizeTips_moneysTmp;
	// 金钱数量
	int _userPrizeTips_moneys_num = ReadInt();	_userPrizeTips_moneysTmp.num = _userPrizeTips_moneys_num;
		// 金钱名称
	string _userPrizeTips_moneys_name = ReadString();	_userPrizeTips_moneysTmp.name = _userPrizeTips_moneys_name;
		// 金钱颜色
	string _userPrizeTips_moneys_color = ReadString();	_userPrizeTips_moneysTmp.color = _userPrizeTips_moneys_color;
		// 货币类型
	int _userPrizeTips_moneys_moneyType = ReadInt();	_userPrizeTips_moneysTmp.moneyType = _userPrizeTips_moneys_moneyType;
		}
	//end
	_userPrizeTipsTmp.moneys = _userPrizeTips_moneys;
	
	// 礼包内物品信息
	int userPrizeTips_itemsSize = ReadShort();
	UserPrizeItemTipInfoData[] _userPrizeTips_items = new UserPrizeItemTipInfoData[userPrizeTips_itemsSize];
	int userPrizeTips_itemsIndex = 0;
	UserPrizeItemTipInfoData _userPrizeTips_itemsTmp = null;
	for(userPrizeTips_itemsIndex=0; userPrizeTips_itemsIndex<userPrizeTips_itemsSize; userPrizeTips_itemsIndex++){
		_userPrizeTips_itemsTmp = new UserPrizeItemTipInfoData();
		_userPrizeTips_items[userPrizeTips_itemsIndex] = _userPrizeTips_itemsTmp;
	// 物品数量
	int _userPrizeTips_items_num = ReadInt();	_userPrizeTips_itemsTmp.num = _userPrizeTips_items_num;
		// 物品名称
	string _userPrizeTips_items_name = ReadString();	_userPrizeTips_itemsTmp.name = _userPrizeTips_items_name;
		// 物品颜色
	string _userPrizeTips_items_color = ReadString();	_userPrizeTips_itemsTmp.color = _userPrizeTips_items_color;
		}
	//end
	_userPrizeTipsTmp.items = _userPrizeTips_items;
		}
	//end



		this.userPrizeTips = _userPrizeTips;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_PRIZE_LIST_TIP;
	}
	
	public override string getEventType()
	{
		return PrizeGCHandler.GCPrizeListTipEvent;
	}
	

	public UserPrizeTipInfoData[] getUserPrizeTips(){
		return userPrizeTips;
	}


}
}