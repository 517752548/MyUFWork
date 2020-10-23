
using System;
namespace app.net
{
/**
 * 返回申请采矿结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCLsMineStart :BaseMessage
{
	/** 操作结果，1成功，2失败 */
	private int result;

	public GCLsMineStart ()
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
        return (short)0;// MessageType.GC_LS_MINE_START;
	}
	
	public override string getEventType()
	{
        return "";// LifeskillGCHandler.GCLsMineStartEvent;
	}
	

	public int getResult(){
		return result;
	}
		

}
}