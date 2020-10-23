using System;
using System.IO;
namespace app.net
{

/**
 * 宠物培养确认更新
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetTrainUpdate :BaseMessage
{
	
	/** 武将唯一Id */
	private long petId;
	
	public CGPetTrainUpdate ()
	{
	}
	
	public CGPetTrainUpdate (
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
		return (short)MessageType.CG_PET_TRAIN_UPDATE;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}