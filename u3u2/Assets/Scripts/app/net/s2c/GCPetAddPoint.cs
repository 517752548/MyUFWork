
using System;
namespace app.net
{
/**
 * 武将加点结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPetAddPoint :BaseMessage
{
	/** 武将唯一Id */
	private long petId;
	/** 操作结果，1成功，2失败 */
	private int result;
	/** 一级属性附加值 */
	private int[] aPropAddArr;

	public GCPetAddPoint ()
	{
	}

	protected override void ReadImpl()
	{
	// 武将唯一Id
	long _petId = ReadLong();
	// 操作结果，1成功，2失败
	int _result = ReadInt();
	// 一级属性附加值
	int aPropAddArrSize = ReadShort();
	int[] _aPropAddArr = new int[aPropAddArrSize];
	int aPropAddArrIndex = 0;
	for(aPropAddArrIndex=0; aPropAddArrIndex<aPropAddArrSize; aPropAddArrIndex++){
		_aPropAddArr[aPropAddArrIndex] = ReadInt();
	}//end
	


		this.petId = _petId;
		this.result = _result;
		this.aPropAddArr = _aPropAddArr;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_PET_ADD_POINT;
	}
	
	public override string getEventType()
	{
		return PetGCHandler.GCPetAddPointEvent;
	}
	

	public long getPetId(){
		return petId;
	}
		

	public int getResult(){
		return result;
	}
		

	public int[] getAPropAddArr(){
		return aPropAddArr;
	}


}
}