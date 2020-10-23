package com.imop.lj.gameserver.common.listener;

import com.imop.lj.core.event.IEventListener;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.event.NotEnoughMoneyEvent;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.human.Human;

public class NotEnoughMoneyListener implements IEventListener<NotEnoughMoneyEvent> {

	@Override
	public void fireEvent(NotEnoughMoneyEvent event) {
		Human human = event.getInfo();
		Currency currency = event.getCurrency();
		long amount = event.getAmount();
//		// TODO
//		switch (currency) {
//		case GOLD:
//			// 小贴士
//			Globals.getPopTipsService().onNotEnoughGold(human);
//			break;
//		case POWER:
//			// 小贴士
//			Globals.getPopTipsService().onNotEnoughPower(human);
//			break;
//		default:
//			break;
//		}
	}
}
