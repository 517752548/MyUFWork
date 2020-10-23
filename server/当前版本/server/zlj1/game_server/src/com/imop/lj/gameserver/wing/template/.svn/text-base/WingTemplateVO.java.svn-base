package com.imop.lj.gameserver.wing.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.ExcelCollectionMapping;
import com.imop.lj.core.template.TemplateObject;
import com.imop.lj.core.util.StringUtils;
import java.util.List;

/**
 * 翅膀
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class WingTemplateVO extends TemplateObject {

	/** 翅膀名称 */
	@ExcelCellBinding(offset = 1)
	protected String wingName;

	/** 翅膀图标 */
	@ExcelCellBinding(offset = 2)
	protected String icon;

	/** 美术Id */
	@ExcelCellBinding(offset = 3)
	protected String modelId;

	/** 品质ID */
	@ExcelCellBinding(offset = 4)
	protected int rarityId;

	/** 技能属性列表 */
	@ExcelCollectionMapping(clazz = com.imop.lj.gameserver.pet.template.PassiveTalentPropItem.class, collectionNumber = "5,6,7;8,9,10;11,12,13;14,15,16;17,18,19;20,21,22")
	protected List<com.imop.lj.gameserver.pet.template.PassiveTalentPropItem> propList;


	public String getWingName() {
		return this.wingName;
	}

	public void setWingName(String wingName) {
		if (wingName != null) {
			this.wingName = wingName.trim();
		}else{
			this.wingName = wingName;
		}
	}
	
	public String getIcon() {
		return this.icon;
	}

	public void setIcon(String icon) {
		if (StringUtils.isEmpty(icon)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[翅膀图标]icon不可以为空");
		}
		if (icon != null) {
			this.icon = icon.trim();
		}else{
			this.icon = icon;
		}
	}
	
	public String getModelId() {
		return this.modelId;
	}

	public void setModelId(String modelId) {
		if (modelId != null) {
			this.modelId = modelId.trim();
		}else{
			this.modelId = modelId;
		}
	}
	
	public int getRarityId() {
		return this.rarityId;
	}

	public void setRarityId(int rarityId) {
		if (rarityId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[品质ID]rarityId的值不得小于1");
		}
		this.rarityId = rarityId;
	}
	
	public List<com.imop.lj.gameserver.pet.template.PassiveTalentPropItem> getPropList() {
		return this.propList;
	}

	public void setPropList(List<com.imop.lj.gameserver.pet.template.PassiveTalentPropItem> propList) {
		if (propList == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[技能属性列表]propList不可以为空");
		}	
		this.propList = propList;
	}
	

	@Override
	public String toString() {
		return "WingTemplateVO[wingName=" + wingName + ",icon=" + icon + ",modelId=" + modelId + ",rarityId=" + rarityId + ",propList=" + propList + ",]";

	}
}