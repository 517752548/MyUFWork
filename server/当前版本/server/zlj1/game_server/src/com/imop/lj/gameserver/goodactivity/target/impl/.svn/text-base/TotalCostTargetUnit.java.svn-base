package com.imop.lj.gameserver.goodactivity.target.impl;

import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.goodactivity.activity.GoodActivityDef.CostSourceEnum;
import com.imop.lj.gameserver.goodactivity.activity.impl.TotalCostActivity;
import com.imop.lj.gameserver.goodactivity.target.AbstractGoodActivityTargetUnit;
import com.imop.lj.gameserver.goodactivity.template.GoodActivityTotalCostTargetTemplate;

public class TotalCostTargetUnit extends AbstractGoodActivityTargetUnit {

	public TotalCostTargetUnit(TotalCostActivity activity, 
			GoodActivityTotalCostTargetTemplate targetTpl) {
		super(activity, targetTpl);
	}
	
	@Override
	public GoodActivityTotalCostTargetTemplate getTargetTpl() {
		return (GoodActivityTotalCostTargetTemplate) super.getTargetTpl();
	}
	
	/**
	 * 获取目标需要的消耗数量
	 * @return
	 */
	public int getCostNum() {
		return getTargetTpl().getCostNum();
	}
	
	/**
	 * 获取货币类型
	 * @return
	 */
	public Currency getCurrency() {
		return getTargetTpl().getCurrency();
	}
	
	/**
	 * 获取消耗来源
	 * @return
	 */
	public CostSourceEnum getCostSource() {
		return getTargetTpl().getCostSource();
	}
	
	@Override
	public int getShowNeedNum() {
		return getCostNum();
	}

}
