package com.imop.lj.gameserver.lifeskill.template;

import java.util.List;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.item.template.ItemTemplate;
import com.imop.lj.gameserver.lifeskill.LifeSkillDef.LifeSkillType;
import com.imop.lj.gameserver.map.template.MapTemplate;
import com.imop.lj.gameserver.npc.template.NpcTemplate;


@ExcelRowBinding
public class LifeSkillMapTemplate extends LifeSkillMapTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		//地图ID是否存在
		MapTemplate mapTpl = templateService.get(this.mapId, MapTemplate.class);
		if(mapTpl == null){
			throw new TemplateConfigException(this.sheetName, getId(), "地图ID非法！" + this.mapId);
		}
		
		//资源类型是否存在
		LifeSkillType lifeSkillType = getLifeSkillType();
		if(lifeSkillType == null){
			throw new TemplateConfigException(this.getSheetName(), this.getId(), "资源类型不存在！resourceType=" + this.resourceType);
		}
		
		//资源ID是否存在
		if (templateService.get(this.resourceId, NpcTemplate.class) == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(), "资源Id不存在！ResourceId=" + this.resourceId);
		}
		
		
		//道具Id是否存在
		if(this.itemId > 0){
			if (templateService.get(this.itemId, ItemTemplate.class) == null) {
				throw new TemplateConfigException(this.getSheetName(), this.getId(), "产出道具Id不存在！itemId=" + this.itemId);
			}
		}
		
		
	}

	public LifeSkillType getLifeSkillType(){
		return LifeSkillType.valueOf(this.resourceType);
	}
}
