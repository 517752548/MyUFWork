package com.imop.lj.gameserver.reward;

import java.util.List;

import com.imop.lj.common.LogReasons.CorpsLogReason;
import com.imop.lj.common.LogReasons.ItemGenLogReason;
import com.imop.lj.common.LogReasons.ItemLogReason;
import com.imop.lj.common.LogReasons.MoneyLogReason;
import com.imop.lj.common.LogReasons.PetExpLogReason;
import com.imop.lj.common.LogReasons.PubExpLogReason;
import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;
import com.imop.lj.gameserver.reward.subreward.CalculateSubReward;
import com.imop.lj.gameserver.reward.subreward.CorpsContributionReward;
import com.imop.lj.gameserver.reward.subreward.CorpsExpReward;
import com.imop.lj.gameserver.reward.subreward.CorpsFundReward;
import com.imop.lj.gameserver.reward.subreward.CurrencySubReward;
import com.imop.lj.gameserver.reward.subreward.ExpLeaderSubReward;
import com.imop.lj.gameserver.reward.subreward.ExpPetHorseSubReward;
import com.imop.lj.gameserver.reward.subreward.ExpPetSubReward;
import com.imop.lj.gameserver.reward.subreward.ItemSubReward;
import com.imop.lj.gameserver.reward.subreward.PubExpReward;

/**
 * 定义奖励相关定义
 * 
 * @author yuanbo.gao
 * 
 */
public interface RewardDef {
	public final static String REWARD_UUID="1";
	
	public final static String REWARD_ITEM_INFO="2";
	
	public final static String REWARD_CURRENCY_INFO="3";
	
	public final static String REWARD_EXP_INFO="4";
	
	public final static String REWARD_REASON_TYPE="5";
	
	public final static String REWARD_PARAMS="6";
	
	public final static String REWARD_CURRENCY_TYPE="7";
	
	public final static String REWARD_CURRENCY_AMOUNT="8";
	
	public final static String REWARD_ITEM_TEMPLATE_ID="9";
	
	public final static String REWARD_ITEM_AMOUNT="10";
	
	public final static String REWARD_LOG_TEMPLATE_ID="11";
	
	public final static String REWARD_LOG_CONTENT="12";
	
	public final static String REWARD_LOG_PARAMS="13";
	
	public final static String REWARD_LOG_MERGE_REWARD_IDS="14";
	
	/** 计算类奖励参数key定义 **/
	public final static String CALC_KEY_LEVEL = "level";
	public final static String CALC_KEY_TARGET_LEVEL = "targetlevel";
	public final static String CALC_KEY_RANK = "rank";
	public final static String CALC_KEY_DAMAGE = "damage";
	public final static String CALC_KEY_MILITARY_RANK = "mrank";
	public final static String CALC_KEY_ISWIN = "iswin";
	public final static String CALC_KEY_FIGHTNUM = "fightnum";
	public final static String CALC_KEY_HP_MAX = "hpmax";
	public final static String CALC_KEY_ONE_WIN_CREDIT = "onewincredit";
	public final static String CALC_KEY_FAIL_RATE = "failrate";
	
	public final static String EXP_AMEND = "exp";
	public final static String GOLD_AMEND = "gold";
	public final static String REWARD_ADDED_FROM = "addedFrom";
	
	public final static String CALC_KEY_BASIC_GOLD = "basic";
	public final static String CALC_KEY_ROLE_ID = "roleId";
	public final static String CALC_KEY_LEVEL_DIFF = "levelDiff";
	public final static String CALC_KEY_GOLD_ADDED = "goldAdded";
	public final static String CALC_KEY_GOLD_FACTOR = "goldFactor";
	public final static String CALC_KEY_GOLD_LOSE = "goldLose";
	public final static String CALC_KEY_ATTACKED_SUCC_NUM = "num";
	public final static String CALC_KEY_COMPLETE_NUM = "num";
	public final static String CALC_KEY_GE_INCOME = "ge";
	
	public enum RewardAddedFromType implements IndexedEnum{
		/** 关卡奖励，来自军团 */
		FROM_CORPS(1),
		/** 关卡奖励，来自世界等级 */
		FROM_WORLD_LEVEL(2),
		/** 双倍点奖励 */
		FROM_DOUBLE_POINT(3),

		;

		/** 枚举的索引 */
		public final int index;
		

		/** 按索引顺序存放的枚举数组 */
		private static final List<RewardAddedFromType> indexes = IndexedEnum.IndexedEnumUtil.toIndexes(RewardAddedFromType.values());

		private RewardAddedFromType(int index) {
			this.index = index;
		}

