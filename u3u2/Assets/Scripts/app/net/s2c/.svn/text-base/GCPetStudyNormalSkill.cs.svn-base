
using System;
namespace app.net
{
/**
 * 宠物学习普通技能
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPetStudyNormalSkill :BaseMessage
{
	/** 武将唯一Id */
	private long petId;
	/** 技能书道具Id */
	private int itemTplId;
	/** 操作结果，1成功，2失败 */
	private int result;

	public GCPetStudyNormalSkill ()
	{
	}

	protected override void ReadImpl()
	{
	// 武将唯一Id
	long _petId = ReadLong();
	// 技能书道具Id
	int _itemTplId = ReadInt();
	// 操作结果，1成功，2失败
	int _result = ReadInt();


		this.petId = _petId;
		this.itemTplId = _itemTplId;
		this.result = _result;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_PET_STUDY_NORMAL_SKILL;
	}
	
	public override string getEventType()
	{
		return PetGCHandler.GCPetStudyNormalSkillEvent;
	}
	

	public long getPetId(){
		return petId;
	}
		

	public int getItemTplId(){
		return itemTplId;
	}
		

	public int getResult(){
		return result;
	}
		

}
}