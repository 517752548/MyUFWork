package com.imop.lj.gameserver.map.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

import com.imop.lj.gameserver.enemy.template.EnemyArmyTemplate;

/**
 * 地图遇怪方案
 * 
 */
@ExcelRowBinding
public class MapMeetMonsterTemplate extends MapMeetMonsterTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		//怪物组是否存在
		if (templateService.get(this.enemyArmyId, EnemyArmyTemplate.class) == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(), 0, "怪物组Id不存在！npcId=" + this.enemyArmyId);
		}
		
	}

}
