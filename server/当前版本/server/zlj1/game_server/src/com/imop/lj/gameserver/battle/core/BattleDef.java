package com.imop.lj.gameserver.battle.core;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;
import com.imop.lj.gameserver.battle.config.SingleFightConfig;
import com.imop.lj.gameserver.battle.config.TestFightConfig;
import com.imop.lj.gameserver.battle.convertor.*;
import com.imop.lj.gameserver.battlereport.BattleReportDefine;

import java.util.List;

/**
 * 战斗常量定义
 */
public interface BattleDef {
	
	/** 战斗最长时间，30分钟 */
	public static final int BATTLE_MAX_TIME = 30 * 60 * 1000;
	/** 两次碰怪直接的最小时间间隔，5秒钟 */
	public static final int MIN_TO_LAST_BATTLE = 5000;
	
	/** 技能默认的表现时间 */
	public static final int SKILL_PERFORM_TIME_DEFAULT = 5000;
	
	/** 每轮选择技能的最长时间 30秒 */
	public static final int CHOOSE_SKILL_MAX_TIME = 30000;
	/** 每轮自动选择技能的最长时间 3秒 */
	public static final int CHOOSE_SKILL_AUTO_TIME = 3000;
	/** 修正时间 2秒 */
	public static final int DELAY_TIME = 2000;

	public static final String SPLIT_ELEMENT = ",";

	public static final String SPLIT_ATTRIBUTE = ":";
	
	public static final int POS_ADD = 100;
	
	/** 主将默认的位置 */
	public static final int LEADER_POS_DEFAULT = 1;
	/** 宠物默认的位置 */
	public static final int PET_POS_DEFAULT = 6;
	
	/** 普通攻击技能id */
	public static final int NORMAL_ATTACK_SKILL_ID = 1;
	/** 技能默认等级 */
	public static final int DEFAULT_SKILL_LEVEL = 1;
	/** 捕捉宠物技能id */
	public static final int CATCH_PET_SKILL_ID = 2;
	/** 防御技能id */
	public static final int DEFENCE_SKILL_ID = 3;
	/** 逃跑技能id */
	public static final int ESCAPE_SKILL_ID = 4;
	/** 嗑药技能id */
	public static final int USEDRUGS_SKILL_ID = 5;
	/** 召唤技能id */
	public static final int SUMMON_PET_SKILL_ID = 6;
	
	/** 生命 */
	public static final String HP = "hp";
	/** 魔法 */
	public static final String MP = "mp";
	/** 怒气 */
	public static final String SP = "sp";
	/** 寿命 */
	public static final String LIFE = "lf";
	
	public static final String MAX = "_max";
	
	/** 速度 */
	public static final String SPEED = "speed";
	
	/** 物理攻击 */
	public static final String PHYSICAL_ATTACK = "pa";
	/** 物理防御 */
	public static final String PHYSICAL_ARMOR = "par";
	/** 物理命中 */
	public static final String PHYSICAL_HIT = "ph";
	/** 物理闪避 */
	public static final String PHYSICAL_DODGY= "pd";
	/** 物理暴击 */
	public static final String PHYSICAL_CRIT = "pc";
	/** 物理抗暴 */
	public static final String PHYSICAL_ANTICRIT = "pac";
	
	/** 法术攻击 */
	public static final String MAGIC_ATTACK = "ma";
	/** 法术防御 */
	public static final String MAGIC_ARMOR = "mar";
	/** 法术命中 */
	public static final String MAGIC_HIT = "mh";
	/** 法术闪避 */
	public static final String MAGIC_DODGY= "md";
	/** 法术暴击 */
	public static final String MAGIC_CRIT = "mc";
	/** 法术抗暴 */
	public static final String MAGIC_ANTICRIT = "mac";
	
	/** 取消 */
	public static final String CANCEL = "cancel";
	
	/** 触发连击*/
	public static final String TRIGGER_DOUBLE_ATTACK = "tri_double";
	/** 连击*/
	public static final String DOUBLE_ATTACK = "double";
	
	
	/**
	 * 战斗阶段定义
	 * 
	 */
	public static enum Phase implements IndexedEnum {
		/** 战斗开始 */
		BATTLE_START(11),
		/** 战斗中 */
		BATTLE_IN_PROGRESS(12),
		
