using System;
using System.IO;
namespace app.net
{

/**
 * 请求查看最优击败者
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGWatchBestKillerReplay :BaseMessage
{
	
	/** 通天塔层数 */
	private int towerLevel;
	
	public CGWatchBestKillerReplay ()
	{
	}
	
	public CGWatchBestKillerReplay (
			int towerLevel )
	{
			this.towerLevel = towerLevel;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 通天塔层数
	WriteInt(towerLevel);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_WATCH_BEST_KILLER_REPLAY;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}