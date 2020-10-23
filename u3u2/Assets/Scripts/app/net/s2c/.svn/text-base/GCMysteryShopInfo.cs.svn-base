
using System;
namespace app.net
{
/**
 * 返回神秘商店信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCMysteryShopInfo :BaseMessage
{
	/** 神秘商店物品列表 */
	private MSItemInfoData[] msItemInfoList;
	/** CD */
	private long cd;
	/** 刷新价格 */
	private CurrencyInfo bondFlushPrice;
	/** 免费刷新次数 */
	private int freeFlushNum;

	public GCMysteryShopInfo ()
	{
	}

	protected override void ReadImpl()
	{

	// 神秘商店物品列表
	int msItemInfoListSize = ReadShort();
	MSItemInfoData[] _msItemInfoList = new MSItemInfoData[msItemInfoListSize];
	int msItemInfoListIndex = 0;
	MSItemInfoData _msItemInfoListTmp = null;
	for(msItemInfoListIndex=0; msItemInfoListIndex<msItemInfoListSize; msItemInfoListIndex++){
		_msItemInfoListTmp = new MSItemInfoData();
		_msItemInfoList[msItemInfoListIndex] = _msItemInfoListTmp;
	// 神秘商店物品ID
	int _msItemInfoList_id = ReadInt();	_msItemInfoListTmp.id = _msItemInfoList_id;
		// 1-等待购买,2-已购买
	int _msItemInfoList_buyState = ReadInt();	_msItemInfoListTmp.buyState = _msItemInfoList_buyState;
		}
	//end

	// CD
	long _cd = ReadLong();
	// 刷新价格
	CurrencyInfo _bondFlushPrice = new CurrencyInfo();
	// 货币类型
	int _bondFlushPrice_currencyType = ReadInt();	_bondFlushPrice.currencyType = _bondFlushPrice_currencyType;
	// 货币数量
	long _bondFlushPrice_num = ReadLong();	_bondFlushPrice.num = _bondFlushPrice_num;

	// 免费刷新次数
	int _freeFlushNum = ReadInt();


		this.msItemInfoList = _msItemInfoList;
		this.cd = _cd;
		this.bondFlushPrice = _bondFlushPrice;
		this.freeFlushNum = _freeFlushNum;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_MYSTERY_SHOP_INFO;
	}
	
	public override string getEventType()
	{
		return MysteryshopGCHandler.GCMysteryShopInfoEvent;
	}
	

	public MSItemInfoData[] getMsItemInfoList(){
		return msItemInfoList;
	}


	public long getCd(){
		return cd;
	}
		

	public CurrencyInfo getBondFlushPrice(){
		return bondFlushPrice;
	}
		

	public int getFreeFlushNum(){
		return freeFlushNum;
	}
		

}
}