package com.imop.lj.gameserver.humanskill.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.pet.PetDef;

@ExcelRowBinding
public class HumanMainSkillTemplate extends HumanMainSkillTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		// TODO 自动生成的方法存根
		if(!PetDef.JobType.valueOf(this.getJobId()).containsMainSkillType(PetDef.MainSkillType.valueOf(this.getId())) ){
			throw new TemplateConfigException(this.sheetName, this.id, "职业与心法设计不匹配!");
		}
//		if(PetDef.MainSkillType.valueOf(this.getId()).getJobType()!=PetDef.JobType.valueOf(this.getJobId())){
//			System.out.println(PetDef.JobType.valueOf(this.getJobId()));
//			System.out.println(PetDef.MainSkillType.valueOf(this.getId()).getMainSKillName());
//			System.out.println(PetDef.MainSkillType.valueOf(this.getId()));
//			System.out.println(PetDef.MainSkillType.valueOf(this.getId()).getJobType());
//			throw new TemplateConfigException(this.sheetName, this.id, "心法与职业设计不匹配!");
//		}
	}

}
