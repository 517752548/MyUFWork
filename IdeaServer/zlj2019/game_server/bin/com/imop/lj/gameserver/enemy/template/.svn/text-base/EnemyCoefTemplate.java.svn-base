package com.imop.lj.gameserver.enemy.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

import com.imop.lj.gameserver.pet.template.PetTemplate;

/**
 * 单个怪物系数表
 * 
 */
@ExcelRowBinding
public class EnemyCoefTemplate extends EnemyCoefTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		if (templateService.get(getId(), PetTemplate.class) == null) {
			if (templateService.get(getId(), EnemyTemplate.class) == null) {
				throw new TemplateConfigException(sheetName, id, "怪物Id不存在! " + getId());
			}
		}
	}

}
