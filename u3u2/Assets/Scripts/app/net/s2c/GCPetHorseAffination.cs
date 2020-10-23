
using System;
namespace app.net
{
/**
 * 骑宠洗炼结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPetHorseAffination :BaseMessage
{
	/** 武将唯一Id */
	private long petId;
	/** 操作结果，1成功，2失败 */
	private int result;

	public GCPetHorseAffination ()
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
		return (short)MessageType.GC_PET_HORSE_AFFINATION;
	}
	
	public override string getEventType()
	{
		return PetGCHandler.GCPetHorseAffinationEvent;
	}
	

	public long getPetId(){
		return petId;
	}
		

	public int getResult(){
		return result;
	}
		

}
}