		/** 回合开始 */
		ROUND_START(21),
		/** 出手排序 */
		ROUND_SEQUENCE(22),
		/** 回合中 */
		ROUND_IN_PROGRESS(23),
		
		/** 行动开始 */
		ACTION_START(31),
		/** 行动对应目标 */
		ACTION_TARGET(32),
		/** 行动目标后 */
		ACTION_TARGET_AFTER(34),
		/** 行动执行 */
		ACTION_EXECUTE(33),
		/** 防守 */
		ACTION_DEFENCE(37),
		/** 行动调整 */
		ACTION_ADJUST(38),
		/** 行动结束 */
		ACTION_END(39),
		
		/** 行动执行后 */
		ACTION_EXECUTE_AFTER(40),
//		/** 行动执行后又触发的效果（如宠物天赋技能的所有攻击都可能触发加buff） */
//		ACTION_EXECUTE_AFTER_AFTER(41),
//		/** 防守后 */
//		ACTION_DEFENCE_AFTER(42),
		
		/** 回合结束 */
		ROUND_END(24),
		
		/** 战斗结束 */
		BATTLE_END(13),

		/** 调试 */
		DEBUG(99), 
		;

		private Phase(int index) {
			this.index = index;
		}

		public final int index;

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<Phase> values = IndexedEnumUtil.toIndexes(Phase.values());

		public static Phase valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
	
	/**
	 * 效果类型
	 */
	public enum EffectType implements IndexedEnum {
		/** 普通攻击 */
		NormalAttack(0),
		/** 带系数伤害 */
		AttackCoef(1),
		/** 加buff */
		AddBuff(2),
		/** 解buff */
		DelBuff(3),
		/** 复活 */
		Revive(4),
		/** 反击 */
		DefenceAttack(5),
		/** 连击 */
		DoubleAttackWithValue(6),
		/** 捕捉宠物 */
		CatchPet(7),
		/** 防御 */
		Defence(8),
		
		/** 伏魔刀法1 */
		Fumo1Main(9),
		/** 伏魔刀法2 */
		Fumo2Main(10),
		/** 加buff，带参数 */
		AddBuffParam(11),
		/** 烈焰风暴主效果 */
		LieyanMain(12),
		/** 回复 */
		Recover(13),
		/** 概率清除n个随机DEBUFF */
		RemoveRandDebuff(14),
		/** 所有主动攻击时触发加buff */
		AddBuffFromAllAttack(15),
		/** 带参数的反击 */
		DefenceAttackParam(16),
		/** 宠物天赋技能主效果 */
		PetTalentMain(17),
		/** 撤退 */
		Escape(18),
		/** 嗑药 */
		UseDrugs(19),
		/** 召唤宠物 */
		SummonPet(20),
		
		/** 一次出手中增加攻击类属性，仙符数值型 */
		AddAttrInAction(21),
		
		/** 吸 参数(hp,mp等)攻击*/
		Suck(22),
		/** 加buff之前需要消耗自身hp或者mp*/
		AddBuffWithCost(23),
		/** 牺牲*/
		Sacrifice(24),
		/** 以血还血*/
		BloodForBlood(25),
		/** 法力灼烧*/
		MpBurn(26),
		/** 反伤 */
		DefenceWithValue(27),
		/** 宠物普通技能主效果 */
		PetNormalMain(28),
		
		/** buff自身 */
		BuffSelf(99),
		;

		public final int index;

		@Override
		public int getIndex() {
			return index;
		}

		private EffectType(int index) {
			this.index = index;
		}

		private static final List<EffectType> values = IndexedEnumUtil.toIndexes(EffectType.values());

		public static EffectType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
	
	/**
	 * 目标类型
	 */
	public enum TargetType implements IndexedEnum {
		/** 敌方 */
		ENEMY(1),
		/** 己方 */
		OUR(2),
		/** 自己 */
		MYSELF(3),
		/** 主将 */
		LEADER(4),
		/** 宠物 */
		PET(5),
		/** 敌方可捕捉单位 */
		ENEMY_CAN_CATCH(6),
		
