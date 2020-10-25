package com.imop.lj.gameserver.goodactivity.target.impl;

import com.imop.lj.gameserver.goodactivity.activity.impl.NormalTotalChargeActivity;
import com.imop.lj.gameserver.goodactivity.target.AbstractGoodActivityTargetUnit;
import com.imop.lj.gameserver.goodactivity.template.GoodActivityNormalTotalChargeTargetTemplate;

public class NormalTotalChargeTargetUnit extends AbstractGoodActivityTargetUnit {

	public NormalTotalChargeTargetUnit(NormalTotalChargeActivity activity, 
			GoodActivityNormalTotalChargeTargetTemplate targetTpl) {
		super(activity, targetTpl);
	}
	
	@Override
	public GoodActivityNormalTotalChargeTargetTemplate getTargetTpl() {
		return (GoodActivityNormalTotalChargeTargetTemplate) super.getTargetTpl();
	}
	
	/**
	 * 获取目标需要的充值数量
	 * @return
	 */
	public int getChargeNum() {
		return getTargetTpl().getChargeNum();
	}
	
	@Override
	public int getShowNeedNum() {
		return getChargeNum();
	}

}
