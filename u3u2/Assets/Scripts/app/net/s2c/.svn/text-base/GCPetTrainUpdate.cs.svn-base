
using System;
namespace app.net
{
/**
 * 宠物培养确认更新
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPetTrainUpdate :BaseMessage
{
	/** 武将唯一Id */
	private long petId;
	/** 1成功,2失败 */
	private int result;

	public GCPetTrainUpdate ()
	{
	}

	protected override void ReadImpl()
	{
	// 武将唯一Id
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
		return (short)MessageType.GC_PET_TRAIN_UPDATE;
	}
	
	public override string getEventType()
	{
		return PetGCHandler.GCPetTrainUpdateEvent;
	}
	

	public long getPetId(){
		return petId;
	}
		

	public int getResult(){
		return result;
	}
		

}
}