		/** 己方死亡单位 */
		OUR_DEAD(7),
		/** 己方含死亡单位 */
		OUR_ALL(8),
		
		/** 属于自己的所有单位 */
		MY_OWN_ALL(9),
		
		;

		public final int index;

		@Override
		public int getIndex() {
			return index;
		}

		private TargetType(int index) {
			this.index = index;
		}

		private static final List<TargetType> values = IndexedEnumUtil.toIndexes(TargetType.values());

		public static TargetType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
	
	/**
	 * 目标范围类型
	 * @author Administrator
	 *
	 */
	public enum RangeType implements IndexedEnum {
		/** 随机 */
		RANDOM(1),
		/** 单体 */
		ONE(2),
		/** 全体 */
		ALL(3),
		/** 十字 */
		CROSS(4),
		
		;

		public final int index;

		@Override
		public int getIndex() {
			return index;
		}

		private RangeType(int index) {
			this.index = index;
		}

		private static final List<RangeType> values = IndexedEnumUtil.toIndexes(RangeType.values());

		public static RangeType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}


	/**
	 * 效果数值类型
	 * @author Administrator
	 *
	 */
	public enum EffectValueType implements IndexedEnum {
		/** 生命 */
		HP(1),
		/** 魔法 */
		MP(2),
		/** 怒气 */
		SP(3),
		/** 攻击，按攻击类型 */
		ATTACK(4),
		/** 防御，按攻击类型 */
		DEFEND(5),
		/** 速度 */
		SPEED(6),
		
		/** 生命上限 */
		HP_MAX(7),
		/** 速度上限 */
		SPEED_MAX(8),
		
		/** 物理防御和法术防御 */
		ALL_DEFENCE(9),
		/** 暴击值 */
		CRIT(10),
		/** 法术暴击值 */
		MAGIC_CRIT(11),
		/** 物理暴击值 */
		PHYSICAL_CRIT(12),
		/** 法术攻击 */
		MAGIC_ATTACK(13),
		/** 物理攻击 */
		PHYSICAL_ATTACK(14),
		/** 法术命中 */
		MAGIC_HIT(15),
		/** 物理命中 */
		PHYSICAL_HIT(16),
		/** 物理闪避和法术闪避 */
		ALL_DODGY(17),
		
		/** 伤害吸收盾 */
		HURT_SHIELD(98),
		/** 状态，如眩晕，沉默等 */
		STATUS(99),
		;

		public final int index;

		@Override
		public int getIndex() {
			return index;
		}

		private EffectValueType(int index) {
			this.index = index;
		}

		private static final List<EffectValueType> values = IndexedEnumUtil.toIndexes(EffectValueType.values());

		public static EffectValueType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
	
	/**
	 * 数值类型
	 * @author Administrator
	 *
	 */
	public enum ValueType implements IndexedEnum {
		/** 百分比 */
		PERCENT(1),
		/** 绝对值 */
		LITERAL(2),
		
		;

		public final int index;

		@Override
		public int getIndex() {
			return index;
		}

		private ValueType(int index) {
			this.index = index;
		}

		private static final List<ValueType> values = IndexedEnumUtil.toIndexes(ValueType.values());

		public static ValueType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
	
	/**
	 * 触发条件类型
	 * @author Administrator
	 *
	 */
	public enum TriggerCondType implements IndexedEnum {
		/**无*/
		NONE(0),
		/** 生命值低于【百分比】 */
		SELF_LIFE_LESS_PERCENT(1),
		/** 自己生命值高于任一效果目标 */
		SELF_LIFE_MORE_TARGET(2),
		/** 任一效果目标死亡后 */
		SELF_TARGET_DIE(3),
		/** 任一队友死亡后，自己触发，被动 */
		SELF_FRIEND_DIE_SELF(4),
		/** 自己受到攻击后 */
		SELF_AFTER_DAMAGE(5),
		/** 命中后【概率】触发，在结算对目标伤害之后 */
		SELF_AFTER_HIT_TARGET_PROB(6),
		
		;

		public final int index;

		@Override
		public int getIndex() {
			return index;
		}

