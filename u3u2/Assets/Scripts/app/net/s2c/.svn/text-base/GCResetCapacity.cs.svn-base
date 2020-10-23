
using System;
namespace app.net
{
/**
 * 重新设置背包的容量，只可能是主道具包、材料包、仓库三者之一
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCResetCapacity :BaseMessage
{
	/** 包Id */
	private int bagId;
	/** 新的容量 */
	private int capacity;

	public GCResetCapacity ()
	{
	}

	protected override void ReadImpl()
	{
	// 包Id
	int _bagId = ReadInt();
	// 新的容量
	int _capacity = ReadInt();


		this.bagId = _bagId;
		this.capacity = _capacity;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_RESET_CAPACITY;
	}
	
	public override string getEventType()
	{
		return ItemGCHandler.GCResetCapacityEvent;
	}
	

	public int getBagId(){
		return bagId;
	}
		

	public int getCapacity(){
		return capacity;
	}
		

}
}