package com.imop.lj.gameserver.common.event;

import com.imop.lj.core.event.IEvent;
import com.imop.lj.core.object.LifeCycle;

/**
 * 玩家的数据变更事件
 *
 *
 */
public class HumanDataChangedEvent implements IEvent<LifeCycle> {
	private final LifeCycle charObj;

	public HumanDataChangedEvent(LifeCycle charObj) {
		this.charObj = charObj;
	}

	@Override
	public LifeCycle getInfo() {
		return charObj;
	}
}