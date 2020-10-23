package com.imop.lj.gameserver.pet;

import java.util.List;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.vip.VipDef.VipFuncTypeEnum;

/**
 * 武将定义
 *
 */
public class PetDef {
	
	/** 技能默认等级 */
	public static final int DEFAULT_SKILL_LEVEL = 1;
	
	public static final String PET_TRAIN_PROP_KEY = "1";
	public static final String PET_TRAIN_TEMP_PROP_KEY = "2";
	
	/**
	 * 武将类型定义
	 */
	public static enum PetType implements IndexedEnum {
		NULL(0),
		/**主将*/
		LEADER(1),
		/**宠物*/
		PET(2),
		/**伙伴*/
		FRIEND(3),
		
		/** 怪物 */
		MONSTER(4),
		
		/** 骑宠 */
		HORSE(5),
		;

		private PetType(int index) {
			this.index = index;
		}

		public final int index;

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<PetType> values = IndexedEnumUtil.toIndexes(PetType.values());

		public static PetType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
	
	/**
	 * 招聘类型
	 * @author yuanbo.gao
	 *
	 */
	public static enum HireType implements IndexedEnum {
		/** 初始化选择武将 */
		SELECT(0),
		/** 普通招募武将 */
		HIRE(1),
		/** 其他途径获得武将 */
		OTHER(2),
		;

		private HireType(int index) {
			this.index = index;
		}

		public final int index;

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<HireType> values = IndexedEnumUtil
				.toIndexes(HireType.values());

		public static HireType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
	
	/**
	 * 职业类型
	 */
	public static enum JobType implements IndexedEnum {
		/** 侠客 */
		XIAKE(1,PetAttackType.STRENGTH, LangConstants.XIAKE, MainSkillType.YINGYONG, MainSkillType.JIANREN, FightPowerType.XIAKE),
		/** 刺客 */
		CIKE(2,PetAttackType.STRENGTH, LangConstants.CIKE, MainSkillType.ZIXIN, MainSkillType.DONGCHA, FightPowerType.CIKE),
		/** 术士 */
		SHUSHI(4,PetAttackType.INTELLECT, LangConstants.SHUSHI, MainSkillType.RECHENG, MainSkillType.MIHUO, FightPowerType.SHUSHI),
		/** 修真 */
		XIUZHEN(8,PetAttackType.INTELLECT, LangConstants.XIUZHEN, MainSkillType.CIBEI, MainSkillType.LIANMIN, FightPowerType.XIUZHEN),
		;

		private JobType(int index,PetAttackType petType, int jobNameLangId,MainSkillType mainSkill1 ,MainSkillType mainSkill2, FightPowerType fightPowerType) {
			this.index = index;
			this.petType = petType;
			this.jobNameLangId = jobNameLangId;
			this.mainSkill1 = mainSkill1;
			this.mainSkill2 = mainSkill2;
			this.fightPowerType = fightPowerType;
		}

		public final int index;
		
		/** 职业名称多语言id*/
		private final int jobNameLangId;
		
		/** 武将类型*/
		public final PetAttackType petType;
		
		/**心法1*/
		public final MainSkillType mainSkill1;
		/**心法2*/
		public final MainSkillType mainSkill2;
		
		/**战斗力类型*/
		public final FightPowerType fightPowerType;

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<JobType> values = IndexedEnumUtil
				.toIndexes(JobType.values());

		public static JobType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}

		public String getJobName() {
			return Globals.getLangService().readSysLang(this.jobNameLangId);
		}

		public PetAttackType getPetType() {
			return petType;
		}
		
		public boolean containsMainSkillType(MainSkillType mainSkill){
			return (this.mainSkill1 == mainSkill || this.mainSkill2 == mainSkill)?true:false;
		}
		
		public MainSkillType getDefaultMainSkillType(){
			return this.mainSkill1;
		}
		
		public FightPowerType getFightPowerType(){
			return this.fightPowerType;
		}
	}
	
	
	/**
	 * 心法类型
	 */
	public static enum MainSkillType implements IndexedEnum {
		/** 空 */
		NULL(0, LangConstants.NULL),
		/** 侠客-英勇 */
		YINGYONG(1, LangConstants.YINGYONG),
		/** 侠客-坚韧 */
		JIANREN(2, LangConstants.JIANREN),
		/** 刺客-自信 */
		ZIXIN(3, LangConstants.ZIXIN),
		/** 刺客-洞察 */
		DONGCHA(4, LangConstants.DONGCHA),
		/** 术士-热诚 */
		RECHENG(5, LangConstants.RECHENG),
		/** 术士-迷惑 */
		MIHUO(6, LangConstants.MIHUO),
		/** 修真-慈悲 */
		CIBEI(7, LangConstants.CIBEI),
		/** 修真-怜悯 */
		LIANMIN(8, LangConstants.LIANMIN),
		;

