using System;
using System.IO;
namespace app.net
{

/**
 * 骑宠悟性提升
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetHorsePerceptAddExp :BaseMessage
{
	
	/** 骑宠唯一Id */
	private long petId;
	/** 提升方式,1初级,2中级,3高级 */
	private int addType;
	/** 是否批量,1是,2否 */
	private int isBatch;
	
	public CGPetHorsePerceptAddExp ()
	{
	}
	
	public CGPetHorsePerceptAddExp (
			long petId,
			int addType,
			int isBatch )
	{
			this.petId = petId;
			this.addType = addType;
			this.isBatch = isBatch;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 骑宠唯一Id
	WriteLong(petId);
	// 提升方式,1初级,2中级,3高级
	WriteInt(addType);
	// 是否批量,1是,2否
	WriteInt(isBatch);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_PET_HORSE_PERCEPT_ADD_EXP;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}