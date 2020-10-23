
using System;
namespace app.net
{
/**
 * 返回挂机结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCStartGuaJi :BaseMessage
{
	/** 1成功，2失败 */
	private int result;

	public GCStartGuaJi ()
	{
	}

	protected override void ReadImpl()
	{
	// 1成功，2失败
	int _result = ReadInt();


		this.result = _result;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_START_GUA_JI;
	}
	
	public override string getEventType()
	{
		return GuajiGCHandler.GCStartGuaJiEvent;
	}
	

	public int getResult(){
		return result;
	}
		

}
}