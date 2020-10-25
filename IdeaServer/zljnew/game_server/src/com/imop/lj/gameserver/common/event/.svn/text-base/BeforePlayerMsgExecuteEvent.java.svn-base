package com.imop.lj.gameserver.common.event;

import com.imop.lj.core.msg.IMessage;
import com.imop.lj.gameserver.human.event.Event;
import com.imop.lj.gameserver.human.event.EventType;
import com.imop.lj.gameserver.player.Player;

public class BeforePlayerMsgExecuteEvent extends Event<Player>{

	/** 玩家角色 */
	private final Player player;
	private IMessage msg;
	
	private final static EventType eventType = EventType.BeforcePlayerMsgExcute;

	public BeforePlayerMsgExecuteEvent(Player player, IMessage msg) {
		super(player, eventType);
		this.player = player;
		this.msg = msg;
	}

	@Override
	public Player getInfo() {
		return player;
	}

	public IMessage getMsg() {
		return msg;
	}

}
