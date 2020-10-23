
using System;
namespace app.net
{
/**
 * 返回帮派建筑面板
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCOpenCorpsBuildingPanel :BaseMessage
{
	/** 帮派建筑信息 */
	private CorpsBuildingInfo corpsBuildingInfo;

	public GCOpenCorpsBuildingPanel ()
	{
	}

	protected override void ReadImpl()
	{
	// 帮派建筑信息
	CorpsBuildingInfo _corpsBuildingInfo = new CorpsBuildingInfo();
	// 帮派ID
	long _corpsBuildingInfo_corpsId = ReadLong();	_corpsBuildingInfo.corpsId = _corpsBuildingInfo_corpsId;
	// 建筑类型
	int _corpsBuildingInfo_buildType = ReadInt();	_corpsBuildingInfo.buildType = _corpsBuildingInfo_buildType;
	// 建筑名称
	string _corpsBuildingInfo_buildingName = ReadString();	_corpsBuildingInfo.buildingName = _corpsBuildingInfo_buildingName;
	// 建筑功能介绍
	string _corpsBuildingInfo_buildingDesc = ReadString();	_corpsBuildingInfo.buildingDesc = _corpsBuildingInfo_buildingDesc;
	// 建筑等级
	int _corpsBuildingInfo_buildingLevel = ReadInt();	_corpsBuildingInfo.buildingLevel = _corpsBuildingInfo_buildingLevel;
	// 当前等级升级倒计时,以毫秒为单位
	long _corpsBuildingInfo_upgradeCountDownTime = ReadLong();	_corpsBuildingInfo.upgradeCountDownTime = _corpsBuildingInfo_upgradeCountDownTime;



		this.corpsBuildingInfo = _corpsBuildingInfo;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_OPEN_CORPS_BUILDING_PANEL;
	}
	
	public override string getEventType()
	{
		return CorpsGCHandler.GCOpenCorpsBuildingPanelEvent;
	}
	

	public CorpsBuildingInfo getCorpsBuildingInfo(){
		return corpsBuildingInfo;
	}
		

}
}