using System;
using System.IO;
namespace app.net
{

/**
 * 清除 Cd 等待时间
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGKillCdTime :BaseMessage
{
	
	/** Cd 类型 */
	private int cdType;
	/** Cd 索引位置 */
	private int cdIndex;
	
	public CGKillCdTime ()
	{
	}
	
	public CGKillCdTime (
			int cdType,
			int cdIndex )
	{
			this.cdType = cdType;
			this.cdIndex = cdIndex;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// Cd 类型
	WriteInt(cdType);
	// Cd 索引位置
	WriteInt(cdIndex);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_KILL_CD_TIME;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}