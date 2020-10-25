package com.imop.lj.gameserver.task;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;

public interface TaskDef {
	
	public static final String TYPE_KEY = "type";
	public static final String INST_KEY = "instKey";
	public static final String GOT_NUM_KEY = "gotNum";
	
	public static enum QuestType implements IndexedEnum {
		/** 普通任务（主线） */
		COMMON(1),
		/**支线*/
		BRANCH(2),

		/** 酒馆任务 */
		PUB(3),
		/** 队伍任务 */
		TEAM(4),
		
		/** 除暴安良任务*/
		THESWEENEY(5),
		
		/** 藏宝图任务*/
		TREASUREMAP(6),
		
		/** 护送粮草任务 */
		FORAGE(7),
		
		/**帮派任务*/
		CORPSTASK(8),
		
		/** 限时杀怪任务*/
		TIME_LIMIT_MONSTER(9),
		
		/** 限时挑战Npc任务*/
		TIME_LIMIT_NPC(10),
		
		/** 七日目标任务 */
		DAY7_TARGET(11),
		
		/** 围剿魔族普通任务 */
		SIEGE_DEMON_NOMAL(12),
		
		/** 围剿魔族困难任务 */
		SIEGE_DEMON_HARD(13),
		
		/** 跑环任务 */
		RING(14),
		
		;

		private final int index;

		private QuestType(int index) {
			this.index = index;
		}

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<QuestType> indexes = IndexedEnum.IndexedEnumUtil
				.toIndexes(QuestType.values());

		/**
		 * 根据指定的索引获取枚举的定义
		 * 
		 * @param index
		 * @return
		 */
		public static QuestType indexOf(final int index) {
			return EnumUtil.valueOf(indexes, index);
		}

	}
	
	public static enum TaskStatus implements IndexedEnum {
		/** 初始默认状态 */
		INIT(0, 0),
		/** 已经接受任务，但没有达到完成条件或没有完成任务 */
		ACCEPTED(1, 2),
		/** 可完成状态，但未领取奖励 */
		CAN_FINISH(2, 1),
		/** 已完成，领取了奖励 */
		FINISHED(3, 5),
		
		/** 可接，但未接 */
		CAN_ACCEPT(4, 3),
		/** 可见，但不可接 */
		CAN_NOT_ACCEPT(5, 4),
		
		/** 已放弃 */
		GIVEUP(6, 6),
		
		/** 无效任务 */
		INVALID(9, 9),
		;
		

		private final int index;
		
		/** 前台用的状态，排序用，不重复且按照顺序即可 */
		private final int order;

		private TaskStatus(int index, int order) {
			this.index = index;
			this.order = order;
		}

		@Override
		public int getIndex() {
			return index;
		}
		
		public int getOrder() {
			return order;
		}

		private static final List<TaskStatus> indexes = IndexedEnum.IndexedEnumUtil
				.toIndexes(TaskStatus.values());

		/**
		 * 根据指定的索引获取枚举的定义
		 * 
		 * @param index
		 * @return
		 */
		public static TaskStatus indexOf(final int index) {
			return EnumUtil.valueOf(indexes, index);
		}
	}
	
	/**
	 * 任务目标类型
	 */
	public enum DestType implements IndexedEnum {
		/** 无 */
		NULL(0),
		/**记数类任务*/
		NUM_RECORD(1),
		/** 主将等级达到A级 */
		LEADER_LEVEL_A(2),
		/** 拥有A道具B个，完成任务时扣除，道具删除时任务数据会回退 */
		COLLECTION_ITEM(3),
		
		/** 心法达到A级 */
		LEADER_MIND_LEVEL_A(4),
		/** 本职业心法所有主动技能达到X级别 */
		LEADER_MIND_A_LEVEL_X(5),
		/** 角色已镶嵌X颗Y颜色Z级仙符 */
		SKILL_EFFECT_EMBED_NUM_X_COLOR_Y_LEVEL_Z(6),
		/** 已穿戴X件Y颜色Z阶数装备 */
		EQUIP_NUM_X_COLOR_Y_GRADE_Z(7),
		/** 将X个装备部位升级到Y星 */
		EQUIPSTAR_NUM_X_STAR_Y(8),
		/** XXX 镶嵌X颗Y级宝石（只统计穿在身上的） */
		EQUIP_GEM_NUM_X_LEVEL_Y(9),
		
		/** 本职业心法对应的主动技能，任意一个达到x级 */
		LEADER_MIND_SKILL_LEVEL_X(10),
		
		;
		
		
		private int type;
		private final int index;

		DestType(int type) {
			this.type = type;
			this.index = type;
		}

		public int getType() {
			return this.type;
		}

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<DestType> values = IndexedEnumUtil.toIndexes(DestType
				.values());

		public static DestType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
	
	/**
	 * 计数类型
	 * 
	 */
	public static enum NumRecordType implements IndexedEnum {
		/** 无条件 */
		NONE(0),
		/** 战胜跑动遇到的怪物 */
		MAP_ENEMY(1),
		/** 战胜指定的NPC */
		MAP_NPC_WIN(2),
		/** 收集指定的任务物品，打怪单独掉落，完成任务时扣除 ，这个任务条件废弃，改用 DestType.COLLECTION_ITEM */
		MAP_COLLECTION(3),
		/** 在地图指定区域使用物品 */
		MAP_USE_ITEM(4),
		/** 竞技场挑战 */
		ARENA_ATTACK(5),
		/** 战胜任意怪,包括NPC*/
		WIN_ANY_ENEMY(6),
		/** 完成酒馆任务次数*/
		FINISH_PUB(7),
		/** 通天塔挂机战斗次数,不包括NPC*/
		MAP_TOWER_ENEMY(8),
		/** 参加科举次数*/
		ENTER_EXAM(9),
		/** 参加绿野仙踪次数*/
		ENTER_WIZARDRAID(10),
		/** 完成藏宝图任务次数*/
		FINISH_TREASURE_MAP(11),
		/** 参加运粮任务次数*/
		ENTER_FORAGE(12),
		/** 完成除暴安良任务次数*/
		FINISH_THESWEENEY(13),
		/** 加入帮派或创建帮派*/
		IN_CORPS(14),
		/** 使用藏宝图*/
		USE_TREASURE_MAP(15),
		/** 购买竞技场商店道具*/
		BUY_ITEM_IN_ARENA_SHOP(16),
		/** 完成升星*/
		FINISH_UPGRADE_STAR(17),
		/** 洗宠物天赋技能*/
		RESET_PET_TALENT_SKILL(18),
		/** 升级人物技能*/
		UPGRADE_HUMAN_SUB_SKILL(19),
		/** 打造装备*/
		CRAFT_EQUIP(20),
		/** 人物加点*/
		HUMAN_ADD_POINT(21),
		/** 宠物加点*/
		PET_ADD_POINT(22),
		/** 升级任意心法 */
		MIND_LEVEL_UP(23),
		;
		

		private final int index;

		private NumRecordType(int index) {
			this.index = index;
		}

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<NumRecordType> indexes = IndexedEnum.IndexedEnumUtil
				.toIndexes(NumRecordType.values());

		/**
		 * 根据指定的索引获取枚举的定义
		 * 
		 * @param index
		 * @return
		 */
		public static NumRecordType indexOf(final int index) {
			return EnumUtil.valueOf(indexes, index);
		}
	}
}
