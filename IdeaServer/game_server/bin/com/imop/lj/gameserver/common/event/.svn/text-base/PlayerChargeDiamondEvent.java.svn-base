package com.imop.lj.gameserver.common.event;

import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.event.Event;
import com.imop.lj.gameserver.human.event.EventType;

public class PlayerChargeDiamondEvent extends Event<Human>{

	/** 玩家角色 */
	private final Human human;
	/** 充值钻石数额 */
	private int chargeDiamond;
	
	private boolean isGM;

	private final static EventType eventType = EventType.PlayerChargeDiamondEvent;
	
	public PlayerChargeDiamondEvent(Human human, int chargeDiamond, boolean isGM) {
		super(human, eventType);
		this.human = human;
		this.chargeDiamond = chargeDiamond;
		this.isGM = isGM;
	}

	@Override
	public Human getInfo() {
		return human;
	}

	public int getChargeDiamond() {
		return chargeDiamond;
	}

	public void setChargeDiamond(int chargeDiamond) {
		this.chargeDiamond = chargeDiamond;
	}

	public boolean isGM() {
		return isGM;
	}

}
