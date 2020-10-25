package com.imop.lj.gameserver.corps.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 返回帮派降级后信息,其中帮派建筑等级未变
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCDegradeCorps extends GCMessage{
	
	/** 军详细团信息 */
	private com.imop.lj.common.model.corps.DetailCorpsInfo detailCorpsInfo;
	/** 帮派建筑信息 */
	private com.imop.lj.common.model.corps.CorpsBuildingInfo corpsBuildingInfo;

	public GCDegradeCorps (){
	}
	
	public GCDegradeCorps (
			com.imop.lj.common.model.corps.DetailCorpsInfo detailCorpsInfo,
			com.imop.lj.common.model.corps.CorpsBuildingInfo corpsBuildingInfo ){
			this.detailCorpsInfo = detailCorpsInfo;
			this.corpsBuildingInfo = corpsBuildingInfo;
	}

	@Override
	protected boolean readImpl() {
	// 军详细团信息
	com.imop.lj.common.model.corps.DetailCorpsInfo _detailCorpsInfo = new com.imop.lj.common.model.corps.DetailCorpsInfo();

	// 军团ID
	long _detailCorpsInfo_corpsId = readLong();
	//end
	_detailCorpsInfo.setCorpsId (_detailCorpsInfo_corpsId);

	// 军团名称
	String _detailCorpsInfo_name = readString();
	//end
	_detailCorpsInfo.setName (_detailCorpsInfo_name);

	// 军团级别
	int _detailCorpsInfo_level = readInteger();
	//end
	_detailCorpsInfo.setLevel (_detailCorpsInfo_level);

	// 是否有下一级，1：有；0：没有
	int _detailCorpsInfo_hasNextLevel = readInteger();
	//end
	_detailCorpsInfo.setHasNextLevel (_detailCorpsInfo_hasNextLevel);

	// 当前成员数量
	int _detailCorpsInfo_currMemNum = readInteger();
	//end
	_detailCorpsInfo.setCurrMemNum (_detailCorpsInfo_currMemNum);

	// 当前帮派经验
	long _detailCorpsInfo_currExp = readLong();
	//end
	_detailCorpsInfo.setCurrExp (_detailCorpsInfo_currExp);

	// 当前帮派资金
	long _detailCorpsInfo_currFund = readLong();
	//end
	_detailCorpsInfo.setCurrFund (_detailCorpsInfo_currFund);

	// 团长名称
	String _detailCorpsInfo_presidentName = readString();
	//end
	_detailCorpsInfo.setPresidentName (_detailCorpsInfo_presidentName);

	// 公告
	String _detailCorpsInfo_notice = readString();
	//end
	_detailCorpsInfo.setNotice (_detailCorpsInfo_notice);

	// 军团排名
	int _detailCorpsInfo_rank = readInteger();
	//end
	_detailCorpsInfo.setRank (_detailCorpsInfo_rank);

	// 帮会解散确认时间
	long _detailCorpsInfo_disbandConfirmDate = readLong();
	//end
	_detailCorpsInfo.setDisbandConfirmDate (_detailCorpsInfo_disbandConfirmDate);

	// 帮派建筑信息
	com.imop.lj.common.model.corps.CorpsBuildingInfo _corpsBuildingInfo = new com.imop.lj.common.model.corps.CorpsBuildingInfo();

	// 帮派ID
	long _corpsBuildingInfo_corpsId = readLong();
	//end
	_corpsBuildingInfo.setCorpsId (_corpsBuildingInfo_corpsId);

	// 建筑类型
	int _corpsBuildingInfo_buildType = readInteger();
	//end
	_corpsBuildingInfo.setBuildType (_corpsBuildingInfo_buildType);

	// 建筑名称
	String _corpsBuildingInfo_buildingName = readString();
	//end
	_corpsBuildingInfo.setBuildingName (_corpsBuildingInfo_buildingName);

	// 建筑功能介绍
	String _corpsBuildingInfo_buildingDesc = readString();
	//end
	_corpsBuildingInfo.setBuildingDesc (_corpsBuildingInfo_buildingDesc);

	// 建筑等级
	int _corpsBuildingInfo_buildingLevel = readInteger();
	//end
	_corpsBuildingInfo.setBuildingLevel (_corpsBuildingInfo_buildingLevel);

	// 当前等级升级倒计时,以毫秒为单位
	long _corpsBuildingInfo_upgradeCountDownTime = readLong();
	//end
	_corpsBuildingInfo.setUpgradeCountDownTime (_corpsBuildingInfo_upgradeCountDownTime);



		this.detailCorpsInfo = _detailCorpsInfo;
		this.corpsBuildingInfo = _corpsBuildingInfo;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	long detailCorpsInfo_corpsId = detailCorpsInfo.getCorpsId ();

	// 军团ID
	writeLong(detailCorpsInfo_corpsId);

	String detailCorpsInfo_name = detailCorpsInfo.getName ();

	// 军团名称
	writeString(detailCorpsInfo_name);

	int detailCorpsInfo_level = detailCorpsInfo.getLevel ();

	// 军团级别
	writeInteger(detailCorpsInfo_level);

	int detailCorpsInfo_hasNextLevel = detailCorpsInfo.getHasNextLevel ();

	// 是否有下一级，1：有；0：没有
	writeInteger(detailCorpsInfo_hasNextLevel);

	int detailCorpsInfo_currMemNum = detailCorpsInfo.getCurrMemNum ();

	// 当前成员数量
	writeInteger(detailCorpsInfo_currMemNum);

	long detailCorpsInfo_currExp = detailCorpsInfo.getCurrExp ();

	// 当前帮派经验
	writeLong(detailCorpsInfo_currExp);

	long detailCorpsInfo_currFund = detailCorpsInfo.getCurrFund ();

	// 当前帮派资金
	writeLong(detailCorpsInfo_currFund);

	String detailCorpsInfo_presidentName = detailCorpsInfo.getPresidentName ();

	// 团长名称
	writeString(detailCorpsInfo_presidentName);

	String detailCorpsInfo_notice = detailCorpsInfo.getNotice ();

	// 公告
	writeString(detailCorpsInfo_notice);

	int detailCorpsInfo_rank = detailCorpsInfo.getRank ();

	// 军团排名
	writeInteger(detailCorpsInfo_rank);

	long detailCorpsInfo_disbandConfirmDate = detailCorpsInfo.getDisbandConfirmDate ();

	// 帮会解散确认时间
	writeLong(detailCorpsInfo_disbandConfirmDate);


	long corpsBuildingInfo_corpsId = corpsBuildingInfo.getCorpsId ();

	// 帮派ID
	writeLong(corpsBuildingInfo_corpsId);

	int corpsBuildingInfo_buildType = corpsBuildingInfo.getBuildType ();

	// 建筑类型
	writeInteger(corpsBuildingInfo_buildType);

	String corpsBuildingInfo_buildingName = corpsBuildingInfo.getBuildingName ();

	// 建筑名称
	writeString(corpsBuildingInfo_buildingName);

	String corpsBuildingInfo_buildingDesc = corpsBuildingInfo.getBuildingDesc ();

	// 建筑功能介绍
	writeString(corpsBuildingInfo_buildingDesc);

	int corpsBuildingInfo_buildingLevel = corpsBuildingInfo.getBuildingLevel ();

	// 建筑等级
	writeInteger(corpsBuildingInfo_buildingLevel);

	long corpsBuildingInfo_upgradeCountDownTime = corpsBuildingInfo.getUpgradeCountDownTime ();

	// 当前等级升级倒计时,以毫秒为单位
	writeLong(corpsBuildingInfo_upgradeCountDownTime);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_DEGRADE_CORPS;
	}
	
	@Override
	public String getTypeName() {
		return "GC_DEGRADE_CORPS";
	}

	public com.imop.lj.common.model.corps.DetailCorpsInfo getDetailCorpsInfo(){
		return detailCorpsInfo;
	}
		
	public void setDetailCorpsInfo(com.imop.lj.common.model.corps.DetailCorpsInfo detailCorpsInfo){
		this.detailCorpsInfo = detailCorpsInfo;
	}

	public com.imop.lj.common.model.corps.CorpsBuildingInfo getCorpsBuildingInfo(){
		return corpsBuildingInfo;
	}
		
	public void setCorpsBuildingInfo(com.imop.lj.common.model.corps.CorpsBuildingInfo corpsBuildingInfo){
		this.corpsBuildingInfo = corpsBuildingInfo;
	}
}