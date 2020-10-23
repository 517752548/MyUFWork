
using System;
namespace app.net
{
/**
 * 骑宠培养确认更新
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPetHorseTrainUpdate :BaseMessage
{
	/** 骑宠唯一Id */
	private long petId;
	/** 1成功,2失败 */
	private int result;

	public GCPetHorseTrainUpdate ()
	{
	}

	protected override void ReadImpl()
	{
	// 骑宠唯一Id
	long _petId = ReadLong();
	// 1成功,2失败
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
		return (short)MessageType.GC_PET_HORSE_TRAIN_UPDATE;
	}
	
	public override string getEventType()
	{
		return PetGCHandler.GCPetHorseTrainUpdateEvent;
	}
	

	public long getPetId(){
		return petId;
	}
		

	public int getResult(){
		return result;
	}
		

}
}