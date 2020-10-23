package com.imop.lj.gameserver.func;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;

public interface FuncDef {
	
	/**
	 * 
	 * @author Administrator
	 *
	 */
	public enum FuncTypeEnum implements IndexedEnum {
		/** 任务功能 */
		QUEST(1, FuncFactory.QuestFuncFactory),
		/** 队伍功能 */
		TEAM(2, FuncFactory.TeamFuncFactory),
		/** 挂机功能 */
		HANG(3, FuncFactory.HangFuncFactory),
		/** 活动按钮 */
		ACTIVITY_UI(4, FuncFactory.ActivityUIFuncFactory),
		/** 竞技场按钮 */
		ARENA(5, FuncFactory.ArenaFuncFactory),
		/** 酒馆功能 */
		PUB(6, FuncFactory.PubFuncFactory),
		/** 科举功能 */
		EXAM(7, FuncFactory.ExamFuncFactory),
		/** 系统功能 */
		SYS(8, FuncFactory.SysFuncFactory),
		/**商城(宠物商店)*/
		MALL(9, FuncFactory.MallFuncFactory),
		/** 商会	功能 */
		BUSINESS(10, FuncFactory.BusinessFuncFactory),
		/** 拍卖行功能 */
		TRADE(11, FuncFactory.TradeFuncFactory),
		/** 充值功能 */
		PAY(12, FuncFactory.PayFuncFactory),
		/** 悟性功能 */
		PERCEPT(13, FuncFactory.PerceptFuncFactory),
		/** 背包功能 */
		INVENTORY(14, FuncFactory.InventoryFuncFactory),
		/** 心法技能功能 */
		MINDSKILL(15, FuncFactory.MindSkillFuncFactory),
		/** 帮派功能 */
		CORPS(16, FuncFactory.CorpsFuncFactory),
		/** 伙伴 */
		PARTNER(17, FuncFactory.PartnerFuncFactory),
		/** 阵型 */
		FORMATION(18, FuncFactory.FormationFuncFactory),
		/** 排行 */
		RANK(19, FuncFactory.RankFuncFactory),
		/** 打造 */
		CRAFT(20, FuncFactory.CraftFuncFactory),
		/** 升星 */
		UPSTAR(21, FuncFactory.UpstarFuncFactory),
		/** 宝石镶嵌 */
		GEM_EQUIP(22, FuncFactory.GemEquipFuncFactory),
		/** 宝石合成 */
		GEM_SYNTHESIS(23, FuncFactory.GemSynthesisFuncFactory),
		/** 强化 */
		INTENSIFY(24, FuncFactory.IntensifyFuncFactory),
		/** 分解 */
		DECOMPOSE(25, FuncFactory.DecomposeFuncFactory),
		/** 重铸 */
		RECAST(26, FuncFactory.RecastFuncFactory),
		/** 炼化 */
		REFINE(27, FuncFactory.RefineFuncFactory),
		/** 灌注 */
		POUR(28, FuncFactory.PourFuncFactory),
		/** 传承 */
		INHERIT(29, FuncFactory.InheritFuncFactory),
//		/** 奖励 */
//		GIFT(30, FuncFactory.GiftFuncFactory),
		/** 每日签到 */
		DAILY_SIGN(31, FuncFactory.DailySignFuncFactory),
		/** 登陆奖励 */
		LOGIN_GIFT(32, FuncFactory.LoginGiftFuncFactory),
		/** 在线奖励 */
		ONLINE_GIFT(33, FuncFactory.OnlineGiftFuncFactory),
		/** 邮件 */
		MAIL(34, FuncFactory.MailFuncFactory),
		/** 好友 */
		RELATION(35, FuncFactory.RelationFuncFactory),
		/** 成就 */
		ACHIEVEMENT(36, FuncFactory.AchievementFuncFactory),
		/** 提升 */
		PROMOTE(37, FuncFactory.PromoteFuncFactory),
		
		/** 下面的暂时用不到*/
		/** GM补偿 */
		USER_PRIZE(38, FuncFactory.UserPrizeFuncFactory),
		/** 神秘商店 */
		MYSTERY_SHOP(39, FuncFactory.MysteryShopFuncFactory),
		/** 精彩活动 */
		GOOD_ACTIVITY(40, FuncFactory.GoodActivityFuncFactory),
		/** VIP */
		VIP(41, FuncFactory.VipFuncFactory),
		/** 金券套餐 */
		CHARGE_ITEM(42, FuncFactory.ChargeItemFuncFactory),
		/** 特殊在线礼包 */
		SPEC_ONLINE_GIFT(43, FuncFactory.SpecOnlineGiftFuncFactory),
		
