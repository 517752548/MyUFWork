
using System;
namespace app.net
{
/**
 * 主将学习技能结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPetLeaderStudySkill :BaseMessage
{
	/** 技能书道具Id */
	private int itemTplId;
	/** 操作结果，1成功，2失败 */
	private int result;

	public GCPetLeaderStudySkill ()
	{
	}

	protected override void ReadImpl()
	{
	// 技能书道具Id
	int _itemTplId = ReadInt();
	// 操作结果，1成功，2失败
	int _result = ReadInt();


		this.itemTplId = _itemTplId;
		this.result = _result;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_PET_LEADER_STUDY_SKILL;
	}
	
	public override string getEventType()
	{
		return PetGCHandler.GCPetLeaderStudySkillEvent;
	}
	

	public int getItemTplId(){
		return itemTplId;
	}
		

	public int getResult(){
		return result;
	}
		

}
}