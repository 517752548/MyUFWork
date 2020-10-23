using System;
using System.IO;
namespace app.net
{

/**
 * 领取富贵至尊仙葫
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGXianhuGive :BaseMessage
{
	
	/** 领取类型，0富贵仙葫，1至尊仙葫 */
	private int giveType;
	
	public CGXianhuGive ()
	{
	}
	
	public CGXianhuGive (
			int giveType )
	{
			this.giveType = giveType;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 领取类型，0富贵仙葫，1至尊仙葫
	WriteInt(giveType);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_XIANHU_GIVE;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}