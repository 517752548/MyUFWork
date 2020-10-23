package com.imop.lj.gameserver.pet.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

/**
 * 战斗类型配置
 * 
 */
@ExcelRowBinding
public class BattleTypeTemplate extends BattleTypeTemplateVO {
	
	@Override
	public void check() throws TemplateConfigException {
	
	}
	
}
