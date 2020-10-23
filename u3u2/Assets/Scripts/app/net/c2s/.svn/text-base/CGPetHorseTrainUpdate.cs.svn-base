using System;
using System.IO;
namespace app.net
{

/**
 * 骑宠培养确认更新
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetHorseTrainUpdate :BaseMessage
{
	
	/** 骑宠唯一Id */
	private long petId;
	
	public CGPetHorseTrainUpdate ()
	{
	}
	
	public CGPetHorseTrainUpdate (
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
		return (short)MessageType.CG_PET_HORSE_TRAIN_UPDATE;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}