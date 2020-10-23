package com.imop.lj.gameserver.lifeskill.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.humanskill.template.HumanSubSkillCost;
import com.imop.lj.gameserver.item.template.ItemTemplate;


@ExcelRowBinding
public class LifeSkillLevelTemplate extends LifeSkillLevelTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		
		//技能Id是否存在
		if (templateService.get(this.lifeSkillId, LifeSkillTemplate.class) == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(), "生活技能Id不存在！lifeSkillId=" + this.lifeSkillId);
		}
		
		//道具Id是否存在
		if (templateService.get(this.itemId, ItemTemplate.class) == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(), "产出最高品质道具Id不存在！itemId=" + this.itemId);
		}	
		
		//技能熟练度是否存在
		if(this.getLifeSkillCostList() == null){
			throw new TemplateConfigException(this.sheetName, this.id, "生活技能消耗配置为空");
		}
		for(HumanSubSkillCost h : this.getLifeSkillCostList()){
			if(h == null || h.getNeedProficiency() <=0 ){
				throw new TemplateConfigException(this.sheetName, this.id, "所需熟练度不正确!");
			}
		}
		
	}

}
