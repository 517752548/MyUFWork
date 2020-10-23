package com.imop.lj.gameserver.offlinereward;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;
import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;

/**
 * 离线奖励类型
 * 注：如果离线奖励有对应的功能按钮，则需要在 {@link OfflineRewardService#getOfflineRewardTypeByFuncType} 方法中添加对应的类型
 * 
 * @author yu.zhao
 *
 */
public interface OfflineRewardDef {
	
	/** 奖励过期时间 7天 */
	public static final long OFFLINE_REWARD_EXPIRED_TIME = 7 * TimeUtils.DAY;

	public enum OfflineRewardType implements IndexedEnum {
		/** 无 */
		NONE(0, false, null, false),
		/** 任务奖励 */
		TASK(1, true, null, false),
		/** 战斗胜利奖励 */
		WIN_ENEMY(2, true, null, false),
		
		/** 绿野仙踪活动奖励 */
		WIZARD_RAID(3, true, null, false),
		/** 挂机奖励 */
		GUAJI(4, true, null, false),
		/** 帮派boss奖励 */
		CORPS_BOSS(5, true, null, false),
		/** 野外封印小妖奖励 */
		SEAL_DEMON(6, true, null, false),
		/** 野外封印魔王奖励 */
		SEAL_DEMON_KING(7, true, null, false),
		/** 混世魔王奖励 */
		DEVIL_INCARNATE(8, true, null, false),
		/** 限时挑战Npc奖励 */
		TIMELIMIT_NPC(9, true, null, false),
		/** 帮派竞赛分配奖励*/
		CORPS_WAR_ALLOCATE(10, true, null, false),
		/** 围剿魔族奖励 */
		SIEGE_DEMON(11, true, null, false),
		
//		/** 世界boss战-蜀国 */
//		BOSSWAR_SHU(1, false, FuncTypeEnum.BOSSWAR_SHU_REWARD, true),
//		/** 世界boss战-魏国*/
//		BOSSWAR_WEI(2, false, FuncTypeEnum.BOSSWAR_WEI_REWARD, true),
//		/** 世界boss战-吴国 */
//		BOSSWAR_WU(3, false, FuncTypeEnum.BOSSWAR_WU_REWARD, true),
//		
//		/** 斗地主奴隶干活经验 */
//		LANDLORD_SLAVER_EXP(4, true, null, false),
//		/** 南蛮入侵排名奖励 */
//		MONSTER_WAR_RANK_REWARD(5, false, FuncTypeEnum.MONSTER_WAR_RANK_REWARD, true),
//		/** 渡江完成 */
//		ESCORT_COMPLETE(6, false, FuncTypeEnum.ESCORT_COMPLETE, true),
//		/** 渡江护送完成 */
//		ESCORT_HELP_COMPLETE(7, false, FuncTypeEnum.ESCORT_HELP_COMPLETE, true),
		;

		private final int index;
		
		/** 是否自动给玩家，如果是，则在玩家登录后直接给，如果不是，则需要玩家触发领取再给 */
		private boolean isAutoSend;
		/** 非自动领取的奖励 绑定的功能类型 */
		private FuncTypeEnum bindFuncType;
		/** 领奖时是否需要显示面板信息 */
		private boolean isShowPanel;
		
		private OfflineRewardType(int index, boolean isAutoSend, FuncTypeEnum bindFuncType, boolean isShowPanel) {
			this.index = index;
			this.isAutoSend = isAutoSend;
			this.bindFuncType = bindFuncType;
			this.isShowPanel = isShowPanel;
		}

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<OfflineRewardType> values = IndexedEnumUtil.toIndexes(OfflineRewardType.values());

		public static OfflineRewardType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}

		/**
		 * 是否自动发给玩家
		 * true则在玩家登录后直接给，false则需要玩家触发领取再给 
		 * @return
		 */
		public boolean isAutoSend() {
			return isAutoSend;
		}

		/**
		 * 获取奖励对应的功能按钮
		 * @return
		 */
		public FuncTypeEnum getBindFuncType() {
			return bindFuncType;
		}

		/**
		 * 领奖时是否需要显示面板信息
		 * @return
		 */
		public boolean isShowPanel() {
			return isShowPanel;
		}
	}
	
}
