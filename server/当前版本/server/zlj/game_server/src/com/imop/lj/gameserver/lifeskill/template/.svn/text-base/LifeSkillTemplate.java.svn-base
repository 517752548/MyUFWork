package com.imop.lj.gameserver.lifeskill.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.lifeskill.LifeSkillDef.LifeSkillType;

@ExcelRowBinding
public class LifeSkillTemplate extends LifeSkillTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		//资源类型是否存在
		LifeSkillType lifeSkillType = getLifeSkillType();
		if(lifeSkillType == null){
			throw new TemplateConfigException(this.getSheetName(), this.getId(), "资源类型不存在！resourceType=" + this.resourceType);
		}
	}
	
	public LifeSkillType getLifeSkillType(){
		return LifeSkillType.valueOf(this.resourceType);
	}

}
