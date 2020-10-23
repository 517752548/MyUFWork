package com.imop.lj.gameserver.human;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;

public enum HumanPropAttr implements IndexedEnum {
	/** 行为 */
	BEHAVIOR(1) ,
	/** 消费提示 */
	CONSUME_CONFIRM(2),
	/** 绑定Id的行为 */
	BINDID_BEHAVIOR(3),
	/** 开启的功能 */
	FUNC(4),
	/**在线礼包 */
	ONLINE_GIFT(5),
	/**商城*/
	MALL(6),
	/** 聊天 */
	CHAT(7),

	/** 酒馆任务 */
	PUB_TASK(8),
	
	/** 采矿 */
	MINE(9),

	/** 护送粮草 */
	FORAGE(10),
	/** 新手引导 */
	GUIDE(11), 
	/** 神秘商城*/
	MYSTERY_SHOP(12),
	/** 通天塔*/
	TOWER(13),
	/** 限时活动*/
	TIME_LIMIT(14),
	/** 帮派修炼*/
	CORPS_CULTIVATE(15),
	/** 帮派辅助*/
	CORPS_ASSIST(16),
	/** 简单剧情副本*/
	EASY_PLOT_DUNGEON(17),
	/** 精英剧情副本*/
	HARD_PLOT_DUNGEON(18),
	/** 战斗相关数据，加速等 */
	BATTLE(19),
	
	;

	private HumanPropAttr(int index) {
		this.index = index;
	}

	public final int index;

	@Override
	public int getIndex() {
		return index;
	}

	public void resolve(JsonPropDataHolder jsonPropDataHolder,String entryString){
		jsonPropDataHolder.loadJsonProp(entryString);
	}

	@Override
	public String toString() {
		return String.valueOf(this.index);
	}

	private static final List<HumanPropAttr> values = IndexedEnumUtil.toIndexes(HumanPropAttr.values());

	public static HumanPropAttr valueOf(int index) {
		return EnumUtil.valueOf(values, index);
	}

}
