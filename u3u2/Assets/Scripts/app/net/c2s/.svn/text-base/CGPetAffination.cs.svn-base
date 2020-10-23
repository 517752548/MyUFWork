using System;
using System.IO;
namespace app.net
{

/**
 * 宠物洗炼
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetAffination :BaseMessage
{
	
	/** 武将唯一Id */
	private long petId;
	
	public CGPetAffination ()
	{
	}
	
	public CGPetAffination (
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
		return (short)MessageType.CG_PET_AFFINATION;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}