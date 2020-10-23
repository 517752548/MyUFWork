
using System;
namespace app.net
{
/**
 * 获得徒弟所有的奖励状态
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCGetLowermanReward :BaseMessage
{
	/** 奖励信息 */
	private OvermanRewardInfo[] rewardInfo;

	public GCGetLowermanReward ()
	{
	}

	protected override void ReadImpl()
	{

	// 奖励信息
	int rewardInfoSize = ReadShort();
	OvermanRewardInfo[] _rewardInfo = new OvermanRewardInfo[rewardInfoSize];
	int rewardInfoIndex = 0;
	OvermanRewardInfo _rewardInfoTmp = null;
	for(rewardInfoIndex=0; rewardInfoIndex<rewardInfoSize; rewardInfoIndex++){
		_rewardInfoTmp = new OvermanRewardInfo();
		_rewardInfo[rewardInfoIndex] = _rewardInfoTmp;
	// 奖励索引
	int _rewardInfo_index = ReadInt();	_rewardInfoTmp.index = _rewardInfo_index;
		// 是否领取,1领取,0未领取
	int _rewardInfo_hadget = ReadInt();	_rewardInfoTmp.hadget = _rewardInfo_hadget;
		}
	//end



		this.rewardInfo = _rewardInfo;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_GET_LOWERMAN_REWARD;
	}
	
	public override string getEventType()
	{
		return OvermanGCHandler.GCGetLowermanRewardEvent;
	}
	

	public OvermanRewardInfo[] getRewardInfo(){
		return rewardInfo;
	}


}
}