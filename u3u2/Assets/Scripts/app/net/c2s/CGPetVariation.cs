using System;
using System.IO;
namespace app.net
{

/**
 * 变异
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetVariation :BaseMessage
{
	
	/** 武将唯一Id */
	private long petId;
	/** 是否批量，0否，1是 */
	private int isBatch;
	
	public CGPetVariation ()
	{
	}
	
	public CGPetVariation (
			long petId,
			int isBatch )
	{
			this.petId = petId;
			this.isBatch = isBatch;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 武将唯一Id
	WriteLong(petId);
	// 是否批量，0否，1是
	WriteInt(isBatch);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_PET_VARIATION;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}