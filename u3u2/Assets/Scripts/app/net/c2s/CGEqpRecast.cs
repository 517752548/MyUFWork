using System;
using System.IO;
namespace app.net
{

/**
 * 重铸装备
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGEqpRecast :BaseMessage
{
	
	/** 装备UUID */
	private string equipUuid;
	/** 重铸时锁定装备列表 */
	private int[] EquipRecastInfo;
	
	public CGEqpRecast ()
	{
	}
	
	public CGEqpRecast (
			string equipUuid,
			int[] EquipRecastInfo )
	{
			this.equipUuid = equipUuid;
			this.EquipRecastInfo = EquipRecastInfo;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 装备UUID
	WriteString(equipUuid);
	// 重铸时锁定装备列表
	WriteShort((short)EquipRecastInfo.Length);
	int EquipRecastInfoSize = EquipRecastInfo.Length;
	int EquipRecastInfoIndex = 0;
	for(EquipRecastInfoIndex=0; EquipRecastInfoIndex<EquipRecastInfoSize; EquipRecastInfoIndex++){
		WriteInt(EquipRecastInfo [ EquipRecastInfoIndex ]);
	}//end
	

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_EQP_RECAST;
	}
	
	public override string getEventType()
	{
		return "";
	}
	

	public int[] getEquipRecastInfo()
	{
		return EquipRecastInfo;
	}

	public void setEquipRecastInfo(int[] EquipRecastInfo)
	{
		this.EquipRecastInfo = EquipRecastInfo;
	}
	}
}