package com.imop.lj.gameserver.common.event;

import java.util.Map;

import com.imop.lj.gameserver.human.event.Event;
import com.imop.lj.gameserver.human.event.EventType;

public class ArenaRefreshEvent extends Event<Object> {

	private final Object obj;
	
	private final static EventType eventType = EventType.ArenaRefresh;
	
	private Map<Integer, Long> rankList;

	public ArenaRefreshEvent(Object obj, Map<Integer, Long> rankList) {
		super(obj, eventType);
		this.obj = obj;
		this.rankList = rankList;
	}
	
	@Override
	public Object getInfo() {
		return obj;
	}

	public Map<Integer, Long> getRankList() {
		return rankList;
	}

	
}
