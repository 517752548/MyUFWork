package com.imop.lj.gameserver.cd.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.cd.CdTypeEnum;

/**
 * 冷却时间模版
 *
 * @author haijiang.jin
 *
 */
@ExcelRowBinding
public class CdTemplate extends CdTemplateVO {
	@Override
	public void check() throws TemplateConfigException {
		// 验证冷却队列类型
		CdTypeEnum cdType = CdTypeEnum.valueOf(this.getId());
		if(cdType == null){
			throw new TemplateConfigException(this.getSheetName(), getId(), String.format("cd类型%d不存在", this.getId()));
		}

		if (this.getCdQueueDefault() > this.getCdQueueMax()) {
			// 如果默认开启队列数量大于队列总数
			throw new TemplateConfigException("冷却队列", this.getId(),
				String.format("CdQueueDefault > CdQueueMax"));
		}

	}
}
