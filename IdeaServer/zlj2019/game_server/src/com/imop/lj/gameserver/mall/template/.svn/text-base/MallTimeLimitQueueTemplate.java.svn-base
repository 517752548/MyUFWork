package com.imop.lj.gameserver.mall.template;

import java.util.Map;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

/**
 * 商城限时队列配置
 * 
 * @author xiaowei.liu
 * 
 */
@ExcelRowBinding
public class MallTimeLimitQueueTemplate extends MallTimeLimitQueueTemplateVO {
	/** 本队列总的持续时间 */
	private long totalPeriodTime;
	private Map<Integer, MallTimeLimitItemTemplate> itemMap;

	@Override
	public void check() throws TemplateConfigException {

	}

	public long getTotalPeriodTime() {
		return totalPeriodTime;
	}

	public void setTotalPeriodTime(long totalPeriodTime) {
		this.totalPeriodTime = totalPeriodTime;
	}

	public Map<Integer, MallTimeLimitItemTemplate> getItemMap() {
		return itemMap;
	}

	public void setItemMap(Map<Integer, MallTimeLimitItemTemplate> itemMap) {
		this.itemMap = itemMap;
	}

}
