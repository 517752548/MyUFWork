
using System;
namespace app.net
{
/**
 * 变异结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPetVariation :BaseMessage
{
	/** 武将唯一Id */
	private long petId;
	/** 是否批量，0否，1是 */
	private int isBatch;
	/** 操作结果，1成功，2失败 */
	private int result;

	public GCPetVariation ()
	{
	}

	protected override void ReadImpl()
	{
	// 武将唯一Id
	long _petId = ReadLong();
	// 是否批量，0否，1是
	int _isBatch = ReadInt();
	// 操作结果，1成功，2失败
	int _result = ReadInt();


		this.petId = _petId;
		this.isBatch = _isBatch;
		this.result = _result;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_PET_VARIATION;
	}
	
	public override string getEventType()
	{
		return PetGCHandler.GCPetVariationEvent;
	}
	

	public long getPetId(){
		return petId;
	}
		

	public int getIsBatch(){
		return isBatch;
	}
		

	public int getResult(){
		return result;
	}
		

}
}