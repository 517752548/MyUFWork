package com.imop.lj.gameserver.pet.template;

import java.util.Map;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.common.Globals;


@ExcelRowBinding
public class PetHorsePerceptLevelTemplate extends PetHorsePerceptLevelTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		//验证等级连续性
		Map<Integer, PetHorsePerceptLevelTemplate> levelMap = templateService.getAll(PetHorsePerceptLevelTemplate.class);
		if(levelMap.size()!=Globals.getGameConstants().getPetPerceptLevelMax()){
			throw new TemplateConfigException(this.sheetName, this.id, "系统配置与xls配置不匹配!");
		}
		if(this.getId()>Globals.getGameConstants().getPetPerceptLevelMax()||this.getId()>levelMap.size()){
			throw new TemplateConfigException(this.sheetName, this.id, "悟性等级没有从1开始或者不连续!");
		}
	}

}
