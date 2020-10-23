using System;
using System.IO;
namespace app.net
{

/**
 * 宠物刷新天赋技能
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetRefreshTalentSkill :BaseMessage
{
	
	/** 武将唯一Id */
	private long petId;
	
	public CGPetRefreshTalentSkill ()
	{
	}
	
	public CGPetRefreshTalentSkill (
			long petId )
	{
			this.petId = petId;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 武将唯一Id
	WriteLong(petId);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_PET_REFRESH_TALENT_SKILL;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}