package com.imop.lj.gameserver.common.event;

import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.event.Event;
import com.imop.lj.gameserver.human.event.EventType;
import com.imop.lj.gameserver.item.template.ItemTemplate;

public class MainBagRemoveItemEvent extends Event<Human>{

	/** 玩家角色 */
	private final Human human;
	/** 道具模板 */
	private ItemTemplate tmpl;
	/** 道具数量 */
	private final int tempCount;
	
	private final static EventType eventType = EventType.MainBagRemoveItem;

	public MainBagRemoveItemEvent(Human human, ItemTemplate tmpl, int count) {
		super(human, eventType);
		this.human = human;
		this.tmpl = tmpl;
		this.tempCount = count;
	}

	@Override
	public Human getInfo() {
		return human;
	}

	public ItemTemplate getTmpl() {
		return tmpl;
	}

	public int getTempCount() {
		return tempCount;
	}

}
