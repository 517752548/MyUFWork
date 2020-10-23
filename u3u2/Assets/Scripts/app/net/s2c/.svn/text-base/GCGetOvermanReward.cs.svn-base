
using System;
namespace app.net
{
/**
 * 师傅在这个徒弟身上所有奖励的状态
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCGetOvermanReward :BaseMessage
{
	/** 徒弟的id */
	private long lowermanCharId;
	/** 奖励信息 */
	private OvermanRewardInfo[] rewardInfo;

	public GCGetOvermanReward ()
	{
	}

	protected override void ReadImpl()
	{
	// 徒弟的id
	long _lowermanCharId = ReadLong();

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



		this.lowermanCharId = _lowermanCharId;
		this.rewardInfo = _rewardInfo;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_GET_OVERMAN_REWARD;
	}
	
	public override string getEventType()
	{
		return OvermanGCHandler.GCGetOvermanRewardEvent;
	}
	

	public long getLowermanCharId(){
		return lowermanCharId;
	}
		

	public OvermanRewardInfo[] getRewardInfo(){
		return rewardInfo;
	}


}
}