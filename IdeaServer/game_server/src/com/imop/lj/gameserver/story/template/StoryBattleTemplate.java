package com.imop.lj.gameserver.story.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;


/**
 * 剧情战报配置表
 */
@ExcelRowBinding
public class StoryBattleTemplate extends StoryBattleTemplateVO {
	
	@Override
	public void check() throws TemplateConfigException {
		
	}
	
}
