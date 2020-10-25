package com.imop.lj.gameserver.common.event;

import com.imop.lj.gameserver.human.event.Event;
import com.imop.lj.gameserver.human.event.EventType;

public class GoodActivityFinishTargetEvent extends Event<Object> {

	private final Object obj;
	
	private final static EventType eventType = EventType.GoodActivityFinishTarget;
	
	private long roleId;
	private long goodActivityId;
	private int targetId;

	public GoodActivityFinishTargetEvent(Object obj, long roleId, long goodActivityId, int targetId) {
		super(obj, eventType);
		this.obj = obj;
		this.roleId = roleId;
		this.goodActivityId = goodActivityId;
		this.targetId = targetId;
	}
	
	@Override
	public Object getInfo() {
		return obj;
	}

	public long getRoleId() {
		return roleId;
	}

	public int getTargetId() {
		return targetId;
	}

	public long getGoodActivityId() {
		return goodActivityId;
	}

}
