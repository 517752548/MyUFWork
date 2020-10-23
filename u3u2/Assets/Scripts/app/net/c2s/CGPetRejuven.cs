using System;
using System.IO;
namespace app.net
{

/**
 * 还童
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetRejuven :BaseMessage
{
	
	/** 武将唯一Id */
	private long petId;
	
	public CGPetRejuven ()
	{
	}
	
	public CGPetRejuven (
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
		return (short)MessageType.CG_PET_REJUVEN;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}