		private MainSkillType(int index, int mainSkillNameLangId) {
			this.index = index;
			this.mainSkillNameLangId = mainSkillNameLangId;
		}

		public final int index;
		
		/** 心法多语言id*/
		private final int mainSkillNameLangId;
		
		@Override
		public int getIndex() {
			return index;
		}

		private static final List<MainSkillType> values = IndexedEnumUtil
				.toIndexes(MainSkillType.values());

		public static MainSkillType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
		
		public String getMainSKillName() {
			return Globals.getLangService().readSysLang(this.mainSkillNameLangId);
		}
		
		public int getMainSkillNameLangId() {
			return mainSkillNameLangId;
		}
	}
	
	/**
	 * 武将战斗类型，区分攻击方式
	 *
	 */
	public static enum PetAttackType implements IndexedEnum {
		/** 力量型（物理攻击） */
		STRENGTH(1),
		/** 智力型（法术攻击） */
		INTELLECT(2),
		;

		private PetAttackType(int index) {
			this.index = index;
		}

		public final int index;
		
		@Override
		public int getIndex() {
			return index;
		}

		private static final List<PetAttackType> values = IndexedEnumUtil
				.toIndexes(PetAttackType.values());

		public static PetAttackType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
	
	/**
	 * 宠物变异类型
	 *
	 */
	public static enum GeneType implements IndexedEnum {
		/** 普通 */
		NORMAL(0, 0),
		/** 变异 */
		TRANSFORM(1, Globals.getGameConstants().getPetGeneAdd1()),
		
		;

		private GeneType(int index, int add) {
			this.index = index;
			this.add = add;
		}

		public final int index;
		/** 加成 */
		private int add;
		
		@Override
		public int getIndex() {
			return index;
		}

		private static final List<GeneType> values = IndexedEnumUtil
				.toIndexes(GeneType.values());

		public static GeneType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
		
		public int getAdd() {
			return add;
		}
	}
	
	/**
	 * 宠物类型
	 */
	public static enum PetPetType implements IndexedEnum {
		/** 普通 */
		NORMAL(0, LangConstants.PET_NORMAL),
		/** 高级 */
		GOOD(1, LangConstants.PET_GOOD),
		/** 神兽 */
		BEST(2, LangConstants.PET_BEST),
		;

		private PetPetType(int index, int nameLangId) {
			this.index = index;
			this.nameLangId = nameLangId;
		}

		public final int index;
		
		private int nameLangId;
		
		@Override
		public int getIndex() {
			return index;
		}

		private static final List<PetPetType> values = IndexedEnumUtil
				.toIndexes(PetPetType.values());

		public static PetPetType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
		
		public int getNameLangId() {
			return nameLangId;
		}
	}
	
	/**
	 * 宠物类别
	 */
	public static enum PetPetKind implements IndexedEnum {
		/** 野兽 */
		BEAST(1),
		/** 妖怪 */
		MONSTER(2),
		/** 精灵 */
		SPIRIT(3),
		/** 人形 */
		HUMANLIKE(4),
		;

		private PetPetKind(int index) {
			this.index = index;
		}

		public final int index;
		
		@Override
		public int getIndex() {
			return index;
		}

		private static final List<PetPetKind> values = IndexedEnumUtil
				.toIndexes(PetPetKind.values());

		public static PetPetKind valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
		
	}
	
	public static enum PetState implements IndexedEnum{
		/** 正常*/
		NORMAL(1),
		/** 解雇 */
		FIRED(2),
		;

		private PetState(int index) {
			this.index = index;
		}

		public final int index;
		
		@Override
		public int getIndex() {
			return index;
		}

		private static final List<PetState> values = IndexedEnumUtil
				.toIndexes(PetState.values());

		public static PetState valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
	
	/**
	 * 武将颜色
	 */
	public static enum PetQuality implements IndexedEnum{
		/** 白色 */
		WHITE(1, "#FFFFFF"),
		/** 绿色 */
		GREEN(2, "#37EE38"),
		/** 蓝色 */
		BLUE(3, "#0069E0"),
		/** 紫色 */
		PURPLE(4, "#9D36FF"),
		/** 橙色 */
		ORANGE(5, "#FF8523"),
		/** 红色 */
		RED(6, "#FF0000"),
		;

		private PetQuality(int index, String color) {
			this.index = index;
			this.color = color;
		}

		public final int index;
		public final String color;
		
		@Override
		public int getIndex() {
			return index;
		}

		public String getColor() {
			return color;
		}

		private static final List<PetQuality> values = IndexedEnumUtil
				.toIndexes(PetQuality.values());

		public static PetQuality valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
	
