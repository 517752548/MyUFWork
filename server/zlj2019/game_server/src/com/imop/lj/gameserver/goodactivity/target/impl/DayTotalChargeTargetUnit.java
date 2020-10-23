package com.imop.lj.gameserver.goodactivity.target.impl;

import com.imop.lj.gameserver.goodactivity.activity.impl.DayTotalChargeActivity;
import com.imop.lj.gameserver.goodactivity.target.AbstractGoodActivityTargetUnit;
import com.imop.lj.gameserver.goodactivity.template.GoodActivityDayTotalChargeTargetTemplate;

public class DayTotalChargeTargetUnit extends AbstractGoodActivityTargetUnit {

	public DayTotalChargeTargetUnit(DayTotalChargeActivity activity, 
			GoodActivityDayTotalChargeTargetTemplate targetTpl) {
		super(activity, targetTpl);
	}
	
	@Override
	public GoodActivityDayTotalChargeTargetTemplate getTargetTpl() {
		return (GoodActivityDayTotalChargeTargetTemplate) super.getTargetTpl();
	}
	
	/**
	 * 获取目标需要的充值数量
	 * @return
	 */
	public int getChargeNum() {
		return getTargetTpl().getChargeNum();
	}
	
	/**
	 * 获取目标需要的充值天数
	 * @return
	 */
	public int getDayNum() {
		return getTargetTpl().getDayNum();
	}
	
	@Override
	public int getShowNeedNum() {
		return getDayNum();
	}

	@Override
	public int getShowNeedNumSecond() {
		return getChargeNum();
	}
}
