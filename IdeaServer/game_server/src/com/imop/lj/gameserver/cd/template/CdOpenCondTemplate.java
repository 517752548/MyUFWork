package com.imop.lj.gameserver.cd.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

/**
 * 冷却队列开启条件
 *
 * @author haijiang.jin
 *
 */
@ExcelRowBinding
public class CdOpenCondTemplate extends CdOpenCondTemplateVO {
	@Override
	public void check() throws TemplateConfigException {
//		if (VipLevel.valueOf(needVipLevel) == null) {
//			throw new TemplateConfigException(this.sheetName, getId(), String.format("vip等级非法id:%d非法", needVipLevel));
//		}
	}
}
