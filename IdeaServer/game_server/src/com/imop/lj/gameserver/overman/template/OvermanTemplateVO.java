package com.imop.lj.gameserver.overman.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;
import com.imop.lj.core.util.StringUtils;

/**
 * 师徒
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class OvermanTemplateVO extends TemplateObject {

	/** 徒弟达到的级别 */
	@ExcelCellBinding(offset = 1)
	protected Integer level;

	/** 师傅给的奖励 */
	@ExcelCellBinding(offset = 2)
	protected Integer overmanReward;

	/** 徒弟给的奖励 */
	@ExcelCellBinding(offset = 3)
	protected Integer lowermanReward;

	/** 描述 */
	@ExcelCellBinding(offset = 4)
	protected String desc;


	public Integer getLevel() {
		return this.level;
	}

	public void setLevel(Integer level) {
		if (level == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[徒弟达到的级别]level不可以为空");
		}	
		if (level < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[徒弟达到的级别]level的值不得小于0");
		}
		this.level = level;
	}
	
	public Integer getOvermanReward() {
		return this.overmanReward;
	}

	public void setOvermanReward(Integer overmanReward) {
		if (overmanReward == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[师傅给的奖励]overmanReward不可以为空");
		}	
		this.overmanReward = overmanReward;
	}
	
	public Integer getLowermanReward() {
		return this.lowermanReward;
	}

	public void setLowermanReward(Integer lowermanReward) {
		if (lowermanReward == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[徒弟给的奖励]lowermanReward不可以为空");
		}	
		this.lowermanReward = lowermanReward;
	}
	
	public String getDesc() {
		return this.desc;
	}

	public void setDesc(String desc) {
		if (StringUtils.isEmpty(desc)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[描述]desc不可以为空");
		}
		if (desc != null) {
			this.desc = desc.trim();
		}else{
			this.desc = desc;
		}
	}
	

	@Override
	public String toString() {
		return "OvermanTemplateVO[level=" + level + ",overmanReward=" + overmanReward + ",lowermanReward=" + lowermanReward + ",desc=" + desc + ",]";

	}
}