		@Override
		public int getIndex() {
			return index;
		}
		

		public static RewardAddedFromType valueOf(final int index) {
			return EnumUtil.valueOf(indexes, index);
		}
	}
	
	public enum RewardAddedType implements IndexedEnum{
		/** 经验 */
		EXP(1),
		/** 金币 */
		GOLD(2),
		
		;

		/** 枚举的索引 */
		public final int index;
		

		/** 按索引顺序存放的枚举数组 */
		private static final List<RewardAddedType> indexes = IndexedEnum.IndexedEnumUtil.toIndexes(RewardAddedType.values());

		private RewardAddedType(int index) {
			this.index = index;
		}

		@Override
		public int getIndex() {
			return index;
		}
		

		public static RewardAddedType valueOf(final int index) {
			return EnumUtil.valueOf(indexes, index);
		}
	}
	
	/**
	 * 奖励修正类型
	 * 
	 * @author xiaowei.liu
	 * 
	 */
	public enum RewardAmendType implements IndexedEnum {
		/** 个人 */
		HUMAN(1),
		/** 军团 */
		CORPS(2),
		
		;

		/** 枚举的索引 */
		public final int index;
		

		/** 按索引顺序存放的枚举数组 */
		private static final List<RewardAmendType> indexes = IndexedEnum.IndexedEnumUtil.toIndexes(RewardAmendType.values());

		private RewardAmendType(int index) {
			this.index = index;
		}

		@Override
		public int getIndex() {
			return index;
		}
		

		public static RewardAmendType valueOf(final int index) {
			return EnumUtil.valueOf(indexes, index);
		}
	}
	/**
	 * 计算类奖励类型
	 * 
	 * @author yuanbo.gao
	 * 
	 */
	public enum RewardCalculateType implements IndexedEnum {
		/** 绿野仙踪最终奖励 */
		WIZARDRAID(1, CalculateRewardFactory.WizardRaidRewardCalculator),
		/** 科举答题奖励 */
		EXAM(2, CalculateRewardFactory.ExamCalculator),

		;

		/** 枚举的索引 */
		public final int index;
		
		public ICalculateReward rewardCalculator;

		/** 按索引顺序存放的枚举数组 */
		private static final List<RewardCalculateType> indexes = IndexedEnum.IndexedEnumUtil.toIndexes(RewardCalculateType.values());

		private RewardCalculateType(int index, ICalculateReward rewardCalculator) {
			this.index = index;
			this.rewardCalculator = rewardCalculator; 
		}

		@Override
		public int getIndex() {
			return index;
		}
		
		public ICalculateReward getRewardCalculator() {
			return rewardCalculator;
		}

		public static RewardCalculateType valueOf(final int index) {
			return EnumUtil.valueOf(indexes, index);
		}
	}
	
	/**
	 * 奖励类型
	 * 
	 * @author yuanbo.gao
	 * 
	 */
	public enum RewardType implements IndexedEnum {
		/** 货币奖励 */
		REWARD_CURRENCY(1, new CurrencySubReward(null)),
		/** 物品奖励 */
		REWARD_ITEM(2, new ItemSubReward(null)),
		/** 人物经验奖励 */
		REWARD_LEADER_EXP(3, new ExpLeaderSubReward(null)),
		/** 需要根据玩家行为定义的奖励 */
		REWARD_CALCULATE(4, new CalculateSubReward(null)),
//		/**奖励军团经验*/
//		REWARD_CORPS_EXP(5, new CorpsExpSubReward(null)),
		/** 酒馆经验奖励 */
		REWARD_PUB_EXP(5, new PubExpReward(null)),
		/** 宠物经验奖励 */
		REWARD_PET_EXP(6, new ExpPetSubReward(null)),
		/** 帮派经验奖励*/
		REWARD_CORPS_EXP(7, new CorpsExpReward(null)),
		/** 帮派资金奖励*/
		REWARD_CORPS_FUND(8, new CorpsFundReward(null)),
		/** 帮贡奖励*/
		REWARD_CORPS_CONTRIBUTION(9, new CorpsContributionReward(null)),
		/** 骑宠经验奖励 */
		REWARD_PET_HORSE_EXP(10, new ExpPetHorseSubReward(null)),
		;

		/** 枚举的索引 */
		public final int index;
		public final ISubReward subReward;

		/** 按索引顺序存放的枚举数组 */
		private static final List<RewardType> indexes = IndexedEnum.IndexedEnumUtil.toIndexes(RewardType.values());

		private RewardType(int index, ISubReward subReward) {
			this.index = index;
			this.subReward = subReward;
		}

		@Override
		public int getIndex() {
			return index;
		}

