package com.imop.lj.gameserver.team;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;

public interface TeamDef {
	/** 最大离线时间，20分钟 */
	public static final int MAX_OFFLINE_TIME = 20 * 60000;
	/** 队伍最大人数 */
	public static final int MAX_TEAM_MEMBER_NUM = 5;
	
	public static enum MemberType implements IndexedEnum {
		/** 队长 */
		LEADER(1),
		/** 队员 */
		MEMBER(2),
		
		;

		private final int index;

		private MemberType(int index) {
			this.index = index;
		}

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<MemberType> indexes = IndexedEnum.IndexedEnumUtil
				.toIndexes(MemberType.values());

		public static MemberType valueOf(final int index) {
			return EnumUtil.valueOf(indexes, index);
		}
	}
	
	public static enum MemberStatus implements IndexedEnum {
		/** 队伍中 */
		NORMAL(1),
		/** 暂离 */
		AWAY(2),
		
		;

		private final int index;

		private MemberStatus(int index) {
			this.index = index;
		}

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<MemberStatus> indexes = IndexedEnum.IndexedEnumUtil
				.toIndexes(MemberStatus.values());

		public static MemberStatus valueOf(final int index) {
			return EnumUtil.valueOf(indexes, index);
		}
	}
	
	public static enum MemberAfterBattleStatus implements IndexedEnum {
		/** 归队 */
		NORMAL(1),
		/** 暂离 */
		AWAY(2),
		/** 退出队伍 */
		LEAVE(3),
		;

		private final int index;

		private MemberAfterBattleStatus(int index) {
			this.index = index;
		}

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<MemberAfterBattleStatus> indexes = IndexedEnum.IndexedEnumUtil
				.toIndexes(MemberAfterBattleStatus.values());

		public static MemberAfterBattleStatus valueOf(final int index) {
			return EnumUtil.valueOf(indexes, index);
		}
	}
	
	public static enum TeamStatus implements IndexedEnum {
		/** 普通 */
		NORMAL(1),
		/** 活动中 */
		DOING(2),
		/** 活动中，不允许暂离 */
		DOING_NO_AWAY(3),
		;

		private final int index;

		private TeamStatus(int index) {
			this.index = index;
		}

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<TeamStatus> indexes = IndexedEnum.IndexedEnumUtil
				.toIndexes(TeamStatus.values());

		public static TeamStatus valueOf(final int index) {
			return EnumUtil.valueOf(indexes, index);
		}
	}
	
	public static enum TeamInviteType implements IndexedEnum {
		/** 好友 */
		FRIEND(1),
		/** 军团 */
		CORPS(2),
		
		;

		private final int index;

		private TeamInviteType(int index) {
			this.index = index;
		}

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<TeamInviteType> indexes = IndexedEnum.IndexedEnumUtil
				.toIndexes(TeamInviteType.values());

		public static TeamInviteType valueOf(final int index) {
			return EnumUtil.valueOf(indexes, index);
		}
	}
}
