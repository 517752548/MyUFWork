package com.imop.lj.gameserver.corps;

import java.util.List;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;
import com.imop.lj.gameserver.common.function.IGameFuncType;
import com.imop.lj.gameserver.corps.function.corps.AbstractCorpsFunction;
import com.imop.lj.gameserver.corps.function.corps.ApplyCorpsFunction;
import com.imop.lj.gameserver.corps.function.corps.ApplyIgnoreCorpsFunction;
import com.imop.lj.gameserver.corps.function.corps.ApplyPresidentCorpsFunction;
import com.imop.lj.gameserver.corps.function.corps.BatchAddCorpsMemberCorpsFunction;
import com.imop.lj.gameserver.corps.function.corps.BatchFireCorpsMemberCorpsFunction;
import com.imop.lj.gameserver.corps.function.corps.CancelApplyCorpsFunction;
import com.imop.lj.gameserver.corps.function.corps.CancleDisbandCorpsFunction;
import com.imop.lj.gameserver.corps.function.corps.ConfirmDisbandCorpsFunction;
import com.imop.lj.gameserver.corps.function.corps.CorpsMailFunction;
import com.imop.lj.gameserver.corps.function.corps.CorpsNoticeUpdateFunction;
import com.imop.lj.gameserver.corps.function.corps.CreateCorpsFunction;
import com.imop.lj.gameserver.corps.function.corps.DisbandCorpsFunction;
import com.imop.lj.gameserver.corps.function.corps.ExitCorpsFunction;
import com.imop.lj.gameserver.corps.function.member.AbstractCorpsMemberFunction;
import com.imop.lj.gameserver.corps.function.member.AddFriendCorpsMemberFunction;
import com.imop.lj.gameserver.corps.function.member.ApplyPassCorpsMemberFunction;
import com.imop.lj.gameserver.corps.function.member.ApplyRefuseCorpsMemberFunction;
import com.imop.lj.gameserver.corps.function.member.FireCorpsMemberFunction;
import com.imop.lj.gameserver.corps.function.member.PrivateChatCorpsMemberFunction;
import com.imop.lj.gameserver.corps.function.member.SeeDetailCorpsMemberFunction;
import com.imop.lj.gameserver.corps.function.member.SendMailCorpsMemberFunction;
import com.imop.lj.gameserver.corps.function.member.SetMemberJobElite;
import com.imop.lj.gameserver.corps.function.member.SetMemberJobNormal;
import com.imop.lj.gameserver.corps.function.member.SetMemberJobViceChairman;
import com.imop.lj.gameserver.corps.function.member.TransferPresidentCorpsMemberFunction;

/**
 * 军团常量
 * 
 * @author xiaowei.liu
 * 
 */
public interface CorpsDef {
	public enum CorpsTypeEnum implements IGameFuncType, IndexedEnum {
		/** 申请加入帮派*/
		APPLY_CORPS_FUNCTION(701, new ApplyCorpsFunction()), 
		/** 取消申请加入帮派*/
		CANCEL_APPLY_CORPS_FUNCTION(702, new CancelApplyCorpsFunction()),
		/** 创建帮派*/
		CREATE_CORPS_FUNCTION(703, new CreateCorpsFunction()),
		/** 发送军团邮件*/
		CORPS_MAIL_FUNCTION(704, new CorpsMailFunction()),
		/** 修改军团公告*/
		CORPS_NOTICE_UPDATE_FUNCTION(705, new CorpsNoticeUpdateFunction()),
		/** 退出军团*/
		EXIT_CORPS_FUNCTION(706, new ExitCorpsFunction()),
		/** 申请团长职务*/
		APPLY_PRESIDENT_CORPS_FUNCTION(707, new ApplyPresidentCorpsFunction()),
		/** 忽略所有申请*/
		APPLY_IGNORE_CORPS_FUNCTION(708, new ApplyIgnoreCorpsFunction()),
		/** 解散军团*/
		DISBAND_CORPS_FUNCTION(709, new DisbandCorpsFunction()),
		/** 确认解散军团*/
		CONFIRM_DISBAND_CORPS_FUNCTION(710, new ConfirmDisbandCorpsFunction()),
		/** 撤销解散军团*/
		CANCLE_DISBAND_CORPS_FUNCTION(711, new CancleDisbandCorpsFunction()),
		/** 批量踢出成员*/
		BATCH_FIRE_CORPS_MEMBER_CORPS_FUNCTION(712, new BatchFireCorpsMemberCorpsFunction()),
		/** 批量添加成员*/
		BATCH_ADD_CORPS_MEMBER_CORPS_FUNCTION(713, new BatchAddCorpsMemberCorpsFunction()),
		;
		private int index;
		private AbstractCorpsFunction func;

