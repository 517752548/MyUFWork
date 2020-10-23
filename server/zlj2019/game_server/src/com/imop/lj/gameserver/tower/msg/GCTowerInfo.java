package com.imop.lj.gameserver.tower.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 返回通天塔面板信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCTowerInfo extends GCMessage{
	
	/** 通天塔面板信息 */
	private com.imop.lj.common.model.tower.TowerInfo towerInfo;

	public GCTowerInfo (){
	}
	
	public GCTowerInfo (
			com.imop.lj.common.model.tower.TowerInfo towerInfo ){
			this.towerInfo = towerInfo;
	}

	@Override
	protected boolean readImpl() {
	// 通天塔面板信息
	com.imop.lj.common.model.tower.TowerInfo _towerInfo = new com.imop.lj.common.model.tower.TowerInfo();

	// 当前玩家的通天塔层数
	int _towerInfo_curTowerLevel = readInteger();
	//end
	_towerInfo.setCurTowerLevel (_towerInfo_curTowerLevel);



		this.towerInfo = _towerInfo;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	int towerInfo_curTowerLevel = towerInfo.getCurTowerLevel ();

	// 当前玩家的通天塔层数
	writeInteger(towerInfo_curTowerLevel);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_TOWER_INFO;
	}
	
	@Override
	public String getTypeName() {
		return "GC_TOWER_INFO";
	}

	public com.imop.lj.common.model.tower.TowerInfo getTowerInfo(){
		return towerInfo;
	}
		
	public void setTowerInfo(com.imop.lj.common.model.tower.TowerInfo towerInfo){
		this.towerInfo = towerInfo;
	}
}