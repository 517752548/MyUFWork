using System;
using System.IO;
namespace app.net
{

/**
 * 请求开启双倍状态
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGOpenDoubleStatus :BaseMessage
{
	
	/** 1开启，0关闭 */
	private int openOrClose;
	
	public CGOpenDoubleStatus ()
	{
	}
	
	public CGOpenDoubleStatus (
			int openOrClose )
	{
			this.openOrClose = openOrClose;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 1开启，0关闭
	WriteInt(openOrClose);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_OPEN_DOUBLE_STATUS;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}