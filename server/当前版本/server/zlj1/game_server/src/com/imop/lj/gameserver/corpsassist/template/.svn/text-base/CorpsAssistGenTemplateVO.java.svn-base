package com.imop.lj.gameserver.corpsassist.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 辅助技能产出配置
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class CorpsAssistGenTemplateVO extends TemplateObject {

	/** 辅助技能ID */
	@ExcelCellBinding(offset = 1)
	protected int assistId;

	/** 需求技能等级 */
	@ExcelCellBinding(offset = 2)
	protected int assistLevel;

	/** 需要活力值 */
	@ExcelCellBinding(offset = 3)
	protected int costEnergy;

	/** 奖励Id */
	@ExcelCellBinding(offset = 4)
	protected int rewardId;

	/** 道具Id */
	@ExcelCellBinding(offset = 5)
	protected int itemId;

	/** 道具产出描述 */
	@ExcelCellBinding(offset = 6)
	protected String genDesc;


	public int getAssistId() {
		return this.assistId;
	}

	public void setAssistId(int assistId) {
		if (assistId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[辅助技能ID]assistId的值不得小于1");
		}
		this.assistId = assistId;
	}
	
	public int getAssistLevel() {
		return this.assistLevel;
	}

	public void setAssistLevel(int assistLevel) {
		if (assistLevel < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[需求技能等级]assistLevel的值不得小于1");
		}
		this.assistLevel = assistLevel;
	}
	
	public int getCostEnergy() {
		return this.costEnergy;
	}

	public void setCostEnergy(int costEnergy) {
		if (costEnergy < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[需要活力值]costEnergy的值不得小于1");
		}
		this.costEnergy = costEnergy;
	}
	
	public int getRewardId() {
		return this.rewardId;
	}

	public void setRewardId(int rewardId) {
		if (rewardId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[奖励Id]rewardId的值不得小于1");
		}
		this.rewardId = rewardId;
	}
	
	public int getItemId() {
		return this.itemId;
	}

	public void setItemId(int itemId) {
		if (itemId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[道具Id]itemId的值不得小于1");
		}
		this.itemId = itemId;
	}
	
	public String getGenDesc() {
		return this.genDesc;
	}

	public void setGenDesc(String genDesc) {
		if (genDesc != null) {
			this.genDesc = genDesc.trim();
		}else{
			this.genDesc = genDesc;
		}
	}
	

	@Override
	public String toString() {
		return "CorpsAssistGenTemplateVO[assistId=" + assistId + ",assistLevel=" + assistLevel + ",costEnergy=" + costEnergy + ",rewardId=" + rewardId + ",itemId=" + itemId + ",genDesc=" + genDesc + ",]";

	}
}