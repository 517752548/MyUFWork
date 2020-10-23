using System;
using System.IO;
namespace app.net
{

/**
 * 炼化
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetHorseArtifice :BaseMessage
{
	
	/** 骑宠唯一Id */
	private long petId;
	
	public CGPetHorseArtifice ()
	{
	}
	
	public CGPetHorseArtifice (
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
		return (short)MessageType.CG_PET_HORSE_ARTIFICE;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}