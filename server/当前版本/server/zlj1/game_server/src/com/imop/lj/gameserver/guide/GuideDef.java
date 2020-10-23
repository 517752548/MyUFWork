package com.imop.lj.gameserver.guide;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;

public interface GuideDef {
	
	public static String GUIDE_WEB_TYPE_ID = "1";
	
	
	/**
	 * 新手引导类型
	 * @author yu.zhao
	 *
	 */
	public enum GuideType implements IndexedEnum {
		/** 欢迎页面 */
		WELCOME(1, GuidePusherFactory.WelcomeGuidePusherFactory, null, false),
		/** 使用装备 */
		USE_EQUIP(2, GuidePusherFactory.UseEquipGuidePusherFactory, null, false),
		/** 宠物出战 */
		PET_FIGHT(3, GuidePusherFactory.PetFightGuidePusherFactory, null, false),
		/** 第一次战斗 */
		FIRST_BATTLE(4, GuidePusherFactory.FirstBattleGuidePusherFactory, null, false),
		/** 每日签到 */
		DAILY_SIGN(5, GuidePusherFactory.DailySignGuidePusherFactory, FuncTypeEnum.DAILY_SIGN, true),
		/** 科举 */
		EXAM(6, GuidePusherFactory.ExamGuidePusherFactory, FuncTypeEnum.EXAM, true),
		/** 竞技场 */
		ARENA(7, GuidePusherFactory.ArenaGuidePusherFactory, FuncTypeEnum.ARENA, true),
		/** 绿野仙踪 */
		WIZARD_RAID(8, GuidePusherFactory.WizardRaidGuidePusherFactory, FuncTypeEnum.WIZARD_RAID, true),
		/** 升星 */
		UPSTAR(9, GuidePusherFactory.UpstarGuidePusherFactory, FuncTypeEnum.UPSTAR, true),
		/** 领取等级奖励 */
		LEVEL_REWARD(10, GuidePusherFactory.LevelRewardGuidePusherFactory, null, false),
		/** 酒馆 */
		PUB(11, GuidePusherFactory.PubGuidePusherFactory, FuncTypeEnum.PUB, true),
		/** 挂机 */
		HANG(12, GuidePusherFactory.HangGuidePusherFactory, FuncTypeEnum.HANG, true),
		
		/** 藏宝图 */
		TREASURE_MAP(13, GuidePusherFactory.TreasureMapGuidePusherFactory, FuncTypeEnum.TREASURE_MAP, true),
		/** 护送粮草 */
		FORAGE(14, GuidePusherFactory.ForageGuidePusherFactory, FuncTypeEnum.FORAGE, true),
		/** 除暴安良功能 */
		THE_SWEENEY(15, GuidePusherFactory.TheSweeneyGuidePusherFactory, FuncTypeEnum.THE_SWEENEY, true),
		/** 打造 */
		CRAFT(16, GuidePusherFactory.CraftGuidePusherFactory, null, false),
		
		/** 宠物洗天赋技能 */
		PET_TALENT_REFRESH(17, GuidePusherFactory.PetTalentGuidePusherFactory, null, false),
		
		;

		private final int index;
		private final IGuidePusherFactory pusherFactory;
		
		/**
		 * 新手引导对应的功能模块，没有则为null
		 */
		private final FuncTypeEnum funcType;
		
		/**
		 * 是否功能开启时的引导，如果是，则会在功能开启时给前台推送对应的功能模块有新手引导了(sendHasGuide)
		 */
		private final boolean isFuncOpenGuide;
		
		private GuideType(int index, IGuidePusherFactory pusherFactory, FuncTypeEnum funcType, boolean isFuncOpenGuide) {
			this.index = index;
			this.pusherFactory = pusherFactory;
			this.funcType = funcType;
			this.isFuncOpenGuide = isFuncOpenGuide;
		}

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<GuideType> values = IndexedEnumUtil.toIndexes(GuideType.values());

		public static GuideType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}

		public IGuidePusherFactory getGuidePuserFactory() {
			return pusherFactory;
		}
		
		public FuncTypeEnum getFuncType() {
			return funcType;
		}

		public boolean isFuncOpenGuide() {
			return isFuncOpenGuide;
		}
		
	}
}
