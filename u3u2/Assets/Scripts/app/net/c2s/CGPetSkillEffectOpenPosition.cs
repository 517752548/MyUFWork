using System;
using System.IO;
namespace app.net
{

/**
 * 主将技能开启仙符格子
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetSkillEffectOpenPosition :BaseMessage
{
	
	/** 技能Id */
	private int skillId;
	
	public CGPetSkillEffectOpenPosition ()
	{
	}
	
	public CGPetSkillEffectOpenPosition (
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
	// 技能Id
	WriteInt(skillId);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_PET_SKILL_EFFECT_OPEN_POSITION;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}