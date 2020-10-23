package com.imop.lj.gameserver.pet.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.template.ExcelCollectionMapping;
import com.imop.lj.core.template.TemplateObject;
import java.util.List;

/**
 * 宠物天赋技能包
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class PetTalentSkillPackTemplateVO extends TemplateObject {

	/** 技能Id权重列表 */
	@ExcelCollectionMapping(clazz = com.imop.lj.gameserver.pet.template.TalentSkillItem.class, collectionNumber = "1,2;3,4;5,6;7,8;9,10;11,12;13,14;15,16;17,18;19,20;21,22;23,24;25,26;27,28;29,30")
	protected List<com.imop.lj.gameserver.pet.template.TalentSkillItem> talentSkillList;


	public List<com.imop.lj.gameserver.pet.template.TalentSkillItem> getTalentSkillList() {
		return this.talentSkillList;
	}

	public void setTalentSkillList(List<com.imop.lj.gameserver.pet.template.TalentSkillItem> talentSkillList) {
		if (talentSkillList == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[技能Id权重列表]talentSkillList不可以为空");
		}	
		this.talentSkillList = talentSkillList;
	}
	

	@Override
	public String toString() {
		return "PetTalentSkillPackTemplateVO[talentSkillList=" + talentSkillList + ",]";

	}
}