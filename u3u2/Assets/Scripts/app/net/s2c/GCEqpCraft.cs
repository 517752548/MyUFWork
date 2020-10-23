
using System;
namespace app.net
{
/**
 * 返回打造结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCEqpCraft :BaseMessage
{
	/** 装备模板ID */
	private int equipmentID;
	/** 道具唯一ID */
	private string itemUUId;
	/** 操作结果，1成功，2失败 */
	private int result;

	public GCEqpCraft ()
	{
	}

	protected override void ReadImpl()
	{
	// 装备模板ID
	int _equipmentID = ReadInt();
	// 道具唯一ID
	string _itemUUId = ReadString();
	// 操作结果，1成功，2失败
	int _result = ReadInt();


		this.equipmentID = _equipmentID;
		this.itemUUId = _itemUUId;
		this.result = _result;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_EQP_CRAFT;
	}
	
	public override string getEventType()
	{
		return EquipGCHandler.GCEqpCraftEvent;
	}
	

	public int getEquipmentID(){
		return equipmentID;
	}
		

	public string getItemUUId(){
		return itemUUId;
	}
		

	public int getResult(){
		return result;
	}
		

}
}