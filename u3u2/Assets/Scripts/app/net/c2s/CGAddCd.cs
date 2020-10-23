using System;
using System.IO;
namespace app.net
{

/**
 * 增加 Cd 队列
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGAddCd :BaseMessage
{
	
	/** Cd 类型 */
	private short cdType;
	/** Cd 索引 */
	private short cdIndex;
	
	public CGAddCd ()
	{
	}
	
	public CGAddCd (
			short cdType,
			short cdIndex )
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
	WriteShort(cdType);
	// Cd 索引
	WriteShort(cdIndex);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_ADD_CD;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}