
using System;
namespace app.net
{
/**
 * 返回挂机结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCGuaji :BaseMessage
{
	/** 1成功，2失败 */
	private int result;

	public GCGuaji ()
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
		return (short)MessageType.GC_GUAJI;
	}
	
	public override string getEventType()
	{
		return TowerGCHandler.GCGuajiEvent;
	}
	

	public int getResult(){
		return result;
	}
		

}
}