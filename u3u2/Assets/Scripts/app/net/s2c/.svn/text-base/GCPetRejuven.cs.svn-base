
using System;
namespace app.net
{
/**
 * 还童结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPetRejuven :BaseMessage
{
	/** 武将唯一Id */
	private long petId;
	/** 操作结果，1成功，2失败 */
	private int result;

	public GCPetRejuven ()
	{
	}

	protected override void ReadImpl()
	{
	// 武将唯一Id
	long _petId = ReadLong();
	// 操作结果，1成功，2失败
	int _result = ReadInt();


		this.petId = _petId;
		this.result = _result;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_PET_REJUVEN;
	}
	
	public override string getEventType()
	{
		return PetGCHandler.GCPetRejuvenEvent;
	}
	

	public long getPetId(){
		return petId;
	}
		

	public int getResult(){
		return result;
	}
		

}
}