using System;
using System.IO;
namespace app.net
{

/**
 * 宠物培养
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetTrain :BaseMessage
{
	
	/** 武将唯一Id */
	private long petId;
	/** 1初级2中级3高级 */
	private int trainTypeId;
	
	public CGPetTrain ()
	{
	}
	
	public CGPetTrain (
			long petId,
			int trainTypeId )
	{
			this.petId = petId;
			this.trainTypeId = trainTypeId;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 武将唯一Id
	WriteLong(petId);
	// 1初级2中级3高级
	WriteInt(trainTypeId);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_PET_TRAIN;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}