package com.imop.lj.gameserver.common.event;

import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.event.Event;
import com.imop.lj.gameserver.human.event.EventType;

public class OpenFuncEvent extends Event<Human>{

	/** 玩家角色 */
	private final Human human;
	/** 开启的功能 */
	private FuncTypeEnum funcType;
	
	private final static EventType eventType = EventType.OpenFunc;

	public OpenFuncEvent(Human human, FuncTypeEnum funcType) {
		super(human, eventType);
		this.human = human;
		this.funcType = funcType;
	}

	@Override
	public Human getInfo() {
		return human;
	}

	public FuncTypeEnum getFuncType() {
		return funcType;
	}

}
