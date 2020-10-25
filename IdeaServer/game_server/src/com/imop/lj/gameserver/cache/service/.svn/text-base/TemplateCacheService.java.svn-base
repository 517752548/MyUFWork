package com.imop.lj.gameserver.cache.service;

import java.util.Map;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.config.ConfigUtil;
import com.imop.lj.core.template.TemplateObject;
import com.imop.lj.core.template.TemplateService;
import com.imop.lj.gameserver.cache.template.ActivityUITemplateCache;
import com.imop.lj.gameserver.cache.template.ArenaTemplateCache;
import com.imop.lj.gameserver.cache.template.BattleTemplateCache;
import com.imop.lj.gameserver.cache.template.CalculateExpTemplateCache;
import com.imop.lj.gameserver.cache.template.CorpsTaskTemplateCache;
import com.imop.lj.gameserver.cache.template.CorpsTemplateCache;
import com.imop.lj.gameserver.cache.template.CraftTemplateCache;
import com.imop.lj.gameserver.cache.template.DevilIncarnateTemplateCache;
import com.imop.lj.gameserver.cache.template.EnemyArmyTemplateCache;
import com.imop.lj.gameserver.cache.template.EquipTemplateCache;
import com.imop.lj.gameserver.cache.template.ExamTemplateCache;
import com.imop.lj.gameserver.cache.template.ExchangeTemplateCache;
import com.imop.lj.gameserver.cache.template.ForageTaskTemplateCache;
import com.imop.lj.gameserver.cache.template.FuncTemplateCache;
import com.imop.lj.gameserver.cache.template.GemSynthesisTemplateCache;
import com.imop.lj.gameserver.cache.template.GemTemplateCache;
import com.imop.lj.gameserver.cache.template.GoodActivityTemplateCache;
import com.imop.lj.gameserver.cache.template.GuaJiTemplateCache;
import com.imop.lj.gameserver.cache.template.HumanSkillTemplateCache;
import com.imop.lj.gameserver.cache.template.ItemTemplateCache;
import com.imop.lj.gameserver.cache.template.LifeSkillTemplateCache;
import com.imop.lj.gameserver.cache.template.MallTemplateCache;
import com.imop.lj.gameserver.cache.template.MapTemplateCache;
import com.imop.lj.gameserver.cache.template.MysteryShopTemplateCache;
import com.imop.lj.gameserver.cache.template.NvnTemplateCache;
import com.imop.lj.gameserver.cache.template.PetTemplateCache;
import com.imop.lj.gameserver.cache.template.PlotDungeonTemplateCache;
import com.imop.lj.gameserver.cache.template.PromoteTemplateCache;
import com.imop.lj.gameserver.cache.template.PubTaskTemplateCache;
import com.imop.lj.gameserver.cache.template.QuestTemplateCache;
import com.imop.lj.gameserver.cache.template.RewardTemplateCache;
import com.imop.lj.gameserver.cache.template.RingTaskTemplateCache;
import com.imop.lj.gameserver.cache.template.SealDemonTemplateCache;
import com.imop.lj.gameserver.cache.template.SiegeDemonTemplateCache;
import com.imop.lj.gameserver.cache.template.TheSweeneyTaskTemplateCache;
import com.imop.lj.gameserver.cache.template.TimeLimitTemplateCache;
import com.imop.lj.gameserver.cache.template.TitleTemplateCache;
import com.imop.lj.gameserver.cache.template.TowerTemplateCache;
import com.imop.lj.gameserver.cache.template.TreasureMapTemplateCache;
import com.imop.lj.gameserver.cache.template.VipTemplateCache;
import com.imop.lj.gameserver.cache.template.WingTemplateCache;
import com.imop.lj.gameserver.cache.template.WizardRaidTemplateCache;
import com.imop.lj.gameserver.cache.template.XianhuTemplateCache;

/**
 * 不能使用Globals.getTemplateService()，以后用于动态加载配置文件
 * 所有模板初始化操作，主要是读取模板完以后，对各个模板数据进行预处理，要与各个service分开，各个service只需要调用此类中的cache类的数据即可
 * 动态加载配置文件时，只需要将TemplateCacheService重新load一下即可，load完成以后将Globals中的TemplateCacheService替换即可。
 * @author yuanbo.gao
 *
 */
