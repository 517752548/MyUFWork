package com.imop.lj.gameserver.battle.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

/**
 * 战斗属性系数表
 * 
 */
@ExcelRowBinding
public class BattlePropCoefTemplate extends BattlePropCoefTemplateVO {
	@Override
	public void check() throws TemplateConfigException {
		//等级段是否合法 TODO
		
	}
}