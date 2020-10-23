package com.imop.lj.gameserver.foragetask.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.currency.Currency;


/**
 * 奖励物品
 */
@ExcelRowBinding
public class ForageTaskRewardTemplate extends ForageTaskRewardTemplateVO {
	
	@Override
	public void check() throws TemplateConfigException {
		// 判断基础奖励类型1和类型2
		if(Currency.valueOf(this.getRewardType1()) == null || 
				Currency.valueOf(this.getRewardType2()) == null ){
			throw new TemplateConfigException(this.sheetName, this.id, "货币类型错误！id=" + this.id);
		}
		
	}

	
}