public class TemplateCacheService implements InitializeRequired{
	/**
	 * 将原来Globals中的templateService放到此类初始化
	 */
	protected TemplateService templateService;
	/**
	 * 物品模版缓存
	 */
	protected ItemTemplateCache itemTemplateCache;
	/**
	 * 武将模板缓存
	 */
	protected PetTemplateCache petTemplateCache;
	/**
	 * 功能模板缓存
	 */
	protected FuncTemplateCache funcTemplateCache;

	/**
	 * 商城模版配置
	 */
	protected MallTemplateCache mallTemplateCache;
	
	/**
	 * 神秘商店模版缓存
	 */
	protected MysteryShopTemplateCache mysteryShopTemplateCache;
	
	/**
	 * 精彩活动模板缓存
	 */
	protected GoodActivityTemplateCache goodActivityTemplateCache;
	
	/**
	 * 奖励缓存
	 */
	protected RewardTemplateCache rewardTemplateCache;
	
	/**
	 * 负责所有战斗相关及游戏内部军队初始化数据，与玩家数据无关
	 */
	protected BattleTemplateCache battleTemplateCache;
	
	/**
	 * map 缓存
	 */
	protected MapTemplateCache mapTemplateCache;
	
	/**
	 * 任务模板缓存
	 */
	protected QuestTemplateCache questTemplateCache;
	
	/**
	 * 怪物组
	 */
	protected EnemyArmyTemplateCache enemyArmyTemplateCache;
	
	/**
	 * 装备缓存
	 */
	protected EquipTemplateCache equipTemplateCache;
	
	/**
	 * 装备打造缓存
	 */
	protected CraftTemplateCache craftTemplateCache;
	
	/**
	 * 酒馆任务缓存
	 */
	protected PubTaskTemplateCache pubTaskTemplateCache;
	
	/**
	 * 心法技能缓存
	 */
	protected HumanSkillTemplateCache humanSkillTemplateCache;
	
	/**
	 * 生活技能缓存
	 */
	protected LifeSkillTemplateCache lifeSkillTemplateCache;
	
	/**
	 * 宝石缓存
	 */
	protected GemTemplateCache gemTemplateCache;
	
	/**
	 * 军团模版缓存
	 */
	protected CorpsTemplateCache corpsTemplateCache;
	
	/**
	 * 剧情副本模版缓存
	 */
	protected PlotDungeonTemplateCache plotDungeonTemplateCache;
	
	/**
	 * 除暴安良任务缓存
	 */
	protected TheSweeneyTaskTemplateCache theSweeneyTemplateCache;

	/**
	 * 藏宝图任务缓存
	 */
	protected TreasureMapTemplateCache treasureMapTemplateCache;

	/**
	 * 绿野仙踪
	 */
	protected WizardRaidTemplateCache wizardRaidTemplateCache;
	
	/**
	 * 围剿魔族
	 */
	protected SiegeDemonTemplateCache siegeDemonTemplateCache;
	
	/**
	 * 兑换
	 */
	protected ExchangeTemplateCache exchangeTemplateCache;
	
	/**
	 * 称号
	 */
	protected TitleTemplateCache titleTemplateCache;
	
	/**
	 * 钻石合成缓存
	 */
	protected GemSynthesisTemplateCache gemSynthesisTemplateCache;
	
	/**
	 * 护送粮草缓存
	 */
	protected ForageTaskTemplateCache forageTaskTemplateCache;
	
	/**
	 * 跑环任务缓存
	 */
	protected RingTaskTemplateCache ringTaskTemplateCache;
	
	/**
	 * 计算经验缓存
	 */
	protected CalculateExpTemplateCache calculateExpTemplateCache;
	
	/**
	 * nvn联赛模板缓存
	 */
	protected NvnTemplateCache nvnTemplateCache;
	
	/**
	 * 翅膀缓存
	 */
	protected WingTemplateCache wingTemplateCache;
	
	/**
	 * 竞技场模板缓存
	 */
	protected ArenaTemplateCache arenaTemplateCache;
	
