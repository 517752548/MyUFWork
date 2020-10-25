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
	@ExcelCellBinding(offset = 38)
	protected int isFixedAttr;

	/** 部位Id */
	@ExcelCellBinding(offset = 39)
	protected int positionId;

	/** 阶数Id */
	@ExcelCellBinding(offset = 40)
	protected int gradeId;

	/** 职业要求 */
	@ExcelCellBinding(offset = 41)
	protected int jobLimit;

	/** 性别要求 */
	@ExcelCellBinding(offset = 42)
	protected int sexLimit;

	/** 属性要求类型 */
	@ExcelCellBinding(offset = 43)
	protected int propLimit;

	/** 属性要求数值 */
	@ExcelCellBinding(offset = 44)
	protected int propValueLimit;

	/** 耐久度 */
	@ExcelCellBinding(offset = 45)
	protected int durability;

	/** 左手模型 */
	@ExcelCellBinding(offset = 46)
	protected String leftModel;

	/** 右手模型 */
	@ExcelCellBinding(offset = 47)
	protected String rightModel;

	/** 基础属性价值 */
	@ExcelCellBinding(offset = 48)
	protected int basePropValue;

	/** 附加属性价值 */
	@ExcelCellBinding(offset = 49)
	protected int addPropValue;

	/** 绑定属性价值 */
	@ExcelCellBinding(offset = 50)
	protected int bindPropValue;

	/** 基础属性列表，目前只有一组 */
	@ExcelCollectionMapping(clazz = com.imop.lj.gameserver.item.template.EquipItemAttribute.class, collectionNumber = "51,52")
	protected List<com.imop.lj.gameserver.item.template.EquipItemAttribute> basePropList;

	/** 附加属性列表 */
	@ExcelCollectionMapping(clazz = com.imop.lj.gameserver.item.template.EquipItemAttribute.class, collectionNumber = "53,54;55,56;57,58;59,60;61,62;63,64")
	protected List<com.imop.lj.gameserver.item.template.EquipItemAttribute> addPropList;


	public int getIsFixedAttr() {
		return this.isFixedAttr;
	}

	public void setIsFixedAttr(int isFixedAttr) {
		if (isFixedAttr > 1 || isFixedAttr < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					39, "[是否固定装备，0否，1是]isFixedAttr的值不合法，应为0至1之间");
		}
		this.isFixedAttr = isFixedAttr;
	}
	
	public int getPositionId() {
		return this.positionId;
	}

	public void setPositionId(int positionId) {
		if (positionId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					40, "[部位Id]positionId的值不得小于1");
		}
		this.positionId = positionId;
	}
	
	public int getGradeId() {
		return this.gradeId;
	}

	public void setGradeId(int gradeId) {
		if (gradeId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					41, "[阶数Id]gradeId的值不得小于1");
		}
		this.gradeId = gradeId;
	}
	
	public int getJobLimit() {
		return this.jobLimit;
	}

	public void setJobLimit(int jobLimit) {
		if (jobLimit < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					42, "[职业要求]jobLimit的值不得小于1");
		}
		this.jobLimit = jobLimit;
	}
	
	public int getSexLimit() {
		return this.sexLimit;
	}

	public void setSexLimit(int sexLimit) {
		if (sexLimit < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					43, "[性别要求]sexLimit的值不得小于1");
		}
		this.sexLimit = sexLimit;
	}
	
	public int getPropLimit() {
		return this.propLimit;
	}

	public void setPropLimit(int propLimit) {
		if (propLimit < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					44, "[属性要求类型]propLimit的值不得小于0");
		}
		this.propLimit = propLimit;
	}
	
	public int getPropValueLimit() {
		return this.propValueLimit;
	}

	public void setPropValueLimit(int propValueLimit) {
		if (propValueLimit < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					45, "[属性要求数值]propValueLimit的值不得小于0");
		}
		this.propValueLimit = propValueLimit;
	}
	
	public int getDurability() {
		return this.durability;
	}

	public void setDurability(int durability) {
		if (durability < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					46, "[耐久度]durability的值不得小于1");
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
					49, "[基础属性价值]basePropValue的值不得小于0");
		}
		this.basePropValue = basePropValue;
	}
	
	public int getAddPropValue() {
		return this.addPropValue;
	}

	public void setAddPropValue(int addPropValue) {
		if (addPropValue < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					50, "[附加属性价值]addPropValue的值不得小于0");
		}
		this.addPropValue = addPropValue;
	}
	
	public int getBindPropValue() {
		return this.bindPropValue;
	}

	public void setBindPropValue(int bindPropValue) {
		if (bindPropValue < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					51, "[绑定属性价值]bindPropValue的值不得小于0");
		}
		this.bindPropValue = bindPropValue;
	}
	
	public List<com.imop.lj.gameserver.item.template.EquipItemAttribute> getBasePropList() {
		return this.basePropList;
	}

	public void setBasePropList(List<com.imop.lj.gameserver.item.template.EquipItemAttribute> basePropList) {
		if (basePropList == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					52, "[基础属性列表，目前只有一组]basePropList不可以为空");
		}	
		this.basePropList = basePropList;
	}
	
	public List<com.imop.lj.gameserver.item.template.EquipItemAttribute> getAddPropList() {
		return this.addPropList;
	}

	public void setAddPropList(List<com.imop.lj.gameserver.item.template.EquipItemAttribute> addPropList) {
		if (addPropList == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					54, "[附加属性列表]addPropList不可以为空");
		}	
		this.addPropList = addPropList;
	}
	

	@Override
	public String toString() {
		return "EquipItemTemplateVO[isFixedAttr=" + isFixedAttr + ",positionId=" + positionId + ",gradeId=" + gradeId + ",jobLimit=" + jobLimit + ",sexLimit=" + sexLimit + ",propLimit=" + propLimit + ",propValueLimit=" + propValueLimit + ",durability=" + durability + ",leftModel=" + leftModel + ",rightModel=" + rightModel + ",basePropValue=" + basePropValue + ",addPropValue=" + addPropValue + ",bindPropValue=" + bindPropValue + ",basePropList=" + basePropList + ",addPropList=" + addPropList + ",]";

	}
}