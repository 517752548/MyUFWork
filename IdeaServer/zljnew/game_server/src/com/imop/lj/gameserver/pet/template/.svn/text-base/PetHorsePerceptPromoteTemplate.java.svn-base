package com.imop.lj.gameserver.pet.template;

import java.util.Map;
import java.util.Map.Entry;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

@ExcelRowBinding

public class PetHorsePerceptPromoteTemplate extends PetHorsePerceptPromoteTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		Map<Integer, PetHorsePerceptLevelTemplate> levelMap = templateService.getAll(PetHorsePerceptLevelTemplate.class);
		Map<Integer, PetHorsePerceptTypeTemplate> typeMap = templateService.getAll(PetHorsePerceptTypeTemplate.class);
		Map<Integer, PetHorsePerceptPromoteTemplate> expMap = templateService.getAll(PetHorsePerceptPromoteTemplate.class);
		for(Entry<Integer, PetHorsePerceptLevelTemplate> e1 : levelMap.entrySet()){
			for(Entry<Integer, PetHorsePerceptTypeTemplate> e2 : typeMap.entrySet()){
				boolean flag = false;
				for(Entry<Integer, PetHorsePerceptPromoteTemplate> e3 : expMap.entrySet()){
					if(e3.getValue().getPromoteType()==e2.getValue().getId()&&e3.getValue().getPerceptLevel()==e1.getValue().getId()){
						flag = true;
						break;
					}
				}
				if(!flag){
					throw new TemplateConfigException(this.sheetName, this.id, "悟性增长经验表与悟性等级和悟性增加类型表不匹配!");
				}
			}
		}
	}

}
