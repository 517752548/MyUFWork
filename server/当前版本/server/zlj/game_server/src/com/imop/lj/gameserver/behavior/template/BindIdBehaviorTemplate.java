package com.imop.lj.gameserver.behavior.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.behavior.bindid.BindIdBehaviorManager;
import com.imop.lj.gameserver.behavior.bindid.BindIdBehaviorTypeEnum;

/**
 * 绑定Id的行为配置模板
 * 
 */
@ExcelRowBinding
public class BindIdBehaviorTemplate extends BindIdBehaviorTemplateVO {
	@Override
	public void check() throws TemplateConfigException {
		if (BindIdBehaviorTypeEnum.valueOf(this.getId()) == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(), "bindid behavior=" + this.getId() + "不存在");
		}
		// 周期最大为30天
		if (periodDay > BindIdBehaviorManager.MAX_REFRESH_DAY) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(), "periodDay不能超过30天！");
		}
	}
}