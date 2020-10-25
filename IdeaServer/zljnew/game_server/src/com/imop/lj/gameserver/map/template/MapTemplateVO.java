package com.imop.lj.gameserver.map.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;
import com.imop.lj.core.util.StringUtils;

/**
 * 地图基础模板
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class MapTemplateVO extends TemplateObject {

	/** 名称多语言 Id */
	@ExcelCellBinding(offset = 1)
	protected int nameLangId;

	/** 名称 */
	@ExcelCellBinding(offset = 2)
	protected String name;

	/** 地图类型 */
	@ExcelCellBinding(offset = 3)
	protected int mapTypeId;

	/** 地图等级 */
	@ExcelCellBinding(offset = 4)
	protected int mapLevel;

	/** 开启等级 */
	@ExcelCellBinding(offset = 5)
	protected int openLevel;

	/** 地图图片Id */
	@ExcelCellBinding(offset = 6)
	protected String icon;

	/** 背景音乐Id */
	@ExcelCellBinding(offset = 7)
	protected String music;

	/** 地图宽度（像素） */
	@ExcelCellBinding(offset = 8)
	protected int width;

	/** 地图高度（像素） */
	@ExcelCellBinding(offset = 9)
	protected int height;

	/** 初始X坐标（像素） */
	@ExcelCellBinding(offset = 10)
	protected int initX;

	/** 初始Y坐标（像素） */
	@ExcelCellBinding(offset = 11)
	protected int initY;

	/** 遇怪方案 */
	@ExcelCellBinding(offset = 12)
	protected int meetMonsterPlanId;

	/** 遇敌率附加值（*1000） */
	@ExcelCellBinding(offset = 13)
	protected int meetMonsterAddProb;

	/** 开启PVP */
	@ExcelCellBinding(offset = 14)
	protected int pvpFlag;

	/** 开启藏宝图 */
	@ExcelCellBinding(offset = 15)
	protected int treasureMap;

	/** 开启挂机 */
	@ExcelCellBinding(offset = 16)
	protected int guajiFlag;

	/** 描述 */
	@ExcelCellBinding(offset = 17)
	protected String desc;


	public int getNameLangId() {
		return this.nameLangId;
	}

	public void setNameLangId(int nameLangId) {
		if (nameLangId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[名称多语言 Id]nameLangId的值不得小于0");
		}
		this.nameLangId = nameLangId;
	}
	
	public String getName() {
		return this.name;
	}

	public void setName(String name) {
		if (StringUtils.isEmpty(name)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[名称]name不可以为空");
		}
		if (name != null) {
			this.name = name.trim();
		}else{
			this.name = name;
		}
	}
	
	public int getMapTypeId() {
		return this.mapTypeId;
	}

	public void setMapTypeId(int mapTypeId) {
		if (mapTypeId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[地图类型]mapTypeId的值不得小于0");
		}
		this.mapTypeId = mapTypeId;
	}
	
	public int getMapLevel() {
		return this.mapLevel;
	}

	public void setMapLevel(int mapLevel) {
		if (mapLevel < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[地图等级]mapLevel的值不得小于0");
		}
		this.mapLevel = mapLevel;
	}
	
	public int getOpenLevel() {
		return this.openLevel;
	}

	public void setOpenLevel(int openLevel) {
		if (openLevel < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[开启等级]openLevel的值不得小于0");
		}
		this.openLevel = openLevel;
	}
	
	public String getIcon() {
		return this.icon;
	}

	public void setIcon(String icon) {
		if (StringUtils.isEmpty(icon)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					7, "[地图图片Id]icon不可以为空");
		}
		if (icon != null) {
			this.icon = icon.trim();
		}else{
			this.icon = icon;
		}
	}
	
	public String getMusic() {
		return this.music;
	}

	public void setMusic(String music) {
		if (StringUtils.isEmpty(music)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					8, "[背景音乐Id]music不可以为空");
		}
		if (music != null) {
			this.music = music.trim();
		}else{
			this.music = music;
		}
	}
	
	public int getWidth() {
		return this.width;
	}

	public void setWidth(int width) {
		if (width < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					9, "[地图宽度（像素）]width的值不得小于1");
		}
		this.width = width;
	}
	
	public int getHeight() {
		return this.height;
	}

	public void setHeight(int height) {
		if (height < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					10, "[地图高度（像素）]height的值不得小于1");
		}
		this.height = height;
	}
	
	public int getInitX() {
		return this.initX;
	}

	public void setInitX(int initX) {
		if (initX < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					11, "[初始X坐标（像素）]initX的值不得小于0");
		}
		this.initX = initX;
	}
	
	public int getInitY() {
		return this.initY;
	}

	public void setInitY(int initY) {
		if (initY < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					12, "[初始Y坐标（像素）]initY的值不得小于0");
		}
		this.initY = initY;
	}
	
	public int getMeetMonsterPlanId() {
		return this.meetMonsterPlanId;
	}

	public void setMeetMonsterPlanId(int meetMonsterPlanId) {
		if (meetMonsterPlanId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					13, "[遇怪方案]meetMonsterPlanId的值不得小于0");
		}
		this.meetMonsterPlanId = meetMonsterPlanId;
	}
	
	public int getMeetMonsterAddProb() {
		return this.meetMonsterAddProb;
	}

	public void setMeetMonsterAddProb(int meetMonsterAddProb) {
		if (meetMonsterAddProb < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					14, "[遇敌率附加值（*1000）]meetMonsterAddProb的值不得小于0");
		}
		this.meetMonsterAddProb = meetMonsterAddProb;
	}
	
	public int getPvpFlag() {
		return this.pvpFlag;
	}

	public void setPvpFlag(int pvpFlag) {
		if (pvpFlag < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					15, "[开启PVP]pvpFlag的值不得小于0");
		}
		this.pvpFlag = pvpFlag;
	}
	
	public int getTreasureMap() {
		return this.treasureMap;
	}

	public void setTreasureMap(int treasureMap) {
		if (treasureMap < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					16, "[开启藏宝图]treasureMap的值不得小于0");
		}
		this.treasureMap = treasureMap;
	}
	
	public int getGuajiFlag() {
		return this.guajiFlag;
	}

	public void setGuajiFlag(int guajiFlag) {
		if (guajiFlag < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					17, "[开启挂机]guajiFlag的值不得小于0");
		}
		this.guajiFlag = guajiFlag;
	}
	
	public String getDesc() {
		return this.desc;
	}

	public void setDesc(String desc) {
		if (StringUtils.isEmpty(desc)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					18, "[描述]desc不可以为空");
		}
		if (desc != null) {
			this.desc = desc.trim();
		}else{
			this.desc = desc;
		}
	}
	

	@Override
	public String toString() {
		return "MapTemplateVO[nameLangId=" + nameLangId + ",name=" + name + ",mapTypeId=" + mapTypeId + ",mapLevel=" + mapLevel + ",openLevel=" + openLevel + ",icon=" + icon + ",music=" + music + ",width=" + width + ",height=" + height + ",initX=" + initX + ",initY=" + initY + ",meetMonsterPlanId=" + meetMonsterPlanId + ",meetMonsterAddProb=" + meetMonsterAddProb + ",pvpFlag=" + pvpFlag + ",treasureMap=" + treasureMap + ",guajiFlag=" + guajiFlag + ",desc=" + desc + ",]";

	}
}