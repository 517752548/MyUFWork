
using System;
namespace app.net
{
/**
 * 冒泡开关
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPopFlag :BaseMessage
{
	/** 是否冒泡，0不冒，1冒 */
	private int flag;

	public GCPopFlag ()
	{
	}

	protected override void ReadImpl()
	{
	// 是否冒泡，0不冒，1冒
	int _flag = ReadInt();


		this.flag = _flag;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_POP_FLAG;
	}
	
	public override string getEventType()
	{
		return CommonGCHandler.GCPopFlagEvent;
	}
	

	public int getFlag(){
		return flag;
	}
		

}
}