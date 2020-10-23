package com.imop.lj.gameserver.goodactivity.target.impl;

import com.imop.lj.gameserver.goodactivity.activity.impl.LevelUpActivity;
import com.imop.lj.gameserver.goodactivity.target.AbstractGoodActivityTargetUnit;
import com.imop.lj.gameserver.goodactivity.template.GoodActivityLevelUpTargetTemplate;

public class LevelUpTargetUnit extends AbstractGoodActivityTargetUnit {

	public LevelUpTargetUnit(LevelUpActivity activity, 
			GoodActivityLevelUpTargetTemplate targetTpl) {
		super(activity, targetTpl);
	}
	
	@Override
	public GoodActivityLevelUpTargetTemplate getTargetTpl() {
		return (GoodActivityLevelUpTargetTemplate) super.getTargetTpl();
	}
	
	/**
	 * 获取目标需要的等级
	 * @return
	 */
	public int getNeedLevel() {
		return getTargetTpl().getNeedLevel();
	}

}
