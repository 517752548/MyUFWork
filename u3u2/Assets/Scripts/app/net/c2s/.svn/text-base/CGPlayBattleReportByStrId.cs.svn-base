using System;
using System.IO;
namespace app.net
{

/**
 * 客户端请求播放战报
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPlayBattleReportByStrId :BaseMessage
{
	
	/** 战报id字符串类型 */
	private string idStr;
	/** 战报读取完毕以后，前端返回场景id */
	private int toBackType;
	
	public CGPlayBattleReportByStrId ()
	{
	}
	
	public CGPlayBattleReportByStrId (
			string idStr,
			int toBackType )
	{
			this.idStr = idStr;
			this.toBackType = toBackType;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 战报id字符串类型
	WriteString(idStr);
	// 战报读取完毕以后，前端返回场景id
	WriteInt(toBackType);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_PLAY_BATTLE_REPORT_BY_STR_ID;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}