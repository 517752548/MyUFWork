
using System;
namespace app.net
{
/**
 * 战斗的战报
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCBattleReportPart :BaseMessage
{
	/** 0战斗开始，1每轮战报 */
	private int playType;
	/** 战报数据包 */
	private string reportPack;
	/** 战斗附加json串，主要是奖励等信息 */
	private string additionPack;

	public GCBattleReportPart ()
	{
	}

	protected override void ReadImpl()
	{
	// 0战斗开始，1每轮战报
	int _playType = ReadInt();
	// 战报数据包
	string _reportPack = ReadString();
	// 战斗附加json串，主要是奖励等信息
	string _additionPack = ReadString();


		this.playType = _playType;
		this.reportPack = _reportPack;
		this.additionPack = _additionPack;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_BATTLE_REPORT_PART;
	}
	
	public override string getEventType()
	{
		return BattleGCHandler.GCBattleReportPartEvent;
	}
	

	public int getPlayType(){
		return playType;
	}
		

	public string getReportPack(){
		return reportPack;
	}
		

	public string getAdditionPack(){
		return additionPack;
	}
		

	public override bool isCompress() {
		return true;
	}
}
}