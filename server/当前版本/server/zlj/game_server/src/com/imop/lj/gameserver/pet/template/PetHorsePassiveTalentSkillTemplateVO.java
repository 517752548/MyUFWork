package com.imop.lj.gameserver.pet.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.ExcelCollectionMapping;
import com.imop.lj.core.template.TemplateObject;
import com.imop.lj.core.util.StringUtils;
import java.util.List;

/**
 * 骑宠被动天赋技能
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class PetHorsePassiveTalentSkillTemplateVO extends TemplateObject {

	/** 名称 */
	@ExcelCellBinding(offset = 1)
	protected String name;

	/** 技能属性列表 */
	@ExcelCollectionMapping(clazz = com.imop.lj.gameserver.pet.template.PassiveTalentPropItem.class, collectionNumber = "2,3,4;5,6,7")
	protected List<com.imop.lj.gameserver.pet.template.PassiveTalentPropItem> propList;


	public String getName() {
		return this.name;
	}

	public void setName(String name) {
		if (StringUtils.isEmpty(name)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[名称]name不可以为空");
		}
		if (name != null) {
			this.name = name.trim();
		}else{
			this.name = name;
		}
	}
	
	public List<com.imop.lj.gameserver.pet.template.PassiveTalentPropItem> getPropList() {
		return this.propList;
	}

	public void setPropList(List<com.imop.lj.gameserver.pet.template.PassiveTalentPropItem> propList) {
		if (propList == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[技能属性列表]propList不可以为空");
		}	
		this.propList = propList;
	}
	

	@Override
	public String toString() {
		return "PetHorsePassiveTalentSkillTemplateVO[name=" + name + ",propList=" + propList + ",]";

	}
}