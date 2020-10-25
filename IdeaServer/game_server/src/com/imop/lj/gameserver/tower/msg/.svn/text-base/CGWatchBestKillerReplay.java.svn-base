package com.imop.lj.gameserver.tower.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.tower.handler.TowerHandlerFactory;

/**
 * 请求查看最优击败者
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGWatchBestKillerReplay extends CGMessage{
	
	/** 通天塔层数 */
	private int towerLevel;
	
	public CGWatchBestKillerReplay (){
	}
	
	public CGWatchBestKillerReplay (
			int towerLevel ){
			this.towerLevel = towerLevel;
	}
	
	@Override
	protected boolean readImpl() {

	// 通天塔层数
	int _towerLevel = readInteger();
	//end



			this.towerLevel = _towerLevel;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 通天塔层数
	writeInteger(towerLevel);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_WATCH_BEST_KILLER_REPLAY;
	}
	
	@Override
	public String getTypeName() {
		return "CG_WATCH_BEST_KILLER_REPLAY";
	}

	public int getTowerLevel(){
		return towerLevel;
	}
		
	public void setTowerLevel(int towerLevel){
		this.towerLevel = towerLevel;
	}


	@Override
	public void execute() {
		TowerHandlerFactory.getHandler().handleWatchBestKillerReplay(this.getSession().getPlayer(), this);
	}
}