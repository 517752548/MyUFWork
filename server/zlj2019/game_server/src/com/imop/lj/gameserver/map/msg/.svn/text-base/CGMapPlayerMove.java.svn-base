package com.imop.lj.gameserver.map.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.map.handler.MapHandlerFactory;

/**
 * 玩家移动
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGMapPlayerMove extends CGMessage{
	
	/** 地图id，校验用 */
	private int mapId;
	/** 目标x坐标(像素) */
	private int x;
	/** 目标y坐标(像素) */
	private int y;
	/** 目标最终x坐标(像素) */
	private int fx;
	/** 目标最终y坐标(像素) */
	private int fy;
	
	public CGMapPlayerMove (){
	}
	
	public CGMapPlayerMove (
			int mapId,
			int x,
			int y,
			int fx,
			int fy ){
			this.mapId = mapId;
			this.x = x;
			this.y = y;
			this.fx = fx;
			this.fy = fy;
	}
	
	@Override
	protected boolean readImpl() {

	// 地图id，校验用
	int _mapId = readInteger();
	//end


	// 目标x坐标(像素)
	int _x = readInteger();
	//end


	// 目标y坐标(像素)
	int _y = readInteger();
	//end


	// 目标最终x坐标(像素)
	int _fx = readInteger();
	//end


	// 目标最终y坐标(像素)
	int _fy = readInteger();
	//end



			this.mapId = _mapId;
			this.x = _x;
			this.y = _y;
			this.fx = _fx;
			this.fy = _fy;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 地图id，校验用
	writeInteger(mapId);


	// 目标x坐标(像素)
	writeInteger(x);


	// 目标y坐标(像素)
	writeInteger(y);


	// 目标最终x坐标(像素)
	writeInteger(fx);


	// 目标最终y坐标(像素)
	writeInteger(fy);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_MAP_PLAYER_MOVE;
	}
	
	@Override
	public String getTypeName() {
		return "CG_MAP_PLAYER_MOVE";
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

	public int getFx(){
		return fx;
	}
		
	public void setFx(int fx){
		this.fx = fx;
	}

	public int getFy(){
		return fy;
	}
		
	public void setFy(int fy){
		this.fy = fy;
	}


	@Override
	public void execute() {
		MapHandlerFactory.getHandler().handleMapPlayerMove(this.getSession().getPlayer(), this);
	}
}