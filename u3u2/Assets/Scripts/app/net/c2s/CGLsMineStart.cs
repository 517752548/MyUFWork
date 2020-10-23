using System;
using System.IO;
namespace app.net
{

/**
 * 申请开始采矿
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGLsMineStart :BaseMessage
{
	
	/** 矿点ID */
	private int pitId;
	/** 矿石ID */
	private int mineId;
	/** 采矿方式ID */
	private int miningTypeId;
	/** 矿工UUID */
	private long minerId;
	
	public CGLsMineStart ()
	{
	}
	
	public CGLsMineStart (
			int pitId,
			int mineId,
			int miningTypeId,
			long minerId )
	{
			this.pitId = pitId;
			this.mineId = mineId;
			this.miningTypeId = miningTypeId;
			this.minerId = minerId;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 矿点ID
	WriteInt(pitId);
	// 矿石ID
	WriteInt(mineId);
	// 采矿方式ID
	WriteInt(miningTypeId);
	// 矿工UUID
	WriteLong(minerId);

	}
	
	public override short GetMessageType()
	{
        return (short)0;// MessageType.CG_LS_MINE_START;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}