		CorpsTypeEnum(int index, AbstractCorpsFunction func) {
			this.index = index;
			this.func = func;
		}

		@Override
		public int getIndex() {
			return index;
		}

		public AbstractCorpsFunction getFunc() {
			return func;
		}

	}

	public enum CorpsMemberTypeEnum implements IGameFuncType, IndexedEnum {
		/** 通过申请*/
		APPLY_PASS_CORPS_MEMBER_FUNCTION(801, new ApplyPassCorpsMemberFunction()),
		/** 拒绝申请*/
		APPLY_REFUSE_CORPS_MEMBER_FUCNTION(802, new ApplyRefuseCorpsMemberFunction()),
		/** 查看成员详细信息*/
		SEE_DETAIL_CORPS_MEMBER_FUNCTION(803, new SeeDetailCorpsMemberFunction()),
		/** 添加好友 TODO*/
		ADD_FRIEND_CORPS_MEMBER_FUNCTION(804, new AddFriendCorpsMemberFunction()),
		/** 发起私聊*/
		PRIVATE_CHAT_CORPS_MEMBER_FUNCTION(805, new PrivateChatCorpsMemberFunction()),
		/** 发送邮件*/
		SEND_MAIL_CORPS_MEMBER_FUNCTION(806, new SendMailCorpsMemberFunction()),
		/** 踢出成员*/
		FIRE_CORPS_MEMBER_FUNCTION(807, new FireCorpsMemberFunction()),
		/** 卸任团长职务*/
		TRANSFER_PRESIDENT_CORPS_MEMBER_FUNCTION(808, new TransferPresidentCorpsMemberFunction()),
		/** 指定职务给个人 精英*/
		SET_MEMBER_JOB_ELITE(809, new SetMemberJobElite()),
		/** 指定职务给个人 帮众*/
		SET_MEMBER_JOB_NORMAL(810, new SetMemberJobNormal()),
		/** 指定职务给个人 副团长*/
		SET_MEMBER_JOB_VICE_CHAIRMAN(811, new SetMemberJobViceChairman()),
		;

		private int index;
		private AbstractCorpsMemberFunction func;

		CorpsMemberTypeEnum(int index, AbstractCorpsMemberFunction func) {
			this.index = index;
			this.func = func;
		}

		@Override
		public int getIndex() {
			return index;
		}

		public AbstractCorpsMemberFunction getFunc() {
			return func;
		}

	}

	public enum MemberJob implements IndexedEnum {
		/** 非会员 */
		NONE(0, LangConstants.CORPS_NONE_MEMBER),
		/** 普通会员 */
		MEMBER(1, LangConstants.CORPS_MEMBER),
		/** 精英 */
		ELITE(2, LangConstants.CORPS_ELITE),
		/** 副会长 */
		VICE_CHAIRMAN(3, LangConstants.CORPS_VICE_CHAIRMAN),
		/** 会长 */
		PRESIDENT(4, LangConstants.CORPS_PRESIDENT),
		;
		private int index;
		private int langId;
		
		private static final List<MemberJob> values = IndexedEnumUtil.toIndexes(MemberJob.values());

		MemberJob(int index, int langId){
			this.index = index;
			this.langId = langId;
		}
		@Override
		public int getIndex() {
			return this.index;
		}

		public static MemberJob valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
		public int getLangId() {
			return langId;
		}
	}
	
