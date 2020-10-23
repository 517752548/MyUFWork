using System;
using System.IO;
namespace app.net
{

/**
 * 开启仙葫
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGXianhuOpen :BaseMessage
{
	
	/** 开启类型，0祝福仙葫，1祈福仙葫 */
	private int openType;
	
	public CGXianhuOpen ()
	{
	}
	
	public CGXianhuOpen (
			int openType )
	{
			this.openType = openType;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 开启类型，0祝福仙葫，1祈福仙葫
	WriteInt(openType);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_XIANHU_OPEN;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}