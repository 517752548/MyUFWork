package com.imop.lj.gameserver.func;

import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.func.allfunc.*;
import com.imop.lj.gameserver.human.Human;

public class FuncFactory {
	
	
	public static IFuncFactory InventoryFuncFactory = new IFuncFactory() {
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new InventoryFunc(owner, FuncTypeEnum.INVENTORY);
		}
	};
	
	
	public static IFuncFactory QuestFuncFactory = new IFuncFactory() {
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new QuestFunc(owner, FuncTypeEnum.QUEST);
		}
	};
	
	public static IFuncFactory RelationFuncFactory = new IFuncFactory() {
		
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new RelationFunc(owner, FuncTypeEnum.RELATION);
		}
	};
	
	
	public static IFuncFactory CorpsFuncFactory = new IFuncFactory() {
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new CorpsFunc(owner, FuncTypeEnum.CORPS);
		}
	};
	
	
	public static IFuncFactory MailFuncFactory = new IFuncFactory() {
		
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new MailFunc(owner, FuncTypeEnum.MAIL);
		}
	};
	
	public static IFuncFactory BusinessFuncFactory = new IFuncFactory() {
		
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new BusinessFunc(owner, FuncTypeEnum.BUSINESS);
		}
	};
	
	public static IFuncFactory TradeFuncFactory = new IFuncFactory() {
		
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new TradeFunc(owner, FuncTypeEnum.TRADE);
		}
	};
	
	
	
	public static IFuncFactory ActivityUIFuncFactory = new IFuncFactory() {
		
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new ActivityUIFunc(owner, FuncTypeEnum.ACTIVITY_UI);
		}
	};
	
	
	public static IFuncFactory TeamFuncFactory = new IFuncFactory() {
		
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new TeamFunc(owner, FuncTypeEnum.TEAM);
		}
	};
	
	public static IFuncFactory ArenaFuncFactory = new IFuncFactory() {
		
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new ArenaFunc(owner, FuncTypeEnum.ARENA);
		}
	};
	
	public static IFuncFactory HangFuncFactory = new IFuncFactory() {
		
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new HangFunc(owner, FuncTypeEnum.HANG);
		}
	};
	
	public static IFuncFactory PubFuncFactory = new IFuncFactory() {
		
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new PubFunc(owner, FuncTypeEnum.PUB);
		}
	};
	
	public static IFuncFactory ExamFuncFactory = new IFuncFactory() {
		
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new ExamFunc(owner, FuncTypeEnum.EXAM);
		}
	};
	
	public static IFuncFactory SysFuncFactory = new IFuncFactory() {
		
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new SysFunc(owner, FuncTypeEnum.SYS);
		}
	};
	
	public static IFuncFactory OnlineGiftFuncFactory = new IFuncFactory() {
		
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new OnlineGiftFunc(owner, FuncTypeEnum.ONLINE_GIFT);
		}
	};
	
	public static IFuncFactory UserPrizeFuncFactory = new IFuncFactory() {
		
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new UserPrizeFunc(owner, FuncTypeEnum.USER_PRIZE);
		}
	};
	
	public static IFuncFactory MysteryShopFuncFactory = new IFuncFactory() {
		
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new MysteryShopFunc(owner, FuncTypeEnum.MYSTERY_SHOP);
		}
	};
	
	public static IFuncFactory MallFuncFactory = new IFuncFactory() {
		
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new MallFunc(owner, FuncTypeEnum.MALL);
		}
	};
	
	public static IFuncFactory GoodActivityFuncFactory = new IFuncFactory() {
		
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new GoodActivityFunc(owner, FuncTypeEnum.GOOD_ACTIVITY);
		}
	};
	
	public static IFuncFactory VipFuncFactory = new IFuncFactory() {
		
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new VipFunc(owner, FuncTypeEnum.VIP);
		}
	};
	
	public static IFuncFactory ChargeItemFuncFactory = new IFuncFactory() {
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new ChargeItemFunc(owner, FuncTypeEnum.CHARGE_ITEM);
		}
	};
	
	public static IFuncFactory SpecOnlineGiftFuncFactory = new IFuncFactory() {
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new SpecOnlineGiftFunc(owner, FuncTypeEnum.SPEC_ONLINE_GIFT);
		}
	};
	
	public static IFuncFactory PayFuncFactory = new IFuncFactory() {
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new PayFunc(owner, FuncTypeEnum.PAY);
		}
	};
	
	public static IFuncFactory PerceptFuncFactory = new IFuncFactory() {
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new PerceptFunc(owner, FuncTypeEnum.PERCEPT);
		}
	};
	
	public static IFuncFactory MindSkillFuncFactory = new IFuncFactory() {
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new MindSkillFunc(owner, FuncTypeEnum.MINDSKILL);
		}
	};
	
	public static IFuncFactory PartnerFuncFactory = new IFuncFactory() {
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new PartnerFunc(owner, FuncTypeEnum.PARTNER);
		}
	};
	
	public static IFuncFactory FormationFuncFactory = new IFuncFactory() {
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new FormationFunc(owner, FuncTypeEnum.FORMATION);
		}
	};

	public static IFuncFactory RankFuncFactory = new IFuncFactory() {
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new RankFunc(owner, FuncTypeEnum.RANK);
		}
	};
	
	public static IFuncFactory CraftFuncFactory = new IFuncFactory() {
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new CraftFunc(owner, FuncTypeEnum.CRAFT);
		}
	};
	
	public static IFuncFactory UpstarFuncFactory = new IFuncFactory() {
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new UpstarFunc(owner, FuncTypeEnum.UPSTAR);
		}
	};
	
	public static IFuncFactory GemEquipFuncFactory = new IFuncFactory() {
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new GemEquipFunc(owner, FuncTypeEnum.GEM_EQUIP);
		}
	};
	
	public static IFuncFactory GemSynthesisFuncFactory = new IFuncFactory() {
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new GemSynthesisFunc(owner, FuncTypeEnum.GEM_SYNTHESIS);
		}
	};
	
	public static IFuncFactory IntensifyFuncFactory = new IFuncFactory() {
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new IntensifyFunc(owner, FuncTypeEnum.INTENSIFY);
		}
	};
	
	public static IFuncFactory DecomposeFuncFactory = new IFuncFactory() {
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new DecomposeFunc(owner, FuncTypeEnum.DECOMPOSE);
		}
	};
	
	public static IFuncFactory RecastFuncFactory = new IFuncFactory() {
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new RecastFunc(owner, FuncTypeEnum.RECAST);
		}
	};
	
	public static IFuncFactory RefineFuncFactory = new IFuncFactory() {
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new RefineFunc(owner, FuncTypeEnum.REFINE);
		}
	};
	
	public static IFuncFactory PourFuncFactory = new IFuncFactory() {
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new PourFunc(owner, FuncTypeEnum.POUR);
		}
	};
	
	public static IFuncFactory InheritFuncFactory = new IFuncFactory() {
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new InheritFunc(owner, FuncTypeEnum.INHERIT);
		}
	};
	
