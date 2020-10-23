package com.imop.lj.gameserver.map.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 给玩家发队长位置信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCMapTeamLeaderPosition extends GCMessage{
	
	/** 队长角色id */
	private long uuid;
	/** 地图id */
	private int mapId;
	/** 玩家X坐标(像素) */
	private int x;
	/** 玩家Y坐标(像素) */
	private int y;

	public GCMapTeamLeaderPosition (){
	}
	
	public GCMapTeamLeaderPosition (
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

	// 队长角色id
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

	// 队长角色id
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
		return MessageType.GC_MAP_TEAM_LEADER_POSITION;
	}
	
	@Override
	public String getTypeName() {
		return "GC_MAP_TEAM_LEADER_POSITION";
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