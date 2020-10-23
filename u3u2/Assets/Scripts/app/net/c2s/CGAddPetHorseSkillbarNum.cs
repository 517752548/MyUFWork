using System;
using System.IO;
namespace app.net
{

/**
 * 扩充骑宠技能栏
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGAddPetHorseSkillbarNum :BaseMessage
{
	
	/** 武将唯一Id */
	private long petId;
	
	public CGAddPetHorseSkillbarNum ()
	{
	}
	
	public CGAddPetHorseSkillbarNum (
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
		return (short)MessageType.CG_ADD_PET_HORSE_SKILLBAR_NUM;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}