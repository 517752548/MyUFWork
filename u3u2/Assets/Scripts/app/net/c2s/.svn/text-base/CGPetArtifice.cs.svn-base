using System;
using System.IO;
namespace app.net
{

/**
 * 炼化
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetArtifice :BaseMessage
{
	
	/** 武将唯一Id */
	private long petId;
	
	public CGPetArtifice ()
	{
	}
	
	public CGPetArtifice (
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
		return (short)MessageType.CG_PET_ARTIFICE;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}