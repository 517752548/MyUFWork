package com.imop.lj.gameserver.skill.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

/**
 * 技能表现
 * 
 */
@ExcelRowBinding
public class SkillPerformTemplate extends SkillPerformTemplateVO {
	
	@Override
	public void check() throws TemplateConfigException {
	
	}
	
}