		/** 骑宠 */
		HORSE(44, FuncFactory.HorseFuncFactory),
		/** 挖矿*/
		MINE(45, FuncFactory.MineFuncFactory),
		/** 除暴安良功能 */
		THE_SWEENEY(46, FuncFactory.TheSweeneyFuncFactory),
		/** 绿野仙踪 */
		WIZARD_RAID(47, FuncFactory.WizardRaidFuncFactory),
		/** 藏宝图功能 */
		TREASURE_MAP(48, FuncFactory.TreasureMapFuncFactory),
		/** 称号系统 */
		TITLE(49,FuncFactory.TitleFuncFactory),
		/** 帮派竞赛 */
		CORPSWAR(50, FuncFactory.CorpsWarFuncFactory),
		/** 护送粮草 */
		FORAGE(51,FuncFactory.ForageFuncFactory),
		/** 师徒 */
		OVERMAN(52,FuncFactory.OvermanFuncFactory),
		/** 结婚 */
		MARRY(53,FuncFactory.MarryFuncFactory),
		/** nvn联赛 */
		NVN(54, FuncFactory.NvnFuncFactory),
		/** 宠物岛 */
		PET_ISLAND(55, FuncFactory.PetIslandFuncFactory),
		/**翅膀*/
		WING(56, FuncFactory.WingFuncFactory),
		/**帮派任务*/
		CORPSTASK(57, FuncFactory.CorpsTaskFactory),
		/**帮派建设*/
		CORPSBUILD(58, FuncFactory.CorpsBuildFactory),
		/**帮派福利*/
		CORPSBENIFIT(59, FuncFactory.CorpsBenefitFactory),
		/** 渠道兑奖码 */
		CHANNEL_EXCHANGE(60, FuncFactory.ChannelExchangeFactory),
		/** 通天塔 */
		TOWER(61, FuncFactory.TowerFactory),
		/** 帮派活动 */
		CORPS_ACTIVITY(62, FuncFactory.CorpsActivityFactory),
		/** 帮派boss */
		CORPS_BOSS(63, FuncFactory.CorpsBossFactory),
		/** 野外小妖 */
		SEAL_DEMON(64, FuncFactory.SealDemonFactory),
		/** 野外魔王 */
		SEAL_DEMON_KING(65, FuncFactory.SealDemonKingFactory),
		/** 混世魔王 */
		DEVIL_INCARNATE(66, FuncFactory.DevilIncarnateFactory),
		/** 限时答题 */
		TIME_LIMIT_EXAM(67, FuncFactory.TimeLimitExamFactory),
		/** 限时杀怪 */
		TIME_LIMIT_MONSTER(68, FuncFactory.TimeLimitMonsterFactory),
		/** 限时挑战NPC */
		TIME_LIMIT_NPC(69, FuncFactory.TimeLimitNpcFactory),
		/** 帮派修炼*/
		CORPS_CULTIVATE(70, FuncFactory.CorpsCultivateFactory),
		/** 帮派辅助技能*/
		CORPS_ASSIST(71, FuncFactory.CorpsAssistFactory),
		/** 帮派红包*/
		CORPS_RED_ENVELOPE(72, FuncFactory.CorpsRedEnvelopeFactory),
		/** 七日目标 */
		DAY7_TARGET(73, FuncFactory.Day7TargetFactory),
		/** 分配帮派竞赛活动物品*/
		ALLOCATE_CORPS_WAR_STORAGE(74, FuncFactory.AllocateCorpsWarStorageFactory),
		/** 剧情副本*/
		PLOT_DUNGEON(75, FuncFactory.PlotDungeonFactory),
		/** 精彩活动2 */
		GOOD_ACTIVITY2(76, FuncFactory.GoodActivity2FuncFactory),
		/** 围剿魔族普通*/
		SIEGE_DEMON_NORMAL(77, FuncFactory.SiegeDemonNormalFuncFactory),
		/** 围剿魔族困难*/
		SIEGE_DEMON_HARD(78, FuncFactory.SiegeDemonHardFuncFactory),
		;

		private FuncTypeEnum(int index, IFuncFactory funcFactory) {
			this.index = index;
			this.funcFactory = funcFactory;
		}
		
		private int index;
		/** 对应的功能对象 */
		private final IFuncFactory funcFactory;

		@Override
		public int getIndex() {
			return index;
		}
		
		private static final List<FuncTypeEnum> values = IndexedEnumUtil.toIndexes(FuncTypeEnum.values());

		public static FuncTypeEnum valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
		
		/**
		 * 获得功能对象
		 *
		 * @return
		 */
		public IFuncFactory getFuncFactory() {
			return this.funcFactory;
		}
	}
	
}
