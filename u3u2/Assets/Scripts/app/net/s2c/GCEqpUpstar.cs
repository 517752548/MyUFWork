
using System;
namespace app.net
{
/**
 * 返回升星结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCEqpUpstar :BaseMessage
{
	/** 装备位 */
	private int equipPosition;
	/** 操作结果，1成功，2失败 */
	private int result;

	public GCEqpUpstar ()
	{
	}

	protected override void ReadImpl()
	{
	// 装备位
	int _equipPosition = ReadInt();
	// 操作结果，1成功，2失败
	int _result = ReadInt();


		this.equipPosition = _equipPosition;
		this.result = _result;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_EQP_UPSTAR;
	}
	
	public override string getEventType()
	{
		return EquipGCHandler.GCEqpUpstarEvent;
	}
	

	public int getEquipPosition(){
		return equipPosition;
	}
		

	public int getResult(){
		return result;
	}
		

}
}