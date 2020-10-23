using System;
using System.IO;
namespace app.net
{

/**
 * 镶嵌宝石
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGEqpGemSet :BaseMessage
{
	
	/** 装备UUID */
	private string equipUuid;
	/** 镶嵌的孔位置，从1开始计数 */
	private int holeNum;
	/** 宝石模板Id */
	private int gemItemId;
	/** 镶嵌符文模板Id */
	private int extraItemId;
	
	public CGEqpGemSet ()
	{
	}
	
	public CGEqpGemSet (
			string equipUuid,
			int holeNum,
			int gemItemId,
			int extraItemId )
	{
			this.equipUuid = equipUuid;
			this.holeNum = holeNum;
			this.gemItemId = gemItemId;
			this.extraItemId = extraItemId;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 装备UUID
	WriteString(equipUuid);
	// 镶嵌的孔位置，从1开始计数
	WriteInt(holeNum);
	// 宝石模板Id
	WriteInt(gemItemId);
	// 镶嵌符文模板Id
	WriteInt(extraItemId);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_EQP_GEM_SET;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}