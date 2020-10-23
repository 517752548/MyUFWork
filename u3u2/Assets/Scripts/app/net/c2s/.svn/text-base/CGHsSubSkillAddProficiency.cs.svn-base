using System;
using System.IO;
namespace app.net
{

/**
 * 人物技能增加熟练度
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGHsSubSkillAddProficiency :BaseMessage
{
	
	/** 技能ID */
	private int skillId;
	
	public CGHsSubSkillAddProficiency ()
	{
	}
	
	public CGHsSubSkillAddProficiency (
			int skillId )
	{
			this.skillId = skillId;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 技能ID
	WriteInt(skillId);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_HS_SUB_SKILL_ADD_PROFICIENCY;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}