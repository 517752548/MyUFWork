package com.imop.lj.gameserver.goodactivity.target.impl;

import com.imop.lj.gameserver.goodactivity.activity.impl.VipLevelActivity;
import com.imop.lj.gameserver.goodactivity.target.AbstractGoodActivityTargetUnit;
import com.imop.lj.gameserver.goodactivity.template.GoodActivityVipLevelTargetTemplate;

public class VipLevelTargetUnit extends AbstractGoodActivityTargetUnit {

	public VipLevelTargetUnit(VipLevelActivity activity, 
			GoodActivityVipLevelTargetTemplate targetTpl) {
		super(activity, targetTpl);
	}
	
	@Override
	public GoodActivityVipLevelTargetTemplate getTargetTpl() {
		return (GoodActivityVipLevelTargetTemplate) super.getTargetTpl();
	}
	
	/**
	 * 获取目标需要的vip等级
	 * @return
	 */
	public int getNeedVipLevel() {
		return getTargetTpl().getNeedVipLevel();
	}

}
