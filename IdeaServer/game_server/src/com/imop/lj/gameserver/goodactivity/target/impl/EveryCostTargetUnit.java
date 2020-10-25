package com.imop.lj.gameserver.goodactivity.target.impl;

import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.goodactivity.activity.GoodActivityDef.CostSourceEnum;
import com.imop.lj.gameserver.goodactivity.activity.impl.EveryCostActivity;
import com.imop.lj.gameserver.goodactivity.target.AbstractGoodActivityTargetUnit;
import com.imop.lj.gameserver.goodactivity.template.GoodActivityEveryCostTargetTemplate;

public class EveryCostTargetUnit extends AbstractGoodActivityTargetUnit {

	public EveryCostTargetUnit(EveryCostActivity activity, 
			GoodActivityEveryCostTargetTemplate targetTpl) {
		super(activity, targetTpl);
	}
	
	@Override
	public GoodActivityEveryCostTargetTemplate getTargetTpl() {
		return (GoodActivityEveryCostTargetTemplate) super.getTargetTpl();
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
	
	/**
	 * 获取领奖次数上限
	 * @return
	 */
	public int getMaxRewardTimes() {
		return getTargetTpl().getMaxRewardTimes();
	}
	
	@Override
	public int getShowNeedNum() {
		return getMaxRewardTimes();
	}
	
	@Override
	public int getShowNeedNumSecond() {
		return getCostNum();
	}

	/**
	 * 该类活动的getCurNumSecond显示时分子可超过分母
	 * @return
	 */
	protected boolean isCurNumSecondShowLimit() {
		return false;
	}
}
