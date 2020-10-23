
using System;
namespace app.net
{
/**
 * 绿野仙踪剩余免费进入次数
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCWizardraidLeftTimes :BaseMessage
{
	/** 剩余免费进入次数 */
	private int leftFreeTimes;

	public GCWizardraidLeftTimes ()
	{
	}

	protected override void ReadImpl()
	{
	// 剩余免费进入次数
	int _leftFreeTimes = ReadInt();


		this.leftFreeTimes = _leftFreeTimes;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_WIZARDRAID_LEFT_TIMES;
	}
	
	public override string getEventType()
	{
		return WizardraidGCHandler.GCWizardraidLeftTimesEvent;
	}
	

	public int getLeftFreeTimes(){
		return leftFreeTimes;
	}
		

}
}