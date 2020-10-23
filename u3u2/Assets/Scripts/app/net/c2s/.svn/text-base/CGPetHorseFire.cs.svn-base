using System;
using System.IO;
namespace app.net
{

/**
 * 骑宠放生
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetHorseFire :BaseMessage
{
	
	/** 骑宠唯一Id */
	private long petId;
	
	public CGPetHorseFire ()
	{
	}
	
	public CGPetHorseFire (
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
		return (short)MessageType.CG_PET_HORSE_FIRE;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}