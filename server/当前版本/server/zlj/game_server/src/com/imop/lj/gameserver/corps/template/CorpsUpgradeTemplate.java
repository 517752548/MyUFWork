package com.imop.lj.gameserver.corps.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.common.Globals;


/**
 * 帮派升级模版
 * 
 */
@ExcelRowBinding
public class CorpsUpgradeTemplate extends CorpsUpgradeTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		//帮派等级
		if(this.corpsLevel > Globals.getGameConstants().getCorpsLevelLimit()){
			throw new TemplateConfigException(sheetName, this.corpsLevel, "帮派等级超过最大限制");
		}
		//建筑等级不能超过帮派等级
		if(this.corpsBldgLevel > corpsLevel){
			throw new TemplateConfigException(sheetName, this.corpsBldgLevel, "帮派建筑等级不能超过帮派等级");
		}
		
	}

}
