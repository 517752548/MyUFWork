
using System;
namespace app.net
{
/**
 * 副本信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCWizardraidInfo :BaseMessage
{
	/** 当前波数 */
	private int wave;
	/** 击杀怪物数量 */
	private int winNum;
	/** 剩余时间，毫秒 */
	private long leftTime;

	public GCWizardraidInfo ()
	{
	}

	protected override void ReadImpl()
	{
	// 当前波数
	int _wave = ReadInt();
	// 击杀怪物数量
	int _winNum = ReadInt();
	// 剩余时间，毫秒
	long _leftTime = ReadLong();


		this.wave = _wave;
		this.winNum = _winNum;
		this.leftTime = _leftTime;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_WIZARDRAID_INFO;
	}
	
	public override string getEventType()
	{
		return WizardraidGCHandler.GCWizardraidInfoEvent;
	}
	

	public int getWave(){
		return wave;
	}
		

	public int getWinNum(){
		return winNum;
	}
		

	public long getLeftTime(){
		return leftTime;
	}
		

}
}