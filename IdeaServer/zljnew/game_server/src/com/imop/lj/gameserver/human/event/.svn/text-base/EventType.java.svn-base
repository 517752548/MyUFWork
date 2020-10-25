package com.imop.lj.gameserver.human.event;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;

public enum EventType implements IndexedEnum {
	/** 玩家消费 */
	PlayerChargeDiamondEvent(1),
	/** 玩家完成某一任务 */
	PlayerFinishQuest(2),
	/** 玩家获得货币 */
	GiveMoney(3),
	/** 玩家获得武将 */
	GetPet(4),
	/** 玩家获得主将技能 */
	GetSkill(5),
	/** PVE战斗结束 */
	PveFightEnd(6),
	/** 主背包获得道具 */
	MainBagGetItem(7),
	/** 主将升级 */
	LeaderLevelUp(8),
	/** 货币不足 */
	NotEnoughMoney(9),
	/** 接受任务 */
	AcceptQuest(10),
	/** PVE战斗成功完成，且在发战报之前 */
	PveBeforeFightEnd(11),
	/** 战胜某关卡 */
	PassMission(12),
	/** 开启新功能 */
	OpenFunc(13),
	/** 登录天数增加 */
	LoginDaysAdd(14),
	/**VIP 状态变化，包含升级，激活，体验，未开启*/
	VipStateChange(15),	
	/** 玩家数据发生变化，需要通知场景中的其他人 */
	PlayerSceneDataChange(16),
	/** 世界boss战结束事件，与玩家无关 */
	WorldBossWarEnd(17),
	/** 军团战结束事件，与玩家无关 */
	CorpsWarEnd(18),
	/** 坐骑升级 */
	HorseLevelUp(19),
	/** 竞技场刷新，与玩家无关 */
	ArenaRefresh(20),
	/** 战力变化 */
	FightPowerChange(21),
	/** 斗地主从苦工身上获取经验 */
	LandlordGetExp(22),
	/** 军衔升级 */
	ArmyTitleLevelUp(23),
	/** 商城购买 */
	MallBuyItem(24),
	/** 消耗货币 */
	CostMoney(25),
	/** timeFuncChange事件 */
	TimeFuncChange(26),
	/** 玩家消息执行前的事件 */
	BeforcePlayerMsgExcute(27),
	/**套装改变*/
	SuitChange(28),
	
	/** 战斗逃跑*/
	BattleEscape(30),
	/** 队伍队员变化，加队、退队、暂离、队伍解散 */
	TeamMemberChange(31),
	/** 玩家军团变更（加入或退出） */
	PlayerCorpsChanged(32),
	/** 主背包删除道具 */
	MainBagRemoveItem(33),
	
	/** 精彩活动完成目标 */
	GoodActivityFinishTarget(34),
	
	;

	private EventType(int index) {
		this.index = index;
	}

	public final int index;

	@Override
	public int getIndex() {
		return index;
	}

	private static final List<EventType> values = IndexedEnumUtil.toIndexes(EventType.values());

	public static EventType valueOf(int index) {
		return EnumUtil.valueOf(values, index);
	}
}
