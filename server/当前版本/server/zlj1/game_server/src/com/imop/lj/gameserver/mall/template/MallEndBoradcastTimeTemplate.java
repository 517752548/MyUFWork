package com.imop.lj.gameserver.mall.template;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.common.Globals;

@ExcelRowBinding
public class MallEndBoradcastTimeTemplate extends
		MallEndBoradcastTimeTemplateVO {
	protected String timeStr;
	@Override
	public void check() throws TemplateConfigException {
		if(this.endTime > TimeUtils.HOUR){
			timeStr = (this.endTime / TimeUtils.HOUR) + Globals.getLangService().readSysLang(LangConstants.HOUR_TIME_STR);
		}else{
			timeStr = (this.endTime / TimeUtils.MIN) + Globals.getLangService().readSysLang(LangConstants.MINUTE_TIME_STR);
		}
	}
	public String getTimeStr() {
		return timeStr;
	}
}
