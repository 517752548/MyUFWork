using System;
using System.IO;
namespace app.net
{

/**
 * 武将解雇
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetFire :BaseMessage
{
	
	/** 武将唯一Id */
	private long petId;
	
	public CGPetFire ()
	{
	}
	
	public CGPetFire (
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
		return (short)MessageType.CG_PET_FIRE;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}