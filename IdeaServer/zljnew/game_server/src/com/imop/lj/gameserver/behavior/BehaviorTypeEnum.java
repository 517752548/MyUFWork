package com.imop.lj.gameserver.behavior;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;
import com.imop.lj.gameserver.behavior.BehaviorManager.BehaviorRecord;

/**
 * 行为类型枚举
 * 
 */
public enum BehaviorTypeEnum implements IndexedEnum {
	/** 未知行为 */
	UNKNOWN(0,BehaviorRefreshCheckFactory.REFRESH_ONCE_TIME), 
	/** 竞技场挑战次数*/
	ARENA_CHALLENGE_NUM(1,BehaviorRefreshCheckFactory.REFRESH_ONCE_DAY),
	/** 购买竞技场挑战次数*/
	BUY_ARENA(2,BehaviorRefreshCheckFactory.REFRESH_ONCE_DAY),
	/** 发邮件次数 */
	MAIL_SEND(3, BehaviorRefreshCheckFactory.REFRESH_ONCE_DAY),
	/** 首充奖励 */
	FIRST_CHARGE(4, BehaviorRefreshCheckFactory.REFRESH_ONCE_TIME),
	/** 玩家累计登录天数 */
	TOTAL_LOGIN_DAYS(5, BehaviorRefreshCheckFactory.REFRESH_ONCE_TIME),
	/**购买体力次数*/
	BUY_POWER_NUM(6, BehaviorRefreshCheckFactory.REFRESH_ONCE_DAY),
	/**酒馆任务数*/
	PUB_TASK_NUM(7, BehaviorRefreshCheckFactory.REFRESH_ONCE_DAY),
	/**乡试答题数*/
	PROVINCIAL_EXAM_NUM(8, BehaviorRefreshCheckFactory.REFRESH_ONCE_DAY),
	/**总活力*/
	TOTAL_ACTIVITY_NUM(9, BehaviorRefreshCheckFactory.REFRESH_ONCE_DAY),
	/** 绿野仙踪进入次数 */
	WIZARDRAID_ENTER_TIMES(10, BehaviorRefreshCheckFactory.REFRESH_ONCE_DAY),
	/**每月签到-已经签到天数*/
	MONTH_SIGN_NUM(11, BehaviorRefreshCheckFactory.REFRESH_ONCE_MONTH),
	/**每月签到-已经使用的补签次数*/
	MONTH_SIGN_USED_RETROACTIVE_NUM(12, BehaviorRefreshCheckFactory.REFRESH_ONCE_MONTH),
	/**每月签到-今天是否已经签到0否1是*/
	MONTH_SIGN_TODAY(13, BehaviorRefreshCheckFactory.REFRESH_ONCE_DAY),
	/**生活技能-采矿*/
	MINE(14, BehaviorRefreshCheckFactory.REFRESH_ONCE_DAY),
	/**除暴安良任务数*/
	THESWEENEY_TASK_NUM(15, BehaviorRefreshCheckFactory.REFRESH_ONCE_DAY),
	/**藏宝图任务数*/
	TREASURE_MAP_NUM(16, BehaviorRefreshCheckFactory.REFRESH_ONCE_DAY),
	/**护送粮草任务数*/
	FORAGE_TASK_NUM(17,BehaviorRefreshCheckFactory.REFRESH_ONCE_DAY),
	/**帮派任务数*/
	CORPS_TASK_NUM(18,BehaviorRefreshCheckFactory.REFRESH_ONCE_WEEK),
	/**神秘商店刷新次数 */
	MYSTERY_SHOP_NUM(19, BehaviorRefreshCheckFactory.REFRESH_ONCE_DAY),
	/** vip每日福利领取次数 */
	VIP_DAY_REWARD(20, BehaviorRefreshCheckFactory.REFRESH_ONCE_DAY),
	/** 野外封妖挑战次数 */
	SEAL_DEMON_REWARD(21, BehaviorRefreshCheckFactory.REFRESH_ONCE_DAY),
	/** 野外魔王挑战次数 */
	SEAL_DEMON_KING_REWARD(22, BehaviorRefreshCheckFactory.REFRESH_ONCE_DAY),
	/** 混世魔王挑战次数 */
	DEVIL_INCARNATE_REWARD(23, BehaviorRefreshCheckFactory.REFRESH_ONCE_DAY),
	/** 野外魔王每5次领取魔王宝箱一个 */
	SEAL_DEMON_KING_BEST_REWARD(24, BehaviorRefreshCheckFactory.REFRESH_ONCE_DAY),
	/** 限时答题次数 */
	TIME_LIMIT_EXAM(25, BehaviorRefreshCheckFactory.REFRESH_ONCE_DAY),
	/** 限时答题数量次数 */
	TIME_LIMIT_EXAM_UNIT(26, BehaviorRefreshCheckFactory.REFRESH_ONCE_DAY),
	/** 限时杀怪次数 */
	TIME_LIMIT_MONSTER(27, BehaviorRefreshCheckFactory.REFRESH_ONCE_DAY),
	/** 限时挑战NPC次数 */
	TIME_LIMIT_NPC(28, BehaviorRefreshCheckFactory.REFRESH_ONCE_DAY),
	/** 围剿魔族普通副本次数*/
	SIEGE_DEMON_NORMAL(29, BehaviorRefreshCheckFactory.REFRESH_ONCE_DAY),
	/** 围剿魔族困难副本次数*/
	SIEGE_DEMON_HARD(30, BehaviorRefreshCheckFactory.REFRESH_ONCE_WEEK),
	/** 祝福仙葫每日次数 */
	XIANHU_ZHUFU(31, BehaviorRefreshCheckFactory.REFRESH_ONCE_DAY),
	/** 富贵仙葫次数 */
	XIANHU_FUGUI(32, BehaviorRefreshCheckFactory.REFRESH_ONCE_TIME),
	/** 至尊仙葫次数 */
	XIANHU_ZHIZUN(33, BehaviorRefreshCheckFactory.REFRESH_ONCE_TIME),
	/**领取月卡每日返利-今天是否已经领取0否1是*/
	MONTH_CARD_GIFT_TODAY(34, BehaviorRefreshCheckFactory.REFRESH_ONCE_DAY),
	/**跑环任务数*/
	RING_TASK_NUM(35,BehaviorRefreshCheckFactory.REFRESH_ONCE_DAY),
	/**跑环放弃次数*/
	RING_TASK_GIVE_UP_NUM(36,BehaviorRefreshCheckFactory.REFRESH_ONCE_DAY),
	;
	
	/** 枚举索引 */
	private int index;
	
	/** 检查周期函数 */
	private BehaviorRefreshCheck<BehaviorRecord>  refreshCheck;
	
	/** 枚举值数组 */
	private static final List<BehaviorTypeEnum> 
		values = IndexedEnumUtil.toIndexes(BehaviorTypeEnum.values());

	/**
	 * 类参数构造器
	 * 
	 * @param index
	 */
	private BehaviorTypeEnum(int index,BehaviorRefreshCheck<BehaviorRecord> refreshCheck) {
		this.index = index;
		this.refreshCheck = refreshCheck;
	}

	@Override
	public int getIndex() {
		return index;
	}

	/**
	 * 将 int 类型值转换成枚举类型
	 * 
	 * @param index
	 * @return
	 */
	public static BehaviorTypeEnum valueOf(int index) {
		return EnumUtil.valueOf(values, index);
	}

	public BehaviorRefreshCheck<BehaviorRecord> getRefreshCheck() {
		return refreshCheck;
	}
}