	public enum BuildType implements IndexedEnum {
		/** 聚义堂 */
		JUYI(1, LangConstants.JUYI),
		/** 青龙堂 */
		QINGLONG(2, LangConstants.QINGLONG),
		/** 白虎堂 */
		BAIHU(3, LangConstants.BAIHU),
		/** 朱雀堂 */
		ZHUQUE(4, LangConstants.ZHUQUE),
		/** 玄武堂 */
		XUANWU(5, LangConstants.XUANWU),
		/** 养生堂 */
		YANGSHENG(6, LangConstants.YANGSHENG),
		/** 侍剑堂 */
		SHIJIAN(7, LangConstants.SHIJIAN),
		;
		private int index;
		private int langId;
		
		private static final List<BuildType> values = IndexedEnumUtil.toIndexes(BuildType.values());
		
		BuildType(int index, int langId){
			this.index = index;
			this.langId = langId;
		}
		@Override
		public int getIndex() {
			return this.index;
		}
		
		public static BuildType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
		public int getLangId() {
			return langId;
		}
	}
	
	/**
	 * 军团成员状态
	 * 
	 * @author xiaowei.liu
	 * 
	 */
	public enum CorpsMemberState implements IndexedEnum{
		/**无军团状态*/
		NONE(0),
		/**正常状态*/
		NORMAL(1),
		/**等待申批状态*/
		WAIT_APPLY(2),
		;
		private int index;
		
		private static final List<CorpsMemberState> values = IndexedEnumUtil.toIndexes(CorpsMemberState.values());
		
		private CorpsMemberState(int index) {
			this.index = index;
		}
		
		@Override
		public int getIndex() {
			return this.index;
		}
		
		public static CorpsMemberState valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
		
	}
	
	/**
	 * 军团事件类型
	 * 
	 * @author xiaowei.liu
	 * 
	 */
	public enum CorpsEventType implements IndexedEnum{
		/**捐献*/
		DONA_GOLD(1, LangConstants.EVENT_DONATE_PATTERN),
		/**新成员加入*/
	    NEW_MEMBER_JOIN(2, LangConstants.EVENT_NEW_MEMBER_JOIN_PATTERN),
	    /**成员退出*/
	    MEMBER_EXIT(3, LangConstants.EVENT_MEMBER_EXIT_PATTERN),
	    /**开除成员*/
	    DECAPITATE_MEMBER(4, LangConstants.EVENT_DECAPITATE_MEMBER_PATTERN),
	    /**升职*/
	    MEMBER_JOB_CHANGE(5, LangConstants.EVENT_JOB_CHANGE_PATTERN),
	    /**团长分配箱子*/
	    DISTRIBUTE_ITEM(6, LangConstants.EVENT_DISTRIBUTE_ITEM_PATTERN),
	    /** 帮派升级*/
	    UPGRADE_CORPS(7, LangConstants.EVENT_UPGRADE_CORPS_PATTERN),
	    /** 帮派降级*/
	    DEGRADE_CORPS(8, LangConstants.EVENT_DEGRADE_CORPS_PATTERN),
	    /** 帮派维护资金不足,通知次数+1 */
	    DELINQUENTNUM(9 ,LangConstants.CORPS_MAINTENANCE_COST_NOT_ENOUGH),
	    /** 帮派boss进度排行榜奖励 */
	    BOSS_RANK_REWARD(10 ,LangConstants.CORPS_BOSS_RANK_REWARD),
	    /** 帮派boss挑战次数排行榜奖励 */
	    BOSS_COUNT_RANK_REWARD(11 ,LangConstants.CORPS_BOSS_COUNT_RANK_REWARD),
	    /** 帮派红包超时*/
	    RED_ENVELOPE_OVER_DUE(12, LangConstants.EVENT_RED_ENVELOPE_OVER_DUE),
	    /**$4|72|{0}发放了帮派礼包，大家快去抢礼包吧$ */
	    BROADCAST_RED_ENVELOPE(13, LangConstants.BROADCAST_RED_ENVELOPE),
	    /** 帮派竞赛排行榜分配奖励 */
	    WAR_RANK_ALLOCATE_REWARD(14 ,LangConstants.WAR_RANK_ALLOCATE_REWARD),
	    ;

