using System;
using System.IO;
namespace app.net
{

/**
 * 武将加点
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetAddPoint :BaseMessage
{
	
	/** 武将唯一Id */
	private long petId;
	/** 加点数组，按照一级属性的顺序加 */
	private int[] addArr;
	
	public CGPetAddPoint ()
	{
	}
	
	public CGPetAddPoint (
			long petId,
			int[] addArr )
	{
			this.petId = petId;
			this.addArr = addArr;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 武将唯一Id
	WriteLong(petId);
	// 加点数组，按照一级属性的顺序加
	WriteShort((short)addArr.Length);
	int addArrSize = addArr.Length;
	int addArrIndex = 0;
	for(addArrIndex=0; addArrIndex<addArrSize; addArrIndex++){
		WriteInt(addArr [ addArrIndex ]);
	}//end
	

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_PET_ADD_POINT;
	}
	
	public override string getEventType()
	{
		return "";
	}
	

	public int[] getAddArr()
	{
		return addArr;
	}

	public void setAddArr(int[] addArr)
	{
		this.addArr = addArr;
	}
	}
}