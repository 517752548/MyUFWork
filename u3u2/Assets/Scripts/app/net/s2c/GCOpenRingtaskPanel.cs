
using System;
namespace app.net
{
/**
 * 打开跑环任务面板
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCOpenRingtaskPanel :BaseMessage
{
	/** 今日已完成任务数 */
	private int finishTimes;
	/** 总任务数 */
	private int totalTimes;
	/** 今日已放弃次数 */
	private int giveUpTimes;
	/** 总放弃次数 */
	private int giveUpTotalTimes;

	public GCOpenRingtaskPanel ()
	{
	}

	protected override void ReadImpl()
	{
	// 今日已完成任务数
	int _finishTimes = ReadInt();
	// 总任务数
	int _totalTimes = ReadInt();
	// 今日已放弃次数
	int _giveUpTimes = ReadInt();
	// 总放弃次数
	int _giveUpTotalTimes = ReadInt();


		this.finishTimes = _finishTimes;
		this.totalTimes = _totalTimes;
		this.giveUpTimes = _giveUpTimes;
		this.giveUpTotalTimes = _giveUpTotalTimes;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_OPEN_RINGTASK_PANEL;
	}
	
	public override string getEventType()
	{
		return RingtaskGCHandler.GCOpenRingtaskPanelEvent;
	}
	

	public int getFinishTimes(){
		return finishTimes;
	}
		

	public int getTotalTimes(){
		return totalTimes;
	}
		

	public int getGiveUpTimes(){
		return giveUpTimes;
	}
		

	public int getGiveUpTotalTimes(){
		return giveUpTotalTimes;
	}
		

}
}