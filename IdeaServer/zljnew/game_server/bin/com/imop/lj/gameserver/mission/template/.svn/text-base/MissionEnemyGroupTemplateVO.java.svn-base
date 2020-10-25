package com.imop.lj.gameserver.mission.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.template.ExcelCollectionMapping;
import com.imop.lj.core.template.TemplateObject;
import java.util.List;

/**
 * 敌人组配置
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class MissionEnemyGroupTemplateVO extends TemplateObject {

	/** 敌人列表 */
	@ExcelCollectionMapping(clazz = com.imop.lj.gameserver.mission.template.MissionUnitEnemyTemplate.class, collectionNumber = "2,3;4,5;6,7;8,9;10,11;12,13")
	protected List<com.imop.lj.gameserver.mission.template.MissionUnitEnemyTemplate> enemyList;


	public List<com.imop.lj.gameserver.mission.template.MissionUnitEnemyTemplate> getEnemyList() {
		return this.enemyList;
	}

	public void setEnemyList(List<com.imop.lj.gameserver.mission.template.MissionUnitEnemyTemplate> enemyList) {
		if (enemyList == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[敌人列表]enemyList不可以为空");
		}	
		this.enemyList = enemyList;
	}
	

	@Override
	public String toString() {
		return "MissionEnemyGroupTemplateVO[enemyList=" + enemyList + ",]";

	}
}