		public static RewardType valueOf(final int index) {
			return EnumUtil.valueOf(indexes, index);
		}

		public ISubReward getSubReward() {
			return subReward;
		}
	}
	
	/**
	 * 为了做到奖励统一处理，将获得奖励logreason统一定义，内部调用
	 * 
	 * @author yuanbo.gao
	 *
	 */
	public enum RewardReasonType implements IndexedEnum {
		/**空奖励*/
		NULL_REWARD(0,null,null,null,null, null,null),
		/** 背包满了道具发邮件 */
		BAG_FULL_SEND_MAIL(1, null, null, ItemGenLogReason.BAG_FULL_SEND_MAIL, ItemLogReason.BAG_FULL_SEND_MAIL, null, null),
		/** 背包满了reward发邮件 */
		BAG_FULL_SEND_MAIL_REWARD(3, null, null, ItemGenLogReason.BAG_FULL_SEND_MAIL_REWARD, ItemLogReason.BAG_FULL_SEND_MAIL_REWARD, null, null),
		
		/** XXX 下面几个小于100的是旧的，废弃 */
		/**军团分配*/
		CORPS_ALLOCATION(2, null, null, ItemGenLogReason.CORPS_ITEM_ALLOCATION_REWARD, ItemLogReason.CORPS_ITEM_ALLOCATION_REWARD, null,CorpsLogReason.CORPS_ADD_EXP),
		/** gm奖励 FIXME 后边的奖励reson是乱写的  */
		USER_PRIZE_REWARD(9, PetExpLogReason.CDKEY_REWARD, MoneyLogReason.CDKEY_REWARD, ItemGenLogReason.CDKEY_REWARD, ItemLogReason.TRADE_REWARD, PubExpLogReason.PUBTASK_REWARD,CorpsLogReason.CORPS_ADD_EXP),
		/**等级礼包奖励*/
		LEVEL_GIFT_PACK_REWARD(31, PetExpLogReason.LEVEL_GIFT_PACK_REWARD, MoneyLogReason.LEVEL_GIFT_PACK_REWARD, ItemGenLogReason.LEVEL_GIFT_PACK_REWARD, ItemLogReason.LEVEL_GIFT_PACK_REWARD, null,null),
		/** 领取cdkey礼包奖励  */
		CDKEY_REWARD(75, PetExpLogReason.CDKEY_REWARD, MoneyLogReason.CDKEY_REWARD, ItemGenLogReason.CDKEY_REWARD, null, PubExpLogReason.PUBTASK_REWARD,CorpsLogReason.CORPS_ADD_EXP),
		/** 消耗钥匙使用礼包  */
		COST_KEY_USE_ITEM(83, PetExpLogReason.COST_KEY_USE_ITEM_GIVE, MoneyLogReason.COST_KEY_USE_ITEM_GIVE, ItemGenLogReason.COST_KEY_USE_ITEM_GIVE, ItemLogReason.COST_KEY_USE_ITEM_GIVE, null,CorpsLogReason.CORPS_ADD_EXP),
		
		
		/** 签到奖励 */
		MONTH_SIGN_REWARD(101, PetExpLogReason.MONTH_SIGN_REWARD, MoneyLogReason.MONTH_SIGN_REWARD, ItemGenLogReason.MONTH_SIGN_REWARD, ItemLogReason.MONTH_SIGN_REWARD, null, CorpsLogReason.MONTH_SIGN_REWARD),
		/** 装备分解 */
		EQUIP_DECOMPOSE_REWARD(102, null, MoneyLogReason.EQUIP_DECOMPOSE_REWARD, ItemGenLogReason.EQUIP_DECOMPOSE_REWARD, ItemLogReason.EQUIP_DECOMPOSE_REWARD, null, null),
		/** 科举答题 */
		EXAM_REWARD(103, PetExpLogReason.EXAM_REWARD, MoneyLogReason.EXAM_REWARD, ItemGenLogReason.EXAM_REWARD, ItemLogReason.EXAM_REWARD, null, CorpsLogReason.EXAM_REWARD),
		/** 采矿奖励 */
		MINE_REWARD(104, PetExpLogReason.MINE_REWARD, MoneyLogReason.MINE_REWARD, ItemGenLogReason.MINE_REWARD, ItemLogReason.MINE_REWARD, null, null),
		/** 邮件附件 */
		MAIL_ATTACHMENT_REWARD(105, PetExpLogReason.MAIL_ATTACHMENT_REWARD, MoneyLogReason.MAIL_ATTACHMENT_REWARD, ItemGenLogReason.MAIL_ATTACHMENT_REWARD, ItemLogReason.MAIL_ATTACHMENT_REWARD, PubExpLogReason.MAIL_ATTACHMENT_REWARD, CorpsLogReason.MAIL_ATTACHMENT_REWARD),
		/** 活跃度奖励 */
		ACTIVITYUI_REWARD(106, PetExpLogReason.ACTIVITYUI_REWARD, MoneyLogReason.ACTIVITYUI_REWARD, ItemGenLogReason.ACTIVITYUI_REWARD, ItemLogReason.ACTIVITYUI_REWARD, PubExpLogReason.ACTIVITYUI_REWARD, CorpsLogReason.ACTIVITYUI_REWARD),
		/** 竞技场攻击奖励 */
		ARENA_ATTACK(107, PetExpLogReason.ARENA_ATTACK, MoneyLogReason.ARENA_ATTACK, ItemGenLogReason.ARENA_ATTACK, ItemLogReason.ARENA_ATTACK, null, CorpsLogReason.ARENA_ATTACK),
		/** 竞技场排名奖励 */
		ARENA_RANK(108, PetExpLogReason.ARENA_RANK, MoneyLogReason.ARENA_RANK, ItemGenLogReason.ARENA_RANK, ItemLogReason.ARENA_RANK, null, CorpsLogReason.ARENA_RANK),
		
