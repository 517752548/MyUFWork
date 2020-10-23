
using System;
namespace app.net
{
/**
 * 返回取得矿石结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCLsMineGain :BaseMessage
{
	/** 操作结果，1成功，2失败 */
	private int result;

	public GCLsMineGain ()
	{
	}

	protected override void ReadImpl()
	{
	// 操作结果，1成功，2失败
	int _result = ReadInt();


		this.result = _result;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
        return (short)0;// MessageType.GC_LS_MINE_GAIN;
	}
	
	public override string getEventType()
	{
        return "";// LifeskillGCHandler.GCLsMineGainEvent;
	}
	

	public int getResult(){
		return result;
	}
		

}
}