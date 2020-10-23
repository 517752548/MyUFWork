using System;
using System.IO;
namespace app.net
{

/**
 * 还童
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetHorseRejuven :BaseMessage
{
	
	/** 骑宠唯一Id */
	private long petId;
	
	public CGPetHorseRejuven ()
	{
	}
	
	public CGPetHorseRejuven (
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
	// 骑宠唯一Id
	WriteLong(petId);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_PET_HORSE_REJUVEN;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}