package com.imop.lj.gameserver.item.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;

/**
 * 宠物技能书
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class GemItemTemplateVO extends ItemTemplate {

	/** 属性key */
	@ExcelCellBinding(offset = 38)
	protected int propKey;

	/** 属性值 */
	@ExcelCellBinding(offset = 39)
	protected int propValue;

	/** 宝石颜色 */
	@ExcelCellBinding(offset = 40)
	protected int gemTypeId;

	/** 宝石等级 */
	@ExcelCellBinding(offset = 41)
	protected int gemLevel;

	/** 宝石组（降级时按组找低级宝石） */
	@ExcelCellBinding(offset = 42)
	protected int gemGroup;


	public int getPropKey() {
		return this.propKey;
	}

	public void setPropKey(int propKey) {
		if (propKey < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					39, "[属性key]propKey的值不得小于0");
		}
		this.propKey = propKey;
	}
	
	public int getPropValue() {
		return this.propValue;
	}

	public void setPropValue(int propValue) {
		if (propValue < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					40, "[属性值]propValue的值不得小于0");
		}
		this.propValue = propValue;
	}
	
	public int getGemTypeId() {
		return this.gemTypeId;
	}

	public void setGemTypeId(int gemTypeId) {
		if (gemTypeId == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					41, "[宝石颜色]gemTypeId不可以为0");
		}
		if (gemTypeId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					41, "[宝石颜色]gemTypeId的值不得小于1");
		}
		this.gemTypeId = gemTypeId;
	}
	
	public int getGemLevel() {
		return this.gemLevel;
	}

	public void setGemLevel(int gemLevel) {
		if (gemLevel == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					42, "[宝石等级]gemLevel不可以为0");
		}
		if (gemLevel < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					42, "[宝石等级]gemLevel的值不得小于1");
		}
		this.gemLevel = gemLevel;
	}
	
	public int getGemGroup() {
		return this.gemGroup;
	}

	public void setGemGroup(int gemGroup) {
		if (gemGroup == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					43, "[宝石组（降级时按组找低级宝石）]gemGroup不可以为0");
		}
		if (gemGroup < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					43, "[宝石组（降级时按组找低级宝石）]gemGroup的值不得小于1");
		}
		this.gemGroup = gemGroup;
	}
	

	@Override
	public String toString() {
		return "GemItemTemplateVO[propKey=" + propKey + ",propValue=" + propValue + ",gemTypeId=" + gemTypeId + ",gemLevel=" + gemLevel + ",gemGroup=" + gemGroup + ",]";

	}
}