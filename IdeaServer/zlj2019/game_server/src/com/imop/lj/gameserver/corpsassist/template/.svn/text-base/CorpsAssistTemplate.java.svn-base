package com.imop.lj.gameserver.corpsassist.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.corps.CorpsDef;

@ExcelRowBinding
public class CorpsAssistTemplate extends CorpsAssistTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		//暴击配置检查
		if(CorpsDef.AssistCritType.valueOf(this.isCrit) == null){
			throw new TemplateConfigException(sheetName, this.isCrit, "暴击配置不存在!");
		}
		//产出方式检查
		if(CorpsDef.AssistGenType.valueOf(this.genType) == null){
			throw new TemplateConfigException(sheetName, this.genType, "产出配置不存在!");
		}
	}

}
