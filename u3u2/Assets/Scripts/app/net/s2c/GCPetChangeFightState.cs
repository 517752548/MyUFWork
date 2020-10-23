
using System;
namespace app.net
{
/**
 * 宠物出战or休息结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPetChangeFightState :BaseMessage
{
	/** 武将唯一Id */
	private long petId;
	/** 出战状态，0休息，1出战 */
	private int state;
	/** 操作结果，1成功，2失败 */
	private int result;

	public GCPetChangeFightState ()
	{
	}

	protected override void ReadImpl()
	{
	// 武将唯一Id
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
		return (short)MessageType.GC_PET_CHANGE_FIGHT_STATE;
	}
	
	public override string getEventType()
	{
		return PetGCHandler.GCPetChangeFightStateEvent;
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