
using System;
namespace app.net
{
/**
 * 可以领取奖励,没有可以领奖就空
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCOvermanHongdian :BaseMessage
{
	/** 奖励信息 */
	private long[] rewardInfo;

	public GCOvermanHongdian ()
	{
	}

	protected override void ReadImpl()
	{
	// 奖励信息
	int rewardInfoSize = ReadShort();
	long[] _rewardInfo = new long[rewardInfoSize];
	int rewardInfoIndex = 0;
	for(rewardInfoIndex=0; rewardInfoIndex<rewardInfoSize; rewardInfoIndex++){
		_rewardInfo[rewardInfoIndex] = ReadLong();
	}//end
	


		this.rewardInfo = _rewardInfo;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_OVERMAN_HONGDIAN;
	}
	
	public override string getEventType()
	{
		return OvermanGCHandler.GCOvermanHongdianEvent;
	}
	

	public long[] getRewardInfo(){
		return rewardInfo;
	}


}
}