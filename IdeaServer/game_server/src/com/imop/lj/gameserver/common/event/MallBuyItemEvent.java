package com.imop.lj.gameserver.common.event;

import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.event.Event;
import com.imop.lj.gameserver.human.event.EventType;

/**
 * @author : bing.dong E-mail: dawson119@163.com
 * @createTime : 2014年5月14日 下午2:44:35
 * @version 1.0
 */

public class MallBuyItemEvent extends Event<Human> {

	/** 玩家角色 */
	private final Human human;
	/** 当前军衔等级 */
	private int itemTempId;
	/** 购买数量 */
	private int num;

	private final static EventType eventType = EventType.MallBuyItem;

	public MallBuyItemEvent(Human human, int itemTempId, int num) {
		super(human, eventType);
		this.human = human;
		this.itemTempId = itemTempId;
		this.num = num;
	}

	@Override
	public Human getInfo() {
		return human;
	}

	public int getItemTempId() {
		return itemTempId;
	}

	public int getNum() {
		return num;
	}

}
