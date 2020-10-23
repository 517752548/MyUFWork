using System;
using System.IO;
namespace app.net
{

/**
 * 扩充宠物技能栏
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGAddPetSkillbarNum :BaseMessage
{
	
	/** 武将唯一Id */
	private long petId;
	
	public CGAddPetSkillbarNum ()
	{
	}
	
	public CGAddPetSkillbarNum (
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
		return (short)MessageType.CG_ADD_PET_SKILLBAR_NUM;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}