using System;
using System.IO;
namespace app.net
{

/**
 * 摘除宝石
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGEqpGemTakedown :BaseMessage
{
	
	/** 装备UUID */
	private string equipUuid;
	/** 摘除的孔位置，从1开始计数 */
	private int holeNum;
	/** 摘除符文模板Id */
	private int extraItemId;
	
	public CGEqpGemTakedown ()
	{
	}
	
	public CGEqpGemTakedown (
			string equipUuid,
			int holeNum,
			int extraItemId )
	{
			this.equipUuid = equipUuid;
			this.holeNum = holeNum;
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
	// 摘除的孔位置，从1开始计数
	WriteInt(holeNum);
	// 摘除符文模板Id
	WriteInt(extraItemId);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_EQP_GEM_TAKEDOWN;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}