		/** 精彩活动奖励 */
		GOOD_ACTIVITY_REWARD(109, PetExpLogReason.GOOD_ACTIVITY_REWARD, MoneyLogReason.GOOD_ACTIVITY_REWARD, ItemGenLogReason.GOOD_ACTIVITY_REWARD, ItemLogReason.GOOD_ACTIVITY_REWARD, PubExpLogReason.GOOD_ACTIVITY_REWARD, CorpsLogReason.GOOD_ACTIVITY_REWARD),
		/** 主线任务奖励 */
		QUEST_REWARD(110, PetExpLogReason.QUEST_REWARD, MoneyLogReason.QUEST_REWARD, ItemGenLogReason.QUEST_REWARD, ItemLogReason.QUEST_REWARD, PubExpLogReason.QUEST_REWARD, CorpsLogReason.QUEST_REWARD),
		/** 帮派竞赛奖励 */
		CORPS_WAR_REWARD(111, PetExpLogReason.CORPS_WAR_REWARD, MoneyLogReason.CORPS_WAR_REWARD, ItemGenLogReason.CORPS_WAR_REWARD, ItemLogReason.CORPS_WAR_REWARD, null, CorpsLogReason.CORPS_WAR_REWARD),
		/** 绿野仙踪最终奖励 */
		WIZARD_RAID_REWARD(112, PetExpLogReason.WIZARD_RAID_REWARD, MoneyLogReason.WIZARD_RAID_REWARD, ItemGenLogReason.WIZARD_RAID_REWARD, ItemLogReason.WIZARD_RAID_REWARD, null, CorpsLogReason.WIZARD_RAID_REWARD),
		/** 在线礼包奖励 */
		ONLINE_GIFT_REWARD(113, PetExpLogReason.ONLINE_GIFT_REWARD, MoneyLogReason.ONLINE_GIFT_REWARD, ItemGenLogReason.ONLINE_GIFT_REWARD, ItemLogReason.ONLINE_GIFT_REWARD, null, CorpsLogReason.ONLINE_GIFT_REWARD),
		/** 打怪胜利奖励 */
		WIN_ENEMY_REWARD(114, PetExpLogReason.WIN_ENEMY_REWARD, MoneyLogReason.WIN_ENEMY_REWARD, ItemGenLogReason.WIN_ENEMY_REWARD, ItemLogReason.WIN_ENEMY_REWARD, PubExpLogReason.WIN_ENEMY_REWARD, CorpsLogReason.WIN_ENEMY_REWARD),
		/** 除暴安良特殊奖励 */
		SWEENEY_TASK_SPECIAL(115, PetExpLogReason.SWEENEY_TASK_SPECIAL, MoneyLogReason.SWEENEY_TASK_SPECIAL, ItemGenLogReason.SWEENEY_TASK_SPECIAL, ItemLogReason.SWEENEY_TASK_SPECIAL, PubExpLogReason.SWEENEY_TASK_SPECIAL, CorpsLogReason.SWEENEY_TASK_SPECIAL),
		/** NVN月度排名奖励 */
		NVN_RANK(116, PetExpLogReason.NVN_RANK, MoneyLogReason.NVN_RANK, ItemGenLogReason.NVN_RANK, ItemLogReason.NVN_RANK, PubExpLogReason.NVN_RANK, CorpsLogReason.NVN_RANK),
		/** 结婚奖励 */
		MARRY_REWARD(117, PetExpLogReason.MARRY_REWARD, MoneyLogReason.MARRY_REWARD, ItemGenLogReason.MARRY_REWARD, ItemLogReason.MARRY_REWARD, PubExpLogReason.MARRY_REWARD, CorpsLogReason.MARRY_REWARD),
		/** 师徒奖励 */
		OVERMAN_REWARD(118, PetExpLogReason.OVERMAN_REWARD, MoneyLogReason.OVERMAN_REWARD, ItemGenLogReason.OVERMAN_REWARD, ItemLogReason.OVERMAN_REWARD, PubExpLogReason.OVERMAN_REWARD, CorpsLogReason.OVERMAN_REWARD),
		/** 藏宝图奖励 */
		TREASURE_MAP_REWARD(119, PetExpLogReason.TREASURE_MAP_REWARD, MoneyLogReason.TREASURE_MAP_REWARD, ItemGenLogReason.TREASURE_MAP_REWARD, ItemLogReason.OVERMAN_REWARD, PubExpLogReason.TREASURE_MAP_REWARD, CorpsLogReason.TREASURE_MAP_REWARD),
		/** 使用礼包道具奖励 */
		GIFT_PACK(120, PetExpLogReason.GIFT_PACK, MoneyLogReason.GIFT_PACK, ItemGenLogReason.GIFT_PACK, ItemLogReason.GIFT_PACK, PubExpLogReason.GIFT_PACK, CorpsLogReason.GIFT_PACK),
		/** 交易行卖出商品的货款 */
		TRADE_REWARD(121, PetExpLogReason.TRADE_REWARD, MoneyLogReason.TRADE_REWARD, ItemGenLogReason.TRADE_REWARD, ItemLogReason.TRADE_REWARD, null,null),
		/** 平台兑换码奖励 */
		LOCAL_CODE_REWARD(122, null, MoneyLogReason.LOCAL_CODE_REWARD, ItemGenLogReason.LOCAL_CODE_REWARD, ItemLogReason.LOCAL_CODE_REWARD, null,null),
		
