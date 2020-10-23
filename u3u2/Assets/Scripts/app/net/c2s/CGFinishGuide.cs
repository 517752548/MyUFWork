using System;
using System.IO;
namespace app.net
{

/**
 * 完成新手引导，一些特殊的地方需要前台主动发完成才算完成，如欢迎的新手、vip体验卡的新手
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGFinishGuide :BaseMessage
{
	
	/** 新手引导类型id */
	private int guideTypeId;
	
	public CGFinishGuide ()
	{
	}
	
	public CGFinishGuide (
			int guideTypeId )
	{
			this.guideTypeId = guideTypeId;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 新手引导类型id
	WriteInt(guideTypeId);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_FINISH_GUIDE;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}