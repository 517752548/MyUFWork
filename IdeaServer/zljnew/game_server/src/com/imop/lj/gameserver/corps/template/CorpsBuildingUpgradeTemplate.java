package com.imop.lj.gameserver.corps.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.corps.CorpsDef;

@ExcelRowBinding
public class CorpsBuildingUpgradeTemplate extends CorpsBuildingUpgradeTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		//建筑类型
		if(CorpsDef.BuildType.valueOf(this.buildType) == null){
			throw new TemplateConfigException(sheetName, this.buildType, "建筑类型不存在!");
		}
		//建筑等级
		if(this.corpsBldgLevel > Globals.getGameConstants().getCorpsLevelLimit()){
			throw new TemplateConfigException(sheetName, this.corpsBldgLevel, "建筑等级超过帮派最大等级!");
		}
	}

}