	/**
	 * 帮派任务缓存
	 */
	protected CorpsTaskTemplateCache corpsTaskTemplateCache;
	
	/**
	 * 提升缓存
	 */
	protected PromoteTemplateCache promoteTemplateCache;
	
	/**
	 * 挂机缓存
	 */
	protected GuaJiTemplateCache guaJiTemplateCache;
	
	/**
	 * 通天塔缓存
	 */
	protected TowerTemplateCache towerTemplateCache;
	
	/**
	 * vip模板缓存
	 */
	protected VipTemplateCache vipTemplateCache;
	
	/**
	 * 封妖缓存
	 */
	protected SealDemonTemplateCache sealDemonTemplateCache;
	
	/**
	 * 混世魔王缓存
	 */
	protected DevilIncarnateTemplateCache devilIncarnateTemplateCache;
	
	/**
	 * 限时活动缓存
	 */
	protected TimeLimitTemplateCache timeLimitTemplateCache;
	
	/**
	 * 科举缓存
	 */
	protected ExamTemplateCache examTemplateCache;
	
	/**
	 * 活动缓存
	 */
	protected ActivityUITemplateCache activityUITemplateCache;
	
	/**
	 * 仙葫模板缓存
	 */
	protected XianhuTemplateCache xianhuTemplateCache;
	
	/**
	 * @param resourceFolder
	 * @param isXorLoad
	 */
	public TemplateCacheService(String resourceFolder, boolean isXorLoad){
		this.templateService = new TemplateService(resourceFolder, isXorLoad);
	}
	
