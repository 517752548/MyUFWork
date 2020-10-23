using System;
using System.IO;
namespace app.net
{

/**
 * 主将学习技能
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetLeaderStudySkill :BaseMessage
{
	
	/** 技能书道具Id */
	private int itemTplId;
	
	public CGPetLeaderStudySkill ()
	{
	}
	
	public CGPetLeaderStudySkill (
			int itemTplId )
	{
			this.itemTplId = itemTplId;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 技能书道具Id
	WriteInt(itemTplId);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_PET_LEADER_STUDY_SKILL;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}