	/**
	 * 性别
	 * @author yu.zhao
	 *
	 */
	public static enum Sex implements IndexedEnum{
		/** 女 */
		FEMALE(1),
		/** 男 */
		MALE(2),
		
		;

		private Sex(int index) {
			this.index = index;
		}

		public final int index;
		
		@Override
		public int getIndex() {
			return index;
		}

		private static final List<Sex> values = IndexedEnumUtil
				.toIndexes(Sex.values());

		public static Sex valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
	
	public static enum PetFightState implements IndexedEnum{
		/** 休息中 */
		REST(0),
		/** 出战中 */
		FIGHT(1),
		;

		private PetFightState(int index) {
			this.index = index;
		}

		public final int index;
		
		@Override
		public int getIndex() {
			return index;
		}

		private static final List<PetFightState> values = IndexedEnumUtil
				.toIndexes(PetFightState.values());

		public static PetFightState valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
	
	public static enum SkillType implements IndexedEnum{
		/** 普通技能 */
		NORMAL(0),
		/** 宠物天赋技能 */
		PET_TALENT(1),
		/** 宠物普通技能 */
		PET_NORMAL(2),
		/** 心法主动技能 */
		MIND_A(3),
		/** 心法被动技能 */
		MIND_B(4),
		/** 主将学习技能 */
		LEADER_STUDY(5),
		;

		private SkillType(int index) {
			this.index = index;
		}

		public final int index;
		
		@Override
		public int getIndex() {
			return index;
		}

		private static final List<SkillType> values = IndexedEnumUtil
				.toIndexes(SkillType.values());

		public static SkillType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}

	public static enum PetTrainType implements IndexedEnum{
		/** 初级 */
		NORMAL(1, null),
		/** 中级 */
		GOOD(2, VipFuncTypeEnum.PET_TRAIN_GOOD),
		/** 高级 */
		BEST(3, VipFuncTypeEnum.PET_TRAIN_BEST),
		;

		private PetTrainType(int index, VipFuncTypeEnum vipFuncTypeEnum) {
			this.index = index;
			this.vipFuncTypeEnum = vipFuncTypeEnum;
		}

		public final int index;
		VipFuncTypeEnum vipFuncTypeEnum;
		
		@Override
		public int getIndex() {
			return index;
		}

		private static final List<PetTrainType> values = IndexedEnumUtil
				.toIndexes(PetTrainType.values());

		public static PetTrainType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
		
		public VipFuncTypeEnum getVipFuncTypeEnum() {
			return this.vipFuncTypeEnum;
		}
	}

	/**
	 * 武将成长率品质
	 */
	public static enum PetGrowthColor implements IndexedEnum{
		/** 普通*/
		ORDINARY(1, "#FFFFFF"),
		/** 优秀 */
		SUPERIOR(2, "#00FF00"),
		/** 杰出 */
		OUTSTANDING(3, "#2AACFF"),
		/** 卓越 */
		EXCELLENT(4, "#FF66F6"),
		/** 完美 */
		PERFECT(5, "#FF6500"),
		/** 超凡 */
		TRANSCENDENCY(6, "#FF0000"),
		;

		private PetGrowthColor(int index, String growthColor) {
			this.index = index;
			this.growthColor = growthColor;
		}

		public final int index;
		public final String growthColor;
		
		@Override
		public int getIndex() {
			return index;
		}

		public String getColor() {
			return growthColor;
		}

		private static final List<PetQuality> values = IndexedEnumUtil
				.toIndexes(PetQuality.values());

		public static PetQuality valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
	
	
	/**
	 * 战斗力相关
	 *
	 */
	public static enum FightPowerType implements IndexedEnum {
		/** 侠客 */
		XIAKE(1),
		/** 刺客  */
		CIKE(2),
		/** 术士  */
		SHUSHI(3),
		/** 修真  */
		XIUZHEN(4),
		/** 通用 (比如，翅膀计算战斗力) */
		GENERAL(5),
		;

		private FightPowerType(int index) {
			this.index = index;
		}

		public final int index;
		
		@Override
		public int getIndex() {
			return index;
		}

		private static final List<FightPowerType> values = IndexedEnumUtil
				.toIndexes(FightPowerType.values());

		public static FightPowerType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
	
	/**
	 * 伙伴解锁类型定义
	 */
	public static enum PetFriendUnlockType implements IndexedEnum {
		/**解锁7天*/
		DAY7(1),
		/**解锁30天*/
		DAY30(2),
		/**永久解锁*/
		FOREVER(3),
		;

		private PetFriendUnlockType(int index) {
			this.index = index;
		}

		public final int index;

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<PetFriendUnlockType> values = IndexedEnumUtil.toIndexes(PetFriendUnlockType.values());

		public static PetFriendUnlockType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
	
}
