
using System;
namespace app.net
{
/**
 * 返回在线礼包信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCOnlinegiftInfo :BaseMessage
{
	/** 该领取到的id */
	private int rewardId;
	/** 计时开始的时间 */
	private long cdTime;
	/** 礼包信息 */
	private RewardInfoData[] rewardInfo;

	public GCOnlinegiftInfo ()
	{
	}

	protected override void ReadImpl()
	{
	// 该领取到的id
	int _rewardId = ReadInt();
	// 计时开始的时间
	long _cdTime = ReadLong();

	// 礼包信息
	int rewardInfoSize = ReadShort();
	RewardInfoData[] _rewardInfo = new RewardInfoData[rewardInfoSize];
	int rewardInfoIndex = 0;
	RewardInfoData _rewardInfoTmp = null;
	for(rewardInfoIndex=0; rewardInfoIndex<rewardInfoSize; rewardInfoIndex++){
		_rewardInfoTmp = new RewardInfoData();
		_rewardInfo[rewardInfoIndex] = _rewardInfoTmp;
	// 奖励信息
	string _rewardInfo_rewardStr = ReadString();	_rewardInfoTmp.rewardStr = _rewardInfo_rewardStr;
		}
	//end



		this.rewardId = _rewardId;
		this.cdTime = _cdTime;
		this.rewardInfo = _rewardInfo;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_ONLINEGIFT_INFO;
	}
	
	public override string getEventType()
	{
		return OnlinegiftGCHandler.GCOnlinegiftInfoEvent;
	}
	

	public int getRewardId(){
		return rewardId;
	}
		

	public long getCdTime(){
		return cdTime;
	}
		

	public RewardInfoData[] getRewardInfo(){
		return rewardInfo;
	}


}
}