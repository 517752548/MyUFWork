
using System;
namespace app.net
{
/**
 * 手机验证面板
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCSmsCheckcodePanel :BaseMessage
{
	/** 是否已经通过验证，1已通过验证，2未通过验证 */
	private int result;
	/** QQ号，已通过验证时有效 */
	private string qqNum;
	/** 手机号，已通过验证时有效 */
	private string phoneNum;
	/** 手机验证奖励信息 */
	private RewardInfoData rewardInfos;

	public GCSmsCheckcodePanel ()
	{
	}

	protected override void ReadImpl()
	{
	// 是否已经通过验证，1已通过验证，2未通过验证
	int _result = ReadInt();
	// QQ号，已通过验证时有效
	string _qqNum = ReadString();
	// 手机号，已通过验证时有效
	string _phoneNum = ReadString();
	// 手机验证奖励信息
	RewardInfoData _rewardInfos = new RewardInfoData();
	// 奖励信息
	string _rewardInfos_rewardStr = ReadString();	_rewardInfos.rewardStr = _rewardInfos_rewardStr;



		this.result = _result;
		this.qqNum = _qqNum;
		this.phoneNum = _phoneNum;
		this.rewardInfos = _rewardInfos;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_SMS_CHECKCODE_PANEL;
	}
	
	public override string getEventType()
	{
		return PlayerGCHandler.GCSmsCheckcodePanelEvent;
	}
	

	public int getResult(){
		return result;
	}
		

	public string getQqNum(){
		return qqNum;
	}
		

	public string getPhoneNum(){
		return phoneNum;
	}
		

	public RewardInfoData getRewardInfos(){
		return rewardInfos;
	}
		

}
}