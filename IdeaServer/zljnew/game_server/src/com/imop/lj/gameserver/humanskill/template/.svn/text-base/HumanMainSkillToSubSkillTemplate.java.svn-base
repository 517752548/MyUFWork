package com.imop.lj.gameserver.humanskill.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;


@ExcelRowBinding
public class HumanMainSkillToSubSkillTemplate extends
		HumanMainSkillToSubSkillTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		// TODO 自动生成的方法存根
//		if(templateService.get(this.getSubSkillId(), SkillTemplate.class) == null){
//			throw new TemplateConfigException(this.sheetName, this.id, "无法找到对应的技能!");
//		}
		if(templateService.get(this.getSubSkillId(), HumanSubSkillTemplate.class) == null){
			throw new TemplateConfigException(this.sheetName, this.id, "无法找到对应的人物技能配置!");
		}
		if(templateService.get(this.getMainSkillId(), HumanMainSkillTemplate.class) == null){
			throw new TemplateConfigException(this.sheetName, this.id, "无法找到对应的人物心法配置!");
		}
	}

}
