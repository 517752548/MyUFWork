
using System;
namespace app.net
{
/**
 * 重铸装备结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCEqpRecast :BaseMessage
{
	/** 1成功2失败 */
	private int result;

	public GCEqpRecast ()
	{
	}

	protected override void ReadImpl()
	{
	// 1成功2失败
	int _result = ReadInt();


		this.result = _result;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_EQP_RECAST;
	}
	
	public override string getEventType()
	{
		return EquipGCHandler.GCEqpRecastEvent;
	}
	

	public int getResult(){
		return result;
	}
		

}
}