//	public static IFuncFactory GiftFuncFactory = new IFuncFactory() {
//		@Override
//		public AbstractFunc createNewFunc(Human owner) {
//			return new GiftFunc(owner, FuncTypeEnum.GIFT);
//		}
//	};
	
	public static IFuncFactory DailySignFuncFactory = new IFuncFactory() {
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new DailySignFunc(owner, FuncTypeEnum.DAILY_SIGN);
		}
	};
	
	public static IFuncFactory LoginGiftFuncFactory = new IFuncFactory() {
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new LoginGiftFunc(owner, FuncTypeEnum.LOGIN_GIFT);
		}
	};
	
	public static IFuncFactory AchievementFuncFactory = new IFuncFactory() {
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new AchievementFunc(owner, FuncTypeEnum.ACHIEVEMENT);
		}
	};
	
	public static IFuncFactory PromoteFuncFactory = new IFuncFactory() {
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new PromoteFunc(owner, FuncTypeEnum.PROMOTE);
		}
	};
	
	public static IFuncFactory HorseFuncFactory = new IFuncFactory() {
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new HorseFunc(owner, FuncTypeEnum.HORSE);
		}
	};
	
	public static IFuncFactory MineFuncFactory = new IFuncFactory() {
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new MineFunc(owner, FuncTypeEnum.MINE);
		}
	};
	
	public static IFuncFactory TheSweeneyFuncFactory = new IFuncFactory() {
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new TheSweeneyFunc(owner, FuncTypeEnum.THE_SWEENEY);
		}
	};
	
	public static IFuncFactory WizardRaidFuncFactory = new IFuncFactory() {
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new WizardRaidFunc(owner, FuncTypeEnum.WIZARD_RAID);
		}
	};
	
	public static IFuncFactory TreasureMapFuncFactory = new IFuncFactory() {
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new TreasureMapFunc(owner, FuncTypeEnum.TREASURE_MAP);
		}
	};
	
	public static IFuncFactory TitleFuncFactory = new IFuncFactory() {
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new TitleMapFunc(owner,FuncTypeEnum.TITLE);
		}
	};
	
	public static IFuncFactory ForageFuncFactory = new IFuncFactory(){
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new ForageFunc(owner,FuncTypeEnum.FORAGE);
		}
	};
	
	public static IFuncFactory CorpsWarFuncFactory = new IFuncFactory() {
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new CorpsWarFunc(owner,FuncTypeEnum.CORPSWAR);
		}
	};
	
	public static IFuncFactory OvermanFuncFactory = new IFuncFactory() {
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new OvermanFunc(owner,FuncTypeEnum.OVERMAN);
		}
	};
	
	public static IFuncFactory MarryFuncFactory = new IFuncFactory() {
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new MarryFunc(owner,FuncTypeEnum.MARRY);
		}
	};
	
	public static IFuncFactory NvnFuncFactory = new IFuncFactory() {
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new NvnFunc(owner, FuncTypeEnum.NVN);
		}
	};
	
	public static IFuncFactory WingFuncFactory = new IFuncFactory() {
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new WingFunc(owner, FuncTypeEnum.WING);
		}
	};
	
	public static IFuncFactory CorpsTaskFactory = new IFuncFactory() {
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new CorpsTaskFunc(owner, FuncTypeEnum.CORPSTASK);
		}
	};
	public static IFuncFactory CorpsBuildFactory = new IFuncFactory() {
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new CorpsBuildFunc(owner, FuncTypeEnum.CORPSBUILD);
		}
	};
	public static IFuncFactory CorpsBenefitFactory = new IFuncFactory() {
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new CorpsBenefitFunc(owner, FuncTypeEnum.CORPSBENIFIT);
		}
	};
	
	public static IFuncFactory PetIslandFuncFactory = new IFuncFactory() {
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new PetIslandFunc(owner, FuncTypeEnum.PET_ISLAND);
		}
	};
	
	public static IFuncFactory ChannelExchangeFactory = new IFuncFactory() {
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new ChannelExchangeFunc(owner, FuncTypeEnum.CHANNEL_EXCHANGE);
		}
	};
	
	public static IFuncFactory TowerFactory = new IFuncFactory() {
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new TowerFunc(owner, FuncTypeEnum.TOWER);
		}
	};
	
	public static IFuncFactory CorpsActivityFactory = new IFuncFactory() {
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new CorpsActivityFunc(owner, FuncTypeEnum.CORPS_ACTIVITY);
		}
	};
	
	public static IFuncFactory CorpsBossFactory = new IFuncFactory() {
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new CorpsBossFunc(owner, FuncTypeEnum.CORPS_BOSS);
		}
	};
	
	public static IFuncFactory SealDemonFactory = new IFuncFactory() {
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new SealDemonFunc(owner, FuncTypeEnum.SEAL_DEMON);
		}
	};
	
	public static IFuncFactory SealDemonKingFactory = new IFuncFactory() {
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new SealDemonKingFunc(owner, FuncTypeEnum.SEAL_DEMON_KING);
		}
	};
	
	public static IFuncFactory DevilIncarnateFactory = new IFuncFactory() {
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new DevilIncarnateFunc(owner, FuncTypeEnum.DEVIL_INCARNATE);
		}
	};
	
	public static IFuncFactory TimeLimitExamFactory = new IFuncFactory() {
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new TimeLimitExamFunc(owner, FuncTypeEnum.TIME_LIMIT_EXAM);
		}
	};
	
	public static IFuncFactory TimeLimitMonsterFactory = new IFuncFactory() {
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new TimeLimitMonsterFunc(owner, FuncTypeEnum.TIME_LIMIT_MONSTER);
		}
	};
	
	public static IFuncFactory TimeLimitNpcFactory = new IFuncFactory() {
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new TimeLimitNpcFunc(owner, FuncTypeEnum.TIME_LIMIT_NPC);
		}
	};
	
	public static IFuncFactory CorpsCultivateFactory = new IFuncFactory() {
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new CorpsCultivateFunc(owner, FuncTypeEnum.CORPS_CULTIVATE);
		}
	};
	
	public static IFuncFactory CorpsAssistFactory = new IFuncFactory() {
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new CorpsAssistFunc(owner, FuncTypeEnum.CORPS_ASSIST);
		}
	};
	
	public static IFuncFactory CorpsRedEnvelopeFactory = new IFuncFactory() {
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new CorpsRedEnvelopeFunc(owner, FuncTypeEnum.CORPS_RED_ENVELOPE);
		}
	};
	
	public static IFuncFactory Day7TargetFactory = new IFuncFactory() {
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new Day7TargetFunc(owner, FuncTypeEnum.DAY7_TARGET);
		}
	};
	
	public static IFuncFactory AllocateCorpsWarStorageFactory = new IFuncFactory() {
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new AllocateCorpsWarStorageFunc(owner, FuncTypeEnum.ALLOCATE_CORPS_WAR_STORAGE);
		}
	};
	
	public static IFuncFactory PlotDungeonFactory = new IFuncFactory() {
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new PlotDungeonFunc(owner, FuncTypeEnum.PLOT_DUNGEON);
		}
	};
	
	public static IFuncFactory GoodActivity2FuncFactory = new IFuncFactory() {
		
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new GoodActivity2Func(owner, FuncTypeEnum.GOOD_ACTIVITY2);
		}
	};
	
	public static IFuncFactory SiegeDemonNormalFuncFactory = new IFuncFactory() {
		
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new SiegeDemonNormalFunc(owner, FuncTypeEnum.SIEGE_DEMON_NORMAL);
		}
	};
	
	public static IFuncFactory SiegeDemonHardFuncFactory = new IFuncFactory() {
		
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new SiegeDemonHardFunc(owner, FuncTypeEnum.SIEGE_DEMON_HARD);
		}
	};
	
	public static IFuncFactory XianhuFuncFactory = new IFuncFactory() {
		
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new XianhuFunc(owner, FuncTypeEnum.XIANHU);
		}
	};
	
	public static IFuncFactory GuaJiFuncFactory = new IFuncFactory() {
		
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new GuaJiFunc(owner, FuncTypeEnum.GUA_JI);
		}
	};
	
	public static IFuncFactory LifeSkillFuncFactory = new IFuncFactory() {
		
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new LifeSkillFunc(owner, FuncTypeEnum.LIFE_SKILL);
		}
	};
	
	
	public static IFuncFactory LifeSkillStoreFactory = new IFuncFactory() {
		
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new LifeSkillStoreFunc(owner, FuncTypeEnum.LIFE_SKILL_STORE);
		}
	};
	
	public static IFuncFactory MonthCardFactory = new IFuncFactory() {
		
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new MonthCardFunc(owner, FuncTypeEnum.MONTH_CARD);
		}
	};
	
	public static IFuncFactory RingFactory = new IFuncFactory() {
		
		@Override
		public AbstractFunc createNewFunc(Human owner) {
			return new RingFunc(owner, FuncTypeEnum.RING);
		}
	};
}
