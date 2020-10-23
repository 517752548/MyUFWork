
using System;
namespace app.net
{
/**
 * 装备打孔/洗孔结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCEqpHole :BaseMessage
{
	/** 装备UUID */
	private string equipUUId;
	/** 0打孔，1洗孔 */
	private int isRefresh;
	/** 1成功2失败 */
	private int result;

	public GCEqpHole ()
	{
	}

	protected override void ReadImpl()
	{
	// 装备UUID
	string _equipUUId = ReadString();
	// 0打孔，1洗孔
	int _isRefresh = ReadInt();
	// 1成功2失败
	int _result = ReadInt();


		this.equipUUId = _equipUUId;
		this.isRefresh = _isRefresh;
		this.result = _result;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_EQP_HOLE;
	}
	
	public override string getEventType()
	{
		return EquipGCHandler.GCEqpHoleEvent;
	}
	

	public string getEquipUUId(){
		return equipUUId;
	}
		

	public int getIsRefresh(){
		return isRefresh;
	}
		

	public int getResult(){
		return result;
	}
		

}
}