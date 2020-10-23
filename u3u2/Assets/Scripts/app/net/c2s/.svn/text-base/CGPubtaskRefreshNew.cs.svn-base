using System;
using System.IO;
namespace app.net
{

/**
 * 酒馆任务手动刷新
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPubtaskRefreshNew :BaseMessage
{
	
	/** 0-普通刷新,1-金子刷新 */
	private int refreshType;
	
	public CGPubtaskRefreshNew ()
	{
	}
	
	public CGPubtaskRefreshNew (
			int refreshType )
	{
			this.refreshType = refreshType;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 0-普通刷新,1-金子刷新
	WriteInt(refreshType);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_PUBTASK_REFRESH_NEW;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}