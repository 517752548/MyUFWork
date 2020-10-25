package com.imop.lj.gameserver.pet.template;

import java.util.Map;
import java.util.Map.Entry;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

@ExcelRowBinding

public class PetPerceptPromoteTemplate extends PetPerceptPromoteTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		// TODO 自动生成的方法存根
		Map<Integer, PetPerceptLevelTemplate> levelMap = templateService.getAll(PetPerceptLevelTemplate.class);
		Map<Integer, PetPerceptTypeTemplate> typeMap = templateService.getAll(PetPerceptTypeTemplate.class);
		Map<Integer, PetPerceptPromoteTemplate> expMap = templateService.getAll(PetPerceptPromoteTemplate.class);
		for(Entry<Integer, PetPerceptLevelTemplate> e1 : levelMap.entrySet()){
			for(Entry<Integer, PetPerceptTypeTemplate> e2 : typeMap.entrySet()){
				boolean flag = false;
				for(Entry<Integer, PetPerceptPromoteTemplate> e3 : expMap.entrySet()){
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
