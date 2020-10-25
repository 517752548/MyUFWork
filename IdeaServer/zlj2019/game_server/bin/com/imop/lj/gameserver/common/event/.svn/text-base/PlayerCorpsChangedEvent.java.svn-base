package com.imop.lj.gameserver.common.event;

import com.imop.lj.gameserver.corps.model.CorpsMemberChangeInfo;
import com.imop.lj.gameserver.human.event.Event;
import com.imop.lj.gameserver.human.event.EventType;

public class PlayerCorpsChangedEvent extends Event<CorpsMemberChangeInfo>{

	private final static EventType eventType = EventType.PlayerCorpsChanged;

	
	public PlayerCorpsChangedEvent(CorpsMemberChangeInfo info) {
		super(info, eventType);
	}

}