		private TriggerCondType(int index) {
			this.index = index;
		}

		private static final List<TriggerCondType> values = IndexedEnumUtil.toIndexes(TriggerCondType.values());

		public static TriggerCondType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
	
	/**
	 * buff大类
	 * @author yu.zhao
	 *
	 */
	public enum BuffCatalog implements IndexedEnum {
		NONE(0),
		/** 基础类型 */
		BASE(1),
		/** 带参数类型 */
		PARAM(2),
		/** 带参数类型1 */
		PARAM_1(3),
		/** 带参数类型2 */
		PARAM_2(4),
		/** 伤害吸收盾 */
		HURT_SHIELD(5),
		/** 宠物天赋类型1 */
		PET_TALENT_1(6),
		/** 指定吸收值的伤害吸收盾 */
		HURT_SHIELD_WITH_VALUE(7),
		;

		public final int index;

		@Override
		public int getIndex() {
			return index;
		}

		private BuffCatalog(int index) {
			this.index = index;
		}

		private static final List<BuffCatalog> values = IndexedEnumUtil.toIndexes(BuffCatalog.values());

		public static BuffCatalog valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
	
	/**
	 * 战斗对象标识类型
	 */
	public static enum FighterType implements IndexedEnum {
		/**布阵中玩家战队*/
		FORMATION(1, new FormationConvertor()),
		/** 离线玩家战队 */
		OFFLINE(2, new OfflineConvertor()),
//		/**有援军的玩家战队*/
//		SUPPORT(3, new SupportConvertor()),
		/** pve敌人对象 */
		ENEMY(4, new EnemyConvertor()),
		
		/** 组队的玩家战队 */
		TEAM(5, new TeamConvertor()),
		
		/** 绿野仙踪-单人 */
		WIZARDRAID_SINGLE(6, new FormationConvertor()),
		/** 绿野仙踪-组队 */
		WIZARDRAID_TEAM(7, new TeamConvertor()),
		
		/** 竞技场机器人 */
		ARENA_ROBOT(8, new ArenaRobotConvertor()),
		
		/** 测试对象 */
		TEST(99, new TestConvertor()),
		;

		private FighterType(int index, UnitConvertor convertor) {
			this.index = index;
			this.convertor = convertor;
		}

		public final int index;
		private UnitConvertor convertor;

		@Override
		public int getIndex() {
			return index;
		}

		public UnitConvertor getConvertor() {
			return convertor;
		}

		private static final List<FighterType> values = IndexedEnumUtil.toIndexes(FighterType.values());

		public static FighterType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
	
	/**
	 * 战斗结果定义
	 * 
	 */
	public static enum BattleResult implements IndexedEnum {
		/** 平局 */
		TIE(0),
		/** 攻击方胜 */
		ATTACKER(1),
		/** 防守方胜 */
		DEFENDER(2),
		;

		private BattleResult(int index) {
			this.index = index;
		}

		public final int index;

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<BattleResult> values = IndexedEnumUtil.toIndexes(BattleResult.values());

		public static BattleResult valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
	
	

	/**
	 * 战斗结果定义
	 * 
	 */
	public static enum BattleType implements IndexedEnum {
		/** 单人战斗 */
		SINGLE(1, new SingleFightConfig(), 0, 10, false, false),
		/** 关卡战斗 */
		MISSION(2, new SingleFightConfig(), 2, 10, false, false),
		/** 副本战斗 */
		RAID(3, new SingleFightConfig(), 3, 10, false, false), 
		/** 竞技场战斗，主将和宠物自动选技能 */
		ARENA(5, new SingleFightConfig(), 5, 10, true, false),
		
		/** PVP战斗 */
		PVP(6, new SingleFightConfig(), 6, 50, false, false),
		
		/** 组队战斗 */
		TEAM(7, new SingleFightConfig(), 7, 10, false, false),
		
