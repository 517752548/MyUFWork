using System;
using System.IO;
namespace app.net
{

/**
 * 设置技能快捷栏
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetSkillPutonShortcut :BaseMessage
{
	
	/** 武将唯一Id */
	private long petId;
	/** 技能ID */
	private int skillId;
	/** 目标位置索引，从0开始计数 */
	private int targetPosIndex;
	
	public CGPetSkillPutonShortcut ()
	{
	}
	
	public CGPetSkillPutonShortcut (
			long petId,
			int skillId,
			int targetPosIndex )
	{
			this.petId = petId;
			this.skillId = skillId;
			this.targetPosIndex = targetPosIndex;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 武将唯一Id
	WriteLong(petId);
	// 技能ID
	WriteInt(skillId);
	// 目标位置索引，从0开始计数
	WriteInt(targetPosIndex);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_PET_SKILL_PUTON_SHORTCUT;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}