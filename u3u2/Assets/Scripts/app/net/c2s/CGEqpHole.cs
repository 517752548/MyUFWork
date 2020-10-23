using System;
using System.IO;
namespace app.net
{

/**
 * 装备打孔/洗孔
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGEqpHole :BaseMessage
{
	
	/** 装备UUID */
	private string equipUUId;
	/** 孔数 */
	private int holeNum;
	/** 打孔道具Id */
	private int holeItemId;
	/** 0打孔，1洗孔 */
	private int isRefresh;
	
	public CGEqpHole ()
	{
	}
	
	public CGEqpHole (
			string equipUUId,
			int holeNum,
			int holeItemId,
			int isRefresh )
	{
			this.equipUUId = equipUUId;
			this.holeNum = holeNum;
			this.holeItemId = holeItemId;
			this.isRefresh = isRefresh;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 装备UUID
	WriteString(equipUUId);
	// 孔数
	WriteInt(holeNum);
	// 打孔道具Id
	WriteInt(holeItemId);
	// 0打孔，1洗孔
	WriteInt(isRefresh);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_EQP_HOLE;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}