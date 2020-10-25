package com.imop.lj.gameserver.tower.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.tower.handler.TowerHandlerFactory;

/**
 * 请求挂机
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGGuaji extends CGMessage{
	
	/** 玩家所在地图Id */
	private int mapId;
	
	public CGGuaji (){
	}
	
	public CGGuaji (
			int mapId ){
			this.mapId = mapId;
	}
	
	@Override
	protected boolean readImpl() {

	// 玩家所在地图Id
	int _mapId = readInteger();
	//end



			this.mapId = _mapId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 玩家所在地图Id
	writeInteger(mapId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_GUAJI;
	}
	
	@Override
	public String getTypeName() {
		return "CG_GUAJI";
	}

	public int getMapId(){
		return mapId;
	}
		
	public void setMapId(int mapId){
		this.mapId = mapId;
	}


	@Override
	public void execute() {
		TowerHandlerFactory.getHandler().handleGuaji(this.getSession().getPlayer(), this);
	}
}