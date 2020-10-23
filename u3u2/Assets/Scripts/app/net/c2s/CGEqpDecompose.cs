using System;
using System.IO;
namespace app.net
{

/**
 * 分解装备
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGEqpDecompose :BaseMessage
{
	
	/** 装备UUIDList */
	private string[] equipList;
	
	public CGEqpDecompose ()
	{
	}
	
	public CGEqpDecompose (
			string[] equipList )
	{
			this.equipList = equipList;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 装备UUIDList
	WriteShort((short)equipList.Length);
	int equipListSize = equipList.Length;
	int equipListIndex = 0;
	for(equipListIndex=0; equipListIndex<equipListSize; equipListIndex++){
		WriteString(equipList [ equipListIndex ]);
	}//end
	

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_EQP_DECOMPOSE;
	}
	
	public override string getEventType()
	{
		return "";
	}
	

	public string[] getEquipList()
	{
		return equipList;
	}

	public void setEquipList(string[] equipList)
	{
		this.equipList = equipList;
	}
	}
}