		/** 酒馆任务奖励 */
		PUB_TASK_REWARD(123, PetExpLogReason.PUB_TASK_REWARD, MoneyLogReason.PUB_TASK_REWARD, ItemGenLogReason.PUB_TASK_REWARD, ItemLogReason.PUB_TASK_REWARD, PubExpLogReason.PUB_TASK_REWARD, CorpsLogReason.PUB_TASK_REWARD),
		/** 除暴任务奖励 */
		SWEENEY_TASK_REWARD(124, PetExpLogReason.SWEENEY_TASK_REWARD, MoneyLogReason.SWEENEY_TASK_REWARD, ItemGenLogReason.SWEENEY_TASK_REWARD, ItemLogReason.SWEENEY_TASK_REWARD, PubExpLogReason.SWEENEY_TASK_REWARD, CorpsLogReason.SWEENEY_TASK_REWARD),
		/** 藏宝图任务奖励 */
		TREASURE_MAP_TASK_REWARD(125, PetExpLogReason.TREASURE_MAP_TASK_REWARD, MoneyLogReason.TREASURE_MAP_TASK_REWARD, ItemGenLogReason.TREASURE_MAP_TASK_REWARD, ItemLogReason.TREASURE_MAP_TASK_REWARD, PubExpLogReason.TREASURE_MAP_TASK_REWARD, CorpsLogReason.TREASURE_MAP_TASK_REWARD),
		/** 护送粮草任务奖励 */
		FORAGE_TASK_REWARD(126, PetExpLogReason.FORAGE_TASK_REWARD, MoneyLogReason.FORAGE_TASK_REWARD, ItemGenLogReason.FORAGE_TASK_REWARD, ItemLogReason.FORAGE_TASK_REWARD, PubExpLogReason.FORAGE_TASK_REWARD, CorpsLogReason.FORAGE_TASK_REWARD),
		/** 帮派任务奖励 */
		CORPS_TASK_REWARD(127, PetExpLogReason.CORPS_TASK_REWARD, MoneyLogReason.CORPS_TASK_REWARD, ItemGenLogReason.CORPS_TASK_REWARD, ItemLogReason.CORPS_TASK_REWARD, PubExpLogReason.CORPS_TASK_REWARD, CorpsLogReason.CORPS_TASK_REWARD),
		/** 宝石合成失败奖励 */
		GEM_SYN_FAIL_REWARD(128, PetExpLogReason.GEM_SYN_FAIL_REWARD, MoneyLogReason.GEM_SYN_FAIL_REWARD, ItemGenLogReason.GEM_SYN_FAIL_REWARD, ItemLogReason.GEM_SYN_FAIL_REWARD, PubExpLogReason.GEM_SYN_FAIL_REWARD, null),
		/** 7日登录奖励 */
		GA_SEVEN_LOGIN_REWARD(129, PetExpLogReason.GA_SEVEN_LOGIN_REWARD, MoneyLogReason.GA_SEVEN_LOGIN_REWARD, ItemGenLogReason.GA_SEVEN_LOGIN_REWARD, ItemLogReason.GA_SEVEN_LOGIN_REWARD, PubExpLogReason.GA_SEVEN_LOGIN_REWARD, CorpsLogReason.GA_LEVEL_UP_REWARD),
		/** 等级奖励 */
		GA_LEVEL_UP_REWARD(130, PetExpLogReason.GA_LEVEL_UP_REWARD, MoneyLogReason.GA_LEVEL_UP_REWARD, ItemGenLogReason.GA_LEVEL_UP_REWARD, ItemLogReason.GA_LEVEL_UP_REWARD, PubExpLogReason.GA_LEVEL_UP_REWARD, CorpsLogReason.GA_LEVEL_UP_REWARD),
		/** vip每日奖励 */
		VIP_DAY_REWARD(131, PetExpLogReason.VIP_DAY_REWARD, MoneyLogReason.VIP_DAY_REWARD, ItemGenLogReason.VIP_DAY_REWARD, ItemLogReason.VIP_DAY_REWARD, PubExpLogReason.VIP_DAY_REWARD, CorpsLogReason.VIP_DAY_REWARD),
		/** 通天塔奖励 */
		TOWER_REWARD(132, PetExpLogReason.TOWER_REWARD, MoneyLogReason.TOWER_REWARD, ItemGenLogReason.TOWER_REWARD, ItemLogReason.TOWER_REWARD, PubExpLogReason.TOWER_REWARD, CorpsLogReason.TOWER_REWARD),
		/** vip等级奖励 */
		VIP_LEVEL_REWARD(133, PetExpLogReason.VIP_LEVEL_REWARD, MoneyLogReason.VIP_LEVEL_REWARD, ItemGenLogReason.VIP_LEVEL_REWARD, ItemLogReason.VIP_LEVEL_REWARD, PubExpLogReason.VIP_LEVEL_REWARD, CorpsLogReason.VIP_LEVEL_REWARD),
		/** 帮派boss奖励 */
		CORPS_BOSS_REWARD(134, PetExpLogReason.CORPS_BOSS_REWARD, MoneyLogReason.CORPS_BOSS_REWARD, ItemGenLogReason.CORPS_BOSS_REWARD, ItemLogReason.CORPS_BOSS_REWARD, PubExpLogReason.CORPS_BOSS_REWARD, CorpsLogReason.CORPS_BOSS_REWARD),
		/** 帮派boss进度排行榜奖励 */
		CORPS_BOSS_RANK_REWARD(135, PetExpLogReason.CORPS_BOSS_RANK_REWARD, MoneyLogReason.CORPS_BOSS_RANK_REWARD, ItemGenLogReason.CORPS_BOSS_RANK_REWARD, ItemLogReason.CORPS_BOSS_RANK_REWARD, PubExpLogReason.CORPS_BOSS_RANK_REWARD, CorpsLogReason.CORPS_BOSS_RANK_REWARD),
		/** 帮派boss挑战次数排行榜奖励 */
		CORPS_BOSS_COUNT_RANK_REWARD(136, PetExpLogReason.CORPS_BOSS_COUNT_RANK_REWARD, MoneyLogReason.CORPS_BOSS_COUNT_RANK_REWARD, ItemGenLogReason.CORPS_BOSS_COUNT_RANK_REWARD, ItemLogReason.CORPS_BOSS_COUNT_RANK_REWARD, PubExpLogReason.CORPS_BOSS_COUNT_RANK_REWARD, CorpsLogReason.CORPS_BOSS_COUNT_RANK_REWARD),
		/** 野外封妖榜奖励 */
		SEAL_DEMON_REWARD(137, PetExpLogReason.SEAL_DEMON_REWARD, MoneyLogReason.SEAL_DEMON_REWARD, ItemGenLogReason.SEAL_DEMON_REWARD, ItemLogReason.SEAL_DEMON_REWARD, PubExpLogReason.SEAL_DEMON_REWARD, CorpsLogReason.SEAL_DEMON_REWARD),
		/** 野外魔王奖励 */
		SEAL_DEMON_KING_REWARD(138, PetExpLogReason.SEAL_DEMON_KING_REWARD, MoneyLogReason.SEAL_DEMON_KING_REWARD, ItemGenLogReason.SEAL_DEMON_KING_REWARD, ItemLogReason.SEAL_DEMON_KING_REWARD, PubExpLogReason.SEAL_DEMON_KING_REWARD, CorpsLogReason.SEAL_DEMON_KING_REWARD),
		/** 混世魔王奖励 */
		DEVIL_INCARNATE_REWARD(139, PetExpLogReason.DEVIL_INCARNATE_REWARD, MoneyLogReason.DEVIL_INCARNATE_REWARD, ItemGenLogReason.DEVIL_INCARNATE_REWARD, ItemLogReason.DEVIL_INCARNATE_REWARD, PubExpLogReason.DEVIL_INCARNATE_REWARD, CorpsLogReason.DEVIL_INCARNATE_REWARD),
		/** 限时杀怪奖励 */
		TIME_LIMIT_MONSTER_REWARD(140, PetExpLogReason.TIME_LIMIT_MONSTER_REWARD, MoneyLogReason.TIME_LIMIT_MONSTER_REWARD, ItemGenLogReason.TIME_LIMIT_MONSTER_REWARD, ItemLogReason.TIME_LIMIT_MONSTER_REWARD, PubExpLogReason.TIME_LIMIT_MONSTER_REWARD, CorpsLogReason.TIME_LIMIT_MONSTER_REWARD),
		/** 限时挑战npc奖励 */
		TIME_LIMIT_NPC_REWARD(141, PetExpLogReason.TIME_LIMIT_NPC_REWARD, MoneyLogReason.TIME_LIMIT_NPC_REWARD, ItemGenLogReason.TIME_LIMIT_NPC_REWARD, ItemLogReason.TIME_LIMIT_NPC_REWARD, PubExpLogReason.TIME_LIMIT_NPC_REWARD, CorpsLogReason.TIME_LIMIT_NPC_REWARD),
		/** 绿野仙踪BOSS奖励 */
		WIZARD_RAID_BOSS_REWARD(142, PetExpLogReason.WIZARD_RAID_BOSS_REWARD, MoneyLogReason.WIZARD_RAID_BOSS_REWARD, ItemGenLogReason.WIZARD_RAID_BOSS_REWARD, ItemLogReason.WIZARD_RAID_BOSS_REWARD, null, CorpsLogReason.WIZARD_RAID_BOSS_REWARD),
		/** 七日目标任务奖励 */
		DAY7_TARGET_REWARD(143, PetExpLogReason.DAY7_TARGET_REWARD, MoneyLogReason.DAY7_TARGET_REWARD, ItemGenLogReason.DAY7_TARGET_REWARD, ItemLogReason.DAY7_TARGET_REWARD, PubExpLogReason.DAY7_TARGET_REWARD, CorpsLogReason.DAY7_TARGET_REWARD),
		/** 帮派辅助技能奖励*/
		CORPS_ASSIST_REWARD(144, PetExpLogReason.CORPS_ASSIST_REWARD, MoneyLogReason.CORPS_ASSIST_REWARD, ItemGenLogReason.CORPS_ASSIST_REWARD, ItemLogReason.CORPS_ASSIST_REWARD, null, CorpsLogReason.CORPS_ASSIST_REWARD),
		/** 帮派红包奖励*/
		CORPS_RED_ENVELOPE_REWARD(145, PetExpLogReason.CORPS_RED_ENVELOPE_REWARD, MoneyLogReason.CORPS_RED_ENVELOPE_REWARD, ItemGenLogReason.CORPS_RED_ENVELOPE_REWARD, ItemLogReason.CORPS_RED_ENVELOPE_REWARD, null, CorpsLogReason.CORPS_RED_ENVELOPE_REWARD),
		/** 剧情副本奖励*/
		PLOT_DUNGEON_REWARD(146, PetExpLogReason.PLOT_DUNGEON_REWARD, MoneyLogReason.PLOT_DUNGEON_REWARD, ItemGenLogReason.PLOT_DUNGEON_REWARD, ItemLogReason.PLOT_DUNGEON_REWARD, null, CorpsLogReason.PLOT_DUNGEON_REWARD),
		/** 招财进宝奖励（精彩活动） */
		GA_BUY_MONEY_REWARD(147, PetExpLogReason.GA_BUY_MONEY_REWARD, MoneyLogReason.GA_BUY_MONEY_REWARD, ItemGenLogReason.GA_BUY_MONEY_REWARD, ItemLogReason.GA_BUY_MONEY_REWARD, null, null),
		/** 开服基金奖励（精彩活动） */
		GA_LEVEL_MONEY_REWARD(148, PetExpLogReason.GA_LEVEL_MONEY_REWARD, MoneyLogReason.GA_LEVEL_MONEY_REWARD, ItemGenLogReason.GA_LEVEL_MONEY_REWARD, ItemLogReason.GA_LEVEL_MONEY_REWARD, null, null),
		/** 限时累计充值奖励（精彩活动） */
		GA_NORMAL_TOTAL_CHARGE(149, PetExpLogReason.GA_NORMAL_TOTAL_CHARGE, MoneyLogReason.GA_NORMAL_TOTAL_CHARGE, ItemGenLogReason.GA_NORMAL_TOTAL_CHARGE, ItemLogReason.GA_NORMAL_TOTAL_CHARGE, null, null),
		/** 每日累计充值奖励（精彩活动） */
		GA_DAY_TOTAL_CHARGE(150, PetExpLogReason.GA_DAY_TOTAL_CHARGE, MoneyLogReason.GA_DAY_TOTAL_CHARGE, ItemGenLogReason.GA_DAY_TOTAL_CHARGE, ItemLogReason.GA_DAY_TOTAL_CHARGE, null, null),
		/** 一元购类型奖励（精彩活动） */
		GA_TOTAL_CHARGE_BUY(151, PetExpLogReason.GA_TOTAL_CHARGE_BUY, MoneyLogReason.GA_TOTAL_CHARGE_BUY, ItemGenLogReason.GA_TOTAL_CHARGE_BUY, ItemLogReason.GA_TOTAL_CHARGE_BUY, null, null),
		/** 围剿魔族普通奖励 */
		SIEGE_DEMON_NORMAL_REWARD(152, PetExpLogReason.SIEGE_DEMON_NORMAL_REWARD, MoneyLogReason.SIEGE_DEMON_NORMAL_REWARD, ItemGenLogReason.SIEGE_DEMON_NORMAL_REWARD, ItemLogReason.SIEGE_DEMON_NORMAL_REWARD, null, null),
		/** 围剿魔族困难奖励 */
		SIEGE_DEMON_HARD_REWARD(153, PetExpLogReason.SIEGE_DEMON_HARD_REWARD, MoneyLogReason.SIEGE_DEMON_HARD_REWARD, ItemGenLogReason.SIEGE_DEMON_HARD_REWARD, ItemLogReason.SIEGE_DEMON_HARD_REWARD, null, null),
		
