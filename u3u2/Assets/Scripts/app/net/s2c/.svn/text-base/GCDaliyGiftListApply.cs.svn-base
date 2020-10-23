
using System;
namespace app.net
{
/**
 * 申请每日签到奖励信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCDaliyGiftListApply :BaseMessage
{
	/** 返回可以获得的奖励的信息 */
	private RewardInfoData[] rewardInfoList;

	public GCDaliyGiftListApply ()
	{
	}

	protected override void ReadImpl()
	{

	// 返回可以获得的奖励的信息
	int rewardInfoListSize = ReadShort();
	RewardInfoData[] _rewardInfoList = new RewardInfoData[rewardInfoListSize];
	int rewardInfoListIndex = 0;
	RewardInfoData _rewardInfoListTmp = null;
	for(rewardInfoListIndex=0; rewardInfoListIndex<rewardInfoListSize; rewardInfoListIndex++){
		_rewardInfoListTmp = new RewardInfoData();
		_rewardInfoList[rewardInfoListIndex] = _rewardInfoListTmp;
	// 奖励信息
	string _rewardInfoList_rewardStr = ReadString();	_rewardInfoListTmp.rewardStr = _rewardInfoList_rewardStr;
		}
	//end



		this.rewardInfoList = _rewardInfoList;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_DALIY_GIFT_LIST_APPLY;
	}
	
	public override string getEventType()
	{
		return OnlinegiftGCHandler.GCDaliyGiftListApplyEvent;
	}
	

	public RewardInfoData[] getRewardInfoList(){
		return rewardInfoList;
	}


}
}