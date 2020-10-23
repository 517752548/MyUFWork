package com.imop.lj.gameserver.map.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 玩家进入地图
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCMapPlayerEnter extends GCMessage{
	
	/** 角色id */
	private long uuid;
	/** 地图id */
	private int mapId;
	/** 玩家X坐标(像素) */
	private int x;
	/** 玩家Y坐标(像素) */
	private int y;

	public GCMapPlayerEnter (){
	}
	
	public GCMapPlayerEnter (
			long uuid,
			int mapId,
			int x,
			int y ){
			this.uuid = uuid;
			this.mapId = mapId;
			this.x = x;
			this.y = y;
	}

	@Override
	protected boolean readImpl() {

	// 角色id
	long _uuid = readLong();
	//end


	// 地图id
	int _mapId = readInteger();
	//end


	// 玩家X坐标(像素)
	int _x = readInteger();
	//end


	// 玩家Y坐标(像素)
	int _y = readInteger();
	//end



		this.uuid = _uuid;
		this.mapId = _mapId;
		this.x = _x;
		this.y = _y;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 角色id
	writeLong(uuid);


	// 地图id
	writeInteger(mapId);


	// 玩家X坐标(像素)
	writeInteger(x);


	// 玩家Y坐标(像素)
	writeInteger(y);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_MAP_PLAYER_ENTER;
	}
	
	@Override
	public String getTypeName() {
		return "GC_MAP_PLAYER_ENTER";
	}

	public long getUuid(){
		return uuid;
	}
		
	public void setUuid(long uuid){
		this.uuid = uuid;
	}

	public int getMapId(){
		return mapId;
	}
		
	public void setMapId(int mapId){
		this.mapId = mapId;
	}

	public int getX(){
		return x;
	}
		
	public void setX(int x){
		this.x = x;
	}

	public int getY(){
		return y;
	}
		
	public void setY(int y){
		this.y = y;
	}
}