		;

		/** 枚举的索引 */
		public final int index;
		/** 经验reason */
		public final PetExpLogReason petExpLogReason;
		/** 货币reason */
		public final MoneyLogReason moneyLogReason;
		/** 物品产生reason */
		public final ItemGenLogReason itemGenLogReason;
		/** 改变物品reason */
		public final ItemLogReason itemLogReason;
		/** 酒馆经验奖励 */
		public final PubExpLogReason pubExpLogReason;
		/** 帮派经验、资金、帮贡奖励 */
		public final CorpsLogReason corpsLogReason;

		/** 按索引顺序存放的枚举数组 */
		private static final List<RewardReasonType> indexes = IndexedEnum.IndexedEnumUtil.toIndexes(RewardReasonType.values());

		private RewardReasonType(int index, PetExpLogReason petExpLogReason, MoneyLogReason moneyLogReason, ItemGenLogReason itemGenLogReason,
				ItemLogReason itemLogReason, PubExpLogReason pubExpLogReason,CorpsLogReason corpsLogReason) {
			this.index = index;
			this.petExpLogReason = petExpLogReason;
			this.moneyLogReason = moneyLogReason;
			this.itemGenLogReason = itemGenLogReason;
			this.itemLogReason = itemLogReason;
			this.pubExpLogReason = pubExpLogReason;
			this.corpsLogReason = corpsLogReason;
		}

		@Override
		public int getIndex() {
			return index;
		}

		public static RewardReasonType valueOf(final int index) {
			return EnumUtil.valueOf(indexes, index);
		}

		public PetExpLogReason getPetExpLogReason() {
			return petExpLogReason;
		}

		public MoneyLogReason getMoneyLogReason() {
			return moneyLogReason;
		}

		public ItemGenLogReason getItemGenLogReason() {
			return itemGenLogReason;
		}

		public ItemLogReason getItemLogReason() {
			return itemLogReason;
		}

		public PubExpLogReason getPubExpLogReason() {
			return pubExpLogReason;
		}
		
		public CorpsLogReason getCorpsLogReason(){
			return corpsLogReason;
		}

	}
}
