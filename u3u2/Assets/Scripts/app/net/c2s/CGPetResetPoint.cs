using System;
using System.IO;
namespace app.net
{

/**
 * 武将洗点
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetResetPoint :BaseMessage
{
	
	/** 武将唯一Id */
	private long petId;
	
	public CGPetResetPoint ()
	{
	}
	
	public CGPetResetPoint (
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
		return (short)MessageType.CG_PET_RESET_POINT;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}