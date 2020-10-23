using System;
using System.IO;
namespace app.net
{

/**
 * 刷新神秘商店
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGFlushMystery :BaseMessage
{
	
	/** 刷新类型1：普通刷新2：Vip刷新 */
	private int flushType;
	
	public CGFlushMystery ()
	{
	}
	
	public CGFlushMystery (
			int flushType )
	{
			this.flushType = flushType;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 刷新类型1：普通刷新2：Vip刷新
	WriteInt(flushType);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_FLUSH_MYSTERY;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}