		private int index;
		private int pattern;
		
		private static final List<CorpsEventType> values = IndexedEnumUtil.toIndexes(CorpsEventType.values());
		
		CorpsEventType(int index, int pattern){
			this.index = index;
			this.pattern = pattern;
		}
		
		@Override
		public int getIndex() {
			return index;
		}
		
		public int getPattern() {
			return pattern;
		}

		public static CorpsEventType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
		
	}
	
	public static enum MemberAfterBattleStatus implements IndexedEnum {
		/** 退出帮派 */
		QUIT_CORPS(1),
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
	
	public enum CorpsEventNoticeType implements IndexedEnum{
		/**创建军团*/
		CREATED(1),
		/**退出军团*/
		EXIT(2),
		;

		private int index;
		CorpsEventNoticeType(int index){
			this.index = index;
		}
		@Override
		public int getIndex() {
			return this.index;
		}
		
	}
	
	public enum CultivateBatchType implements IndexedEnum{
		/**一次*/
		ONE(0),
		/**批量*/
		BATCH(1),
		;
		
		private int index;
		CultivateBatchType(int index){
			this.index = index;
		}
		@Override
		public int getIndex() {
			return this.index;
		}
		
		private static final List<CultivateBatchType> indexes = IndexedEnum.IndexedEnumUtil
				.toIndexes(CultivateBatchType.values());
		
		public static CultivateBatchType valueOf(final int index) {
			return EnumUtil.valueOf(indexes, index);
		}
		
	}
	
	public enum AssistGenType implements IndexedEnum{
		/**随机产出*/
		UNFIXED(0),
		/**固定产出*/
		FIXED(1),
		;
		
		private int index;
		AssistGenType(int index){
			this.index = index;
		}
		@Override
		public int getIndex() {
			return this.index;
		}
		
		private static final List<AssistGenType> indexes = IndexedEnum.IndexedEnumUtil
				.toIndexes(AssistGenType.values());

		public static AssistGenType valueOf(final int index) {
			return EnumUtil.valueOf(indexes, index);
		}
		
	}
	
	public enum AssistCritType implements IndexedEnum{
		/**不出暴击*/
		UNCRIT(0),
		/**出暴击*/
		CRIT(1),
		;
		
		private int index;
		AssistCritType(int index){
			this.index = index;
		}
		@Override
		public int getIndex() {
			return this.index;
		}
		
		private static final List<AssistCritType> indexes = IndexedEnum.IndexedEnumUtil
				.toIndexes(AssistCritType.values());
		
		public static AssistCritType valueOf(final int index) {
			return EnumUtil.valueOf(indexes, index);
		}
		
	}
	
	public enum SkillType implements IndexedEnum{
		/**影响宠物属性的技能*/
		PET(0),
		/**影响人物属性的技能*/
		PLAYER(1),
		;
		
		private int index;
		SkillType(int index){
			this.index = index;
		}
		@Override
		public int getIndex() {
			return this.index;
		}
		
		private static final List<SkillType> indexes = IndexedEnum.IndexedEnumUtil
				.toIndexes(SkillType.values());
		
		public static SkillType valueOf(final int index) {
			return EnumUtil.valueOf(indexes, index);
		}
		
	}
	
	public enum CultivateSkillType implements IndexedEnum{
		/**人物攻击*/
		PLAYER_ATT(8001),
		/**人物防御*/
		PLAYER_DEF(8002),
		/**人物气血*/
		PLAYER_HP(8003),
		/**人物内力*/
		PLAYER_MP(8004),
		/**宠物攻击*/
		PET_ATT(8005),
		/**宠物防御*/
		PET_DEF(8006),
		/**宠物气血*/
		PET_HP(8007),
		/**宠物内力*/
		PET_MP(8008),
		;
		
		private int index;
		CultivateSkillType(int index){
			this.index = index;
		}
		@Override
		public int getIndex() {
			return this.index;
		}
		
