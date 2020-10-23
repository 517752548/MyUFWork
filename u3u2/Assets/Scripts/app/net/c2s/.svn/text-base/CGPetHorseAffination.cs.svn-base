using System;
using System.IO;
namespace app.net
{

/**
 * 骑宠洗炼
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetHorseAffination :BaseMessage
{
	
	/** 武将唯一Id */
	private long petId;
	
	public CGPetHorseAffination ()
	{
	}
	
	public CGPetHorseAffination (
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
		return (short)MessageType.CG_PET_HORSE_AFFINATION;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}