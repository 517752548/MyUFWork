package com.imop.lj.gameserver.corps.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.corpstask.CorpsBenifitTemplateVO;
import com.imop.lj.gameserver.currency.Currency;

/**
 * 帮派福利模版
 * 
 */
@ExcelRowBinding
public class CorpsBenifitTemplate extends CorpsBenifitTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		//判断上限和下限
		if(this.ContributionFoot >= this.ContributionTop){
			throw new TemplateConfigException(this.sheetName, this.id, "帮贡配置错误！ContributionFoot=" + this.ContributionFoot
					+ "ContributionTop=" + this.ContributionTop);
		}
		//货币类型
		if(Currency.valueOf(this.getCurrencyType()) == null){
			throw new TemplateConfigException(this.sheetName, this.id, "货币类型错误！id=" + this.id);
		}
	}

}
