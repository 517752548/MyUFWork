package com.imop.lj.gameserver.map.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 地图npc模板
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class MapNpcTemplateVO extends TemplateObject {

	/** 地图Id */
	@ExcelCellBinding(offset = 1)
	protected int mapId;

	/** NPCId */
	@ExcelCellBinding(offset = 2)
	protected int npcId;

	/** 是否像素点，0否，1是 */
	@ExcelCellBinding(offset = 3)
	protected int pixelFlag;

	/** x坐标 */
	@ExcelCellBinding(offset = 4)
	protected int x;

	/** y坐标 */
	@ExcelCellBinding(offset = 5)
	protected int y;


	public int getMapId() {
		return this.mapId;
	}

	public void setMapId(int mapId) {
		this.mapId = mapId;
	}
	
	public int getNpcId() {
		return this.npcId;
	}

	public void setNpcId(int npcId) {
		this.npcId = npcId;
	}
	
	public int getPixelFlag() {
		return this.pixelFlag;
	}

	public void setPixelFlag(int pixelFlag) {
		this.pixelFlag = pixelFlag;
	}
	
	public int getX() {
		return this.x;
	}

	public void setX(int x) {
		this.x = x;
	}
	
	public int getY() {
		return this.y;
	}

	public void setY(int y) {
		this.y = y;
	}
	

	@Override
	public String toString() {
		return "MapNpcTemplateVO[mapId=" + mapId + ",npcId=" + npcId + ",pixelFlag=" + pixelFlag + ",x=" + x + ",y=" + y + ",]";

	}
}