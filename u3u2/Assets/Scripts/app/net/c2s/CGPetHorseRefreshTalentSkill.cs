using System;
using System.IO;
namespace app.net
{

/**
 * 骑宠刷新天赋技能
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetHorseRefreshTalentSkill :BaseMessage
{
	
	/** 武将唯一Id */
	private long petId;
	
	public CGPetHorseRefreshTalentSkill ()
	{
	}
	
	public CGPetHorseRefreshTalentSkill (
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
		return (short)MessageType.CG_PET_HORSE_REFRESH_TALENT_SKILL;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}