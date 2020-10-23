
using System;
namespace app.net
{
/**
 * 离线奖励信息，一个奖励
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCOfflinerewardInfo :BaseMessage
{
	/** 离线奖励类型 */
	private int offlineRewardType;
	/** 创建时间 */
	private string createTime;
	/** 离线奖励描述信息 */
	private string props;
	/** 具体奖励信息 */
	private RewardInfoData rewardInfos;

	public GCOfflinerewardInfo ()
	{
	}

	protected override void ReadImpl()
	{
	// 离线奖励类型
	int _offlineRewardType = ReadInt();
	// 创建时间
	string _createTime = ReadString();
	// 离线奖励描述信息
	string _props = ReadString();
	// 具体奖励信息
	RewardInfoData _rewardInfos = new RewardInfoData();
	// 奖励信息
	string _rewardInfos_rewardStr = ReadString();	_rewardInfos.rewardStr = _rewardInfos_rewardStr;



		this.offlineRewardType = _offlineRewardType;
		this.createTime = _createTime;
		this.props = _props;
		this.rewardInfos = _rewardInfos;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_OFFLINEREWARD_INFO;
	}
	
	public override string getEventType()
	{
		return HumanGCHandler.GCOfflinerewardInfoEvent;
	}
	

	public int getOfflineRewardType(){
		return offlineRewardType;
	}
		

	public string getCreateTime(){
		return createTime;
	}
		

	public string getProps(){
		return props;
	}
		

	public RewardInfoData getRewardInfos(){
		return rewardInfos;
	}
		

}
}