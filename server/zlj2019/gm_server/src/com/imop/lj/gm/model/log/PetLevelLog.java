package com.imop.lj.gm.model.log;

import java.util.List;

/**
 * This is an auto generated source,please don't modify it.
 *
 * @author com.mop.dnf2.logs.codegen.ModelLogMsgGenerator
 * @version Thu Sep 24 11:51:15 CST 2009
 *
 */

public class PetLevelLog extends BaseLog {

	/** 地图ID */
	private int mapId;

	/** 地图X坐标 */
	private int mapX;

	/** 地图Y坐标 */
	private int mapY;

	/** 宠物ID */
	private String petId;

	/** 宠物级别 */
	private int petLevel;


	public String getPetId() {
		return petId;
	}

	public void setPetId(String petId) {
		this.petId = petId;
	}

	public int getPetLevel() {
		return petLevel;
	}

	public void setPetLevel(int petLevel) {
		this.petLevel = petLevel;
	}

	public int getMapId() {
		return mapId;
	}

	public void setMapId(int mapId) {
		this.mapId = mapId;
	}

	public int getMapX() {
		return mapX;
	}

	public void setMapX(int mapX) {
		this.mapX = mapX;
	}

	public int getMapY() {
		return mapY;
	}

	public void setMapY(int mapY) {
		this.mapY = mapY;
	}
	@SuppressWarnings("unchecked")
	@Override
	public List toList() {
		List list = super.toList();
		list.add(this.mapId);
		list.add(this.mapX);
		list.add(this.mapY);
		list.add(this.petId);
		list.add(this.petLevel);
		return list;
	}
}