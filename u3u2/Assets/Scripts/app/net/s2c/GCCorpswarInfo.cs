
using System;
namespace app.net
{
/**
 * 帮派竞赛信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCCorpswarInfo :BaseMessage
{
	/** 本帮派积分 */
	private int corpsScore;
	/** 帮派名字 */
	private string corpsName;
	/** 剩余时间，毫秒 */
	private long leftTime;
	/** 活动当前状态，1准备中，2已开始 */
	private int state;

	public GCCorpswarInfo ()
	{
	}

	protected override void ReadImpl()
	{
	// 本帮派积分
	int _corpsScore = ReadInt();
	// 帮派名字
	string _corpsName = ReadString();
	// 剩余时间，毫秒
	long _leftTime = ReadLong();
	// 活动当前状态，1准备中，2已开始
	int _state = ReadInt();


		this.corpsScore = _corpsScore;
		this.corpsName = _corpsName;
		this.leftTime = _leftTime;
		this.state = _state;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_CORPSWAR_INFO;
	}
	
	public override string getEventType()
	{
		return CorpsGCHandler.GCCorpswarInfoEvent;
	}
	

	public int getCorpsScore(){
		return corpsScore;
	}
		

	public string getCorpsName(){
		return corpsName;
	}
		

	public long getLeftTime(){
		return leftTime;
	}
		

	public int getState(){
		return state;
	}
		

}
}