package com.imop.lj.gameserver.common.event;

import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.event.Event;
import com.imop.lj.gameserver.human.event.EventType;

public class NotEnoughMoneyEvent extends Event<Human>{

	/** 玩家角色 */
	private final Human human;
	/** 货币类型 */
	private Currency currency;
	/** 货币数量 */
	private long amount;
	
	private final static EventType eventType = EventType.NotEnoughMoney;

	public NotEnoughMoneyEvent(Human human, Currency currency, long amount) {
		super(human, eventType);
		this.human = human;
		this.currency = currency;
		this.amount = amount;
	}

	@Override
	public Human getInfo() {
		return human;
	}

	public Currency getCurrency() {
		return currency;
	}

	public long getAmount() {
		return amount;
	}

}
