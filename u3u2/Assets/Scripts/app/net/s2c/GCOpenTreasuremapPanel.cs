
using System;
namespace app.net
{
/**
 * 藏宝图
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCOpenTreasuremapPanel :BaseMessage
{
	/** 今日已完成任务数 */
	private int finishTimes;
	/** 总任务数 */
	private int totalTimes;

	public GCOpenTreasuremapPanel ()
	{
	}

	protected override void ReadImpl()
	{
	// 今日已完成任务数
	int _finishTimes = ReadInt();
	// 总任务数
	int _totalTimes = ReadInt();


		this.finishTimes = _finishTimes;
		this.totalTimes = _totalTimes;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_OPEN_TREASUREMAP_PANEL;
	}
	
	public override string getEventType()
	{
		return TreasuremapGCHandler.GCOpenTreasuremapPanelEvent;
	}
	

	public int getFinishTimes(){
		return finishTimes;
	}
		

	public int getTotalTimes(){
		return totalTimes;
	}
		

}
}