	@Override
	public void init() {
		this.templateService.init(ConfigUtil.getConfigURL("templates.xml"));
		
		itemTemplateCache = new ItemTemplateCache(this.templateService);
		itemTemplateCache.init();
		
		petTemplateCache = new PetTemplateCache(this.templateService);
		petTemplateCache.init();
		
		funcTemplateCache = new FuncTemplateCache(templateService);
		funcTemplateCache.init();
		
		mallTemplateCache = new MallTemplateCache(templateService);
		mallTemplateCache.init();
		
		mysteryShopTemplateCache = new MysteryShopTemplateCache(templateService);
		mysteryShopTemplateCache.init();
		
		goodActivityTemplateCache = new GoodActivityTemplateCache(templateService);
		goodActivityTemplateCache.init();
		
		rewardTemplateCache = new RewardTemplateCache(templateService);
		rewardTemplateCache.init();
		
		battleTemplateCache = new BattleTemplateCache(this.templateService);
		battleTemplateCache.init();
		
		mapTemplateCache = new MapTemplateCache(templateService);
		mapTemplateCache.init();
		
		enemyArmyTemplateCache = new EnemyArmyTemplateCache(templateService);
		enemyArmyTemplateCache.init();
		
		questTemplateCache = new QuestTemplateCache(templateService, mapTemplateCache);
		questTemplateCache.init();
		
		equipTemplateCache = new EquipTemplateCache(templateService);
		equipTemplateCache.init();
		
		craftTemplateCache = new CraftTemplateCache(templateService);
		craftTemplateCache.init();
		
		pubTaskTemplateCache = new PubTaskTemplateCache(templateService);
		pubTaskTemplateCache.init();
		
		humanSkillTemplateCache = new HumanSkillTemplateCache(templateService);
		humanSkillTemplateCache.init();
		
		lifeSkillTemplateCache = new LifeSkillTemplateCache(templateService);
		lifeSkillTemplateCache.init();
	
		gemTemplateCache = new GemTemplateCache(templateService);
		gemTemplateCache.init();
		
		corpsTemplateCache = new CorpsTemplateCache(templateService);
		corpsTemplateCache.init();
		
		plotDungeonTemplateCache = new PlotDungeonTemplateCache(templateService);
		plotDungeonTemplateCache.init();
		
		wizardRaidTemplateCache = new WizardRaidTemplateCache(templateService);
		wizardRaidTemplateCache.init();
		
		siegeDemonTemplateCache = new SiegeDemonTemplateCache(templateService);
		siegeDemonTemplateCache.init();
		
		exchangeTemplateCache = new ExchangeTemplateCache(templateService);
		exchangeTemplateCache.init();
		
		theSweeneyTemplateCache = new TheSweeneyTaskTemplateCache(templateService);
		theSweeneyTemplateCache.init();
		
		treasureMapTemplateCache = new TreasureMapTemplateCache(templateService);
		treasureMapTemplateCache.init();

		titleTemplateCache = new TitleTemplateCache(templateService);
		titleTemplateCache.init();
		
		gemSynthesisTemplateCache = new GemSynthesisTemplateCache(templateService);
		gemSynthesisTemplateCache.init();
		
		forageTaskTemplateCache = new ForageTaskTemplateCache(templateService);
		forageTaskTemplateCache.init();
		
		ringTaskTemplateCache = new RingTaskTemplateCache(templateService);
		ringTaskTemplateCache.init();
		
		calculateExpTemplateCache = new CalculateExpTemplateCache(templateService);
		calculateExpTemplateCache.init();
		
		nvnTemplateCache = new NvnTemplateCache(templateService);
		nvnTemplateCache.init();
		
		wingTemplateCache = new WingTemplateCache(templateService);
		wingTemplateCache.init();
		
		arenaTemplateCache = new ArenaTemplateCache(templateService);
		arenaTemplateCache.init();
		
		corpsTaskTemplateCache= new CorpsTaskTemplateCache(templateService);
		corpsTaskTemplateCache.init();
		
		promoteTemplateCache = new PromoteTemplateCache(templateService);
		promoteTemplateCache.init();
		
		guaJiTemplateCache = new GuaJiTemplateCache(templateService);
		guaJiTemplateCache.init();
		
		vipTemplateCache = new VipTemplateCache(templateService);
		vipTemplateCache.init();
		
		towerTemplateCache = new TowerTemplateCache(templateService);
		towerTemplateCache.init();
		
		sealDemonTemplateCache = new SealDemonTemplateCache(templateService);
		sealDemonTemplateCache.init();
		
		devilIncarnateTemplateCache = new DevilIncarnateTemplateCache(templateService);
		devilIncarnateTemplateCache.init();
		
		timeLimitTemplateCache = new TimeLimitTemplateCache(templateService);
		timeLimitTemplateCache.init();
		
		examTemplateCache = new ExamTemplateCache(templateService);
		examTemplateCache.init();
		
		activityUITemplateCache = new ActivityUITemplateCache(templateService);
		activityUITemplateCache.init();
		
		xianhuTemplateCache = new XianhuTemplateCache(templateService);
		xianhuTemplateCache.init();
		
		Loggers.gameLogger.info("all template and template cache load finished.");
	}

	public void checkAfterInit(){
		//itemTemplateCache.checkAfterInit();
		//equipTemplateCache.checkAfterInit();
	}
	/**
	 * 将原来Globals中的templateService放到此类初始化
	 * Globals将不提供getTemplateService方法
	 * @return
	 */
	public <T extends TemplateObject> T get(int id, Class<T> clazz) {
		return templateService.get(id, clazz);
	}

	public <T extends TemplateObject> Map<Integer, T> getAll(Class<T> clazz) {
		return templateService.getAll(clazz);
	}
	
	public <T extends TemplateObject> boolean isTemplateExist(int id, Class<T> clazz) {
		return templateService.isTemplateExist(id, clazz);
	}
	
	public PetTemplateCache getPetTemplateCache() {
		return petTemplateCache;
	}

	public TemplateService getTemplateService() {
		return templateService;
	}

	public FuncTemplateCache getFuncTemplateCache() {
		return funcTemplateCache;
	}
	
	public ItemTemplateCache getItemTemplateCache() {
		return itemTemplateCache;
	}
	
	public MysteryShopTemplateCache getMysteryShopTemplateCache() {
		return mysteryShopTemplateCache;
	}
	
	public GoodActivityTemplateCache getGoodActivityTemplateCache() {
		return goodActivityTemplateCache;
	}

	public MallTemplateCache getMallTemplateCache() {
		return mallTemplateCache;
	}

	public RewardTemplateCache getRewardTemplateCache() {
		return rewardTemplateCache;
	}

