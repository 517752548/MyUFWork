
using System;
namespace app.net
{
/**
 * 宠物刷新天赋技能
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPetRefreshTalentSkill :BaseMessage
{
	/** 武将唯一Id */
	private long petId;
	/** 操作结果，1成功，2失败 */
	private int result;

	public GCPetRefreshTalentSkill ()
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
		return (short)MessageType.GC_PET_REFRESH_TALENT_SKILL;
	}
	
	public override string getEventType()
	{
		return PetGCHandler.GCPetRefreshTalentSkillEvent;
	}
	

	public long getPetId(){
		return petId;
	}
		

	public int getResult(){
		return result;
	}
		

}
}