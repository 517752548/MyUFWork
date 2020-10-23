package com.imop.lj.gameserver.nvn;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;

public interface NvnDef {
	//定时任务时间id
	public static int NvnRankRewardTimeId = 1009;
	//匹配后冷却时间，3秒
	public static int MatchedCoolTime = 3000;
	//每个玩家log最大数量
	public static int LogQueueSize = 20;
	//排行榜显示人数
	public static int RankShowSize = 20;
	
	/**
	 * nvn队伍状态定义
	 * @author yu.zhao
	 *
	 */
	public static enum NvnTeamStatus implements IndexedEnum {
		/** 空闲中 */
		IDLE(0),
		/** 匹配中 */
		MATCHING(1),
		/** 已配对 */
		MATCHED(2),
		/** 轮空 */
		NO_MATCHED(3),
		/** 战斗中 */
		FIGHTING(4),
		;

		private final int index;

		private NvnTeamStatus(int index) {
			this.index = index;
		}

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<NvnTeamStatus> indexes = IndexedEnum.IndexedEnumUtil
				.toIndexes(NvnTeamStatus.values());

		public static NvnTeamStatus valueOf(final int index) {
			return EnumUtil.valueOf(indexes, index);
		}
	}
	
	
}