	public BattleTemplateCache getBattleTemplateCache() {
		return battleTemplateCache;
	}
	
	public MapTemplateCache getMapTemplateCache() {
		return mapTemplateCache;
	}
	
	public QuestTemplateCache getQuestTemplateCache() {
		return questTemplateCache;
	}
	
	public EnemyArmyTemplateCache getEnemyArmyTemplateCache() {
		return enemyArmyTemplateCache;
	}
	
	public EquipTemplateCache getEquipTemplateCache() {
		return equipTemplateCache;
	}
	
	public CraftTemplateCache getCraftTemplateCache() {
		return craftTemplateCache;
	}

	public PubTaskTemplateCache getPubTaskTemplateCache() {
		return pubTaskTemplateCache;
	}

	public HumanSkillTemplateCache getHumanSkillTemplateCache() {
		return humanSkillTemplateCache;
	}
	
	public LifeSkillTemplateCache getLifeSkillTemplateCache() {
		return lifeSkillTemplateCache;
	}

	public GemTemplateCache getGemTemplateCache() {
		return gemTemplateCache;
	}

	public CorpsTemplateCache getCorpsTemplateCache() {
		return corpsTemplateCache;
	}
	
	public PlotDungeonTemplateCache getPlotDungeonTemplateCache() {
		return plotDungeonTemplateCache;
	}

	public WizardRaidTemplateCache getWizardRaidTemplateCache() {
		return wizardRaidTemplateCache;
	}
	
	public SiegeDemonTemplateCache getSiegeDemonTemplateCache() {
		return siegeDemonTemplateCache;
	}
	
	public ExchangeTemplateCache getExchangeTemplateCache() {
		return exchangeTemplateCache;
	}

	public TheSweeneyTaskTemplateCache getTheSweeneyTemplateCache() {
		return theSweeneyTemplateCache;
	}

	public TreasureMapTemplateCache getTreasureMapTemplateCache() {
		return treasureMapTemplateCache;
	}

	public TitleTemplateCache getTitleTemplateCache() {return titleTemplateCache;}

	public GemSynthesisTemplateCache getGemSynthesisTemplateCache() {
		return gemSynthesisTemplateCache;
	}

	public ForageTaskTemplateCache getForageTaskTemplateCache() {
		return forageTaskTemplateCache;
	}
	
	public RingTaskTemplateCache getRingTaskTemplateCache() {
		return ringTaskTemplateCache;
	}
	
	public CalculateExpTemplateCache getCalculateExpTemplateCache() {
		return calculateExpTemplateCache;
	}

	public NvnTemplateCache getNvnTemplateCache() {
		return nvnTemplateCache;
	}

	public WingTemplateCache getWingTemplateCache() {
		return wingTemplateCache;
	}
	
	public ArenaTemplateCache getArenaTemplateCache() {
		return arenaTemplateCache;
	}

	public CorpsTaskTemplateCache getCorpsTaskTemplateCache() {
		return corpsTaskTemplateCache;
	}

	public PromoteTemplateCache getPromoteTemplateCache() {
		return promoteTemplateCache;
	}

	public GuaJiTemplateCache getGuaJiTemplateCache() {
		return guaJiTemplateCache;
	}

	public TowerTemplateCache getTowerTemplateCache() {
		return towerTemplateCache;
	}
	
	public VipTemplateCache getVipTemplateCache() {
		return vipTemplateCache;
	}

	public SealDemonTemplateCache getSealDemonTemplateCache() {
		return sealDemonTemplateCache;
	}

	public DevilIncarnateTemplateCache getDevilIncarnateTemplateCache() {
		return devilIncarnateTemplateCache;
	}

	public TimeLimitTemplateCache getTimeLimitTemplateCache() {
		return timeLimitTemplateCache;
	}

	public ExamTemplateCache getExamTemplateCache() {
		return examTemplateCache;
	}

	public ActivityUITemplateCache getActivityUITemplateCache() {
		return activityUITemplateCache;
	}
	
	public XianhuTemplateCache getXianhuTemplateCache() {
		return xianhuTemplateCache;
	}
	
}
