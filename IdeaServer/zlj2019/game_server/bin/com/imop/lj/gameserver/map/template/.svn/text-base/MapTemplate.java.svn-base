package com.imop.lj.gameserver.map.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.map.MapDef.MapType;

/**
 * 地图基础模板
 * 
 */
@ExcelRowBinding
public class MapTemplate extends MapTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		if (MapType.valueOf(getMapTypeId()) == null) {
			throw new TemplateConfigException(sheetName, id, "地图类型不存在！" + getMapTypeId());
		}
		
		//地图等级目前只能为1-4
		if (!(getMapLevel() >= 1 && getMapLevel() <= 4)) {
			throw new TemplateConfigException(sheetName, id, "地图等级非法！" + getMapLevel());
		}
	}

	public MapType getMapType() {
		return MapType.valueOf(getMapTypeId());
	}
	
	public boolean canPvp() {
		return this.getPvpFlag() > 0;
	}
	
	public boolean cantreasureMap(){
		return this.getTreasureMap() == 1;
	}
	
}
