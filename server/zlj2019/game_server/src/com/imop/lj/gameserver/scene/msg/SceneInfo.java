package com.imop.lj.gameserver.scene.msg;

import com.imop.lj.gameserver.scene.Scene;

/**
 * 场景信息
 *
 * @author haijiang.jin
 *
 */
public class SceneInfo {
	/** 场景 Id */
	private int id;
	/** 场景类型 */
	private int typeId;
	/** 场景名称 */
	private String name;
//	/** 图片 */
//	private String image;
	/** 地图提示 */
	private String mpaTips;
	/** 地图场景索引 */
	private int index;
//	/** 阵营 Id */
//	private int allianceId;
	/** 是否可用 */
	private boolean available;
	/**
	 * 类默认构造器
	 *
	 */
	public SceneInfo() {
	}

	/**
	 * 类参数构造器
	 *
	 * @param s
	 */
	public SceneInfo(Scene s) {
		if (s != null) {
			this.id = s.getId();
			this.typeId = s.getTypeId();
			this.name = s.getName();
//			this.image = s.getImage();
//			this.allianceId = s.getAllianceId();
		}
	}

	/**
	 * 获取场景 Id
	 *
	 * @return
	 */
	public int getId() {
		return id;
	}

	/**
	 * 设置场景 Id
	 *
	 * @param id
	 */
	public void setId(int id) {
		this.id = id;
	}

	/**
	 * 获取类型 Id
	 *
	 * @return
	 */
	public int getTypeId() {
		return typeId;
	}

	/**
	 * 设置类型 Id
	 *
	 * @param typeId
	 */
	public void setTypeId(int typeId) {
		this.typeId = typeId;
	}

	/**
	 * 获取名称
	 *
	 * @return
	 */
	public String getName() {
		return name;
	}

	/**
	 * 设置名称
	 *
	 * @param name
	 */
	public void setName(String name) {
		this.name = name;
	}

//	/**
//	 * 获取图片
//	 *
//	 * @return
//	 */
//	public String getImage() {
//		return image;
//	}
//
//	/**
//	 * 设置图片
//	 *
//	 * @param image
//	 */
//	public void setImage(String image) {
//		this.image = image;
//	}

	/**
	 * 是否可见
	 *
	 * @return
	 */
	public boolean getAvailable() {
		return available;
	}

	/**
	 * 设置可见
	 *
	 * @param available
	 */
	public void setAvailable(boolean available) {
		this.available = available;
	}

//	/**
//	 * 获取阵营 Id
//	 *
//	 * @return
//	 */
//	public int getAllianceId() {
//		return this.allianceId;
//	}
//
//	/**
//	 * 设置阵营 Id
//	 *
//	 * @param value
//	 */
//	public void setAllianceId(int value) {
//		this.allianceId = value;
//	}

	public int getIndex() {
		return index;
	}

	public void setIndex(int index) {
		this.index = index;
	}

	public String getMpaTips() {
		return mpaTips;
	}

	public void setMpaTips(String mpaTips) {
		this.mpaTips = mpaTips;
	}

	@Override
	public String toString() {
		return "SceneInfo [ Id = " + this.id
			+ ", typeId = " + this.typeId
			+ ", name = " + this.name
//			+ ", image = " + this.image
//			+ ", allianceId = " + this.allianceId 
			+ " ]";
	}
}
