
using System;
namespace app.net
{
/**
 * 武将增加经验，目前只有主将才发
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPetAddExp :BaseMessage
{
	/** 武将唯一Id */
	private long petId;
	/** 增加的经验 */
	private long addExp;

	public GCPetAddExp ()
	{
	}

	protected override void ReadImpl()
	{
	// 武将唯一Id
	long _petId = ReadLong();
	// 增加的经验
	long _addExp = ReadLong();


		this.petId = _petId;
		this.addExp = _addExp;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_PET_ADD_EXP;
	}
	
	public override string getEventType()
	{
		return PetGCHandler.GCPetAddExpEvent;
	}
	

	public long getPetId(){
		return petId;
	}
		

	public long getAddExp(){
		return addExp;
	}
		

}
}