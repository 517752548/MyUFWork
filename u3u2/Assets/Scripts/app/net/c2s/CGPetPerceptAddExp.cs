using System;
using System.IO;
namespace app.net
{

/**
 * 宠物悟性提升
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetPerceptAddExp :BaseMessage
{
	
	/** 武将唯一Id */
	private long petId;
	/** 提升方式,1初级,2中级,3高级 */
	private int addType;
	/** 是否批量,1是,2否 */
	private int isBatch;
	
	public CGPetPerceptAddExp ()
	{
	}
	
	public CGPetPerceptAddExp (
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
	// 武将唯一Id
	WriteLong(petId);
	// 提升方式,1初级,2中级,3高级
	WriteInt(addType);
	// 是否批量,1是,2否
	WriteInt(isBatch);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_PET_PERCEPT_ADD_EXP;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}