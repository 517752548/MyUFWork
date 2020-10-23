package com.imop.lj.gameserver.goodactivity.target.impl;

import com.imop.lj.gameserver.goodactivity.activity.impl.SevenDayLoginActivity;
import com.imop.lj.gameserver.goodactivity.target.AbstractGoodActivityTargetUnit;
import com.imop.lj.gameserver.goodactivity.template.GoodActivitySevenDayLoginTargetTemplate;

public class SevenDayLoginTargetUnit extends AbstractGoodActivityTargetUnit {

	public SevenDayLoginTargetUnit(SevenDayLoginActivity activity,
								   GoodActivitySevenDayLoginTargetTemplate targetTpl) {
		super(activity, targetTpl);
	}
	
	@Override
	public GoodActivitySevenDayLoginTargetTemplate getTargetTpl() {
		return (GoodActivitySevenDayLoginTargetTemplate) super.getTargetTpl();
	}
	
	/**
	 * 获取目标需要的等级
	 * @return
	 */
	public int getNeedDay() {
		return getTargetTpl().getNeedDay();
	}

}
