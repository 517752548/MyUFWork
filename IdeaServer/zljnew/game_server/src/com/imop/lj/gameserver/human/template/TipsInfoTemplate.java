package com.imop.lj.gameserver.human.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.common.model.human.TipsInfoDef.TipsInfoType;
import com.imop.lj.core.annotation.ExcelRowBinding;



/**
 * tips信息模板
 *
 * @author fanghua.cui
 *
 */
@ExcelRowBinding
public class TipsInfoTemplate extends TipsInfoTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		TipsInfoType tipsInfoType = TipsInfoType.valueOf(this.id);
		if(tipsInfoType == null){
			throw new TemplateConfigException(this.getSheetName(), getId(), String.format("tips类型%d不存在", this.getId()));
		}
	}

}
