package com.imop.lj.gameserver.humanskill.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;
import com.imop.lj.core.util.StringUtils;

/**
 * 人物心法
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class HumanMainSkillTemplateVO extends TemplateObject {

	/** 职业ID */
	@ExcelCellBinding(offset = 1)
	protected int jobId;

	/** 名称 */
	@ExcelCellBinding(offset = 2)
	protected String name;

	/** 心法类型描述 */
	@ExcelCellBinding(offset = 3)
	protected String mainSkillTypeDetail;

	/** 心法描述 */
	@ExcelCellBinding(offset = 4)
	protected String mainSkillDetail;


	public int getJobId() {
		return this.jobId;
	}

	public void setJobId(int jobId) {
		if (jobId == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[职业ID]jobId不可以为0");
		}
		if (jobId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[职业ID]jobId的值不得小于1");
		}
		this.jobId = jobId;
	}
	
	public String getName() {
		return this.name;
	}

	public void setName(String name) {
		if (StringUtils.isEmpty(name)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[名称]name不可以为空");
		}
		if (name != null) {
			this.name = name.trim();
		}else{
			this.name = name;
		}
	}
	
	public String getMainSkillTypeDetail() {
		return this.mainSkillTypeDetail;
	}

	public void setMainSkillTypeDetail(String mainSkillTypeDetail) {
		if (StringUtils.isEmpty(mainSkillTypeDetail)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[心法类型描述]mainSkillTypeDetail不可以为空");
		}
		if (mainSkillTypeDetail != null) {
			this.mainSkillTypeDetail = mainSkillTypeDetail.trim();
		}else{
			this.mainSkillTypeDetail = mainSkillTypeDetail;
		}
	}
	
	public String getMainSkillDetail() {
		return this.mainSkillDetail;
	}

	public void setMainSkillDetail(String mainSkillDetail) {
		if (StringUtils.isEmpty(mainSkillDetail)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[心法描述]mainSkillDetail不可以为空");
		}
		if (mainSkillDetail != null) {
			this.mainSkillDetail = mainSkillDetail.trim();
		}else{
			this.mainSkillDetail = mainSkillDetail;
		}
	}
	

	@Override
	public String toString() {
		return "HumanMainSkillTemplateVO[jobId=" + jobId + ",name=" + name + ",mainSkillTypeDetail=" + mainSkillTypeDetail + ",mainSkillDetail=" + mainSkillDetail + ",]";

	}
}