package com.imop.lj.gameserver.corps.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 返回帮派建筑面板
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCOpenCorpsBuildingPanel extends GCMessage{
	
	/** 帮派建筑信息 */
	private com.imop.lj.common.model.corps.CorpsBuildingInfo corpsBuildingInfo;

	public GCOpenCorpsBuildingPanel (){
	}
	
	public GCOpenCorpsBuildingPanel (
			com.imop.lj.common.model.corps.CorpsBuildingInfo corpsBuildingInfo ){
			this.corpsBuildingInfo = corpsBuildingInfo;
	}

	@Override
	protected boolean readImpl() {
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



		this.corpsBuildingInfo = _corpsBuildingInfo;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

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
		return MessageType.GC_OPEN_CORPS_BUILDING_PANEL;
	}
	
	@Override
	public String getTypeName() {
		return "GC_OPEN_CORPS_BUILDING_PANEL";
	}

	public com.imop.lj.common.model.corps.CorpsBuildingInfo getCorpsBuildingInfo(){
		return corpsBuildingInfo;
	}
		
	public void setCorpsBuildingInfo(com.imop.lj.common.model.corps.CorpsBuildingInfo corpsBuildingInfo){
		this.corpsBuildingInfo = corpsBuildingInfo;
	}
}