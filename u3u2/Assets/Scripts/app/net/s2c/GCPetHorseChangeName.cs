
using System;
namespace app.net
{
/**
 * 骑宠改名结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPetHorseChangeName :BaseMessage
{
	/** 骑宠唯一Id */
	private long petId;
	/** 操作结果，1成功，2失败 */
	private int result;

	public GCPetHorseChangeName ()
	{
	}

	protected override void ReadImpl()
	{
	// 骑宠唯一Id
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
		return (short)MessageType.GC_PET_HORSE_CHANGE_NAME;
	}
	
	public override string getEventType()
	{
		return PetGCHandler.GCPetHorseChangeNameEvent;
	}
	

	public long getPetId(){
		return petId;
	}
		

	public int getResult(){
		return result;
	}
		

}
}