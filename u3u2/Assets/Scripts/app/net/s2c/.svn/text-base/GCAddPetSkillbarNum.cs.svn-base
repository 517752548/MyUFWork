
using System;
namespace app.net
{
/**
 * 扩充宠物技能栏结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCAddPetSkillbarNum :BaseMessage
{
	/** 武将唯一Id */
	private long petId;
	/** 操作结果，1成功，2失败 */
	private int result;

	public GCAddPetSkillbarNum ()
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
		return (short)MessageType.GC_ADD_PET_SKILLBAR_NUM;
	}
	
	public override string getEventType()
	{
		return PetGCHandler.GCAddPetSkillbarNumEvent;
	}
	

	public long getPetId(){
		return petId;
	}
		

	public int getResult(){
		return result;
	}
		

}
}