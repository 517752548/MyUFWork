package com.imop.lj.gameserver.human.event;

import com.imop.lj.core.event.IEvent;

/**
 * 事件
 * 
 */
public class Event<T> implements IEvent<T> {
	private T t;
	private EventType type;

	public Event(T t, EventType type) {
		this.t = t;
		this.type = type;
	}

	@Override
	public T getInfo() {
		return t;
	}

	public EventType getType() {
		return type;
	}
}
