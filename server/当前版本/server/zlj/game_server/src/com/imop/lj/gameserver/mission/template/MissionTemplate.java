package com.imop.lj.gameserver.mission.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

/**
 * 关卡配置
 * 
 */
@ExcelRowBinding
public class MissionTemplate extends MissionTemplateVO {
	
	@Override
	public void check() throws TemplateConfigException {
		
	}
	
}
