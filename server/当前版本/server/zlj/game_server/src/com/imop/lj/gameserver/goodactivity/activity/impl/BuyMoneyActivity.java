package com.imop.lj.gameserver.goodactivity.activity.impl;

import com.imop.lj.gameserver.goodactivity.activity.AbstractGoodActivity;
import com.imop.lj.gameserver.goodactivity.persistance.GoodActivityPO;
import com.imop.lj.gameserver.goodactivity.target.impl.BuyMoneyTargetUnit;
import com.imop.lj.gameserver.goodactivity.template.GoodActivityBuyMoneyTargetTemplate;
import com.imop.lj.gameserver.goodactivity.template.GoodActivityTargetTemplate;
import com.imop.lj.gameserver.goodactivity.useractivity.AbstractUserGoodActivity;
import com.imop.lj.gameserver.goodactivity.useractivity.impl.BuyMoneyUserGoodActivity;
import com.imop.lj.gameserver.human.event.EventType;

/**
 * 招财进宝活动
 * @author yu.zhao
 *
 */
public class BuyMoneyActivity extends AbstractGoodActivity {

	public BuyMoneyActivity(GoodActivityPO goodActivityPO) {
		super(goodActivityPO);
	}
	
	@Override
	protected void buildTargetUnit(GoodActivityTargetTemplate targetTpl) {
		addTargetUnit(new BuyMoneyTargetUnit(this, (GoodActivityBuyMoneyTargetTemplate) targetTpl));
	}
	
	@Override
	public AbstractUserGoodActivity buildUserGoodActivity(long charId) {
		return new BuyMoneyUserGoodActivity(charId, this);
	}

	@Override
	public EventType getBindEventType() {
		return null;
	}

	@Override
	public boolean needAutoJoin() {
		return true;
	}
}