		/** 组队PVP战斗 */
		TEAM_PVP(8, new SingleFightConfig(), 8, 50, false, false),
		/** 军团战组队PVP战斗 */
		CORPS_WAR_TEAM_PVP(9, new SingleFightConfig(), 9, 50, false, false),
		/** nvn联赛组队PVP战斗，伙伴不上阵 */
		NVN_TEAM_PVP(10, new SingleFightConfig(), 10, 50, false, true),
		/** 剧情副本战斗 */
		PLOT_DUNGEON(11, new SingleFightConfig(), 75, 10, false, false),
		/** 帮派boss战斗 */
		CORPS_BOSS(12, new SingleFightConfig(), 63, 10, false, false),

		
		/** 测试战斗 */
		TEST(99, new TestFightConfig(), 0, 10, false, false), 
		;

		private BattleType(int index, IFightConfig fightConfig, 
				int toBackType, int maxUseDrugsTimes, boolean isAutoSelSkill, boolean exceptFriend) {
			this.index = index;
			this.fightConfig = fightConfig;
			this.toBackType = toBackType;
			this.maxUseDrugsTimes = maxUseDrugsTimes;
			this.isAutoSelSkill = isAutoSelSkill;
			this.exceptFriend = exceptFriend;
		}

		public final int index;

		private IFightConfig fightConfig;
		/** 前台需要的返回类型 */
		private int toBackType;
		
		/** 最大嗑药次数 */
		private int maxUseDrugsTimes;
		
		/** 是否自动选择技能 */
		private boolean isAutoSelSkill;
		
		/** 是否不让伙伴上 */
		private boolean exceptFriend;

		@Override
		public int getIndex() {
			return index;
		}

		public IFightConfig getFightConfig() {
			return fightConfig;
		}
		
		public int getToBackType() {
			return toBackType;
		}

		public int getMaxUseDrugsTimes() {
			return this.maxUseDrugsTimes;
		}
		
		public boolean isAutoSelSkill() {
			return isAutoSelSkill;
		}

		public boolean isExceptFriend() {
			return exceptFriend;
		}

		private static final List<BattleType> values = IndexedEnumUtil.toIndexes(BattleType.values());

		public static BattleType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}

	/**
	 * 战斗状态定义
	 */
	public static enum BattleStatus implements IndexedEnum {
		/** 战斗准备 */
		PREPARE(1),
		/** 战斗中 */
		IN_PROGRESS(2),
		/** 战斗结束 */
		END(3);
		;

		private BattleStatus(int index) {
			this.index = index;
		}

		public final int index;

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<BattleStatus> values = IndexedEnumUtil.toIndexes(BattleStatus.values());

		public static BattleStatus valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}

	/**
	 * 回合状态定义
	 */
	public static enum RoundStatus implements IndexedEnum {
		/** 回合准备 */
		PREPARE(1),
		/** 回合中 */
		IN_PROGRESS(2),
		/** 回合结束 */
		END(3);
		;

		private RoundStatus(int index) {
			this.index = index;
		}

		public final int index;

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<RoundStatus> values = IndexedEnumUtil.toIndexes(RoundStatus.values());

		public static RoundStatus valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}

	/**
	 * 战报类型
	 * 
	 * 
	 * 
	 */
	public static enum ReportType implements IndexedEnum {
		/** 战斗 */
		BATTLE(1),
		/** 回合 */
		ROUND(2),
		/** 轮次 */
		ACTION(3),

		/** 调试 */
		DEBUG(99), 
		;

		private ReportType(int index) {
			this.index = index;
		}

		public final int index;

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<ReportType> values = IndexedEnumUtil.toIndexes(ReportType.values());

		public static ReportType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
	
	

	/**
	 * 动作技能类型
	 * 
	 * 
	 * 
	 */
	public enum ActionSkillType implements IndexedEnum {
		/** 默认类型 */
		DEFAULT(0),
		/** 力量相关 */
		STRENGTH(1),
		/** 敏捷相关 */
		AGILITY(2),
		/** 智力相关 */
		INTELLECT(3),
		/** 怒气相关 */
		ANGER(4),
		/** 移动位置相关 */
		POSITION(5),
		/** 控制相关 */
		CONTROL(6),
		/** 增益相关 */
		POSITIVE(7),
		/** 减益相关 */
		NEGATIVE(8),
		/**职业类型*/
		JOB(9);

		public final int index;

		@Override
		public int getIndex() {
			return index;
		}

		private ActionSkillType(int index) {
			this.index = index;
		}

