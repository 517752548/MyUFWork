
using System;
namespace app.net
{
/**
 * 骑宠出战or休息结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPetHorseRide :BaseMessage
{
	/** 骑宠唯一Id */
	private long petId;
	/** 出战状态，0休息，1出战 */
	private int state;
	/** 操作结果，1成功，2失败 */
	private int result;

	public GCPetHorseRide ()
	{
	}

	protected override void ReadImpl()
	{
	// 骑宠唯一Id
	long _petId = ReadLong();
	// 出战状态，0休息，1出战
	int _state = ReadInt();
	// 操作结果，1成功，2失败
	int _result = ReadInt();


		this.petId = _petId;
		this.state = _state;
		this.result = _result;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_PET_HORSE_RIDE;
	}
	
	public override string getEventType()
	{
		return PetGCHandler.GCPetHorseRideEvent;
	}
	

	public long getPetId(){
		return petId;
	}
		

	public int getState(){
		return state;
	}
		

	public int getResult(){
		return result;
	}
		

}
}