
using System;
namespace app.net
{
/**
 * 仙葫面板消息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCXianhuPanel :BaseMessage
{
	/** 祝福已开启次数 */
	private int zhufuNum;
	/** 祈福已开启次数 */
	private int qifuNum;
	/** 富贵仙葫可领取次数 */
	private int fuguiNum;
	/** 至尊仙葫可领取次数 */
	private int zhizunNum;
	/** 祝福祈福显示奖励id */
	private int rewardId;
	/** 富贵仙葫显示奖励id */
	private int fuguiRewardId;
	/** 至尊仙葫显示奖励id */
	private int zhizunRewardId;

	public GCXianhuPanel ()
	{
	}

	protected override void ReadImpl()
	{
	// 祝福已开启次数
	int _zhufuNum = ReadInt();
	// 祈福已开启次数
	int _qifuNum = ReadInt();
	// 富贵仙葫可领取次数
	int _fuguiNum = ReadInt();
	// 至尊仙葫可领取次数
	int _zhizunNum = ReadInt();
	// 祝福祈福显示奖励id
	int _rewardId = ReadInt();
	// 富贵仙葫显示奖励id
	int _fuguiRewardId = ReadInt();
	// 至尊仙葫显示奖励id
	int _zhizunRewardId = ReadInt();


		this.zhufuNum = _zhufuNum;
		this.qifuNum = _qifuNum;
		this.fuguiNum = _fuguiNum;
		this.zhizunNum = _zhizunNum;
		this.rewardId = _rewardId;
		this.fuguiRewardId = _fuguiRewardId;
		this.zhizunRewardId = _zhizunRewardId;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_XIANHU_PANEL;
	}
	
	public override string getEventType()
	{
		return HumanGCHandler.GCXianhuPanelEvent;
	}
	

	public int getZhufuNum(){
		return zhufuNum;
	}
		

	public int getQifuNum(){
		return qifuNum;
	}
		

	public int getFuguiNum(){
		return fuguiNum;
	}
		

	public int getZhizunNum(){
		return zhizunNum;
	}
		

	public int getRewardId(){
		return rewardId;
	}
		

	public int getFuguiRewardId(){
		return fuguiRewardId;
	}
		

	public int getZhizunRewardId(){
		return zhizunRewardId;
	}
		

}
}