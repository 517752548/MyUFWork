
using System;
namespace app.net
{
/**
 * 返回请求打开帮派红包面板
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCOpenCorpsRedEnvelopePanel :BaseMessage
{
	/** 帮派发送红包的玩家信息 */
	private CorpsRedEnvelopeInfo[] corpsRedEnvelopeInfoList;

	public GCOpenCorpsRedEnvelopePanel ()
	{
	}

	protected override void ReadImpl()
	{

	// 帮派发送红包的玩家信息
	int corpsRedEnvelopeInfoListSize = ReadShort();
	CorpsRedEnvelopeInfo[] _corpsRedEnvelopeInfoList = new CorpsRedEnvelopeInfo[corpsRedEnvelopeInfoListSize];
	int corpsRedEnvelopeInfoListIndex = 0;
	CorpsRedEnvelopeInfo _corpsRedEnvelopeInfoListTmp = null;
	for(corpsRedEnvelopeInfoListIndex=0; corpsRedEnvelopeInfoListIndex<corpsRedEnvelopeInfoListSize; corpsRedEnvelopeInfoListIndex++){
		_corpsRedEnvelopeInfoListTmp = new CorpsRedEnvelopeInfo();
		_corpsRedEnvelopeInfoList[corpsRedEnvelopeInfoListIndex] = _corpsRedEnvelopeInfoListTmp;
	// 要领取红包的uuid
	string _corpsRedEnvelopeInfoList_uuid = ReadString();	_corpsRedEnvelopeInfoListTmp.uuid = _corpsRedEnvelopeInfoList_uuid;
		// 所属帮派Id
	long _corpsRedEnvelopeInfoList_corpsId = ReadLong();	_corpsRedEnvelopeInfoListTmp.corpsId = _corpsRedEnvelopeInfoList_corpsId;
		// 发红包玩家id
	long _corpsRedEnvelopeInfoList_sendId = ReadLong();	_corpsRedEnvelopeInfoListTmp.sendId = _corpsRedEnvelopeInfoList_sendId;
		// 发红包玩家名称
	string _corpsRedEnvelopeInfoList_sendName = ReadString();	_corpsRedEnvelopeInfoListTmp.sendName = _corpsRedEnvelopeInfoList_sendName;
		// 红包内容
	string _corpsRedEnvelopeInfoList_content = ReadString();	_corpsRedEnvelopeInfoListTmp.content = _corpsRedEnvelopeInfoList_content;
		// 红包类型,1-帮派红包
	int _corpsRedEnvelopeInfoList_redEnvelopeType = ReadInt();	_corpsRedEnvelopeInfoListTmp.redEnvelopeType = _corpsRedEnvelopeInfoList_redEnvelopeType;
		// 红包状态,0-不可领取,1-可领取
	int _corpsRedEnvelopeInfoList_redEnvelopeStatus = ReadInt();	_corpsRedEnvelopeInfoListTmp.redEnvelopeStatus = _corpsRedEnvelopeInfoList_redEnvelopeStatus;
		// 发送时间
	long _corpsRedEnvelopeInfoList_createTime = ReadLong();	_corpsRedEnvelopeInfoListTmp.createTime = _corpsRedEnvelopeInfoList_createTime;
		// 红包总金额
	int _corpsRedEnvelopeInfoList_bonusAmount = ReadInt();	_corpsRedEnvelopeInfoListTmp.bonusAmount = _corpsRedEnvelopeInfoList_bonusAmount;
		// 剩余红包数量
	int _corpsRedEnvelopeInfoList_remainingNum = ReadInt();	_corpsRedEnvelopeInfoListTmp.remainingNum = _corpsRedEnvelopeInfoList_remainingNum;
		// 剩余红包金额
	int _corpsRedEnvelopeInfoList_remainingBonus = ReadInt();	_corpsRedEnvelopeInfoListTmp.remainingBonus = _corpsRedEnvelopeInfoList_remainingBonus;
	
	// 帮派抢到红包的玩家信息
	int corpsRedEnvelopeInfoList_openRedEnveloperInfoListSize = ReadShort();
	OpenRedEnveloperInfo[] _corpsRedEnvelopeInfoList_openRedEnveloperInfoList = new OpenRedEnveloperInfo[corpsRedEnvelopeInfoList_openRedEnveloperInfoListSize];
	int corpsRedEnvelopeInfoList_openRedEnveloperInfoListIndex = 0;
	OpenRedEnveloperInfo _corpsRedEnvelopeInfoList_openRedEnveloperInfoListTmp = null;
	for(corpsRedEnvelopeInfoList_openRedEnveloperInfoListIndex=0; corpsRedEnvelopeInfoList_openRedEnveloperInfoListIndex<corpsRedEnvelopeInfoList_openRedEnveloperInfoListSize; corpsRedEnvelopeInfoList_openRedEnveloperInfoListIndex++){
		_corpsRedEnvelopeInfoList_openRedEnveloperInfoListTmp = new OpenRedEnveloperInfo();
		_corpsRedEnvelopeInfoList_openRedEnveloperInfoList[corpsRedEnvelopeInfoList_openRedEnveloperInfoListIndex] = _corpsRedEnvelopeInfoList_openRedEnveloperInfoListTmp;
	// 抢到红包玩家id
	long _corpsRedEnvelopeInfoList_openRedEnveloperInfoList_recId = ReadLong();	_corpsRedEnvelopeInfoList_openRedEnveloperInfoListTmp.recId = _corpsRedEnvelopeInfoList_openRedEnveloperInfoList_recId;
		// 抢到红包玩家姓名
	string _corpsRedEnvelopeInfoList_openRedEnveloperInfoList_recName = ReadString();	_corpsRedEnvelopeInfoList_openRedEnveloperInfoListTmp.recName = _corpsRedEnvelopeInfoList_openRedEnveloperInfoList_recName;
		// 抢到红包的时间
	long _corpsRedEnvelopeInfoList_openRedEnveloperInfoList_openTime = ReadLong();	_corpsRedEnvelopeInfoList_openRedEnveloperInfoListTmp.openTime = _corpsRedEnvelopeInfoList_openRedEnveloperInfoList_openTime;
		// 抢到的红包金额
	int _corpsRedEnvelopeInfoList_openRedEnveloperInfoList_gotBonus = ReadInt();	_corpsRedEnvelopeInfoList_openRedEnveloperInfoListTmp.gotBonus = _corpsRedEnvelopeInfoList_openRedEnveloperInfoList_gotBonus;
		}
	//end
	_corpsRedEnvelopeInfoListTmp.openRedEnveloperInfoList = _corpsRedEnvelopeInfoList_openRedEnveloperInfoList;
		}
	//end



		this.corpsRedEnvelopeInfoList = _corpsRedEnvelopeInfoList;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_OPEN_CORPS_RED_ENVELOPE_PANEL;
	}
	
	public override string getEventType()
	{
		return CorpsGCHandler.GCOpenCorpsRedEnvelopePanelEvent;
	}
	

	public CorpsRedEnvelopeInfo[] getCorpsRedEnvelopeInfoList(){
		return corpsRedEnvelopeInfoList;
	}


}
}