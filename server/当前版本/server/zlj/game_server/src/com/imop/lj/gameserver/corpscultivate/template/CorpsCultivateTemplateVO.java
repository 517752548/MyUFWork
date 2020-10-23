package com.imop.lj.gameserver.corpscultivate.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.ExcelCollectionMapping;
import com.imop.lj.core.template.TemplateObject;
import java.util.List;

/**
 * 帮派修炼技能配置
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class CorpsCultivateTemplateVO extends TemplateObject {

	/** 修炼技能ID */
	@ExcelCellBinding(offset = 1)
	protected int cultivateId;

	/** 技能icon */
	@ExcelCellBinding(offset = 2)
	protected String icon;

	/**  是否影响人物属性 */
	@ExcelCellBinding(offset = 3)
	protected int playerSkillFlag;

	/** 修炼技能名称 */
	@ExcelCellBinding(offset = 4)
	protected String cultivateName;

	/** 修炼技能描述 */
	@ExcelCellBinding(offset = 5)
	protected String cultivateDesc;

	/** 技能属性列表 */
	@ExcelCollectionMapping(clazz = com.imop.lj.gameserver.pet.template.PassiveTalentPropItem.class, collectionNumber = "6,7,8;9,10,11;12,13,14")
	protected List<com.imop.lj.gameserver.pet.template.PassiveTalentPropItem> propList;


	public int getCultivateId() {
		return this.cultivateId;
	}

	public void setCultivateId(int cultivateId) {
		if (cultivateId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[修炼技能ID]cultivateId的值不得小于1");
		}
		this.cultivateId = cultivateId;
	}
	
	public String getIcon() {
		return this.icon;
	}

	public void setIcon(String icon) {
		if (icon != null) {
			this.icon = icon.trim();
		}else{
			this.icon = icon;
		}
	}
	
	public int getPlayerSkillFlag() {
		return this.playerSkillFlag;
	}

	public void setPlayerSkillFlag(int playerSkillFlag) {
		this.playerSkillFlag = playerSkillFlag;
	}
	
	public String getCultivateName() {
		return this.cultivateName;
	}

	public void setCultivateName(String cultivateName) {
		if (cultivateName != null) {
			this.cultivateName = cultivateName.trim();
		}else{
			this.cultivateName = cultivateName;
		}
	}
	
	public String getCultivateDesc() {
		return this.cultivateDesc;
	}

	public void setCultivateDesc(String cultivateDesc) {
		if (cultivateDesc != null) {
			this.cultivateDesc = cultivateDesc.trim();
		}else{
			this.cultivateDesc = cultivateDesc;
		}
	}
	
	public List<com.imop.lj.gameserver.pet.template.PassiveTalentPropItem> getPropList() {
		return this.propList;
	}

	public void setPropList(List<com.imop.lj.gameserver.pet.template.PassiveTalentPropItem> propList) {
		if (propList == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					7, "[技能属性列表]propList不可以为空");
		}	
		this.propList = propList;
	}
	

	@Override
	public String toString() {
		return "CorpsCultivateTemplateVO[cultivateId=" + cultivateId + ",icon=" + icon + ",playerSkillFlag=" + playerSkillFlag + ",cultivateName=" + cultivateName + ",cultivateDesc=" + cultivateDesc + ",propList=" + propList + ",]";

	}
}