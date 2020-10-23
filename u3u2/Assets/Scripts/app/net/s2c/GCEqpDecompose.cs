
using System;
namespace app.net
{
/**
 * 分解装备结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCEqpDecompose :BaseMessage
{
	/** 1成功2失败 */
	private int result;

	public GCEqpDecompose ()
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
		return (short)MessageType.GC_EQP_DECOMPOSE;
	}
	
	public override string getEventType()
	{
		return EquipGCHandler.GCEqpDecomposeEvent;
	}
	

	public int getResult(){
		return result;
	}
		

}
}