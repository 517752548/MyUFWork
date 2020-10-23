package com.imop.lj.gameserver.vip.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.vip.VipDef.VipFuncTypeEnum;

@ExcelRowBinding
public class VipConfigTemplate extends VipConfigTemplateVO {
	
	private VipFuncTypeEnum vipFuncType;
	
	@Override
	public void check() throws TemplateConfigException {
		// 功能类型是否正确
		vipFuncType = VipFuncTypeEnum.valueOf(this.id);
		if (vipFuncType == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(), "功能类型 typeId=" + this.id + " 不存在");
		}
		
	}

	
	public VipFuncTypeEnum getVipFuncTypeEnum() {
		return vipFuncType;
	}

}
