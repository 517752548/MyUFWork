using System;
using System.IO;
namespace app.net
{

/**
 * 取消技能快捷栏
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetSkillOffShortcut :BaseMessage
{
	
	/** 武将唯一Id */
	private long petId;
	/** 目标位置索引，从0开始计数 */
	private int targetPosIndex;
	
	public CGPetSkillOffShortcut ()
	{
	}
	
	public CGPetSkillOffShortcut (
			long petId,
			int targetPosIndex )
	{
			this.petId = petId;
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
	// 目标位置索引，从0开始计数
	WriteInt(targetPosIndex);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_PET_SKILL_OFF_SHORTCUT;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}