		private static final List<ActionSkillType> values = IndexedEnumUtil.toIndexes(ActionSkillType.values());

		public static ActionSkillType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}

	

	/**
	 * buff更改的类型的作用对象
	 * 
	 * 
	 * 
	 */
	public enum AlterableType implements IndexedEnum {
		/** 更改FightUnit中的attacks或defenses */
		ATTRIBUTE(1),
		/** 更改FightUnit中的BUFF */
		BUFF(2),
		/** 更改FightUnit中的RATE */
		RATE(3),
		/** 更改FightUnit中的MAX */
		MAX(4),
		/** 更改FightUnit中的状态 */
		STATUS(5),
		;

		public final int index;

		@Override
		public int getIndex() {
			return index;
		}

		private AlterableType(int index) {
			this.index = index;
		}

		private static final List<AlterableType> values = IndexedEnumUtil.toIndexes(AlterableType.values());

		public static AlterableType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
	
	/**
	 * 恢复类型
	 */
	public enum RecoverType implements IndexedEnum {
		/** hp恢复*/
		HP(1), 
		/** 怒气恢复*/
		ANGER(2);
		;

		public final int index;

		@Override
		public int getIndex() {
			return index;
		}

		private RecoverType(int index) {
			this.index = index;
		}

		private static final List<RecoverType> values = IndexedEnumUtil.toIndexes(RecoverType.values());

		public static RecoverType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
	
	/**
	 * Buff状态
	 *
	 */
	public enum BuffState implements IndexedEnum{
		/** 添加 */
		ADD(1), 
		/** 执行中 */
		ING(2),
		/** 删除 */
		REMOVE(3),
		;

		public final int index;

		@Override
		public int getIndex() {
			return index;
		}

		private BuffState(int index) {
			this.index = index;
		}

		private static final List<BuffState> values = IndexedEnumUtil.toIndexes(BuffState.values());

		public static BuffState valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
		
	}
	
	public enum ReportMsgType implements IndexedEnum {
		/** 战斗开始的战报 */
		START(0), 
		/** 每轮战报 */
		ROUND(1),
		
		;

		public final int index;

		@Override
		public int getIndex() {
			return index;
		}

		private ReportMsgType(int index) {
			this.index = index;
		}

		private static final List<ReportMsgType> values = IndexedEnumUtil.toIndexes(ReportMsgType.values());

		public static ReportMsgType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
	
	public enum SideType implements IndexedEnum {
		NONE(0), 
		/** 攻击方 */
		ATTACKER(1),
		/** 防守方 */
		DEFENDER(2),
		;

		public final int index;

		@Override
		public int getIndex() {
			return index;
		}

		private SideType(int index) {
			this.index = index;
		}

		private static final List<SideType> values = IndexedEnumUtil.toIndexes(SideType.values());

		public static SideType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
	
	public enum SkillCostType implements IndexedEnum {
		/** 不消耗 */
		NONE(0, null, 0, 0), 
		/** 魔法 */
		MP(1, BattleDef.MP, BattleReportDefine.REPORT_ITEM_MP, LangConstants.BATTLE_MP),
		/** 怒气 */
		SP(2, BattleDef.SP, BattleReportDefine.REPORT_ITEM_SP, LangConstants.BATTLE_SP),
		/** 寿命 */
		LIFE(3, BattleDef.LIFE, BattleReportDefine.REPORT_ITEM_LIFE, LangConstants.BATTLE_LIFE),
		;

		public final int index;

		private String attrKey;
		private int reportKey;
		private int langId;
		
		@Override
		public int getIndex() {
			return index;
		}

		private SkillCostType(int index, String attrKey, int reportKey, int langId) {
			this.index = index;
			this.attrKey = attrKey;
			this.reportKey = reportKey;
			this.langId = langId;
		}

		private static final List<SkillCostType> values = IndexedEnumUtil.toIndexes(SkillCostType.values());

		public static SkillCostType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
		
		public String getAttrKey() {
			return this.attrKey;
		}
		
		public int getReportKey() {
			return this.reportKey;
		}
		
		public int getLangId() {
			return this.langId;
		}
	}
}
