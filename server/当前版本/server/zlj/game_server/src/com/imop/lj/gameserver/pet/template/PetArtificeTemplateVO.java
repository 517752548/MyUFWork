package com.imop.lj.gameserver.pet.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;
import com.imop.lj.core.util.StringUtils;

/**
 * 炼化
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class PetArtificeTemplateVO extends TemplateObject {

	/** 消耗物品ID */
	@ExcelCellBinding(offset = 1)
	protected int itemId;

	/** 消耗物品数量 */
	@ExcelCellBinding(offset = 2)
	protected int itemNum;

	/** 消耗金币 */
	@ExcelCellBinding(offset = 3)
	protected int currencyNum;

	/** 货币种类 */
	@ExcelCellBinding(offset = 4)
	protected int currencyType;

	/** 开启悟性等级 */
	@ExcelCellBinding(offset = 5)
	protected int perceptionLevel;

	/** 品质下限 */
	@ExcelCellBinding(offset = 6)
	protected int minQuality;

	/** 品质上限 */
	@ExcelCellBinding(offset = 7)
	protected int maxQuality;

	/** 名称 */
	@ExcelCellBinding(offset = 8)
	protected String name;


	public int getItemId() {
		return this.itemId;
	}

	public void setItemId(int itemId) {
		if (itemId == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[消耗物品ID]itemId不可以为0");
		}
		if (itemId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[消耗物品ID]itemId的值不得小于0");
		}
		this.itemId = itemId;
	}
	
	public int getItemNum() {
		return this.itemNum;
	}

	public void setItemNum(int itemNum) {
		if (itemNum == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[消耗物品数量]itemNum不可以为0");
		}
		if (itemNum < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[消耗物品数量]itemNum的值不得小于0");
		}
		this.itemNum = itemNum;
	}
	
	public int getCurrencyNum() {
		return this.currencyNum;
	}

	public void setCurrencyNum(int currencyNum) {
		if (currencyNum < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[消耗金币]currencyNum的值不得小于0");
		}
		this.currencyNum = currencyNum;
	}
	
	public int getCurrencyType() {
		return this.currencyType;
	}

	public void setCurrencyType(int currencyType) {
		if (currencyType < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[货币种类]currencyType的值不得小于0");
		}
		this.currencyType = currencyType;
	}
	
	public int getPerceptionLevel() {
		return this.perceptionLevel;
	}

	public void setPerceptionLevel(int perceptionLevel) {
		if (perceptionLevel < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[开启悟性等级]perceptionLevel的值不得小于0");
		}
		this.perceptionLevel = perceptionLevel;
	}
	
	public int getMinQuality() {
		return this.minQuality;
	}

	public void setMinQuality(int minQuality) {
		if (minQuality == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					7, "[品质下限]minQuality不可以为0");
		}
		if (minQuality < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					7, "[品质下限]minQuality的值不得小于1");
		}
		this.minQuality = minQuality;
	}
	
	public int getMaxQuality() {
		return this.maxQuality;
	}

	public void setMaxQuality(int maxQuality) {
		if (maxQuality == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					8, "[品质上限]maxQuality不可以为0");
		}
		if (maxQuality < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					8, "[品质上限]maxQuality的值不得小于1");
		}
		this.maxQuality = maxQuality;
	}
	
	public String getName() {
		return this.name;
	}

	public void setName(String name) {
		if (StringUtils.isEmpty(name)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					9, "[名称]name不可以为空");
		}
		if (name != null) {
			this.name = name.trim();
		}else{
			this.name = name;
		}
	}
	

	@Override
	public String toString() {
		return "PetArtificeTemplateVO[itemId=" + itemId + ",itemNum=" + itemNum + ",currencyNum=" + currencyNum + ",currencyType=" + currencyType + ",perceptionLevel=" + perceptionLevel + ",minQuality=" + minQuality + ",maxQuality=" + maxQuality + ",name=" + name + ",]";

	}
}