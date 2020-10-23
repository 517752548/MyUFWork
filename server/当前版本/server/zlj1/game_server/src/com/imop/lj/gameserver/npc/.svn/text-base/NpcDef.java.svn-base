package com.imop.lj.gameserver.npc;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;

public class NpcDef {
	
	/**
	 * npc类型
	 */
	public static enum NpcType implements IndexedEnum {
		/** 普通 */
		NORMAL(1),
		/** 传送点 */
		TRANSPORT(2),
		/** 战斗目标，有指定任务才能打 */
		FIGHT_TARGET(3),
		/** 副本战斗NPC，不受任务限制，可随意打 */
		RAID_FIGHT_TARGET(4),
		/** 显示特效，服务器端无任何功能 */
		SHOW_EFFECT(5),
		;

		private NpcType(int index) {
			this.index = index;
		}

		public final int index;

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<NpcType> values = IndexedEnumUtil
				.toIndexes(NpcType.values());

		public static NpcType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
	
	/**
	 * 活动战斗npc类型
	 */
	public static enum ActivityNpcType implements IndexedEnum {
		/** 无活动*/
		NULL(0),
		/** 封印妖魔*/
		SEAL_DEMON(1),
		/** 封印魔王 */
		SEAL_DEMON_KING(2),
		/** 混世魔王*/
		DEVIL_INCARNATE(3),
		;
		
		private ActivityNpcType(int index) {
			this.index = index;
		}
		
		public final int index;
		
		@Override
		public int getIndex() {
			return index;
		}
		
		private static final List<ActivityNpcType> values = IndexedEnumUtil
				.toIndexes(ActivityNpcType.values());
		
		public static ActivityNpcType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
	
	
}
