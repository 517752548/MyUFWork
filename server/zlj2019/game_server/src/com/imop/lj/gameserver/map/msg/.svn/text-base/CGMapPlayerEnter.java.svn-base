package com.imop.lj.gameserver.map.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.map.handler.MapHandlerFactory;

/**
 * 玩家进入地图
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGMapPlayerEnter extends CGMessage{
	
	/** 地图id */
	private int mapId;
	
	public CGMapPlayerEnter (){
	}
	
	public CGMapPlayerEnter (
			int mapId ){
			this.mapId = mapId;
	}
	
	@Override
	protected boolean readImpl() {

	// 地图id
	int _mapId = readInteger();
	//end



			this.mapId = _mapId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 地图id
	writeInteger(mapId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_MAP_PLAYER_ENTER;
	}
	
	@Override
	public String getTypeName() {
		return "CG_MAP_PLAYER_ENTER";
	}

	public int getMapId(){
		return mapId;
	}
		
	public void setMapId(int mapId){
		this.mapId = mapId;
	}


	@Override
	public void execute() {
		MapHandlerFactory.getHandler().handleMapPlayerEnter(this.getSession().getPlayer(), this);
	}
}