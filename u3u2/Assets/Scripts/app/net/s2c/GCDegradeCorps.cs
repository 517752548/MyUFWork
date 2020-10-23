
using System;
namespace app.net
{
/**
 * 返回帮派降级后信息,其中帮派建筑等级未变
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCDegradeCorps :BaseMessage
{
	/** 军详细团信息 */
	private DetailCorpsInfo detailCorpsInfo;
	/** 帮派建筑信息 */
	private CorpsBuildingInfo corpsBuildingInfo;

	public GCDegradeCorps ()
	{
	}

	protected override void ReadImpl()
	{
	// 军详细团信息
	DetailCorpsInfo _detailCorpsInfo = new DetailCorpsInfo();
	// 军团ID
	long _detailCorpsInfo_corpsId = ReadLong();	_detailCorpsInfo.corpsId = _detailCorpsInfo_corpsId;
	// 军团名称
	string _detailCorpsInfo_name = ReadString();	_detailCorpsInfo.name = _detailCorpsInfo_name;
	// 军团级别
	int _detailCorpsInfo_level = ReadInt();	_detailCorpsInfo.level = _detailCorpsInfo_level;
	// 是否有下一级，1：有；0：没有
	int _detailCorpsInfo_hasNextLevel = ReadInt();	_detailCorpsInfo.hasNextLevel = _detailCorpsInfo_hasNextLevel;
	// 当前成员数量
	int _detailCorpsInfo_currMemNum = ReadInt();	_detailCorpsInfo.currMemNum = _detailCorpsInfo_currMemNum;
	// 当前帮派经验
	long _detailCorpsInfo_currExp = ReadLong();	_detailCorpsInfo.currExp = _detailCorpsInfo_currExp;
	// 当前帮派资金
	long _detailCorpsInfo_currFund = ReadLong();	_detailCorpsInfo.currFund = _detailCorpsInfo_currFund;
	// 团长名称
	string _detailCorpsInfo_presidentName = ReadString();	_detailCorpsInfo.presidentName = _detailCorpsInfo_presidentName;
	// 公告
	string _detailCorpsInfo_notice = ReadString();	_detailCorpsInfo.notice = _detailCorpsInfo_notice;
	// 军团排名
	int _detailCorpsInfo_rank = ReadInt();	_detailCorpsInfo.rank = _detailCorpsInfo_rank;
	// 帮会解散确认时间
	long _detailCorpsInfo_disbandConfirmDate = ReadLong();	_detailCorpsInfo.disbandConfirmDate = _detailCorpsInfo_disbandConfirmDate;

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



		this.detailCorpsInfo = _detailCorpsInfo;
		this.corpsBuildingInfo = _corpsBuildingInfo;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_DEGRADE_CORPS;
	}
	
	public override string getEventType()
	{
		return CorpsGCHandler.GCDegradeCorpsEvent;
	}
	

	public DetailCorpsInfo getDetailCorpsInfo(){
		return detailCorpsInfo;
	}
		

	public CorpsBuildingInfo getCorpsBuildingInfo(){
		return corpsBuildingInfo;
	}
		

}
}