
using System;
namespace app.net
{
/**
 * 返回帮派福利面板
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCOpenCorpsBenifitPanel :BaseMessage
{
	/** 帮派福利信息 */
	private CorpsBenifitInfo corpsBenifitInfo;

	public GCOpenCorpsBenifitPanel ()
	{
	}

	protected override void ReadImpl()
	{
	// 帮派福利信息
	CorpsBenifitInfo _corpsBenifitInfo = new CorpsBenifitInfo();
	// 帮派ID
	long _corpsBenifitInfo_corpsId = ReadLong();	_corpsBenifitInfo.corpsId = _corpsBenifitInfo_corpsId;
	// 上周帮贡 
	int _corpsBenifitInfo_lastWeekContribution = ReadInt();	_corpsBenifitInfo.lastWeekContribution = _corpsBenifitInfo_lastWeekContribution;
	// 是否可领取 ,1可以,0不可以
	int _corpsBenifitInfo_canReceive = ReadInt();	_corpsBenifitInfo.canReceive = _corpsBenifitInfo_canReceive;



		this.corpsBenifitInfo = _corpsBenifitInfo;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_OPEN_CORPS_BENIFIT_PANEL;
	}
	
	public override string getEventType()
	{
		return CorpsGCHandler.GCOpenCorpsBenifitPanelEvent;
	}
	

	public CorpsBenifitInfo getCorpsBenifitInfo(){
		return corpsBenifitInfo;
	}
		

}
}