		private static final List<CultivateSkillType> indexes = IndexedEnum.IndexedEnumUtil
				.toIndexes(CultivateSkillType.values());
		
		public static CultivateSkillType valueOf(final int index) {
			return EnumUtil.valueOf(indexes, index);
		}
		
	}
	
	public enum AssistSkillType implements IndexedEnum{
		/**烹饪*/
		COOK(9001),
		/** 制药*/
		MEDICINE(9002),
		/** 打造*/
		BUILD(9003),
		/** 裁缝*/
		CLOTH(9004),
		/** 制皮*/
		LEATHER(9005),
		;
		
		private int index;
		AssistSkillType(int index){
			this.index = index;
		}
		@Override
		public int getIndex() {
			return this.index;
		}
		
		private static final List<AssistSkillType> indexes = IndexedEnum.IndexedEnumUtil
				.toIndexes(AssistSkillType.values());
		
		public static AssistSkillType valueOf(final int index) {
			return EnumUtil.valueOf(indexes, index);
		}
		
	}
	
	
	/**
	 * 军团列表功能列表(申请，撤销)
	 */
	public static CorpsTypeEnum[] corspListFuncList = new CorpsTypeEnum[]{CorpsTypeEnum.APPLY_CORPS_FUNCTION, CorpsTypeEnum.CANCEL_APPLY_CORPS_FUNCTION};
	/**
	 * 军团列表面板功能列表（创建军团）
	 */
	public static CorpsTypeEnum[] corpsListPanelFuncList = new CorpsTypeEnum[]{CorpsTypeEnum.CREATE_CORPS_FUNCTION};
	/**
	 * 军团信息面板军团相关功能（军团邮件-仅控制显示，修改-仅控制显示，退出军团）
	 */
	public static CorpsTypeEnum[] corpsPanelFuncList = new CorpsTypeEnum[]{CorpsTypeEnum.CORPS_MAIL_FUNCTION, CorpsTypeEnum.CORPS_NOTICE_UPDATE_FUNCTION, CorpsTypeEnum.EXIT_CORPS_FUNCTION, CorpsTypeEnum.APPLY_IGNORE_CORPS_FUNCTION};
	/**
	 * 成员列表军团功能（申请团长）
	 */
	public static CorpsTypeEnum[] memListCorpsFuncList = new CorpsTypeEnum[]{CorpsTypeEnum.APPLY_PRESIDENT_CORPS_FUNCTION};
	/**
	 * 申请列表功能(通过申请，拒绝申请)
	 */
	public static CorpsMemberTypeEnum[] applyListCorpsMemFuncList = new CorpsMemberTypeEnum[]{CorpsMemberTypeEnum.APPLY_PASS_CORPS_MEMBER_FUNCTION, CorpsMemberTypeEnum.APPLY_REFUSE_CORPS_MEMBER_FUCNTION};
	/**
	 * 成员列表成员功能(查看信息，加为好友，发起私聊，发送邮件，开除成员，转让团长, 设置为精英，设置为帮众，设置为副帮主)
	 */
	public static CorpsMemberTypeEnum[] memListCorpsMemFuncList = new CorpsMemberTypeEnum[]{CorpsMemberTypeEnum.SEE_DETAIL_CORPS_MEMBER_FUNCTION, 
		CorpsMemberTypeEnum.ADD_FRIEND_CORPS_MEMBER_FUNCTION, CorpsMemberTypeEnum.PRIVATE_CHAT_CORPS_MEMBER_FUNCTION, 
		CorpsMemberTypeEnum.SEND_MAIL_CORPS_MEMBER_FUNCTION, CorpsMemberTypeEnum.FIRE_CORPS_MEMBER_FUNCTION, CorpsMemberTypeEnum.TRANSFER_PRESIDENT_CORPS_MEMBER_FUNCTION,
		CorpsMemberTypeEnum.SET_MEMBER_JOB_NORMAL,CorpsMemberTypeEnum.SET_MEMBER_JOB_ELITE,CorpsMemberTypeEnum.SET_MEMBER_JOB_VICE_CHAIRMAN};
}
