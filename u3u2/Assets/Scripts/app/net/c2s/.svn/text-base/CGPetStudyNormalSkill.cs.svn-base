using System;
using System.IO;
namespace app.net
{

/**
 * 宠物学习普通技能
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetStudyNormalSkill :BaseMessage
{
	
	/** 武将唯一Id */
	private long petId;
	/** 技能书道具Id */
	private int itemTplId;
	
	public CGPetStudyNormalSkill ()
	{
	}
	
	public CGPetStudyNormalSkill (
			long petId,
			int itemTplId )
	{
			this.petId = petId;
			this.itemTplId = itemTplId;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 武将唯一Id
	WriteLong(petId);
	// 技能书道具Id
	WriteInt(itemTplId);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_PET_STUDY_NORMAL_SKILL;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}