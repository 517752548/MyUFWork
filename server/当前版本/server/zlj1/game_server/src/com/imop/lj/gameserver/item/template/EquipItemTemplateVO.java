package com.imop.lj.gameserver.item.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.ExcelCollectionMapping;
import java.util.List;

/**
 * 装备物品模板
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class EquipItemTemplateVO extends ItemTemplate {

	/** 是否固定装备，0否，1是 */
	@ExcelCellBinding(offset = 34)
	protected int isFixedAttr;

	/** 部位Id */
	@ExcelCellBinding(offset = 35)
	protected int positionId;

	/** 阶数Id */
	@ExcelCellBinding(offset = 36)
	protected int gradeId;

	/** 职业要求 */
	@ExcelCellBinding(offset = 37)
	protected int jobLimit;

	/** 性别要求 */
	@ExcelCellBinding(offset = 38)
	protected int sexLimit;

	/** 耐久度 */
	@ExcelCellBinding(offset = 39)
	protected int durability;

	/** 左手模型 */
	@ExcelCellBinding(offset = 40)
	protected String leftModel;

	/** 右手模型 */
	@ExcelCellBinding(offset = 41)
	protected String rightModel;

	/** 基础属性价值 */
	@ExcelCellBinding(offset = 42)
	protected int basePropValue;

	/** 附加属性价值 */
	@ExcelCellBinding(offset = 43)
	protected int addPropValue;

	/** 基础属性列表，目前只有一组 */
	@ExcelCollectionMapping(clazz = com.imop.lj.gameserver.item.template.EquipItemAttribute.class, collectionNumber = "44,45")
	protected List<com.imop.lj.gameserver.item.template.EquipItemAttribute> basePropList;

	/** 附加属性列表 */
	@ExcelCollectionMapping(clazz = com.imop.lj.gameserver.item.template.EquipItemAttribute.class, collectionNumber = "46,47;48,49;50,51;52,53;54,55;56,57")
	protected List<com.imop.lj.gameserver.item.template.EquipItemAttribute> addPropList;


	public int getIsFixedAttr() {
		return this.isFixedAttr;
	}

	public void setIsFixedAttr(int isFixedAttr) {
		if (isFixedAttr > 1 || isFixedAttr < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					35, "[是否固定装备，0否，1是]isFixedAttr的值不合法，应为0至1之间");
		}
		this.isFixedAttr = isFixedAttr;
	}
	
	public int getPositionId() {
		return this.positionId;
	}

	public void setPositionId(int positionId) {
		if (positionId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					36, "[部位Id]positionId的值不得小于1");
		}
		this.positionId = positionId;
	}
	
	public int getGradeId() {
		return this.gradeId;
	}

	public void setGradeId(int gradeId) {
		if (gradeId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					37, "[阶数Id]gradeId的值不得小于1");
		}
		this.gradeId = gradeId;
	}
	
	public int getJobLimit() {
		return this.jobLimit;
	}

	public void setJobLimit(int jobLimit) {
		if (jobLimit < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					38, "[职业要求]jobLimit的值不得小于1");
		}
		this.jobLimit = jobLimit;
	}
	
	public int getSexLimit() {
		return this.sexLimit;
	}

	public void setSexLimit(int sexLimit) {
		if (sexLimit < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					39, "[性别要求]sexLimit的值不得小于1");
		}
		this.sexLimit = sexLimit;
	}
	
	public int getDurability() {
		return this.durability;
	}

	public void setDurability(int durability) {
		if (durability < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					40, "[耐久度]durability的值不得小于1");
		}
		this.durability = durability;
	}
	
	public String getLeftModel() {
		return this.leftModel;
	}

	public void setLeftModel(String leftModel) {
		if (leftModel != null) {
			this.leftModel = leftModel.trim();
		}else{
			this.leftModel = leftModel;
		}
	}
	
	public String getRightModel() {
		return this.rightModel;
	}

	public void setRightModel(String rightModel) {
		if (rightModel != null) {
			this.rightModel = rightModel.trim();
		}else{
			this.rightModel = rightModel;
		}
	}
	
	public int getBasePropValue() {
		return this.basePropValue;
	}

	public void setBasePropValue(int basePropValue) {
		if (basePropValue < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					43, "[基础属性价值]basePropValue的值不得小于0");
		}
		this.basePropValue = basePropValue;
	}
	
	public int getAddPropValue() {
		return this.addPropValue;
	}

	public void setAddPropValue(int addPropValue) {
		if (addPropValue < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					44, "[附加属性价值]addPropValue的值不得小于0");
		}
		this.addPropValue = addPropValue;
	}
	
	public List<com.imop.lj.gameserver.item.template.EquipItemAttribute> getBasePropList() {
		return this.basePropList;
	}

	public void setBasePropList(List<com.imop.lj.gameserver.item.template.EquipItemAttribute> basePropList) {
		if (basePropList == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					45, "[基础属性列表，目前只有一组]basePropList不可以为空");
		}	
		this.basePropList = basePropList;
	}
	
	public List<com.imop.lj.gameserver.item.template.EquipItemAttribute> getAddPropList() {
		return this.addPropList;
	}

	public void setAddPropList(List<com.imop.lj.gameserver.item.template.EquipItemAttribute> addPropList) {
		if (addPropList == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					47, "[附加属性列表]addPropList不可以为空");
		}	
		this.addPropList = addPropList;
	}
	

	@Override
	public String toString() {
		return "EquipItemTemplateVO[isFixedAttr=" + isFixedAttr + ",positionId=" + positionId + ",gradeId=" + gradeId + ",jobLimit=" + jobLimit + ",sexLimit=" + sexLimit + ",durability=" + durability + ",leftModel=" + leftModel + ",rightModel=" + rightModel + ",basePropValue=" + basePropValue + ",addPropValue=" + addPropValue + ",basePropList=" + basePropList + ",addPropList=" + addPropList + ",]";

	}
}